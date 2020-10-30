using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.IoC;
using SME.Pedagogico.Gestao.WebApp.Contexts;
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            RegistrarDependencias.Registrar(services);

            services.AddRabbit();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            // Configuração de injeção de dependência do SMEContext (Postgres - Npgsql)
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
                        .AllowAnyOrigin() // Ulilizar a função abaixo e comentar essa para definir permissão de acesso de determinadas origens, caso contrário será aceito qualquer origem da requisição
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

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.DTO.Portugues.GrupoDTO, Gestao.Models.Autoral.Grupo>();
                cfg.CreateMap<Data.DTO.Portugues.OrdemDTO, Gestao.Models.Autoral.Ordem>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
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
            app.UseSwagger();


            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/documentation/swagger.json", "SME.Pedagogico.Gestao.WebApp");
                //options.RoutePrefix = "/documentation";
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