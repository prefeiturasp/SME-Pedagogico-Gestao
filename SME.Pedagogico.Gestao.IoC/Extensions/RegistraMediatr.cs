using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SME.Pedagogico.Gestao.Aplicacao;
using System;

namespace SME.Pedagogico.Gestao.IoC
{
    public static class RegistraMediatr
    {
        public static void AdicionarMediatr(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SME.Pedagogico.Gestao.Aplicacao");
            services.AddMediatR(assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacoesPipeline<,>));
        }
    }
}
