using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterCCPorTurmaUsuarioQueryHandler : IRequestHandler<ObterCCPorTurmaUsuarioQuery, IList<DisciplinaRetornoDto>>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMediator mediator;
        public ObterCCPorTurmaUsuarioQueryHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<IList<DisciplinaRetornoDto>> Handle(ObterCCPorTurmaUsuarioQuery request, CancellationToken cancellationToken)
        {
            var token = await mediator.Send(new ObterObterTokenUsuarioLogadoQuery());

            using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var resposta = await httpClient.GetAsync($"v1/professores/turmas/{request.TurmaCodigo}/disciplinas");

                if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                {
                    return null;
                }

                var json = await resposta.Content.ReadAsStringAsync();

                var listaComponentes =  JsonConvert.DeserializeObject<List<DisciplinaRetornoDto>>(json);

                var listFixaComponentes = new List<DisciplinaRetornoDto>() 
                { 
                    new DisciplinaRetornoDto() { CodigoComponenteCurricular = "math", Nome = "Matemática" }, 
                    new DisciplinaRetornoDto() { CodigoComponenteCurricular = "port", Nome = "Língua Portuguesa" }
                };                

                return listFixaComponentes;

            }
        }
    }
}