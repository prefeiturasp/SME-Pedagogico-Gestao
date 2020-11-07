using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterCCPorTurmaUsuarioQuery : IRequest<IList<DisciplinaRetornoDto>>
    {
        public ObterCCPorTurmaUsuarioQuery(int turmaCodigo)
        {
            TurmaCodigo = turmaCodigo;
        }

        public int TurmaCodigo { get; set; }
    }
}
