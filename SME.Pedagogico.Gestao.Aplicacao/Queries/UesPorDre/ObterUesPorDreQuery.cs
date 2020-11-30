using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterUesPorDreQuery : IRequest<IList<EscolasPorDREDTO>>
    {
        public ObterUesPorDreQuery(long dreCodigo, long anoLetivo)
        {
            DreCodigo = dreCodigo;
            AnoLetivo = anoLetivo;
        }

        public long DreCodigo { get; set; }
        public long AnoLetivo { get; set; }
    }
}
