using MediatR;
using Newtonsoft.Json;
using SME.Pedagogico.Gestao.Data.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao.Queries.ListarTurmas
{
    public class ListarTurmasQueryHandler : IRequestHandler<ListarTurmasQuery, IList<TurmaDTO>>
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ListarTurmasQueryHandler(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IList<TurmaDTO>> Handle(ListarTurmasQuery request, CancellationToken cancellationToken)
        {
            var listaTurmas = new List<TurmaDTO>();
            var filtro = JsonConvert.SerializeObject(request.CodigosTurmas);

            using (var httpClient = httpClientFactory.CreateClient("apiEOL"))
            {
                var resposta = await httpClient.PostAsync("turmas/listar-turmas", new StringContent(filtro, Encoding.UTF8, "application/json-patch+json"));

                if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                    return listaTurmas;

                var json = await resposta.Content.ReadAsStringAsync();

                listaTurmas = JsonConvert.DeserializeObject<List<TurmaDTO>>(json);
            }

            return listaTurmas;
        }
    }
}