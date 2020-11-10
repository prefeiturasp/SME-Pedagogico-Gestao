using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class AtualizarPerfilCommandHandler : IRequestHandler<AtualizarPerfilCommand, ModificarPerfilRetornoSGPDto>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMediator mediator;

        public AtualizarPerfilCommandHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<ModificarPerfilRetornoSGPDto> Handle(AtualizarPerfilCommand request, CancellationToken cancellationToken)
        {

            var perfilAtual = await mediator.Send(new ObterPerfilUsuarioLogadoQuery());

            if (perfilAtual == request.Perfil)
                return default;

            var token = await mediator.Send(new ObterTokenUsuarioLogadoQuery());            

            using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var resposta = await httpClient.PutAsync($"v1/autenticacao/perfis/{request.Perfil}", new StringContent(string.Empty, Encoding.UTF8, "application/json-patch+json"));

                if (resposta.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new NegocioException("Não foi possível obter o perfil.");
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new NegocioException("É necessário autenticar novamente.", 401);
                }

                var json = await resposta.Content.ReadAsStringAsync();
                var retornoSGP = JsonConvert.DeserializeObject<ModificarPerfilRetornoSGPDto>(json); 
                
                retornoSGP.Menus = await mediator.Send(new ObterPermissaoMenuPorPerfilQuery(Guid.Parse(perfilAtual)));

                return retornoSGP;

            }
        }
    }
}

