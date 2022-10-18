using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using SME.Pedagogico.Gestao.Aplicacao;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Infra.Excecoes;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Middlewares
{
    public class FiltroExcecoesAttribute : ExceptionFilterAttribute
    {
        private readonly IMediator mediator;

        public FiltroExcecoesAttribute(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public override async void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NegocioException negocioException:
                    await SalvaLogAsync(LogNivel.Negocio, context.Exception.Message, context.Exception.StackTrace);
                    context.Result = new ResultadoBaseResult(context.Exception.Message, negocioException.StatusCode);
                    break;
                case ValidacaoException validacaoException:
                    await SalvaLogAsync(LogNivel.Negocio, context.Exception.Message, context.Exception.StackTrace);
                    context.Result = new ResultadoBaseResult(new RetornoBaseDto(validacaoException.Erros));
                    break;
                default:
                    await SalvaLogAsync(LogNivel.Critico, context.Exception.Message, context.Exception.StackTrace);
                    context.Result = new ResultadoBaseResult($"Ocorreu um erro interno. Favor contatar o suporte. {context.Exception}", 500);
                    break;
            }

            base.OnException(context);
        }

        public async Task SalvaLogAsync(LogNivel nivel, string erro, string stackTrace) 
            => await mediator.Send(new SalvarLogViaRabbitCommand(erro, nivel, LogContexto.Geral, "", rastreamento: stackTrace));

    }
}

