﻿using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Models.Base.Abstracts;

namespace SME.Pedagogico.Gestao.Models.Autoral
{
    public class Pergunta : Table
    {
        public string Descricao { get; set; }
        public int Ordenacao { get; set; }
        public ComponenteCurricular ComponenteCurricular { get; set; }
        public bool Excluido { get; set; }
    }
}
