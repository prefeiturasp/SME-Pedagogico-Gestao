using AutoMapper;
using Elastic.Apm.AspNetCore;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Elastic.Apm.SqlClient;
using MediatR;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SME.Pedagogico.Gestao.Data;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Infra.Utilitarios;
using SME.Pedagogico.Gestao.IoC;
using SME.Pedagogico.Gestao.WebApp.Configuracoes;
using SME.Pedagogico.Gestao.WebApp.Contexts;
using SME.Pedagogico.Gestao.WebApp.Middlewares;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace SME.Pedagogico.Gestao.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddHttpContextAccessor();

            RegistrarDependencias.Registrar(services);
            RegistraClientesHttp.Registrar(services, Configuration);

            ConfiguraRabbitParaLogs(services);
            ConfiguraTelemetria(services);

            var serviceProvider = services.BuildServiceProvider();
            var mediator = serviceProvider.GetService<IMediator>();
            services.AddMvc(options =>
            {
                options.AllowValidatingTopLevelNodes = false;
                options.EnableEndpointRouting = true;
                options.Filters.Add(new FiltroExcecoesAttribute(mediator));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            // Configuração de inje��o de depend�ncia do SMEContext (Postgres - Npgsql)
            services.AddDbContext<SMEManagementContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            // JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JwtSettings:Issuer"],
                        ValidAudience = Configuration["JwtSettings:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]))
                    };
                });

            // CORS (Cross-Origin Requests)
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin() // Ulilizar a fun��o abaixo e comentar essa para definir permiss�o de acesso de determinadas origens, caso contr�rio ser� aceito qualquer origem da requisi��o
                                          //.WithOrigins("https://mydomain.com", "http://outroendereco.com.br")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .Build());
            });

            //Insights 
            services.AddApplicationInsightsTelemetry(Configuration);

            // Registra o Swagger Generator (OpenAPI)
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("documentation", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "SME.Pedagogico.Gestao.WebApp",
                    Version = "v1.0.0",
                    Description = "Documentação das APIs do SME.Pedagogico.Gestao.WebApp (.NET Core v2.2)",
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.DTO.Portugues.GrupoDTO, Gestao.Models.Autoral.Grupo>();
                cfg.CreateMap<Data.DTO.Portugues.OrdemDTO, Gestao.Models.Autoral.Ordem>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void ConfiguraTelemetria(IServiceCollection services)
        {
            var telemetriaOptions = new TelemetriaOptions();
            Configuration.GetSection(TelemetriaOptions.Secao).Bind(telemetriaOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(telemetriaOptions);

            var serviceProvider = services.BuildServiceProvider();

            var clientTelemetry = serviceProvider.GetService<TelemetryClient>();

            var servicoTelemetria = new ServicoTelemetria(clientTelemetry, telemetriaOptions);

            QueryInterceptors.Init(servicoTelemetria);
            DapperInterceptor.Init(servicoTelemetria);

            services.AddSingleton<IServicoTelemetria>(servicoTelemetria);
        }

        private void ConfiguraRabbitParaLogs(IServiceCollection services)
        {
            var configuracaoRabbitLogOptions = new ConfiguracaoRabbitLogOptions();
            Configuration.GetSection("ConfiguracaoRabbitLog").Bind(configuracaoRabbitLogOptions, c => c.BindNonPublicProperties = true);

            services.AddSingleton(configuracaoRabbitLogOptions);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseResponseCaching();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");

            app.UseElasticApm(Configuration,
                new SqlClientDiagnosticSubscriber(),
                new HttpDiagnosticsSubscriber(),
                new EfCoreDiagnosticsSubscriber());

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/documentation/swagger.json", "SME.Pedagogico.Gestao.WebApp");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}