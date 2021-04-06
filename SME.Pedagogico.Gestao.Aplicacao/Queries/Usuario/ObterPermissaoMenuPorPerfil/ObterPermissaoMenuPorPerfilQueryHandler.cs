using MediatR;
using SME.Pedagogico.Gestao.Dominio.Enumerados;
using SME.Pedagogico.Gestao.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterPermissaoMenuPorPerfilQueryHandler : IRequestHandler<ObterPermissaoMenuPorPerfilQuery, List<MenuPermissaoDto>>
    {
        public Task<List<MenuPermissaoDto>> Handle(ObterPermissaoMenuPorPerfilQuery request, CancellationToken cancellationToken)
        {

            var podeIncluirSondagem = false;

            if (request.PerfilCodigo == Perfis.PERFIL_AD || request.PerfilCodigo == Perfis.PERFIL_PROFESSOR || request.PerfilCodigo == Perfis.PERFIL_CP
                      || request.PerfilCodigo == Perfis.PERFIL_ADMIN_SME_COPED || request.PerfilCodigo == Perfis.PERFIL_ADMIN_COTIC)
                podeIncluirSondagem = true;


            return Task.FromResult(new List<MenuPermissaoDto>
            {
                new MenuPermissaoDto
                {
                    PodeAlterar = false,
                    PodeConsultar = podeIncluirSondagem,
                    PodeExcluir = false,
                    PodeIncluir = false,
                },
            });

        }
    }
}
