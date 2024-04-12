using MediatR;
using Microsoft.EntityFrameworkCore;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnumModel = SME.Pedagogico.Gestao.Models.Enums;

namespace SME.Pedagogico.Gestao.Aplicacao.Queries.Periodos
{
    public class ObterPeriodoFixoAnualPorTipoAnoLetivoEBimestreQueryHandler : IRequestHandler<ObterPeriodoFixoAnualPorTipoAnoLetivoEBimestreQuery, PeriodoFixoAnual>
    {
        public async Task<PeriodoFixoAnual> Handle(ObterPeriodoFixoAnualPorTipoAnoLetivoEBimestreQuery request, CancellationToken cancellationToken)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var periodos = await contexto.PeriodoFixoAnual.Where(fixo => fixo.Ano == request.AnoLetivo).ToListAsync();

                return periodos?.FirstOrDefault(p=> p.Descricao.Substring(0, 1).Equals(request.Bimestre.ToString()) && p.TipoPeriodo == (EnumModel.TipoPeriodoEnum) request.TipoPeriodo) ?? null;
            }
        }
    }
}
