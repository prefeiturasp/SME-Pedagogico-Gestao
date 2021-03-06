﻿using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Portugues
{
   public class AlunoSondagemPortuguesDTO2
    {
        public string Id { get; set; }
        public string SondagemId{ get; set; }
        [Required(ErrorMessage = "O Codigo do Aluno é Obrigátorio")]
        public string CodigoAluno { get; set; }

        [Required(ErrorMessage = "O Nome do Aluno é Obrigátorio")]
        public string NomeAluno { get; set; }

        [Required(ErrorMessage = "O Codigo da turma é Obrigátorio")]
        public string CodigoTurma { get; set; }

        [Required(ErrorMessage = "O Codigo da DRE é Obrigátorio")]
        public string CodigoDre { get; set; }

        [Required(ErrorMessage = "O Codigo da UE é Obrigátorio")]
        public string CodigoUe { get; set; }

        [Required(ErrorMessage = "O Ano letivo é Obrigátorio")]
        public int AnoLetivo { get; set; }

        [Required(ErrorMessage = "O Ano escolar é Obrigátorio")]
        public int AnoTurma { get; set; }

        [Required(ErrorMessage = "O Componente curricular é Obrigátorio")]
        public string ComponenteCurricular { get; set; }


        [Required(ErrorMessage = "A Ordem é Obrigatória")]
        public string OrdemId { get; set; }

        [Required(ErrorMessage = "O Grupo é Obrigatório")]
        public string GrupoId { get; set; }

        public int? SequenciaOrdemSalva { get; set; }

        public int NumeroChamada { get; set; }
        public List<AlunoRespostaDto> Respostas { get; set; }

        public static explicit operator Sondagem(AlunoSondagemPortuguesDTO2 alunoSondagemPortuguesDto) =>
         alunoSondagemPortuguesDto == null ? null : new Sondagem
         {
             AnoLetivo = alunoSondagemPortuguesDto.AnoLetivo,
             AnoTurma = alunoSondagemPortuguesDto.AnoTurma,
             CodigoDre = alunoSondagemPortuguesDto.CodigoDre,
             CodigoTurma = alunoSondagemPortuguesDto.CodigoTurma,
             CodigoUe = alunoSondagemPortuguesDto.CodigoUe,
             GrupoId = alunoSondagemPortuguesDto.GrupoId,
             OrdemId = alunoSondagemPortuguesDto.OrdemId,
             ComponenteCurricularId = alunoSondagemPortuguesDto.ComponenteCurricular,
             Id = string.IsNullOrEmpty(alunoSondagemPortuguesDto.Id) ? Guid.NewGuid() :  Guid.Parse(alunoSondagemPortuguesDto.Id),
             SequenciaDeOrdemSalva = alunoSondagemPortuguesDto.SequenciaOrdemSalva

         };
    }
}


