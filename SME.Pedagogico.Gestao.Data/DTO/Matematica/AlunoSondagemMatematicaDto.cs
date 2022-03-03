using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class AlunoSondagemMatematicaDto
    {     
        public string Id { get; set; }

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

        public int NumeroChamada { get; set; }
        public int? Bimestre { get; set; }

        public List<AlunoRespostaDto> Respostas { get; set; }


        public static explicit operator SondagemAutoral(AlunoSondagemMatematicaDto alunoSondagemMatematicaDto) =>
            alunoSondagemMatematicaDto == null ? null : new SondagemAutoral
            {
                AnoLetivo = alunoSondagemMatematicaDto.AnoLetivo,
                AnoTurma = alunoSondagemMatematicaDto.AnoTurma,
                CodigoAluno = alunoSondagemMatematicaDto.CodigoAluno,
                CodigoDre = alunoSondagemMatematicaDto.CodigoDre,
                CodigoTurma = alunoSondagemMatematicaDto.CodigoTurma,
                CodigoUe = alunoSondagemMatematicaDto.CodigoUe,
                ComponenteCurricularId = alunoSondagemMatematicaDto.ComponenteCurricular,
                Id = alunoSondagemMatematicaDto.Id,
                NomeAluno = alunoSondagemMatematicaDto.NomeAluno   
                
            };
    }
}
