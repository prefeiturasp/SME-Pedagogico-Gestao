using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
    public class AlunoPorTurmaCapacidadeLeituraDTO
    {
        public int CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public List<OrdemPorAlunoCapacidadeLeituraDTO> Ordens { get; set; }
        
    }
}
