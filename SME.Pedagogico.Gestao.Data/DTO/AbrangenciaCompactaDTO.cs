using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class AbrangenciaCompactaDTO
    {
        public string Login { get; set; }
        public GrupoCargosDTO Abrangencia { get; set; }
        public string[] IdDres { get; set; }
        public IEnumerable<DreDTO> Dres { get; set; }
        public string[] IdUes { get; set; }
        public string[] IdTurmas { get; set; }
    }
}
