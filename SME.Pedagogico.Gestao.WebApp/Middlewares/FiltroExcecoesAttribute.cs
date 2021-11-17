using Microsoft.AspNetCore.Mvc.Filters;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Infra.Excecoes;

namespace SME.Pedagogico.Gestao.WebApp.Middlewares
{
    public class FiltroExcecoesAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NegocioException negocioException:
                    context.Result = new ResultadoBaseResult(context.Exception.Message, negocioException.StatusCode);
                    break;
                case ValidacaoException validacaoException:
                    //context.Result = new ResultadoBaseResult(new RetornoBaseDto(validacaoException.Erros));
                    context.Result = new ResultadoBaseResult($"Erro de validação. Detalhes: {validacaoException}");
                    break;
                default:
                    context.Result = new ResultadoBaseResult($"Ocorreu um erro interno. Favor contatar o suporte. {context.Exception}", 500);
                    break;
            }

            base.OnException(context);
        }
    }
}

