using System.ComponentModel.DataAnnotations;

namespace SME.Pedagogico.Gestao.Infra
{
    public enum TipoRelatorio
    {
        [Display(Name = "relatorios/alunos", ShortName = "RelatorioExemplo", Description = "Relatório exemplo")]
        RelatorioExemplo = 1,
        
        [Display(Name = "relatorios/sondagem/matematica-por-turma", ShortName = "RelatorioExemplo", Description = "Relatório exemplo")]
        RelatorioMatetimaticaPorTurma = 2,

    }
}
