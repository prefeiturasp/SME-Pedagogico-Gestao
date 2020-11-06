using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
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

            var token = await mediator.Send(new ObterObterTokenUsuarioLogadoQuery());            

            using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var resposta = await httpClient.PutAsync($"v1/autenticacao/perfis/{request.Perfil}", new StringContent(string.Empty, Encoding.UTF8, "application/json-patch+json"));

                if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                {
                    return null;
                }

                var json = await resposta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ModificarPerfilRetornoSGPDto>(json);

            }
        }
    }
}

