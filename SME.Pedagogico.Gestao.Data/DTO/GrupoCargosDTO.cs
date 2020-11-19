using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Data.DTO
{
    public class GrupoCargosDTO
    {
        public Guid GrupoID { get; set; }
        public List<int> CargosId { get; set; }
        public GruposSGP Grupo { get; set; }
        public int TipoFuncaoAtividade { get; set; }
        public Abrangencia Abrangencia { get; set; }
        public bool EhPerfilManual { get; set; }
    }
}
