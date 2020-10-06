﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase()
        {
            CriadoEm = DateTime.Now;
        }

        public DateTime? AlteradoEm { get; set; }
        public string AlteradoPor { get; set; }
        public string AlteradoRF { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public string CriadoRF { get; set; }
        public long Id { get; set; }
    }
}
