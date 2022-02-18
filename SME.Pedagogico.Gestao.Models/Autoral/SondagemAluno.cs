using SME.Pedagogico.Gestao.Models.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class SondagemAluno
    {
        public Guid Id
        {
            get; set;
        }
        public virtual Sondagem Sondagem { get; set; }
        public Guid SondagemId { get; set; }
        public string CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public int? Bimestre { get; set; }
        public  List<SondagemAlunoRespostas> ListaRespostas { get; set; }
    }
}
