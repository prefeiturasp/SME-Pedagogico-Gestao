using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.Pedagogico.Gestao.Aplicacao;

namespace SME.Pedagogico.Gestao.IoC
{
    public class RegistrarDependencias
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AdicionarMediatr();

            RegistrarRepositorios(services);
            RegistrarContextos(services);
            RegistrarComandos(services);
            RegistrarConsultas(services);
            RegistrarServicos(services);
            RegistrarCasosDeUso(services);
        }

        private static void RegistrarComandos(IServiceCollection services)
        {
           
        }

        private static void RegistrarConsultas(IServiceCollection services)
        {
        
        }

        private static void RegistrarContextos(IServiceCollection services)
        {
           
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {
         
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
          
        }

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScoped<IGamesUseCase, GamesUseCase>();
            services.TryAddScoped<IRelatorioImpressaoUseCase, RelatorioImpressaoUseCase>();
        }
    }
}
