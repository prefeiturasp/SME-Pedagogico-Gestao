using MediatR;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterListagemAutoralQuery : IRequest<IEnumerable<AlunoSondagemMatematicaDto>>
    {
        public ObterListagemAutoralQuery(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            FiltrarListagemDto = filtrarListagemDto;
        }

        public FiltrarListagemMatematicaDTO FiltrarListagemDto { get; }
    }
}
