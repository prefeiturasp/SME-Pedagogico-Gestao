using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Utilitarios;

namespace SME.Pedagogico.Gestao.Data.Integracao
{
    public class PerfilSgpAPI
    {
        private readonly EndpointsAPI endpointsAPI;

        public PerfilSgpAPI(EndpointsAPI endpointsAPI)
        {
            this.endpointsAPI = endpointsAPI;
        }

        public async Task<RetornoCargosServidorDTO> GetCargosDeServidor(string codigoRF, string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaCargosdeServidor);

            return await HttpHelper
                .GetAsync<RetornoCargosServidorDTO>
                      (token, string.Format(url, UtilCriptografia.ConverterBase64(codigoRF)));
        }

        public async Task<RetornoInfoPerfilDTO> getInformacoesPerfil(string codigoRF,
                                                     int codigoCargo,
                                                     int anoLetivo, string token, Guid? Perfil)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.BuscaInformacoesPerfil);

            if (Perfil.HasValue)
                url += $"?perfil={Perfil.Value}";

            return await HttpHelper
                .GetAsync<RetornoInfoPerfilDTO>
                      (token, string.Format(url, codigoRF, codigoCargo, anoLetivo));
        }


        public async Task<bool> VerificaSeProfessorTemAcesso(string codigoRF,
                                                     string token)
        {
            var url = HttpHelper.ConstroiURL(endpointsAPI.BaseEndpoint, endpointsAPI.VerificaSeProfessorTemAcesso);

            return await HttpHelper
                .GetAsync<bool>
                      (token, string.Format(url, codigoRF));
        }


    }
}
