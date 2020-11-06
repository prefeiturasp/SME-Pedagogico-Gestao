using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterUesPorDreQueryHandler : IRequestHandler<ObterUesPorDreQuery, IList<EscolasPorDREDTO>>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMediator mediator;

        public ObterUesPorDreQueryHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<IList<EscolasPorDREDTO>> Handle(ObterUesPorDreQuery request, CancellationToken cancellationToken)
        {
            var token = await mediator.Send(new ObterObterTokenUsuarioLogadoQuery());
            var consideraHistorico = request.AnoLetivo != DateTime.Now.Year;

            using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var resposta = await httpClient.GetAsync($"v1/abrangencias/{consideraHistorico}/dres/{request.DreCodigo}/ues");

                if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                {
                    return null;
                }

                var json = await resposta.Content.ReadAsStringAsync();

                var listaRetorno = new List<EscolasPorDREDTO>();
                var listaUesSGP =  JsonConvert.DeserializeObject<List<UesPorDreSGPDto>>(json);

                foreach (var item in listaUesSGP)
                {
                    listaRetorno.Add(new EscolasPorDREDTO()
                    {
                         NomeEscola = item.NomeSimples,
                          CodigoEscola = item.Codigo
                    });
                }


                return listaRetorno;

            }
        }
    }
}
