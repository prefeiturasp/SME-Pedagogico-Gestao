using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio
{
    public class filtrosRelatorioDTO
    {     
        public string DescricaoDisciplina { get; set; }
        public string DescricaoPeriodo { get; set; }
        public string CodigoDRE { get; set; }
        public string CodigoEscola { get; set; }
        public string CodigoTurmaEol { get; set; }
        public int AnoDaTurma { get; set; }
        public int AnoLetivo { get; set; }
        public string ComponenteCurricularId { get; set; }
        public string PeriodoId { get; set; }
    }
}
