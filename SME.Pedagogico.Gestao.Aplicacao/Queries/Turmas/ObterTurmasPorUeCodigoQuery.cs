using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterTurmasPorUeCodigoQuery : IRequest<List<SalasPorUEDTO>>
    {
        public ObterTurmasPorUeCodigoQuery(int anoLetivo, string ueCodigo, bool consideraNovosAnosInfantil)
        {
            AnoLetivo = anoLetivo;
            UeCodigo = ueCodigo;
            ConsideraNovosAnosInfantil = consideraNovosAnosInfantil;
        }

        public int AnoLetivo { get; }
        public string UeCodigo { get; }
        public bool ConsideraNovosAnosInfantil { get; }
    }
}
