using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisDoUsuarioLoginQuery : IRequest<List<PerfilDto>>
    {
        public ObterVerificarPerfisDoUsuarioLoginQuery(string usuarioRF, IList<PerfilDto> perfis)
        {
            UsuarioRF = usuarioRF;
            Perfis = perfis;
        }


        public string UsuarioRF { get; set; }

        public IList<PerfilDto> Perfis { get; set; }
    }
}
