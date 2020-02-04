using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.WebApp.Models.RelatorioSondagem
{
    public class ParametersModel
    {
        public bool ClassroomReport { get; set; }
        public string Discipline { get; set; }
        public string Proficiency { get; set; }
        public string Term { get; set; }
        public string CodigoDRE { get; set; }
        public string CodigoEscola { get; set; }
        public string CodigoCurso { get; set; }
        public string CodigoTurmaEol { get; set; }
        public string SchoolYear { get; set;}

    }
}
