using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using System;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Infra
{
    public class PerfisMenusAutenticacaoDto
    {
        public PerfisMenusAutenticacaoDto(List<PerfilDto> perfis, List<MenuPermissaoDto> menus)
        {
            Perfis = perfis;
            Menus = menus;            
        }

        public List<PerfilDto> Perfis { get; set; }
        public List<MenuPermissaoDto> Menus { get; set; }
        public string Token { get; set; }

        
    }
}
