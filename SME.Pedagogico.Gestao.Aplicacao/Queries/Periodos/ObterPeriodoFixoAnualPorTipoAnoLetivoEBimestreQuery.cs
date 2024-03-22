using MediatR;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Aplicacao.Queries.Periodos
{
    public class ObterPeriodoFixoAnualPorTipoAnoLetivoEBimestreQuery : IRequest<PeriodoFixoAnual>
    {
        public int AnoLetivo { get; set; }
        public int Bimestre { get; set; }
        public TipoPeriodoEnum TipoPeriodo { get; set; }

        public ObterPeriodoFixoAnualPorTipoAnoLetivoEBimestreQuery(int anoLetivo, int bimestre, TipoPeriodoEnum tipoPeriodo)
        {
            AnoLetivo = anoLetivo;
            Bimestre = bimestre;
            TipoPeriodo = tipoPeriodo;
        }
    }
}
