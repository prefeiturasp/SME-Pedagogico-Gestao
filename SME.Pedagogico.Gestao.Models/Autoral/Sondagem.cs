using System;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Sondagem
    {
        public Guid Id { get; set; }
      
        public virtual ComponenteCurricular ComponenteCurricular { get; set; }
        public string ComponenteCurricularId { get; set; }
        public virtual Periodo Periodo { get; set; }
        public string PeriodoId { get; set; }
        public int AnoTurma { get; set; }
        public string CodigoTurma { get; set; }
        public string CodigoUe { get; set; }
        public string CodigoDre { get; set; }
        public int AnoLetivo { get; set; }
        public virtual Ordem Ordem { get; set; }
        public string OrdemId { get; set; }
        public virtual Grupo Grupo { get; set; }
        public string GrupoId { get; set; }
        public int? SequenciaDeOrdemSalva { get; set; }
        public int Bimestre { get; set; }
        public  List<SondagemAluno> AlunosSondagem { get; set; }

        //public Sondagem()
        //{
        //    NewId();
        //}
        //public virtual void NewId()
        //{
        //    Id = Guid.NewGuid();
        //}
    }
}
