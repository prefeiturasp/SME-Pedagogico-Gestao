using SME.Pedagogico.Gestao.WebApp.Middlewares;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace SME.Pedagogico.Gestao.WebApp.Filtros
{
    public class FiltroIntegracaoExterna : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {

            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                    .Union(context.MethodInfo.GetCustomAttributes(true))
                                    .OfType<ChaveIntegracaoSondagemApi>();

            if (attributes != null && attributes.Any())
            {

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "x-sondagem-api-key",
                    In = "header",
                    Type = "string",
                    Required = false
                });
            }
        }
    }
}
