using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Middlewares
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class ChaveIntegracaoSondagemApi : Attribute, IAsyncActionFilter
    {
        private const string ChaveIntegracaoHeader = "x-sondagem-api-key";
        private const string ChaveIntegracaoEnvironmentVariableName = "ChaveIntegracaoSondagemApi";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string chaveApi = Environment.GetEnvironmentVariable(ChaveIntegracaoEnvironmentVariableName);

            if (!context.HttpContext.Request.Headers.TryGetValue(ChaveIntegracaoHeader, out var chaveRecebida) ||
                !chaveRecebida.Equals(chaveApi))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
