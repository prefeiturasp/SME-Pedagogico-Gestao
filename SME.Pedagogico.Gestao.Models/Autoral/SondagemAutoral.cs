using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class SondagemAutoral : Table
    {
        public virtual ComponenteCurricular ComponenteCurricular { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public virtual Resposta Resposta { get; set; }
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoUe { get; set; }
        public string CodigoTurma { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Ordem Ordem { get; set; }
        public int AnoTurma { get; set; }
        public int AnoLetivo { get; set; }
        public virtual Periodo Periodo { get; set; }
    }
}
