using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class AlunosAPI
    {
        private readonly EndpointsAPI endpointsAPI;

        public AlunosAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI ?? throw new ArgumentNullException(nameof(endpointsAPI));
        }

        public async Task<int> ObterTotalAlunosAtivosPorPeriodo(FiltroTotalAlunosAtivos filtro)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.ObterTotalAlunosAtivosPorPeriodo);

            var parametros = new List<string>();

            if (!string.IsNullOrWhiteSpace(filtro.DreId))
                parametros.Add($"dreId={filtro.DreId}");

            if (!string.IsNullOrWhiteSpace(filtro.UeId))
                parametros.Add($"ueId={filtro.UeId}");

            var parametrosString = string.Join('&', parametros);

            var urlCompleta = string.Format(url, filtro.AnoTurma, filtro.AnoLetivo, filtro.DataInicio, filtro.DataFim);

            if (!string.IsNullOrWhiteSpace(parametrosString))
                urlCompleta += $"?{parametrosString}";

            return await HttpHelper.GetAsync<int>(urlCompleta);
        }
    }
}
