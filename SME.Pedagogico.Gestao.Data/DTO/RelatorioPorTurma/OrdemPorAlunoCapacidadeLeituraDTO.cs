using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
  public  class OrdemPorAlunoCapacidadeLeituraDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public List<PerguntaRespostaPorAluno> Perguntas { get; set; }


    }
}
