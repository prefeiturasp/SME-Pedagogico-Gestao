using Dapper;
using Npgsql;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.Relatorios.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Relatorios
{
    public  static class ConsultaTotalDeAlunos
    {

        public static async Task<int> BuscaTotalDeAlunosEOl(filtrosRelatorioDTO filtro)
        {
            var DatasPeriodo = await BuscaDatasPeriodoFixoAnual(filtro);
            if (DatasPeriodo.Count() == 0)
                return 0;

            var endpointsApi = new EndpointsAPI();
            var alunoApi = new AlunosAPI(endpointsApi);

            var filtroAlunos = new FiltroTotalAlunosAtivos()
            {
                AnoLetivo = filtro.AnoLetivo,
                AnoTurma = filtro.AnoEscolar,
                DreId = filtro.CodigoDre,
                UeId = filtro.CodigoUe,
                DataInicio = DatasPeriodo.First().DataInicio,
                DataFim = DatasPeriodo.First().DataFim
            };


            var totalDeAlunos = await alunoApi.ObterTotalAlunosAtivosPorPeriodo(filtroAlunos);
            return totalDeAlunos;
        }

       


        private static async Task<IEnumerable<DatasPeriodoFixoAnualDTO>> BuscaDatasPeriodoFixoAnual(filtrosRelatorioDTO filtro)
        {
            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                var queryPeriodoFixoAnual = ConsultasRelatorios.QueryPeriodoFixoAnual;
                var DatasPeriodo = await conexao.QueryAsync<DatasPeriodoFixoAnualDTO>(queryPeriodoFixoAnual.ToString(),
                  new
                  {
                      PeriodoId = filtro.PeriodoId,
                      AnoLetivo = filtro.AnoLetivo,

                  });

                return DatasPeriodo;
            }
        }
    }
}
