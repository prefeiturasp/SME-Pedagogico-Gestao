using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterDresQueryHandler : IRequestHandler<ObterDresQuery, List<DREsDTO>>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMediator mediator;
        public ObterDresQueryHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<List<DREsDTO>> Handle(ObterDresQuery request, CancellationToken cancellationToken)
        {
            var token = await mediator.Send(new ObterTokenUsuarioLogadoQuery());

            var consideraHistorico = request.AnoLetivo != DateTime.Now.Year;

            using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var resposta = await httpClient.GetAsync($"v1/abrangencias/{consideraHistorico}/dres?modalidade=5&anoLetivo={request.AnoLetivo}");

                if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                {
                    if (resposta.StatusCode == HttpStatusCode.Unauthorized)
                        throw new NegocioException("Não autorizado", 401);
                    else return null;
                }

                var json = await resposta.Content.ReadAsStringAsync();

                var listaRetornoDre = JsonConvert.DeserializeObject<List<DreSGPDto>>(json);
                var listaRetornoFinal = new List<DREsDTO>();

                foreach (var item in listaRetornoDre)
                {
                    listaRetornoFinal.Add(new DREsDTO()
                    {
                        CodigoDRE = item.Codigo,
                        NomeDRE = item.Nome,
                        SiglaDRE = item.Abreviacao
                    });
                }

                return listaRetornoFinal;

            }
        }
    }
}
