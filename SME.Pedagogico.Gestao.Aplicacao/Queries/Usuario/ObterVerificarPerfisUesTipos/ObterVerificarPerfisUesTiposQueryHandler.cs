using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Dominio.Enumerados;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterVerificarPerfisUesTiposQueryHandler : IRequestHandler<ObterVerificarPerfisUesTiposQuery, bool>
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ObterVerificarPerfisUesTiposQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public async Task<bool> Handle(ObterVerificarPerfisUesTiposQuery request, CancellationToken cancellationToken)
        {

            if (request.UsuarioPerfil == Perfis.PERFIL_CP || request.UsuarioPerfil == Perfis.PERFIL_AD || request.UsuarioPerfil == Perfis.PERFIL_DIRETOR)
            {
                using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
                {
                    var resposta = await httpClient.GetAsync($"v1/abrangencias/{request.UsuarioRF}/perfis/{request.UsuarioPerfil}/acesso-sondagem");

                    if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                        return false;

                    var json = await resposta.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<bool>(json);

                }
            }
            else return true;
        }
    }
}
