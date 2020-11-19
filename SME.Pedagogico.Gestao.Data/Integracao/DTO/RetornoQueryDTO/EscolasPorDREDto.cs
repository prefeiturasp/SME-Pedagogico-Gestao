using Newtonsoft.Json;

namespace SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO
{
    public class EscolasPorDREDTO
    {
        
        public string CodigoEscola { get; set; }
        
        public string NomeEscola { get; set; }
        public string CodigoDRE { get; set; }
        public string TipoEscola { get; set; }
        public string SiglaTipoEscola { get; set; }
        public string NomeDRE { get; set; }
        public string SiglaDRE { get; set; }
    }
}
