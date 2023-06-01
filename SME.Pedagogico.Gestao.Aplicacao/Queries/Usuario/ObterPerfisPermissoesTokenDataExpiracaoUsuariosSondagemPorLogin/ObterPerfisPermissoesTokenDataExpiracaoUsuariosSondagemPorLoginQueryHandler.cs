using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http.Authentication.Internal;
using MoreLinq.Extensions;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Dominio.Enumerados;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Infra.Constantes;
using SME.Pedagogico.Gestao.Infra.Enumerados;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQueryHandler : IRequestHandler<ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQuery, PerfisPermissaoTokenDataExpiracaoDto>
    {
        private readonly IMediator mediator;

        public ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQueryHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PerfisPermissaoTokenDataExpiracaoDto> Handle(ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQuery request, CancellationToken cancellationToken)
        {
            var obterPerfisAcessoSondagem = await mediator.Send(new ObterPerfisUsuariosSondagemPorLoginQuery(request.Login), cancellationToken);

            if (obterPerfisAcessoSondagem?.PerfisCompleto == null)
                throw new NegocioException(MensagensNegocio.USUARIO_SEM_PERMISSAO_ACESSO_SONDAGEM, 401);

            var perfisElegiveis = obterPerfisAcessoSondagem.PerfisCompleto;
            var guidsProfessores = new Guid[] { Perfis.PERFIL_PROFESSOR, Perfis.PERFIL_CJ };
            
            var perfisProfessores = perfisElegiveis != null && perfisElegiveis.Any() 
                                                    ? perfisElegiveis.Where(a => guidsProfessores.Any(p => p == a.GrupoId))
                                                    : null;

            if (perfisProfessores != null && perfisProfessores.Any())
            {
                var temAcesso = await mediator.Send(new ObterUsuarioProfessorTemAcessoQuery(obterPerfisAcessoSondagem.CodigoRf), cancellationToken);

                if (!temAcesso)
                    perfisProfessores.ToList().ForEach(p => perfisElegiveis.Remove(p));    
            }

            var perfilElegivel = perfisElegiveis.FirstOrDefault();

            if (perfilElegivel == null)
                throw new NegocioException(MensagensNegocio.USUARIO_SEM_PERMISSAO_ACESSO_SONDAGEM, 401);

            var permissoesAcessoSondagem =
                await mediator.Send(
                    new ObterDadosAcessoSondagemPorLoginPerfilQuery(obterPerfisAcessoSondagem.CodigoRf,
                        perfilElegivel.GrupoId), cancellationToken);

            if (permissoesAcessoSondagem == null)
                throw new NegocioException(MensagensNegocio.USUARIO_SEM_PERMISSAO_ACESSO_SONDAGEM, 401);

            return new PerfisPermissaoTokenDataExpiracaoDto()
            {
                Token = permissoesAcessoSondagem.Token,
                DataExpiracaoToken = permissoesAcessoSondagem.DataExpiracaoToken,
                PerfisUsuario = await ObterPerfisUsuario(obterPerfisAcessoSondagem),
                Permissoes = ObterPermissoesUsuario(permissoesAcessoSondagem),
            };
        }

        private static IEnumerable<MenuPermissaoDto> ObterPermissoesUsuario(PerfilAcessoSondagemDto permissoesAcessoSondagem)
        {
            return new List<MenuPermissaoDto>
            {
                new MenuPermissaoDto
                {
                    PodeConsultar = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Consulta),
                    PodeIncluir = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Inclusao),
                    PodeExcluir = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Exclusao),
                    PodeAlterar = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Alteracao),
                    Relatorios = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Relatorio),
                }
            }.ToList();
        }

        private async Task<PerfisPorPrioridadeDto> ObterPerfisUsuario(PerfisUsuarioSondagemDto obterPerfisAcessoSondagem)
        {
            var perfisElegiveis = obterPerfisAcessoSondagem.PerfisCompleto.Select(s => new PerfilDto
            {
                CodigoPerfil = s.GrupoId,
                NomePerfil = s.GrupoNome.Trim()
            }).ToList();

            var perfilProfessor = perfisElegiveis.FirstOrDefault(a => a.CodigoPerfil == Perfis.PERFIL_PROFESSOR);

            if (perfilProfessor != null)
            {
                var temAcesso = await mediator.Send(new ObterUsuarioProfessorTemAcessoQuery(obterPerfisAcessoSondagem.CodigoRf));

                if (!temAcesso)
                    perfisElegiveis.Remove(perfilProfessor);
            }

            var perfisUsuario = new PerfisPorPrioridadeDto
            {
                Perfis = perfisElegiveis,
                EhProfessor = obterPerfisAcessoSondagem.PossuiPerfilProfessor,
                EhProfessorCj = obterPerfisAcessoSondagem.PossuiPerfilCJ,
                EhProfessorPoa = obterPerfisAcessoSondagem.PossuiPerfilProfessorPoa,
                PossuiPerfilDre = obterPerfisAcessoSondagem.PossuiPerfilDre,
                PossuiPerfilSme = obterPerfisAcessoSondagem.PossuiPerfilSme,
                PossuiPerfilSmeOuDre = obterPerfisAcessoSondagem.PossuiPerfilSmeOuDre
            };

            var perfilElegivel = perfisElegiveis.FirstOrDefault();

            if (obterPerfisAcessoSondagem.PerfisCompleto.Count > 1 && perfilElegivel != null)
                perfisUsuario.PerfilSelecionado = perfilElegivel.CodigoPerfil;

            return perfisUsuario;
        }
    }
}