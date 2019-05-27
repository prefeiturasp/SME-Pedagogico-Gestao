using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.Endpoints
{
    public class EndpointsAPI
    {
        private string baseEndPoint = "";
        private string buscaAlunosNaTurma = "";


        public string BaseEndpoint { get; set; } = "http://10.50.0.196/api/";

        public string BuscaAlunosNaTurma { get; set; } = "turmas/{0}/alunos/anosLetivos/{1}";

        public string BuscaCargos { get; set; } = "cargos";

        //professores/{codigoRF}/escolas/{codigoUE}/anos_letivos/{anoLetivo}
        public string BuscaTurmasDeProfessores { get; set; } = "professores/{0}/escolas/{1}/anos_letivos/{2}";
        
        //perfis/servidores/{codigoRF}/cargos
        public string BuscaCargosdeServidor { get; internal set; } = "perfis/servidores/{0}/cargos";

        //servidores/{codigoRF}/{codigoCargo}/{anoLetivo}/informacoes_perfil"
        public string BuscaInformacoesPerfil { get; internal set; } = "perfis/servidores/{0}/{1}/{2}/informacoes_perfil";

        //Funcionarios/cargos/{codigoCargo}
        public string BuscaFuncionario { get; internal set; }= "Funcionarios/cargos/{0}";

    }
}