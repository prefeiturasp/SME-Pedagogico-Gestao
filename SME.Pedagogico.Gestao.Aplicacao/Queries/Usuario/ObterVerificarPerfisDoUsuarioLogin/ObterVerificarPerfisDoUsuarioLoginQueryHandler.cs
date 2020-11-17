using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Dominio.Enumerados;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisDoUsuarioLoginQueryHandler : IRequestHandler<ObterVerificarPerfisDoUsuarioLoginQuery, PerfisMenusAutenticacaoDto>
    {
        private readonly IMediator mediator;
        public ObterVerificarPerfisDoUsuarioLoginQueryHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<PerfisMenusAutenticacaoDto> Handle(ObterVerificarPerfisDoUsuarioLoginQuery request, CancellationToken cancellationToken)
        {
            
            var perfisElegiveis = Perfil.ObterPerfis().Where(x => request.Perfis.Any(y => y.CodigoPerfil.Equals(x.PerfilGuid))).ToList();
            
            //Verificar se possui perfil professor
            var perfilProfessor = perfisElegiveis.FirstOrDefault(a => a.PerfilGuid == Guid.Parse("40E1E074-37D6-E911-ABD6-F81654FE895D"));

            if (perfilProfessor != null)
            {
                var temAcesso = await mediator.Send(new ObterUsuarioProfessorTemAcessoQuery(request.UsuarioRF));
                if (!temAcesso)
                    perfisElegiveis.Remove(perfilProfessor);
            }

            if (!perfisElegiveis.Any())
                throw new NegocioException("Usuário sem permissão de acesso na Sondagem.", 401);

            var listaPerfisRetorno = new List<PerfilDto>();

            // FIM Da verificação de perfis \\

            //Tratar os Perfis que podem visualizar           

            foreach (var perfilElegivel in perfisElegiveis)
            {
                listaPerfisRetorno.Add(new PerfilDto()
                {
                    CodigoPerfil = perfilElegivel.PerfilGuid,
                    NomePerfil = perfilElegivel.RoleName
                });
            }

            var podeIncluir = false;
            var menus = new List<MenuPermissaoDto>
            {
                new MenuPermissaoDto
                {
                    PodeAlterar = false,
                    PodeConsultar = podeIncluir,
                    PodeExcluir = false,
                    PodeIncluir = false,
                },
            };

            

            //Verificando se pode acessar haba SONDAGEM
            if (perfisElegiveis.Count == 1)
            {   
                var perfilCodigo = listaPerfisRetorno.FirstOrDefault().CodigoPerfil;

                if (perfilCodigo == Perfis.PERFIL_AD || perfilCodigo == Perfis.PERFIL_PROFESSOR || perfilCodigo == Perfis.PERFIL_CP
                    || perfilCodigo == Perfis.PERFIL_ADMIN_SME_COPED || perfilCodigo == Perfis.PERFIL_ADMIN_COTIC)
                        podeIncluir = true;
                menus = await mediator.Send(new ObterPermissaoMenuPorPerfilQuery(perfilCodigo));


                //Verificando se o usuário tem abrangencia UE com tipos definidos
                var podeAcessarTiposDeEscola = await mediator.Send(new ObterVerificarPerfisUesTiposQuery(request.UsuarioRF, perfilCodigo));
                
                if (!podeAcessarTiposDeEscola)
                    throw new NegocioException("Usuário sem permissão de acesso na Sondagem.", 401);


            }
            return new PerfisMenusAutenticacaoDto(listaPerfisRetorno, menus);
        }
    }
}
