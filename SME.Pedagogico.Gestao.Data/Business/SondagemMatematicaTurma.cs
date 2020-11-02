using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class SondagemMatematicaTurma
    {
        private string _token;

        public IConfiguration _config;
        public SondagemMatematicaTurma(IConfiguration config)
        {
            _config = config;
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }


        public async Task<PollReportMathStudentResult> BuscarDadosMatematicaPorTurmaAsync(string proficiency, string term,
                                                                                            string codigoDRE,
                                                                                            string codigoEscola,
                                                                                            string codigoTurmaEol, string CodigoCurso, string schoolYear)
        {

            PollReportMathStudentResult retorno = new PollReportMathStudentResult();

            if (proficiency == "Campo Aditivo")
            {
                retorno = await BuscaDadosCA(codigoTurmaEol, proficiency, term, CodigoCurso, schoolYear);
            }
            else if (proficiency == "Campo Multiplicativo")
            {
                retorno = await BuscaDadosCM(codigoTurmaEol, proficiency, term, CodigoCurso, schoolYear);
            }

            return retorno;
        }


        public async Task<PollReportMathStudentNumbersResult> BuscarDadosMatematicaPorTurmaNumbersAsync(string proficiency, string term,
                                                                                            string codigoDRE,
                                                                                            string codigoEscola,
                                                                                            string codigoTurmaEol, string CodigoCurso, string schoolYear)
        {
            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollReportMathStudentNumbersResult retorno = new PollReportMathStudentNumbersResult();
            //ajustar para pegar a turma 
            List<PollReportMathStudentNumbersItem> result = new List<PollReportMathStudentNumbersItem>();

            var relatorioGrafico = await BuscaDadosNumeros(codigoTurmaEol, proficiency, term, schoolYear);

            result = relatorioGrafico.Relatorio;
            graficos = relatorioGrafico.Graficos;

            result = result.OrderBy(r => r.StudentName).ToList();

            retorno.Results = result;
            retorno.ChartData = graficos;

            return retorno;
        }

        private async Task<IEnumerable<AlunosNaTurmaDTO>> ObterAlunosEOL(string schoolYear, string codigoTurmaEol, string term)
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
            return (await alunoApi.ObterAlunosAtivosPorTurmaEPeriodo(codigoTurmaEol, periodos.First().DataFim)).OrderBy(a => a.NomeAluno);
        }

        private async Task<PollReportMathStudentResult> BuscaDadosCA(string CodigoTurmaEol, string Proficiency, string Term, string CodigoCurso, string schoolYear)
        {
            PollReportMathStudentResult result = new PollReportMathStudentResult();
            List<PollReportMathStudentItem> relatorio = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollMatematica poll = new PollMatematica(_config);

            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaCA(CodigoTurmaEol,
                                                            Proficiency,
                                                            Term);
            var alunosEol = await ObterAlunosEOL(schoolYear, CodigoTurmaEol, Term);
            var totalAlunosEol = alunosEol.Count();

            foreach (var aluno in alunosEol)
            {
                var sondagem = listaAlunosTurma.Where(s => s.AlunoEolCode == aluno.CodigoAluno.ToString()).FirstOrDefault();
                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();

                relatorio.Add(
                    new PollReportMathStudentItem()
                    {
                        Code = aluno.CodigoAluno.ToString(),
                        StudentName = aluno.NomeAlunoRelatorio,
                        Poll = pollTotal
                    }
                );

                string ano = "";
                for (int ordem = 1; ordem < 5; ordem++)
                {
                    MathStudentItemResult item = new MathStudentItemResult();
                    string ideia = "";
                    string resultado = "";

                    switch (ordem)
                    {
                        case 1:
                            ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem1Ideia) : null;
                            resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem1Resultado) : null;
                            item.Idea = ideia;
                            item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                            item.Result = resultado;
                            pollTotal.Add(item);
                            break;
                        case 2:
                            ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem2Ideia) : null;
                            resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem2Resultado) : null;
                            item.Idea = ideia;
                            item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                            item.Result = resultado;
                            pollTotal.Add(item);
                            break;
                        case 3:
                            if (!CodigoCurso.Equals("2"))
                            {
                                ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem3Ideia) : null;
                                resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem3Resultado) : null;
                                item.Idea = ideia;
                                item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                item.Result = resultado;
                                pollTotal.Add(item);
                            }
                            break;
                        case 4:
                            if (!CodigoCurso.Equals("1") && !CodigoCurso.Equals("2") && !CodigoCurso.Equals("3"))
                            {
                                ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem4Ideia) : null;
                                resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem4Resultado) : null;
                                item.Idea = ideia;
                                item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                item.Result = resultado;
                                pollTotal.Add(item);
                            }
                            break;
                    }

                }

            }

            for (int ordem = 1; ordem < 5; ordem++)
            {
                MathChartDataModel item = new MathChartDataModel();

                switch (ordem)
                {
                    case 1:
                        item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                        item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem1Ideia != null && p.Ordem1Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem1Ideia != null && p.Ordem1Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem1Ideia != null && p.Ordem1Ideia.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem1Ideia != null &&
                                                        (p.Ordem1Ideia.Equals("A") || p.Ordem1Ideia.Equals("NR")||p.Ordem1Ideia.Equals("E"))).Count()};
                        item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem1Resultado != null &&  p.Ordem1Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem1Resultado != null &&  p.Ordem1Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem1Resultado != null &&  p.Ordem1Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem1Resultado != null &&
                                                        (p.Ordem1Resultado.Equals("A") || p.Ordem1Resultado.Equals("NR")||p.Ordem1Resultado.Equals("E"))).Count()};

                        graficos.Add(item);
                        break;
                    case 2:
                        item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                        item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem2Ideia != null &&      p.Ordem2Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem2Ideia != null &&      p.Ordem2Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem2Ideia != null &&      p.Ordem2Ideia.Equals("NR")).Count() ,
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem2Ideia != null &&
                                                        (p.Ordem2Ideia.Equals("A") || p.Ordem2Ideia.Equals("NR")||p.Ordem2Ideia.Equals("E"))).Count()};
                        item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem2Resultado != null &&  p.Ordem2Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem2Resultado != null &&  p.Ordem2Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem2Resultado != null &&  p.Ordem2Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem2Resultado != null &&
                                                        (p.Ordem2Resultado.Equals("A") || p.Ordem2Resultado.Equals("NR")||p.Ordem2Resultado.Equals("E"))).Count()};

                        graficos.Add(item);
                        break;
                    case 3:
                        if (!CodigoCurso.Equals("2"))
                        {
                            item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                            item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&        p.Ordem3Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&        p.Ordem3Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&        p.Ordem3Ideia.Equals("NR")).Count() ,
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&
                                                        (p.Ordem3Ideia.Equals("A") || p.Ordem3Ideia.Equals("NR")||p.Ordem3Ideia.Equals("E"))).Count()};
                            item.Result = new List<int> { listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&  p.Ordem3Resultado.Equals("A")).Count() ,
                                                      listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&   p.Ordem3Resultado.Equals("E")).Count() ,
                                                      listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&   p.Ordem3Resultado.Equals("NR")).Count()  ,
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&
                                                        (p.Ordem3Resultado.Equals("A") || p.Ordem3Resultado.Equals("NR")||p.Ordem3Resultado.Equals("E"))).Count()};

                            graficos.Add(item);
                        }
                        break;
                    case 4:
                        if (!CodigoCurso.Equals("1") && !CodigoCurso.Equals("2") && !CodigoCurso.Equals("3"))
                        {
                            item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                            item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&        p.Ordem4Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&        p.Ordem4Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&        p.Ordem4Ideia.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&
                                                        (p.Ordem4Ideia.Equals("A") || p.Ordem4Ideia.Equals("NR")||p.Ordem4Ideia.Equals("E"))).Count()};
                            item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&   p.Ordem4Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&   p.Ordem4Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&   p.Ordem4Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&
                                                        (p.Ordem4Resultado.Equals("A") || p.Ordem4Resultado.Equals("NR")||p.Ordem4Resultado.Equals("E"))).Count()};

                            graficos.Add(item);
                        }
                        break;
                }

            }
            result.Results = relatorio;
            result.ChartData = graficos;

            return result;
        }

        private async Task<PollReportMathStudentResult> BuscaDadosCM(string CodigoTurmaEol, string Proficiency, string Term, string CodigoCurso, string schoolYear)
        {
            PollReportMathStudentResult result = new PollReportMathStudentResult();
            List<PollReportMathStudentItem> relatorio = new List<PollReportMathStudentItem>();
            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollMatematica poll = new PollMatematica(_config);
            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaCM(CodigoTurmaEol, Proficiency, Term);

            var alunosEol = await ObterAlunosEOL(schoolYear, CodigoTurmaEol, Term);
            var totalAlunosEol = alunosEol.Count();

            foreach (var aluno in alunosEol)
            {
                var sondagem = listaAlunosTurma.Where(s => s.AlunoEolCode == aluno.CodigoAluno.ToString()).FirstOrDefault();
                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();
                if (CodigoCurso.Equals("2"))
                {
                    MathStudentItemResult item = new MathStudentItemResult();
                    string ideia = "";
                    string resultado = "";

                    ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem3Ideia) : null;
                    resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem3Resultado) : null;
                    item.Idea = ideia;
                    item.Order = CadastraLegenda(Proficiency, 3, CodigoCurso, false);
                    item.Result = resultado;
                    pollTotal.Add(item);
                }
                else
                {
                    for (int ordem = 4; ordem < 9; ordem++)
                    {
                        MathStudentItemResult item = new MathStudentItemResult();
                        MathChartDataModel itemGrafico = new MathChartDataModel();

                        string ideia = "";
                        string resultado = "";

                        switch (ordem)
                        {
                            case 4:
                                if (CodigoCurso.Equals("3"))
                                {
                                    ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem4Ideia) : null;
                                    resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem4Resultado) : null;
                                    item.Idea = ideia;
                                    item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                    item.Result = resultado;
                                    pollTotal.Add(item);
                                }
                                break;
                            case 5:
                                ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem5Ideia) : null;
                                resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem5Resultado) : null;
                                item.Idea = ideia;
                                item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                item.Result = resultado;
                                pollTotal.Add(item);
                                break;
                            case 6:
                                if (!CodigoCurso.Equals("3"))
                                {
                                    ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem6Ideia) : null;
                                    resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem6Resultado) : null;
                                    item.Idea = ideia;
                                    item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                    item.Result = resultado;
                                    pollTotal.Add(item);
                                }
                                break;
                            case 7:
                                if (!CodigoCurso.Equals("3"))
                                {
                                    ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem7Ideia) : null;
                                    resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem7Resultado) : null;
                                    item.Idea = ideia;
                                    item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                    item.Result = resultado;
                                    pollTotal.Add(item);
                                }
                                break;
                            case 8:
                                if (!CodigoCurso.Equals("3") && !CodigoCurso.Equals("4"))
                                {
                                    ideia = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem8Ideia) : null;
                                    resultado = sondagem != null ? ConverteTextoPollMatematica(sondagem.Ordem8Resultado) : null;
                                    item.Idea = ideia;
                                    item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                    item.Result = resultado;
                                    pollTotal.Add(item);
                                }
                                break;
                        }
                    }
                }

                relatorio.Add(
                   new PollReportMathStudentItem()
                   {
                       Code = aluno.CodigoAluno.ToString(),
                       StudentName = aluno.NomeAlunoRelatorio,
                       Poll = pollTotal
                   }
               );
            }

            if (CodigoCurso.Equals("2"))
            {
                MathChartDataModel item = new MathChartDataModel();
                item.Name = CadastraLegenda(Proficiency, 3, CodigoCurso, true);
                item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&      p.Ordem3Ideia.Equals("A")).Count(),
                                                listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&      p.Ordem3Ideia.Equals("E")).Count(),
                                                listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&      p.Ordem3Ideia.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&
                                                        (p.Ordem3Ideia.Equals("A") || p.Ordem3Ideia.Equals("NR")||p.Ordem3Ideia.Equals("E"))).Count() };
                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&  p.Ordem3Resultado.Equals("A")).Count() ,
                                                listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&  p.Ordem3Resultado.Equals("E")).Count() ,
                                                listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&  p.Ordem3Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&
                                                        (p.Ordem3Resultado.Equals("A") || p.Ordem3Resultado.Equals("NR")||p.Ordem3Resultado.Equals("E"))).Count()};
                graficos.Add(item);
            }
            else
            {
                for (int ordem = 4; ordem < 11; ordem++)
                {
                    MathChartDataModel item = new MathChartDataModel();

                    switch (ordem)
                    {
                        case 4:
                            if (CodigoCurso.Equals("3"))
                            {
                                item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                                item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&      p.Ordem4Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&      p.Ordem4Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&      p.Ordem4Ideia.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&
                                                        (p.Ordem4Ideia.Equals("A") || p.Ordem4Ideia.Equals("NR")||p.Ordem4Ideia.Equals("E"))).Count() };
                                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&  p.Ordem4Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&  p.Ordem4Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&  p.Ordem4Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&
                                                        (p.Ordem4Resultado.Equals("A") || p.Ordem4Resultado.Equals("NR")||p.Ordem4Resultado.Equals("E"))).Count()};
                                graficos.Add(item);
                            }
                            break;

                        case 5:
                            item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);

                            item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Ordem5Ideia != null &&      p.Ordem5Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem5Ideia != null &&      p.Ordem5Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem5Ideia != null &&      p.Ordem5Ideia.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem5Ideia != null &&
                                                        (p.Ordem5Ideia.Equals("A") || p.Ordem5Ideia.Equals("NR")||p.Ordem5Ideia.Equals("E"))).Count() };
                            item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem5Resultado != null &&  p.Ordem5Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem5Resultado != null &&  p.Ordem5Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem5Resultado != null &&  p.Ordem5Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem5Resultado != null &&
                                                        (p.Ordem5Resultado.Equals("A") || p.Ordem5Resultado.Equals("NR")||p.Ordem5Resultado.Equals("E"))).Count()};
                            graficos.Add(item);
                            break;
                        case 6:
                            if (!CodigoCurso.Equals("3"))
                            {
                                item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                                item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem6Ideia != null &&      p.Ordem6Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem6Ideia != null &&      p.Ordem6Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem6Ideia != null &&      p.Ordem6Ideia.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem6Ideia != null &&
                                                        (p.Ordem6Ideia.Equals("A") || p.Ordem6Ideia.Equals("NR")||p.Ordem6Ideia.Equals("E"))).Count() };
                                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem6Resultado != null &&  p.Ordem6Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem6Resultado != null &&  p.Ordem6Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem6Resultado != null &&  p.Ordem6Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem6Resultado != null &&
                                                        (p.Ordem6Resultado.Equals("A") || p.Ordem6Resultado.Equals("NR")||p.Ordem6Resultado.Equals("E"))).Count()};
                                graficos.Add(item);
                            }
                            break;

                        case 7:

                            if (!CodigoCurso.Equals("3"))
                            {
                                item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                                item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem7Ideia != null &&      p.Ordem7Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem7Ideia != null &&      p.Ordem7Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem7Ideia != null &&      p.Ordem7Ideia.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem7Ideia != null &&
                                                        (p.Ordem7Ideia.Equals("A") || p.Ordem7Ideia.Equals("NR")||p.Ordem7Ideia.Equals("E"))).Count() };
                                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem7Resultado != null &&  p.Ordem7Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem7Resultado != null &&  p.Ordem7Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem7Resultado != null &&  p.Ordem7Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem7Ideia != null &&
                                                        (p.Ordem7Ideia.Equals("A") || p.Ordem7Ideia.Equals("NR")||p.Ordem7Ideia.Equals("E"))).Count()};
                                graficos.Add(item);
                            }
                            break;
                        case 8:

                            if (!CodigoCurso.Equals("3") && !CodigoCurso.Equals("4"))
                            {
                                item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                                item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem8Ideia != null &&      p.Ordem8Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem8Ideia != null &&      p.Ordem8Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem8Ideia != null &&      p.Ordem8Ideia.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem8Ideia != null &&
                                                        (p.Ordem8Ideia.Equals("A") || p.Ordem8Ideia.Equals("NR")||p.Ordem8Ideia.Equals("E"))).Count() };
                                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem8Resultado != null &&  p.Ordem8Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem8Resultado != null &&  p.Ordem8Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem8Resultado != null &&  p.Ordem8Resultado.Equals("NR")).Count(),
                                                        totalAlunosEol - listaAlunosTurma.Where(p => p.Ordem8Resultado != null &&
                                                        (p.Ordem8Resultado.Equals("A") || p.Ordem8Resultado.Equals("NR")||p.Ordem8Resultado.Equals("E"))).Count()};
                                graficos.Add(item);
                            }
                            break;
                    }
                }
            }

            result.Results = relatorio;
            result.ChartData = graficos;

            return result;
        }

        private string CadastraLegenda(string proeficiencia, int ordem, string codigoCurso, bool isGrafico)
        {
            StringBuilder legenda = new StringBuilder();
            if (isGrafico)
            {
                legenda.Append("Ordem");
            }

            if (proeficiencia == "Campo Aditivo")
            {
                switch (ordem)
                {
                    case 1:
                        legenda.AppendFormat(" {0} - COMPOSIÇÃO", ordem);
                        break;
                    case 2:

                        if (codigoCurso == "1")
                        {
                            legenda.AppendFormat(" {0} - COMPOSIÇÃO", ordem);
                        }
                        else
                        {

                            legenda.AppendFormat(" {0} - TRANSFORMAÇÃO", ordem);
                        }
                        break;
                    case 3:
                        if (codigoCurso == "1")
                        {
                            legenda.AppendFormat(" {0} - COMPOSIÇÃO", ordem);
                        }
                        else if (codigoCurso == "3")
                        {
                            legenda.AppendFormat(" {0} - COMPARAÇÃO", ordem);
                        }
                        else
                        {
                            legenda.AppendFormat(" {0} - COMPOSIÇÃO DE TRANSF.", ordem);
                        }
                        break;
                    case 4:
                        legenda.AppendFormat(" {0} - COMPARAÇÃO", ordem);
                        break;
                    default:
                        break;
                }

            }
            else if (proeficiencia == "Campo Multiplicativo")
            {
                switch (ordem)
                {
                    case 3:
                        if (codigoCurso == "2")
                        {
                            legenda.AppendFormat(" {0} - PROPORCIONALIDADE", ordem);
                        }
                        break;
                    case 4:
                        if (codigoCurso == "3")
                        {
                            legenda.AppendFormat(" {0} - CONFIGURAÇÃO RETANGULAR", ordem);
                        }
                        break;
                    case 5:
                        if (codigoCurso == "3")
                        {
                            legenda.AppendFormat(" {0} - PROPORCIONALIDADE", ordem);
                        }
                        else if (codigoCurso == "4")
                        {
                            legenda.AppendFormat(" {0} - CONFIGURAÇÃO RETANGULAR", ordem);
                        }
                        else if (codigoCurso == "5" || codigoCurso == "6")
                        {
                            legenda.AppendFormat(" {0} - COMBINATÓRIA", ordem);
                        }

                        break;
                    case 6:
                        if (codigoCurso == "4")
                        {
                            legenda.AppendFormat(" {0} - PROPORCIONALIDADE", ordem);
                        }
                        else if (codigoCurso == "5" || codigoCurso == "6")
                        {
                            legenda.AppendFormat(" {0} - CONFIGURAÇÃO RETANGULAR", ordem);
                        }
                        break;
                    case 7:
                        if (codigoCurso == "4")
                        {
                            legenda.AppendFormat(" {0} - COMBINATÓRIA", ordem);
                        }
                        else if (codigoCurso == "5" || codigoCurso == "6")
                        {
                            legenda.AppendFormat(" {0} - PROPORCIONALIDADE", ordem);
                        }
                        break;
                    case 8:
                        if (codigoCurso == "5" || codigoCurso == "6")
                        {
                            legenda.AppendFormat(" {0} - MULTIPLICAÇÃO COMPARATIVA", ordem);
                        }
                        break;
                    default:
                        break;
                }

            }

            return legenda.ToString();

        }

        private string ConverteTextoPollMatematica(string texto)
        {
            switch (texto)
            {
                case "A":
                    return "Acertou";
                case "E":
                    return "Errou";
                case "NR":
                    return "Não Resolveu";
                default:
                    return "";
            }
        }
        private string ConverteTextoPollMatematicaNumeros(string texto)
        {
            if (texto.Equals("S"))
            {
                return "Escreve convencionalmente";
            }
            else if (texto.Equals("N"))
            {
                return "Não escreve convencionalmente";
            }

            return "";
        }

        private async Task<RelatorioGraficoNumerosDTO> BuscaDadosNumeros(string codigoTurmaEol, string proficiency, string term, string schoolYear)
        {
            List<PollReportMathStudentNumbersItem> result = new List<PollReportMathStudentNumbersItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollMatematica poll = new PollMatematica(_config);

            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaNumber(codigoTurmaEol, proficiency, term);

            var alunosEol = await ObterAlunosEOL(schoolYear, codigoTurmaEol, term);
            var totalAlunosEol = alunosEol.Count();

            foreach (var aluno in alunosEol)
            {
                var sondagem = listaAlunosTurma.Where(s => s.AlunoEolCode == aluno.CodigoAluno.ToString()).FirstOrDefault();
                List<MathStudentItemNumbersResult> pollTotal = new List<MathStudentItemNumbersResult>();

                MathStudentItemNumbersResult item1 = new MathStudentItemNumbersResult();
                item1.Idea = "Familiares ou Frequentes";
                item1.Result = ConverteTextoPollMatematicaNumeros(sondagem != null ? sondagem.Familiares : "");
                pollTotal.Add(item1);

                MathStudentItemNumbersResult item2 = new MathStudentItemNumbersResult();
                item2.Idea = "Opacos";
                item2.Result = ConverteTextoPollMatematicaNumeros(sondagem != null ? sondagem.Opacos : "");
                pollTotal.Add(item2);

                MathStudentItemNumbersResult item3 = new MathStudentItemNumbersResult();
                item3.Idea = "Transparentes";
                item3.Result = ConverteTextoPollMatematicaNumeros(sondagem != null ? sondagem.Transparentes : "");
                pollTotal.Add(item3);

                MathStudentItemNumbersResult item4 = new MathStudentItemNumbersResult();
                item4.Idea = "Terminam em Zero";
                item4.Result = ConverteTextoPollMatematicaNumeros(sondagem != null ? sondagem.TerminamZero : "");
                pollTotal.Add(item4);

                MathStudentItemNumbersResult item5 = new MathStudentItemNumbersResult();
                item5.Idea = "Algarismos Iguais";
                item5.Result = ConverteTextoPollMatematicaNumeros(sondagem != null ? sondagem.Algarismos : "");
                pollTotal.Add(item5);

                MathStudentItemNumbersResult item6 = new MathStudentItemNumbersResult();
                item6.Idea = "Processos de Generalização";
                item6.Result = ConverteTextoPollMatematicaNumeros(sondagem != null ? sondagem.Processo : "");
                pollTotal.Add(item6);

                MathStudentItemNumbersResult item7 = new MathStudentItemNumbersResult();
                item7.Idea = "Zero Intercalado";
                item7.Result = ConverteTextoPollMatematicaNumeros(sondagem != null ? sondagem.ZeroIntercalados : "");
                pollTotal.Add(item7);

                result.Add(
                    new PollReportMathStudentNumbersItem()
                    {
                        Code = aluno.CodigoAluno.ToString(),
                        StudentName = aluno.NomeAlunoRelatorio,
                        Poll = pollTotal
                    }
                );

            }

            for (int ordem = 1; ordem < 8; ordem++)
            {
                MathChartDataModel item = new MathChartDataModel();

                switch (ordem)
                {
                    case 1:
                        item.Name = "Familiares ou Frequentes";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Familiares != null & p.Familiares.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Familiares != null & p.Familiares.Equals("N")).Count() };
                        item.NoFill = new List<int> { totalAlunosEol - listaAlunosTurma.Where(p => (p.Familiares != null && p.Familiares.Equals("S") || p.Familiares != null & p.Familiares.Equals("N"))).Count() };
                        break;
                    case 2:
                        item.Name = "Opacos";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Opacos != null & p.Opacos.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Opacos != null & p.Opacos.Equals("N")).Count() };
                        item.NoFill = new List<int> { totalAlunosEol - listaAlunosTurma.Where(p => (p.Opacos != null && p.Opacos.Equals("S") || p.Opacos != null & p.Opacos.Equals("N"))).Count() };
                        break;
                    case 3:
                        item.Name = "Transparentes";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Transparentes != null & p.Transparentes.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Transparentes != null & p.Transparentes.Equals("N")).Count() };
                        item.NoFill = new List<int> { totalAlunosEol - listaAlunosTurma.Where(p => (p.Transparentes != null && p.Transparentes.Equals("S") || p.Transparentes != null & p.Transparentes.Equals("N"))).Count() };
                        break;
                    case 4:
                        item.Name = "Terminam em Zero";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.TerminamZero != null & p.TerminamZero.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.TerminamZero != null & p.TerminamZero.Equals("N")).Count() };
                        item.NoFill = new List<int> { totalAlunosEol - listaAlunosTurma.Where(p => (p.TerminamZero != null && p.TerminamZero.Equals("S") || p.TerminamZero != null & p.TerminamZero.Equals("N"))).Count() };
                        break;
                    case 5:
                        item.Name = "Algarismos Iguais";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Algarismos != null & p.Algarismos.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Algarismos != null & p.Algarismos.Equals("N")).Count() };
                        item.NoFill = new List<int> { totalAlunosEol - listaAlunosTurma.Where(p => (p.Algarismos != null && p.Algarismos.Equals("S") || p.Algarismos != null & p.Algarismos.Equals("N"))).Count() };
                        break;
                    case 6:
                        item.Name = "Processo de Generalização";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Processo != null & p.Processo.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Processo != null & p.Processo.Equals("N")).Count() };
                        item.NoFill = new List<int> { totalAlunosEol - listaAlunosTurma.Where(p => (p.Processo != null && p.Processo.Equals("S") || p.Processo != null & p.Processo.Equals("N"))).Count() };
                        break;
                    case 7:
                        item.Name = "Zero Intercalado";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.ZeroIntercalados != null & p.ZeroIntercalados.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.ZeroIntercalados != null & p.ZeroIntercalados.Equals("N")).Count() };
                        item.NoFill = new List<int> { totalAlunosEol - listaAlunosTurma.Where(p => (p.ZeroIntercalados != null && p.ZeroIntercalados.Equals("S") || p.ZeroIntercalados != null & p.ZeroIntercalados.Equals("N"))).Count() };
                        break;
                }
                graficos.Add(item);
            }

            return new RelatorioGraficoNumerosDTO()
            {
                Graficos = graficos,
                Relatorio = result
            };
        }
    }
}
