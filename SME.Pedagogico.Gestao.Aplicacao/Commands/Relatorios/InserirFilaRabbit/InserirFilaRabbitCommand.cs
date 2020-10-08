using MediatR;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class InserirFilaRabbitCommand : IRequest<bool>
    {
        public InserirFilaRabbitCommand(PublicaFilaRelatoriosDto adicionarFilaDto)
        {
            AdicionarFilaDto = adicionarFilaDto;
        }

        public PublicaFilaRelatoriosDto AdicionarFilaDto { get; set; }
      
    }
}
