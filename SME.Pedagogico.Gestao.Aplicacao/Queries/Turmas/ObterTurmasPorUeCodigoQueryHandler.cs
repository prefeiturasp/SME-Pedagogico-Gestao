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

        private const string PERFIL_CJ = "41e1e074-37d6-e911-abd6-f81654fe895d";
        private const string PERFIL_PROFESSOR = "40E1E074-37D6-E911-ABD6-F81654FE895D";
        private const string PERFIL_PAP = "3ee1e074-37d6-e911-abd6-f81654fe895d";

        public ObterTurmasPorUeCodigoQueryHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<List<SalasPorUEDTO>> Handle(ObterTurmasPorUeCodigoQuery request, CancellationToken cancellationToken)
        {
            var perfilAtual = await mediator.Send(new ObterPerfilUsuarioLogadoQuery());

            using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
            {
                var listaRetornoTurmas = new List<TurmaSGPDto>();

                if (request.AnoLetivo < DateTime.Now.Year)
                {
                    for (var i = 0; i < 2; i++)
                        listaRetornoTurmas.AddRange(await EnviarRequisicao(httpClient, i % 2 != 0, request.UeCodigo,
                            request.AnoLetivo, request.ConsideraNovosAnosInfantil, perfilAtual));
                }
                else
                {
                    listaRetornoTurmas.AddRange(await EnviarRequisicao(httpClient, false, request.UeCodigo,
                        request.AnoLetivo,
                        request.ConsideraNovosAnosInfantil, perfilAtual));
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

                if (EhProfessor(perfilAtual))
                    listaRetornoFinal = await RetornaTurmasAbrangenciaProfessor(listaRetornoFinal);


                return listaRetornoFinal;
            }
        }

        private bool EhPerfilPAP(string perfilAtual) 
        {
            return perfilAtual.ToUpper() == PERFIL_PAP.ToUpper();
        }

        private bool EhProfessor(string perfilAtual)
            => perfilAtual.ToUpper() == PERFIL_CJ.ToUpper() || perfilAtual.ToUpper() == PERFIL_PROFESSOR.ToUpper();

        private async Task<IEnumerable<TurmaSGPDto>> EnviarRequisicao(HttpClient httpClient, bool consideraHistorico, string ueCodigo, int anoLetivo,
            bool consideraNovosAnosInfantil, string perfilAtual)
        {
            const int modalidade = 5;

            if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await mediator.Send(new ObterTokenUsuarioLogadoQuery());
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }

            var uri = $"v1/abrangencias/{consideraHistorico}/dres/ues/{ueCodigo}/turmas?modalidade={modalidade}&anoLetivo={anoLetivo}&consideraNovosAnosInfantil={consideraNovosAnosInfantil}";

            if (EhPerfilPAP(perfilAtual))
                uri = $"v1/turmas/ues/{ueCodigo}/sondagem?anoLetivo={anoLetivo}";

            var resposta = await httpClient.GetAsync(uri);

            if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
            {
                if (resposta.StatusCode == HttpStatusCode.Unauthorized)
                    throw new NegocioException("Não autorizado", 401);

                return await Task.FromResult(Enumerable.Empty<TurmaSGPDto>());
            }

            var json = await resposta.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<List<TurmaSGPDto>>(json));
        }

        private async Task<List<SalasPorUEDTO>> RetornaTurmasAbrangenciaProfessor(List<SalasPorUEDTO> turmasDoProfessor)
        {
            var turmasQuePossuemSondagem = new List<SalasPorUEDTO>();

            foreach(var turma in turmasDoProfessor)
            {
                var componentesDaTurma = await mediator.Send(new ObterCCPorTurmaUsuarioQuery(turma.CodigoTurma));

                if (componentesDaTurma.Any())
                    turmasQuePossuemSondagem.Add(turma);
            }

            return turmasQuePossuemSondagem;
        }
    }
}
