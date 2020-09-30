using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SME.Pedagogico.Gestao.Dominio.Enumerados
{
    public enum TipoRelatorio
    {
        [Display(Name = "relatorios/alunos", ShortName = "RelatorioExemplo", Description = "Relatório exemplo")]
        RelatorioExemplo = 1
    }
}
