using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisDoUsuarioLoginQueryHandler : IRequestHandler<ObterVerificarPerfisDoUsuarioLoginQuery, List<PerfilDto>>
    {
        private readonly IMediator mediator;
        public ObterVerificarPerfisDoUsuarioLoginQueryHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<List<PerfilDto>> Handle(ObterVerificarPerfisDoUsuarioLoginQuery request, CancellationToken cancellationToken)
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

            return listaPerfisRetorno;
         
        }
    }
}
