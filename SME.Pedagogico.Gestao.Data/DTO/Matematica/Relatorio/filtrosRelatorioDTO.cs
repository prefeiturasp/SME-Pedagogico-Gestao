using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio
{
    public class filtrosRelatorioDTO
    {
        public string GrupoId { get; set; }
        public string DescricaoDisciplina { get; set; }
        public string DescricaoPeriodo { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoUe { get; set; }
        public string CodigoTurmaEol { get; set; }
        public int AnoEscolar { get; set; }
        public int AnoLetivo { get; set; }
        public string ComponenteCurricularId { get; set; }
        public string PeriodoId { get; set; }
        public bool ConsiderarBimestre {  get; set; }

        public int Bimestre { get; set; }

    }
}
