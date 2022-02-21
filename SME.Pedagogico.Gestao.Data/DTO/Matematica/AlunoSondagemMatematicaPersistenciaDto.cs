using System;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class AlunoSondagemMatematicaPersistenciaDto
    {     
        public Guid SondagemAlunoRespostaId { get; set; }

        public Guid SondagemAlunoId { get; set; }

        public string PerguntaId { get; set; }

        public string RespostaId { get; set; }
        
        public int? Bimestre { get; set; }

        public string PerguntaAnoEscolarId { get; set; }
        
        public TipoAcao TipoAcao { get; set; }
    }

    public enum TipoAcao
    {
        Atualizar = 1,
        Remover = 2,
        Inserir = 3
    }
}
