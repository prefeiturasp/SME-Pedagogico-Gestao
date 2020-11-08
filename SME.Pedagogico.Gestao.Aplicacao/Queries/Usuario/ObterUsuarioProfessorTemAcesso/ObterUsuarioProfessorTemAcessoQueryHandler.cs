using MediatR;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterUsuarioProfessorTemAcessoQueryHandler : IRequestHandler<ObterUsuarioProfessorTemAcessoQuery, bool>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMediator mediator;
        public ObterUsuarioProfessorTemAcessoQueryHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Handle(ObterUsuarioProfessorTemAcessoQuery request, CancellationToken cancellationToken)
        {
            using (var httpClient = httpClientFactory.CreateClient("apiEOL"))
            {
                var resposta = await httpClient.GetAsync($"perfis/servidores/{request.ProfessorRF}/VerificaSeProfessorTemAcessoAhSondagem");

                if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                    return false;

                var json = await resposta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(json);
            }
        }
    }
}
