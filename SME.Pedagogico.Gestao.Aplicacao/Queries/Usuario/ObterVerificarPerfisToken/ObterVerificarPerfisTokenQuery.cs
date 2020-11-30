using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisTokenQuery : IRequest<PerfisMenusAutenticacaoDto>
    {
        public ObterVerificarPerfisTokenQuery(IList<PerfilDto> perfis)
        {
            Perfis = perfis;
        }

        public IList<PerfilDto> Perfis { get; set; }
        public string Token { get; set; }
    }
}
