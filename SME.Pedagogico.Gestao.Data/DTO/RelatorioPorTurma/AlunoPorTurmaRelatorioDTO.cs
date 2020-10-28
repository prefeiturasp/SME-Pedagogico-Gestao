using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
  public  class AlunoPorTurmaRelatorioDTO
    {
        public int CodigoAluno { get; set; }

        public string NomeAluno { get; set; }

        public List<PerguntaRespostaPorAluno> Perguntas { get; set; }
    }
}
