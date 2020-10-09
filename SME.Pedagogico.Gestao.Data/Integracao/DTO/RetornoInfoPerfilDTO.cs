using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class RetornoInfoPerfilDTO
    {
        public RetornoInfoPerfilDTO()
        {
            DREs = new HashSet<RetornoDREDTO>();
            Escolas = new HashSet<RetornoEscolaDTO>();
            Turmas = new HashSet<RetornoTurmaDTO>();
        }

        public string NomeServidor { get; set; }
        public string CodigoServidor { get; set; }
        public HashSet<RetornoDREDTO> DREs { get; set; }
        public HashSet<RetornoEscolaDTO> Escolas { get; set; }
        public HashSet<RetornoTurmaDTO> Turmas { get; set; }        
    }
}
