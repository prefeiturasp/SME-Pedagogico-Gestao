﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Integracao.Endpoints
{
    public class EndpointsAPI
    {
        private string baseEndPoint = "";
        private string buscaAlunosNaTurma = "";
        
        public string BaseEndpoint { get; set; } = Environment.GetEnvironmentVariable("urlApiEol");

        public string BuscaAlunosNaTurma { get; set; } = "turmas/{0}/considera-inativos/{1}";

        public string AbrangenciaCompacta { get; set; } = "abrangencia/compacta-vigente/{0}/perfil/{1}/DreDetalhes";

        public string AbrangenciaCompactaSondagem { get; set; } = "abrangencia/compacta-vigente/{0}/perfil/{1}/Sondagem";

        public string BuscaCargos { get; set; } = "cargos";
		
		public string ObterTotalAlunosAtivosPorPeriodo { get; set; } = "alunos/ativos/anos/{0}/anos-letivos/{1}/inicio/{2}/fim/{3}";
		public string ObterAlunosAtivosPorTurmaEPeriodo { get; set; } = "alunos/turmas/{0}/ativos/{1}";

        //professores/{codigoRF}/escolas/{codigoUE}/anos_letivos/{anoLetivo}
        public string BuscaTurmasDeProfessores { get; set; } = "professores/{0}/escolas/{1}/anos_letivos/{2}";
        // Turmas por escola 
        // Escolas por DRE 
        // Alunos da turma

        //perfis/servidores/{codigoRF}/cargos
        public string BuscaCargosdeServidor { get; set; } = "perfis/servidores/{0}/cargos/criptografado";

        //servidores/{codigoRF}/{codigoCargo}/{anoLetivo}/informacoes_perfil"
        public string BuscaInformacoesPerfil { get; set; } = "perfis/servidores/{0}/{1}/{2}/informacoes_perfil";

        public string VerificaSeProfessorTemAcesso { get; set; } = "perfis/servidores/{0}/VerificaSeProfessorTemAcessoAhSondagem";
        //Funcionarios/cargos/{codigoCargo}
        public string BuscaFuncionario { get; set; } = "Funcionarios/cargos/{0}";

        // ******    Métodos da API Escola  **************************************************************************
        //HttpGet("{codigoEol}")]
        public string BuscaEscolasPor { get; set; } = "escolas/{0}";

        //HttpGet("{codigoEolEscola}/professores/{anoLetivo}")]
        public string BuscaProfessores { get; set; } = "escolas/{0}/professores/{1}";

        //HttpGet("modalidades_ensino")]
        public string BuscaModalidadesEnsino { get; set; } = "escolas/modalidades_ensino";

        //HttpGet("tipos_unidade_educacao")]
        public string BuscaTiposUE { get; set; } = "escolas/tipos_unidade_educacao";

        //HttpGet("{codigoUE}/salas/{tipoSala}/anos_letivos/{anoLetivo}")]
        public string BuscaTurmasDoTipoSala { get; set; } = "escolas/{0}/salas/{1}/anos_letivos/{2}";



        //HttpGet("{codigoUE}/funcionarios")]
        public string BuscaFuncionariosdaEscola { get; set; } = "escolas/{0}/funcionarios";

        //HttpGet("{codigoUE}/funcionarios/cargos/{codigoCargo}")]
        public string BuscaFuncionariosdaEscolaPorCargo { get; set; } = "escolas/{0}/funcionarios/cargos/{1}";


        //HttpGet("{codigoEscolaEol}/subprefeituras")]
        public string BuscaSubprefeiturasPor { get; set; } = "escolas/{0}/subprefeituras";


        //HttpGet("{codigoUE}/turmas/anos_letivos/{anoLetivo}")]
        public string BuscaTurmasPorEscola { get; set; } = "escolas/{0}/turmasSondagem/anos_letivos/{1}";

        // ******  FIM   Métodos da API Escola  **************************************************************************




        // ******       Métodos da API DREs  **************************************************************************
        //[HttpGet]
        public string BuscaDres { get; set; } = "dres";

        //[HttpGet("{codigoDRE}")] 
        public string BuscaDresPorCodigo { get; set; } = "dres/{0}";

        //[HttpGet("{codigoDRE}/escolas/{tipoEscola}")]
        public string BuscaEscolasPorDREPorTipoEscola { get; set; } = "dres/{0}/escolas/{1}";

        //[HttpGet("{codigoDRE}/escolas/")]
        public string BuscaEscolasPorDre { get; set; } = "dres/{0}/escolas/";

        //[HttpGet("escolas/{tipoEscola}")]
        public string BuscaEscolasPorTipoEscola { get; set; } = "dres/escolas/{0}";

        //[HttpGet("{codigoDRE}/subprefeituras")] 
        public string BuscaSubprefeituraPor { get; set; } = "dres/{0}/subprefeituras";

        // ****** FIM   Métodos da API DREs  **************************************************************************

    }
}