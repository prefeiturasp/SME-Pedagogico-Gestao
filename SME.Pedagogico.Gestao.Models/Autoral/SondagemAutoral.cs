using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class SondagemAutoral
    {
        public Guid Id { get; set; }
        public ComponenteCurricular ComponenteCurricular { get; set; }
        public Pergunta Pergunta { get; set; }
        public Resposta Resposta { get; set; }
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoUe { get; set; }
        public string CodigoTurma { get; set; }
        public Grupo Grupo { get; set; }
        public Ordem Ordem { get; set; }
        public int AnoTurma { get; set; }
        public int AnoLetivo { get; set; }
        public Periodo Periodo { get; set; }
    }
}
