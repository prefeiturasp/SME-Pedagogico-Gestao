using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SME.Pedagogico.Gestao.Infra
{
    public enum SituacaoMatriculaAluno
    {
        [Display(Name = "Ativo")]
        Ativo = 1,

        [Display(Name = "Desistente")]
        Desistente = 2,

        [Display(Name = "Transferido")]
        Transferido = 3,

        [Display(Name = "Vínculo Indevido")]
        VinculoIndevido = 4,

        [Display(Name = "Concluído")]
        Concluido = 5,

        [Display(Name = "Pendente Rematricula")]
        PendenteRematricula = 6,

        [Display(Name = "Falecido")]
        Falecido = 7,

        [Display(Name = "Não Compareceu")]
        NaoCompareceu = 8,

        [Display(Name = "Rematriculado")]
        Rematriculado = 10,

        [Display(Name = "Deslocamento")]
        Deslocamento = 11,

        [Display(Name = "Cessado")]
        Cessado = 12,

        [Display(Name = "Sem Continuidade")]
        SemContinuidade = 13,

        [Display(Name = "Remanejado")]
        RemanejadoSaida = 14,

        [Display(Name = "Reclassificado")]
        ReclassificadoSaida = 15

    }
}
