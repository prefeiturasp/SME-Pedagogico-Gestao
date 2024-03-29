﻿using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma
{
    public class PerguntasRelatorioProficienciaDTO
    {
        public string PerguntaId { get; set; }
        public string NomePergunta { get; set; }
        public int Ordenacao { get; set; }
        public List<SubPerguntaRelatorioDTO> subPerguntas { get; set; }
    }
}
