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
      // Turmas por escola 
      // Escolas por DRE 
      // Alunos da turma
        
        //perfis/servidores/{codigoRF}/cargos
        public string BuscaCargosdeServidor { get;  set; } = "perfis/servidores/{0}/cargos";

        //servidores/{codigoRF}/{codigoCargo}/{anoLetivo}/informacoes_perfil"
        public string BuscaInformacoesPerfil { get;  set; } = "perfis/servidores/{0}/{1}/{2}/informacoes_perfil";

        //Funcionarios/cargos/{codigoCargo}
        public string BuscaFuncionario { get;  set; }= "Funcionarios/cargos/{0}";




        // ******    Métodos da API Escola  **************************************************************************
        //HttpGet("{codigoEol}")]
        public string BuscaEscolasPor { get;  set; } = "escolas/{0}";
         
        //HttpGet("{codigoEolEscola}/professores/{anoLetivo}")]
        public string BuscaProfessores { get;  set; } = "escolas/{0}/professores/{1}";
         
        //HttpGet("modalidades_ensino")]
        public string BuscaModalidadesEnsino { get;  set; } = "escolas/modalidades_ensino";
         
        //HttpGet("tipos_unidade_educacao")]
        public string BuscaTiposUE { get;  set; } = "escolas/tipos_unidade_educacao";
         
        //HttpGet("{codigoUE}/salas/{tipoSala}/anos_letivos/{anoLetivo}")]
        public string BuscaTurmasDoTipoSala { get;  set; } = "escolas/{0}/salas/{1}/anos_letivos/{2}";

         
         
        //HttpGet("{codigoUE}/funcionarios")]
        public string BuscaFuncionariosdaEscola { get;  set; } = "escolas/{0}/funcionarios";
         
        //HttpGet("{codigoUE}/funcionarios/cargos/{codigoCargo}")]
        public string BuscaFuncionariosdaEscolaPorCargo { get;  set; } = "escolas/{0}/funcionarios/cargos/{1}";
         
            

        //HttpGet("{codigoEscolaEol}/subprefeituras")]
        public string BuscaSubprefeiturasPor { get;  set; } = "escolas/{0}/subprefeituras";


        //HttpGet("{codigoUE}/turmas/anos_letivos/{anoLetivo}")]
        public string BuscaTurmasPorEscola { get;  set; } = "escolas/{0}/turmas/anos_letivos/{1}";

        // ******  FIM   Métodos da API Escola  **************************************************************************



    }
}