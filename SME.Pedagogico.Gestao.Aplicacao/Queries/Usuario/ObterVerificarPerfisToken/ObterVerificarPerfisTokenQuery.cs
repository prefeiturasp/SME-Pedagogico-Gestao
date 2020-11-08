using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisTokenQuery : IRequest<List<PerfilDto>>
    {
        public ObterVerificarPerfisTokenQuery(IList<PerfilDto> perfis)
        {
            Perfis = perfis;
        }

        public IList<PerfilDto> Perfis { get; set; }
    }
}
