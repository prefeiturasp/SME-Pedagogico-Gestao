using System.ComponentModel.DataAnnotations;

namespace SME.Pedagogico.Gestao.Dominio
{
    public enum TipoRelatorio
    {
        [Display(Name = "relatorios/alunos", ShortName = "RelatorioExemplo", Description = "Relatório exemplo")]
        RelatorioExemplo = 1
    }
}
