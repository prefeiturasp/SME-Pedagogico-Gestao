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

        public static Func<string> RevalidarAutenticacao = () => $"autenticacao/revalidar";

        public static Func<bool, int?, string> AbrangenciaDres = (consideraHistorico, anoLetivo) => $"abrangencias/{consideraHistorico}/dres{ (anoLetivo.HasValue ? $"?anoLetivo={anoLetivo}" : string.Empty) }";

        public static Func<bool, int?, string, string> AbrangenciaUes = (consideraHistorico, anoLetivo, codigoDre) => $"abrangencias/{consideraHistorico}/dres/{codigoDre}/ues{ (anoLetivo.HasValue ? $"?anoLetivo={anoLetivo}" : string.Empty) }";

        public static Func<string, string> Disciplinas = (codigoTurma) => $"professores/turmas/{codigoTurma}/disciplinas";
        public static Func<string> Menus = () => "menus";
    }
}
