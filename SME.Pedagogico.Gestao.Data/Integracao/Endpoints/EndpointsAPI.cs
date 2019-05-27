using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.Endpoints
{
    public class EndpointsAPI
    {
        private string baseEndPoint = "";
        private string buscaAlunosNaTurma = "";


        public string BaseEndpoint { get; set; } = "http://10.50.0.196:81/api/";

        public string BuscaAlunosNaTurma { get; set; } = "turmas/{0}/alunos/anosLetivos/{1}";

        public string BuscaCargos { get; set; } = "cargos";

        //professores/{codigoRF}/escolas/{codigoUE}/anos_letivos/{anoLetivo}
        public string BuscaTurmasDeProfessores { get; set; } = "professores/{0}/escolas/{1}/anos_letivos/{2}";
    } // Turmas por escola 
      // Escolas por DRE 
      // Alunos da turma
}