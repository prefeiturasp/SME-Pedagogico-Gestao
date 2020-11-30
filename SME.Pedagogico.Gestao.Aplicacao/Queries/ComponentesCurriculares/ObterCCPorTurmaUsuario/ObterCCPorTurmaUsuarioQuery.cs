using MediatR;
using SME.Pedagogico.Gestao.Infra;
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
