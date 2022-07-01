using MediatR;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ExcluirSondagemMatematica2022ComDivergenciasCommand : IRequest
    {
        public ExcluirSondagemMatematica2022ComDivergenciasCommand(string dreCodigo)
        {
            DreCodigo = dreCodigo ?? throw new System.ArgumentNullException(nameof(dreCodigo));
        }

        public string DreCodigo { get; }
    }
}
