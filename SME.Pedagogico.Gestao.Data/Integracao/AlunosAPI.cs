using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
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

            parametros.Add("modalidades=5"); //ENSINO FUNDAMENTAL DE 9 ANOS
            parametros.Add("modalidades=13"); //ENSINO FUNDAMENTAL 9 ANOS

            if (!string.IsNullOrWhiteSpace(filtro.UeId))
                parametros.Add($"ueId={filtro.UeId}");
            else
            {
                if (!string.IsNullOrWhiteSpace(filtro.DreId))
                    parametros.Add($"dreId={filtro.DreId}");
            }

            var parametrosString = string.Join('&', parametros);

            var urlCompleta = string.Format(url, filtro.AnoTurma, filtro.AnoLetivo, filtro.DataInicio.ToString("yyyy-MM-dd"), filtro.DataFim.ToString("yyyy-MM-dd"));

            if (!string.IsNullOrWhiteSpace(parametrosString))
                urlCompleta += $"?{parametrosString}";            

            return await HttpHelper.GetAsync<int>(urlCompleta);
        }

        public async Task<IEnumerable<AlunosNaTurmaDTO>> ObterAlunosAtivosPorTurmaEPeriodo(string codigoTurma, DateTime dataReferenciaFim, DateTime? dataReferenciaInicio = null)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.ObterAlunosAtivosPorTurmaEPeriodo);

            var urlCompleta = string.Format(url, codigoTurma, dataReferenciaFim.ToString("yyyy-MM-dd"));

            if (dataReferenciaInicio != null)
                urlCompleta += $"?dataReferenciaInicio={dataReferenciaInicio.Value.ToString("yyyy-MM-dd")}";

            return await HttpHelper.GetAsync<IEnumerable<AlunosNaTurmaDTO>>(urlCompleta);
        }
    }
}
