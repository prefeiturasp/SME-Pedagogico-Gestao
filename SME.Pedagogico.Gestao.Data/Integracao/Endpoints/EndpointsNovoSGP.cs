using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.Endpoints
{
    public static class EndpointsNovoSGP
    {
        public static Func<string, string> BaseSGPEndpoint = (versao) => Environment.GetEnvironmentVariable("urlApiSgp") + versao + "/";

        public static Func<string> AutenticacaoEndpoint = () => "autenticacao";

        public static Func<string> MeusDadosEndpoint = () => "usuarios/meus-dados";

        public static Func<string, string> ListarPerfisEndpoint = login => $"autenticacao/{login}/perfis/listar";

        public static Func<string, string> TrocarPerfilEndpoint = perfil => $"autenticacao/perfis/{perfil}";
    }
}
