using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterTurmasPorUeCodigoQuery : IRequest<List<SalasPorUEDTO>>
    {
        public ObterTurmasPorUeCodigoQuery(int anoLetivo, string ueCodigo)
        {
            AnoLetivo = anoLetivo;
            UeCodigo = ueCodigo;
        }

        public int AnoLetivo { get; set; }
        public string UeCodigo { get; set; }
    }
}
