using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SME.Pedagogico.Gestao.Data.Business
{
    public class AlunosBusiness
    {
        private string _token;

        public IConfiguration _config;
        public AlunosBusiness(IConfiguration config)
        {
            _config = config;
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }
        public async Task<IEnumerable<AlunosNaTurmaDTO>> ObterAlunosEOL(string schoolYear, string codigoTurmaEol, string term)
        {
            filtrosRelatorioDTO filtro = new filtrosRelatorioDTO()
            {
                AnoLetivo = int.Parse(schoolYear),
                PeriodoId = ""
            };

            using (var contexto = new SMEManagementContextData())
            {
                var periodo = contexto.Periodo.Where(x => x.Descricao == term).FirstOrDefault();
                filtro.PeriodoId = periodo.Id;
            }

            var periodos = await ConsultaTotalDeAlunos.BuscaDatasPeriodoFixoAnual(filtro);

            if (periodos.Count() == 0)
                throw new Exception("Período fixo anual não encontrado");

            var endpoits = new EndpointsAPI();
            var alunoApi = new AlunosAPI(endpoits);
            return (await alunoApi.ObterAlunosAtivosPorTurmaEPeriodo(codigoTurmaEol, periodos.First().DataFim, periodos.First().DataInicio)).OrderBy(a => a.NomeAluno);
        }
    }
}
