using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using SME.Pedagogico.Gestao.Infra;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisDoUsuarioLoginQuery : IRequest<PerfisMenusAutenticacaoDto>
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
