using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.Endpoints
{
    public static class EndpointsNovoSGP
    {
        public static Func<string, string> BaseSGPEndpoint = (versao) => $"https://dev-novosgp.sme.prefeitura.sp.gov.br/api/{versao}/";

        public static Func<string, string> AutenticacaoEndpoint = (urlBase) => $"${urlBase}autenticacao";
    }
}
