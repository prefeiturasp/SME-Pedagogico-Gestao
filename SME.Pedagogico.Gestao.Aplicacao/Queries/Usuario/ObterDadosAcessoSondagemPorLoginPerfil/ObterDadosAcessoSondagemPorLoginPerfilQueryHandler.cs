using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterDadosAcessoSondagemPorLoginPerfilQueryHandler: IRequestHandler<ObterDadosAcessoSondagemPorLoginPerfilQuery, PerfilAcessoSondagemDto>
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ObterDadosAcessoSondagemPorLoginPerfilQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<PerfilAcessoSondagemDto> Handle(ObterDadosAcessoSondagemPorLoginPerfilQuery request, CancellationToken cancellationToken)
        {
            var httpClient = httpClientFactory.CreateClient("apiEOL");
            var resposta = await httpClient.GetAsync($"AutenticacaoSondagem/dados-acesso/usuarios/{request.Login}/perfis/{request.Perfil}");

            if (resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<PerfilAcessoSondagemDto>(json);
                return retorno;
            }
            else
                return null;
        }
    }
}