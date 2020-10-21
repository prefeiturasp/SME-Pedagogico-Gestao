using System.ComponentModel.DataAnnotations;

namespace SME.Pedagogico.Gestao.Infra
{
    public enum TipoRelatorio
    {
        [Display(Name = "relatorios/alunos", ShortName = "RelatorioExemplo.pdf")]
        RelatorioExemplo = 1,    

        [Display(Name = "v1/sondagem/matematica-por-turma", ShortName = "Relatório de Sondagem (Matemática)", Description = "Relatório de Sondagem (Matemática)")]
        RelatorioMatematicaPorTurma = 16,

        [Display(Name = "v1/sondagem/matematica-consolidado", ShortName = "MatematicaConsolidado", Description = "Matematica Consolidado")]
        RelatorioMatematicaConsolidado = 17,

        [Display(Name = "v1/sondagem/portugues-por-turma", ShortName = "Relatório de Sondagem (Português)", Description = "Relatório de Sondagem (Português)")]
        RelatorioPortuguesPorTurma = 18,

        [Display(Name = "v1/sondagem/portugues-consolidado", ShortName = "PortuguesConsolidado", Description = "Português Consolidado")]
        RelatorioPortuguesConsolidado = 18

    }
}
