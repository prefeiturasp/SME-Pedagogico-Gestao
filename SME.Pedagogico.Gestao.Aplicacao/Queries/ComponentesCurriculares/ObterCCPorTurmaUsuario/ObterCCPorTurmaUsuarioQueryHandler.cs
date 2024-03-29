﻿using MediatR;
using Newtonsoft.Json;
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
    public class ObterCCPorTurmaUsuarioQueryHandler : IRequestHandler<ObterCCPorTurmaUsuarioQuery, IList<DisciplinaRetornoDto>>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMediator mediator;
        private const string CODIGO_COMPONENTE_CURRICULAR_MATEMATICA = "2";
        private const string CODIGO_COMPONENTE_CURRICULAR_PORTUGUES = "138";

        public ObterCCPorTurmaUsuarioQueryHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<IList<DisciplinaRetornoDto>> Handle(ObterCCPorTurmaUsuarioQuery request, CancellationToken cancellationToken)
        {
            var componenteMat = new DisciplinaRetornoDto() { CodigoComponenteCurricular = "math", Nome = "Matemática" };
            var componentePor = new DisciplinaRetornoDto() { CodigoComponenteCurricular = "port", Nome = "Língua Portuguesa" };

            var listFixaComponentes = new List<DisciplinaRetornoDto>() { componenteMat, componentePor };

            var perfilAtual = await mediator.Send(new ObterPerfilUsuarioLogadoQuery());

            if (perfilAtual.ToUpper() == "40E1E074-37D6-E911-ABD6-F81654FE895D")
            {
                var token = await mediator.Send(new ObterTokenUsuarioLogadoQuery());

                using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var resposta = await httpClient.GetAsync($"v1/professores/turmas/{request.TurmaCodigo}/disciplinas");

                    if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                    {
                        if (resposta.StatusCode == HttpStatusCode.Unauthorized)
                            throw new NegocioException("Não autorizado", 401);
                        else return null;
                    }

                    var json = await resposta.Content.ReadAsStringAsync();

                    var listaComponentesSGP = JsonConvert.DeserializeObject<List<DisciplinaRetornoDto>>(json);

                    //Verificar se tem regencia, se tiver, deve visualizar PT e MT, caso não, verifico se tem MT e PT para deixar na lista
                    var listaIdsEnum = EnumExtensao.Listar<ComponentesCurricularesRegenciaEnum>().Select(a => ((int)a).ToString());

                    if (!listaComponentesSGP.Any(a => listaIdsEnum.Contains(a.CodigoComponenteCurricular)))
                    {
                        //Verifico se tem Mat
                        if (!listaComponentesSGP.Any(a => a.CodigoComponenteCurricular.Equals(CODIGO_COMPONENTE_CURRICULAR_MATEMATICA)))
                            listFixaComponentes.Remove(componenteMat);

                        //Verifico se tem Pt
                        if (!listaComponentesSGP.Any(a => a.CodigoComponenteCurricular.Equals(CODIGO_COMPONENTE_CURRICULAR_PORTUGUES)))
                            listFixaComponentes.Remove(componentePor);

                    }
                }
            }


            return listFixaComponentes;
        }
    }
}
