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
using System.Linq;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Dominio.Enumerados;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterUesPorDreQueryHandler : IRequestHandler<ObterUesPorDreQuery, IList<EscolasPorDREDTO>>
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMediator mediator;
        private const string TIPO_ESCOLA_CEU_EXCLUSIVO_ATIVIDADE_COMPLEMENTAR = "27";

        public ObterUesPorDreQueryHandler(IHttpClientFactory httpClientFactory, IMediator mediator)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<IList<EscolasPorDREDTO>> Handle(ObterUesPorDreQuery request, CancellationToken cancellationToken)
        {
            var token = await mediator.Send(new ObterTokenUsuarioLogadoQuery());
            var consideraHistorico = request.AnoLetivo != DateTime.Now.Year;

            using (var httpClient = httpClientFactory.CreateClient("apiSGP"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var resposta = await httpClient.GetAsync($"v1/abrangencias/{consideraHistorico}/dres/{request.DreCodigo}/ues?modalidade=5&filtrarTipoEscolaPorAnoLetivo=true");

                if (!resposta.IsSuccessStatusCode || resposta.StatusCode == HttpStatusCode.NoContent)
                {
                    if (resposta.StatusCode == HttpStatusCode.Unauthorized)
                        throw new NegocioException("Não autorizado", 401);
                    else return null;
                }

                var json = await resposta.Content.ReadAsStringAsync();

                var listaRetorno = new List<EscolasPorDREDTO>();
                var listaUesSGP =  JsonConvert.DeserializeObject<List<UesPorDreSGPDto>>(json);

                foreach (var item in listaUesSGP.Where(ue => EnumExtensao.EhUmDosValores(ue.TipoEscola, new Enum[] { TipoEscola.EMEF, TipoEscola.EMEFM, TipoEscola.EMEBS, TipoEscola.CEUEMEF, TipoEscola.EMEFPFOM })))
                {
                    var tipoEscola = (int)item.TipoEscola;
                    listaRetorno.Add(new EscolasPorDREDTO()
                    {
                         NomeEscola = item.NomeSimples,
                          CodigoEscola = item.Codigo,
                          TipoEscola = tipoEscola > 0 ? tipoEscola.ToString() : string.Empty
                    });
                }


                return listaRetorno
                    .Where(l=> l.TipoEscola != TIPO_ESCOLA_CEU_EXCLUSIVO_ATIVIDADE_COMPLEMENTAR)
                    .OrderBy(a => a.NomeEscola)
                    .ToList();

            }
        }
    }
}
