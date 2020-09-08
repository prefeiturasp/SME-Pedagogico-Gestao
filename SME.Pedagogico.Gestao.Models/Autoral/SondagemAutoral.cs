using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class SondagemAutoral : Table
    {
        public SondagemAutoral() { }

        public SondagemAutoral(SondagemAutoral sondagemAutoral)
        {
            ComponenteCurricular = sondagemAutoral.ComponenteCurricular;
            ComponenteCurricularId = sondagemAutoral.ComponenteCurricularId;
            Pergunta = sondagemAutoral.Pergunta;
            PerguntaId = sondagemAutoral.PerguntaId;
            Resposta = sondagemAutoral.Resposta;
            Id = null;
            RespostaId = sondagemAutoral.RespostaId;
            CodigoAluno = sondagemAutoral.CodigoAluno;
            NomeAluno = sondagemAutoral.NomeAluno;
            CodigoDre = sondagemAutoral.CodigoDre;
            CodigoUe = sondagemAutoral.CodigoUe;
            CodigoTurma = sondagemAutoral.CodigoTurma;
            Grupo = sondagemAutoral.Grupo;
            GrupoId = sondagemAutoral.GrupoId;
            Ordem = sondagemAutoral.Ordem;
            OrdemId = sondagemAutoral.OrdemId;
            AnoTurma = sondagemAutoral.AnoTurma;
            AnoLetivo = sondagemAutoral.AnoLetivo;
            Periodo = sondagemAutoral.Periodo;
            PeriodoId = sondagemAutoral.PeriodoId;
            SequenciaOrdemSalva = sondagemAutoral.SequenciaOrdemSalva;
            

    }

    public virtual ComponenteCurricular ComponenteCurricular { get; set; }
        public string ComponenteCurricularId { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public string PerguntaId { get; set; }
        public virtual Resposta Resposta { get; set; }
        public string RespostaId { get; set; }
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public string CodigoDre { get; set; }
        public string CodigoUe { get; set; }
        public string CodigoTurma { get; set; }
        public virtual Grupo Grupo { get; set; }
        public string GrupoId { get; set; }
        public virtual Ordem Ordem { get; set; }
        public string OrdemId { get; set; }
        public int AnoTurma { get; set; }
        public int AnoLetivo { get; set; }
        public virtual Periodo Periodo { get; set; }
        public string PeriodoId { get; set; }
        public int SequenciaOrdemSalva { get; set; }

    }
}
