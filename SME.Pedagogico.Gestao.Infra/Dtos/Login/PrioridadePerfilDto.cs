using System;

namespace SME.Pedagogico.Gestao.Infra
{
    public class PrioridadePerfilDto
    {
        public Guid CodigoPerfil { get; set; }
        public string NomePerfil { get; set; }
        public int Ordem { get; set; }
        public TipoPerfil Tipo { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public string AlteradoPor { get; set; }
        public string AlteradoRF { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public string CriadoRF { get; set; }
        public long Id { get; set; }
    }
}
