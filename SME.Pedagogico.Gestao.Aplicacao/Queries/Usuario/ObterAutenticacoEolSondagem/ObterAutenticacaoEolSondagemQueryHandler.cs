using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterAutenticacaoEolSondagemQueryHandler: IRequestHandler<ObterAutenticacaoEolSondagemQuery, UsuarioAutenticacaoRetornoDto>
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ObterAutenticacaoEolSondagemQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<UsuarioAutenticacaoRetornoDto> Handle(ObterAutenticacaoEolSondagemQuery request, CancellationToken cancellationToken)
        {
            var parametros = JsonConvert.SerializeObject(new { request.Login, request.Senha });
            
            var httpClient = httpClientFactory.CreateClient("apiEOL");
            var resposta = await httpClient.PostAsync($"v1/autenticacao", new StringContent(parametros, Encoding.UTF8, "application/json-patch+json"));

            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<UsuarioAutenticacaoRetornoDto>(json);
                return retorno;
            }
            else
                return null;
        }
    }
}