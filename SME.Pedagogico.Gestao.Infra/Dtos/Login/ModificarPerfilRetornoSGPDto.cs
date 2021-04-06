using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Infra
{
    public class ModificarPerfilRetornoSGPDto
    {
        public ModificarPerfilRetornoSGPDto()
        {
            Menus = new List<MenuPermissaoDto>();
        }
        public bool EhProfessor { get; set; }

        public string Token { get; set; }
        public List<MenuPermissaoDto> Menus { get; set; }

    }
}
