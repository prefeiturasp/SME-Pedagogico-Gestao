using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SME.Pedagogico.Gestao.Aplicacao;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.WebApp.Contexts;
using SME.Pedagogico.Gestao.WebApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra.Constantes;
using SME.Pedagogico.Gestao.Infra.Enumerados;

namespace SME.Pedagogico.Gestao.WebApp.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Construtor padrão para o AuthController, faz injeção de dependências de IConfiguration e SMEManagementContext.
        /// </summary>
        /// <param name="config">Depêndencia de configurações</param>
        /// <param name="db">Depêndencia de dataContext (SMEManagementContext)</param>
        public AuthController(){}

        /// <summary>
        /// Método para deslogar o usuário.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username e session</param>
        /// <returns>Retorna verdadeiro caso o usuário estiver logado com as credenciais especificadas, caso contrário retorna falso.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Logout([FromBody] CredentialModel credential)
        {
            return (Ok(await Authentication.LogoutUser(credential.Username, credential.Session)));
        }

        /// <summary>
        /// Método para fazer login do usuário utilizando o sistema http://identity.sme.prefeitura.sp.gov.br.
        /// </summary>
        /// <param name="credential">Objeto que contém informações da credencial do usuário, neste caso específico é necessário o atributo username e password</param>
        /// <returns>Informações sobre o usuário que está tentando logar (tokens de acesso e cookies), caso não seja encontrado nenhum usuário correspondente à credencial, o método retorna usuário não autorizado.</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(UsuarioAutenticacaoRetornoDto), 200)]
        [AllowAnonymous]
        public async Task<ActionResult<string>> LoginIdentity([FromBody] CredentialModel credential, [FromServices]IMediator mediator)
        {
            var retornoAutenticacao = await mediator.Send(new ObterAutenticacaoEolSondagemQuery(credential.Username, credential.Password));
            if (retornoAutenticacao == null)
                return Unauthorized(MensagensNegocio.USUARIO_SENHA_INVALIDA);

            retornoAutenticacao.Autenticado = EstaAutenticado(retornoAutenticacao);
            retornoAutenticacao.ModificarSenha = retornoAutenticacao.Status == AutenticacaoStatusEol.SenhaPadrao;
            
            if (retornoAutenticacao.ModificarSenha)
                return Unauthorized(MensagensNegocio.VOCE_DEVE_ALTERAR_SENHA_DIRETAMENTE_NO_SGP);
             
            var obterPerfisAcessoSondagem = await mediator.Send(new ObterPerfisUsuariosSondagemPorLoginQuery(credential.Username));

            if (obterPerfisAcessoSondagem == null || obterPerfisAcessoSondagem.PerfisCompleto == null)
                throw new NegocioException(MensagensNegocio.USUARIO_SEM_PERMISSAO_ACESSO_SONDAGEM, 401);
            
            var permissoesAcessoSondagem = await mediator.Send(new ObterDadosAcessoSondagemPorLoginPerfilQuery(obterPerfisAcessoSondagem.CodigoRf, obterPerfisAcessoSondagem.PerfisCompleto.FirstOrDefault().GrupoId));

            if (permissoesAcessoSondagem == null)
                throw new NegocioException(MensagensNegocio.USUARIO_SEM_PERMISSAO_ACESSO_SONDAGEM, 401);
            
            retornoAutenticacao.Token = permissoesAcessoSondagem.Token;
            retornoAutenticacao.DataHoraExpiracao = permissoesAcessoSondagem.DataExpiracaoToken;
            retornoAutenticacao.PerfisUsuario = ObterPerfisUsuario(obterPerfisAcessoSondagem);
            retornoAutenticacao.Permissoes = ObterPermissoesUsuario(permissoesAcessoSondagem);
            
            return Ok(retornoAutenticacao);
        }

        private List<MenuPermissaoDto> ObterPermissoesUsuario(PerfilAcessoSondagemDto permissoesAcessoSondagem)
        {
            return new List<MenuPermissaoDto>()
            {
                new MenuPermissaoDto()
                {
                    PodeConsultar = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Consulta),
                    PodeIncluir = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Inclusão),
                    PodeExcluir = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Exclusão),
                    PodeAlterar = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Alteração),
                    Relatorios = permissoesAcessoSondagem.Permissoes.Contains((int)PermissoesSondagemEnum.Relatório),
                }
            }.ToList();
        }

        private PerfisPorPrioridadeDto ObterPerfisUsuario(PerfisUsuarioSondagemDto obterPerfisAcessoSondagem)
        {
            var perfisUsuario = new PerfisPorPrioridadeDto
            {
                Perfis = obterPerfisAcessoSondagem.PerfisCompleto.Select(s => new PerfilDto()
                {
                    CodigoPerfil = s.GrupoId,
                    NomePerfil = s.GrupoNome
                }).ToList(),
                EhProfessor = obterPerfisAcessoSondagem.PossuiPerfilProfessor,
                EhProfessorCj = obterPerfisAcessoSondagem.PossuiPerfilCJ,
                EhProfessorPoa = obterPerfisAcessoSondagem.PossuiPerfilProfessorPoa,
                PossuiPerfilDre = obterPerfisAcessoSondagem.PossuiPerfilDre,
                PossuiPerfilSme = obterPerfisAcessoSondagem.PossuiPerfilSme,
                PossuiPerfilSmeOuDre = obterPerfisAcessoSondagem.PossuiPerfilSmeOuDre
            };
            if (obterPerfisAcessoSondagem.PerfisCompleto.Count > 1)
                perfisUsuario.PerfilSelecionado = obterPerfisAcessoSondagem.PerfisCompleto.FirstOrDefault().GrupoId;

            return perfisUsuario;
        }

        private static bool EstaAutenticado(UsuarioAutenticacaoRetornoDto retornoAutenticacao)
        {
            return retornoAutenticacao.Status == AutenticacaoStatusEol.Ok || retornoAutenticacao.Status == AutenticacaoStatusEol.SenhaPadrao;
        }


        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> ModificarPerfil([FromQuery] string perfil, [FromServices]IMediator mediator)
        {
            return Ok(await mediator.Send(new AtualizarPerfilCommand(perfil)));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> ValidarPerfisToken([FromBody] List<PerfilDto> perfis, [FromServices]IMediator mediator)
        {
            return Ok(await mediator.Send(new ObterVerificarPerfisTokenQuery(perfis)));
        }
    }
}