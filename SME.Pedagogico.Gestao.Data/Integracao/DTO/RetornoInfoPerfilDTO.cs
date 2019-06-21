using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO
{
    public class RetornoInfoPerfilDTO
    {
        public string NomeServidor { get; set; }
        public string CodigoServidor { get; set; }
        public HashSet<DREsDTO> DREs { get; set; }
        public HashSet<RetornoEscolaDTO> Escolas { get; set; }
        public HashSet<RetornoTurmaDTO> Turmas { get; set; }
    }
}
