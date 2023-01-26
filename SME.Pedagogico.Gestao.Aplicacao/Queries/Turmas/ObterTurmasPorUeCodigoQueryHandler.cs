using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterTurmasPorUeCodigoQueryHandler : IRequestHandler<ObterTurmasPorUeCodigoQuery, List<SalasPorUEDTO>>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMediator mediator;

        public ObterTurmasPorUeCodigoQueryHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<List<SalasPorUEDTO>> Handle(ObterTurmasPorUeCodigoQuery request, CancellationToken cancellationToken)
        {
            using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
            {
                var listaRetornoTurmas = new List<TurmaSGPDto>();

                if (request.AnoLetivo < DateTime.Now.Year)
                {
                    for (var i = 0; i < 2; i++)
                        listaRetornoTurmas.AddRange(await EnviarRequisicao(httpClient, i % 2 != 0, request.UeCodigo,
                            request.AnoLetivo, request.ConsideraNovosAnosInfantil));
                }
                else
                {
                    listaRetornoTurmas.AddRange(await EnviarRequisicao(httpClient, false, request.UeCodigo,
                        request.AnoLetivo,
                        request.ConsideraNovosAnosInfantil));
                }

                var listaRetornoFinal = new List<SalasPorUEDTO>();

                foreach (var item in listaRetornoTurmas.Where(a => a.Ano != "0").OrderBy(a => a.Nome))
                {
                    if (!listaRetornoFinal.Any(l => l.CodigoTurma.Equals(item.Codigo)))
                    {
                        listaRetornoFinal.Add(new SalasPorUEDTO()
                        {
                            CodigoTurma = item.Codigo,
                            NomeTurma = item.Nome
                        });
                    }
                }

                return listaRetornoFinal;
            }
        }

        private async Task<IEnumerable<TurmaSGPDto>> EnviarRequisicao(HttpClient httpClient, bool consideraHistorico, string ueCodigo, int anoLetivo,
            bool consideraNovosAnosInfantil)
        {
            const int modalidade = 5;

            if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await mediator.Send(new ObterTokenUsuarioLogadoQuery());
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }

            var resposta = await httpClient
                .GetAsync($"v1/abrangencias/{consideraHistorico}/dres/ues/{ueCodigo}/turmas?modalidade={modalidade}&anoLetivo={anoLetivo}&consideraNovosAnosInfantil={consideraNovosAnosInfantil}");

            if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
            {
                if (resposta.StatusCode == HttpStatusCode.Unauthorized)
                    throw new NegocioException("Não autorizado", 401);

                return await Task.FromResult(Enumerable.Empty<TurmaSGPDto>());
            }

            var json = await resposta.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<List<TurmaSGPDto>>(json));
        }
    }
}
