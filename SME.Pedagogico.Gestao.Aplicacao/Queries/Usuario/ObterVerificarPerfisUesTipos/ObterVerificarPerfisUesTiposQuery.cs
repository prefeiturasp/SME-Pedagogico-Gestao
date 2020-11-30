using MediatR;
using System;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisUesTiposQuery : IRequest<bool>
    {
        public ObterVerificarPerfisUesTiposQuery(string usuarioRF, Guid usuarioPerfil)
        {
            UsuarioRF = usuarioRF;
            UsuarioPerfil = usuarioPerfil;
        }

        public string UsuarioRF { get; set; }
        public Guid UsuarioPerfil { get; set; }
    }
}
