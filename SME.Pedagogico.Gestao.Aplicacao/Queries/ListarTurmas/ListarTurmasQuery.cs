using MediatR;
using SME.Pedagogico.Gestao.Data.DTO;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao.Queries.ListarTurmas
{
    public class ListarTurmasQuery : IRequest<IList<TurmaDTO>>
    {
        public ListarTurmasQuery(List<string> codigosTurmas)
        {
            CodigosTurmas = codigosTurmas;
        }

        public List<string> CodigosTurmas { get; set; }
    }
}
