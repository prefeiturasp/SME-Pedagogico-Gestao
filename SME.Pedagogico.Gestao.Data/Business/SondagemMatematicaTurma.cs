using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Functionalities;
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


        public PollReportMathStudentResult BuscarDadosMatematicaPorTurmaAsync(string proficiency, string term,
                                                                                            string codigoDRE,
                                                                                            string codigoEscola,
                                                                                            string codigoTurmaEol, string CodigoCurso)
        {
            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollReportMathStudentResult retorno = new PollReportMathStudentResult();
            //ajustar para pegar a turma 
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            if (proficiency == "Campo Aditivo")
            {
                result = BuscaDadosCA(codigoTurmaEol, proficiency, term, codigoEscola, CodigoCurso);
                graficos = BuscaGraficoCA(codigoTurmaEol, proficiency, term, CodigoCurso);
            }
            else if (proficiency == "Campo Multiplicativo")
            {
                result = BuscaDadosCM(codigoTurmaEol, proficiency, term, CodigoCurso);
                graficos = BuscaGraficoCM(codigoTurmaEol, proficiency, term, CodigoCurso);
            } 

            result = result.OrderBy(r => r.StudentName).ToList();

            retorno.Results = result;
            retorno.ChartData = graficos;

            return retorno;
        }


        public PollReportMathStudentNumbersResult BuscarDadosMatematicaPorTurmaNumbersAsync(string proficiency, string term,
                                                                                            string codigoDRE,
                                                                                            string codigoEscola,
                                                                                            string codigoTurmaEol, string CodigoCurso)
        {
            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollReportMathStudentNumbersResult retorno = new PollReportMathStudentNumbersResult();
            //ajustar para pegar a turma 
            List<PollReportMathStudentNumbersItem> result = new List<PollReportMathStudentNumbersItem>();

            result = BuscaDadosNumeros(codigoTurmaEol, proficiency, term);
            graficos = BuscaGraficoNumeros(codigoTurmaEol, proficiency, term);

            result = result.OrderBy(r => r.StudentName).ToList();

            retorno.Results = result;
            retorno.ChartData = graficos;

            return retorno;
        }



        private List<PollReportMathStudentItem> BuscaDadosCA(string CodigoTurmaEol, string Proficiency, string Term, string codigoEscola, string CodigoCurso)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            PollMatematica poll = new PollMatematica(_config);

            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaCA(CodigoTurmaEol,
                                                            Proficiency,
                                                            Term);

            foreach (var sondagem in listaAlunosTurma)
            {
                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();

                result.Add(
                    new PollReportMathStudentItem()
                    {
                        Code = sondagem.AlunoEolCode,
                        StudentName = sondagem.AlunoNome,
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
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem1Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem1Resultado);
                            item.Idea = ideia;
                            item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                            item.Result = resultado;
                            pollTotal.Add(item);
                            break;
                        case 2:
                            ideia = ConverteTextoPollMatematica(sondagem.Ordem2Ideia);
                            resultado = ConverteTextoPollMatematica(sondagem.Ordem2Resultado);
                            item.Idea = ideia;
                            item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                            item.Result = resultado;
                            pollTotal.Add(item);
                            break;
                        case 3:
                            if (!CodigoCurso.Equals("2"))
                            {
                                ideia = ConverteTextoPollMatematica(sondagem.Ordem3Ideia);
                                resultado = ConverteTextoPollMatematica(sondagem.Ordem3Resultado);
                                item.Idea = ideia;
                                item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                item.Result = resultado;
                                pollTotal.Add(item);
                            }
                            break;
                        case 4:
                            if (!CodigoCurso.Equals("1") && !CodigoCurso.Equals("2") && !CodigoCurso.Equals("3"))
                            {
                                ideia = ConverteTextoPollMatematica(sondagem.Ordem4Ideia);
                                resultado = ConverteTextoPollMatematica(sondagem.Ordem4Resultado);
                                item.Idea = ideia;
                                item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                item.Result = resultado;
                                pollTotal.Add(item);
                            }
                            break;
                    }

                }

            }

            return result;
        }

        private List<PollReportMathStudentItem> BuscaDadosCM(string CodigoTurmaEol, string Proficiency, string Term, string CodigoCurso)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            PollMatematica poll = new PollMatematica(_config);
            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaCM(CodigoTurmaEol, Proficiency, Term);

            foreach (var sondagem in listaAlunosTurma)
            {
                List<MathStudentItemResult> pollTotal = new List<MathStudentItemResult>();
                if (CodigoCurso.Equals("2"))
                {
                    MathStudentItemResult item = new MathStudentItemResult();
                    string ideia = "";
                    string resultado = "";

                    ideia = ConverteTextoPollMatematica(sondagem.Ordem3Ideia);
                    resultado = ConverteTextoPollMatematica(sondagem.Ordem3Resultado);
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
                        string ideia = "";
                        string resultado = "";

                        switch (ordem)
                        {
                            case 4:
                                if (CodigoCurso.Equals("3"))
                                {
                                    ideia = ConverteTextoPollMatematica(sondagem.Ordem4Ideia);
                                    resultado = ConverteTextoPollMatematica(sondagem.Ordem4Resultado);
                                    item.Idea = ideia;
                                    item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                    item.Result = resultado;
                                    pollTotal.Add(item);
                                }
                                break;
                            case 5:
                                ideia = ConverteTextoPollMatematica(sondagem.Ordem5Ideia);
                                resultado = ConverteTextoPollMatematica(sondagem.Ordem5Resultado);
                                item.Idea = ideia;
                                item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                item.Result = resultado;
                                pollTotal.Add(item);
                                break;
                            case 6:
                                if (!CodigoCurso.Equals("3"))
                                {
                                    ideia = ConverteTextoPollMatematica(sondagem.Ordem6Ideia);
                                    resultado = ConverteTextoPollMatematica(sondagem.Ordem6Resultado);
                                    item.Idea = ideia;
                                    item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                    item.Result = resultado;
                                    pollTotal.Add(item);
                                }
                                break;
                            case 7:
                                if (!CodigoCurso.Equals("3"))
                                {
                                    ideia = ConverteTextoPollMatematica(sondagem.Ordem7Ideia);
                                    resultado = ConverteTextoPollMatematica(sondagem.Ordem7Resultado);
                                    item.Idea = ideia;
                                    item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                    item.Result = resultado;
                                    pollTotal.Add(item);
                                }
                                break;
                            case 8:
                                if (!CodigoCurso.Equals("3") && !CodigoCurso.Equals("4"))
                                {
                                    ideia = ConverteTextoPollMatematica(sondagem.Ordem8Ideia);
                                    resultado = ConverteTextoPollMatematica(sondagem.Ordem8Resultado);
                                    item.Idea = ideia;
                                    item.Order = CadastraLegenda(Proficiency, ordem, CodigoCurso, false);
                                    item.Result = resultado;
                                    pollTotal.Add(item);
                                }
                                break;
                        }
                    }
                }

                result.Add(
                   new PollReportMathStudentItem()
                   {
                       Code = sondagem.AlunoEolCode,
                       StudentName = sondagem.AlunoNome,
                       Poll = pollTotal
                   }
               );
            }
            return result;
        }


        private List<MathChartDataModel> BuscaGraficoCA(string CodigoTurmaEol, string Proficiency, string Term, string CodigoCurso)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();


            PollMatematica poll = new PollMatematica(_config);

            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaCA(CodigoTurmaEol, Proficiency, Term);

            for (int ordem = 1; ordem < 5; ordem++)
            {
                MathChartDataModel item = new MathChartDataModel();

                switch (ordem)
                {
                    case 1:
                        item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                        item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem1Ideia != null &&      p.Ordem1Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem1Ideia != null &&     p.Ordem1Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem1Ideia != null &&      p.Ordem1Ideia.Equals("NR")).Count() };
                        item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem1Resultado != null &&  p.Ordem1Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem1Resultado != null &&  p.Ordem1Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem1Resultado != null &&  p.Ordem1Resultado.Equals("NR")).Count()};

                        graficos.Add(item);
                        break;
                    case 2:
                        item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                        item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem2Ideia != null &&      p.Ordem2Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem2Ideia != null &&      p.Ordem2Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem2Ideia != null &&      p.Ordem2Ideia.Equals("NR")).Count() };
                        item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem2Resultado != null &&  p.Ordem2Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem2Resultado != null &&  p.Ordem2Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem2Resultado != null &&  p.Ordem2Resultado.Equals("NR")).Count()};

                        graficos.Add(item);
                        break;
                    case 3:
                        if (!CodigoCurso.Equals("2"))
                        {
                            item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                            item.Idea = new List<int> {  listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&        p.Ordem3Ideia.Equals("A")).Count(),
                                                     listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&        p.Ordem3Ideia.Equals("E")).Count(),
                                                     listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&        p.Ordem3Ideia.Equals("NR")).Count() };
                            item.Result = new List<int> { listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&  p.Ordem3Resultado.Equals("A")).Count() ,
                                                      listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&   p.Ordem3Resultado.Equals("E")).Count() ,
                                                      listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&   p.Ordem3Resultado.Equals("NR")).Count()  };

                            graficos.Add(item);
                        }
                        break;
                    case 4:
                        if (!CodigoCurso.Equals("1") && !CodigoCurso.Equals("2") && !CodigoCurso.Equals("3"))
                        {
                            item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                            item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&        p.Ordem4Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&        p.Ordem4Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&        p.Ordem4Ideia.Equals("NR")).Count() };
                            item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&   p.Ordem4Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&   p.Ordem4Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&   p.Ordem4Resultado.Equals("NR")).Count()};

                            graficos.Add(item);
                        }
                        break;
                }

            }
            return graficos;
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

        private List<MathChartDataModel> BuscaGraficoCM(string CodigoTurmaEol, string Proficiency, string Term, string CodigoCurso)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();


            PollMatematica poll = new PollMatematica(_config);

            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaCM(CodigoTurmaEol, Proficiency, Term);

            if (CodigoCurso.Equals("2"))
            {
                MathChartDataModel item = new MathChartDataModel();
                item.Name = CadastraLegenda(Proficiency, 3, CodigoCurso, true);
                item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&      p.Ordem3Ideia.Equals("A")).Count(),
                                                listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&      p.Ordem3Ideia.Equals("E")).Count(),
                                                listaAlunosTurma.Where(p => p.Ordem3Ideia != null &&      p.Ordem3Ideia.Equals("NR")).Count() };
                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&  p.Ordem3Resultado.Equals("A")).Count() ,
                                                listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&  p.Ordem3Resultado.Equals("E")).Count() ,
                                                listaAlunosTurma.Where(p => p.Ordem3Resultado != null &&  p.Ordem3Resultado.Equals("NR")).Count()};
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
                                                        listaAlunosTurma.Where(p => p.Ordem4Ideia != null &&      p.Ordem4Ideia.Equals("NR")).Count() };
                                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&  p.Ordem4Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&  p.Ordem4Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem4Resultado != null &&  p.Ordem4Resultado.Equals("NR")).Count()};
                                graficos.Add(item);
                            }
                            break;

                        case 5:
                            item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);

                            item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Ordem5Ideia != null &&      p.Ordem5Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem5Ideia != null &&      p.Ordem5Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem5Ideia != null &&      p.Ordem5Ideia.Equals("NR")).Count() };
                            item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem5Resultado != null &&  p.Ordem5Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem5Resultado != null &&  p.Ordem5Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem5Resultado != null &&  p.Ordem5Resultado.Equals("NR")).Count()};
                            graficos.Add(item);
                            break;
                        case 6:
                            if (!CodigoCurso.Equals("3"))
                            {
                                item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                                item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem6Ideia != null &&      p.Ordem6Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem6Ideia != null &&      p.Ordem6Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem6Ideia != null &&      p.Ordem6Ideia.Equals("NR")).Count() };
                                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem6Resultado != null &&  p.Ordem6Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem6Resultado != null &&  p.Ordem6Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem6Resultado != null &&  p.Ordem6Resultado.Equals("NR")).Count()};
                                graficos.Add(item);
                            }
                            break;

                        case 7:

                            if (!CodigoCurso.Equals("3"))
                            {
                                item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                                item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem7Ideia != null &&      p.Ordem7Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem7Ideia != null &&      p.Ordem7Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem7Ideia != null &&      p.Ordem7Ideia.Equals("NR")).Count() };
                                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem7Resultado != null &&  p.Ordem7Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem7Resultado != null &&  p.Ordem7Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem7Resultado != null &&  p.Ordem7Resultado.Equals("NR")).Count()};
                                graficos.Add(item);
                            }
                            break;
                        case 8:

                            if (!CodigoCurso.Equals("3") && !CodigoCurso.Equals("4"))
                            {
                                item.Name = CadastraLegenda(Proficiency, ordem, CodigoCurso, true);
                                item.Idea = new List<int> {     listaAlunosTurma.Where(p => p.Ordem8Ideia != null &&      p.Ordem8Ideia.Equals("A")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem8Ideia != null &&      p.Ordem8Ideia.Equals("E")).Count(),
                                                        listaAlunosTurma.Where(p => p.Ordem8Ideia != null &&      p.Ordem8Ideia.Equals("NR")).Count() };
                                item.Result = new List<int> {   listaAlunosTurma.Where(p => p.Ordem8Resultado != null &&  p.Ordem8Resultado.Equals("A")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem8Resultado != null &&  p.Ordem8Resultado.Equals("E")).Count() ,
                                                        listaAlunosTurma.Where(p => p.Ordem8Resultado != null &&  p.Ordem8Resultado.Equals("NR")).Count()};
                                graficos.Add(item);
                            }
                            break;
                    }
                }
            }
            return graficos;
        }

        private List<MathChartDataModel> BuscaGraficoNumeros(string codigoTurmaEol, string proficiency, string term)
        {
            List<PollReportMathStudentItem> result = new List<PollReportMathStudentItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollMatematica poll = new PollMatematica(_config);

            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaNumber(codigoTurmaEol,
                                                            proficiency,
                                                            term);

            for (int ordem = 1; ordem < 8; ordem++)
            {
                MathChartDataModel item = new MathChartDataModel();

                switch (ordem)
                {
                    case 1:
                        item.Name = "Familiares ou Frequentes";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Familiares != null & p.Familiares.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Familiares != null & p.Familiares.Equals("N")).Count() };
                        break;
                    case 2:
                        item.Name = "Opacos";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Opacos != null & p.Opacos.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Opacos != null & p.Opacos.Equals("N")).Count() };
                        break;
                    case 3:
                        item.Name = "Transparentes";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Transparentes != null & p.Transparentes.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Transparentes != null & p.Transparentes.Equals("N")).Count() };
                        break;
                    case 4:
                        item.Name = "Terminam em Zero";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.TerminamZero != null & p.TerminamZero.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.TerminamZero != null & p.TerminamZero.Equals("N")).Count() };
                        break;
                    case 5:
                        item.Name = "Algarismos Iguais";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Algarismos != null & p.Algarismos.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Algarismos != null & p.Algarismos.Equals("N")).Count() };
                        break;
                    case 6:
                        item.Name = "Processo de Generalização";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.Processo != null & p.Processo.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.Processo != null & p.Processo.Equals("N")).Count() };
                        break;
                    case 7:
                        item.Name = "Zeros Intercalados";
                        item.Idea = new List<int> { listaAlunosTurma.Where(p => p.ZeroIntercalados != null & p.ZeroIntercalados.Equals("S")).Count() };
                        item.Result = new List<int> { listaAlunosTurma.Where(p => p.ZeroIntercalados != null & p.ZeroIntercalados.Equals("N")).Count() };
                        break;
                }
                graficos.Add(item);
            }
            return graficos;
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
        private string ConverteTextoPollMatematica(string texto, bool tipoNumero)
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
        private List<PollReportMathStudentNumbersItem> BuscaDadosNumeros(string codigoTurmaEol, string proficiency, string term)
        {
            List<PollReportMathStudentNumbersItem> result = new List<PollReportMathStudentNumbersItem>();

            List<MathChartDataModel> graficos = new List<MathChartDataModel>();

            PollMatematica poll = new PollMatematica(_config);

            var listaAlunosTurma = poll.BuscarAlunosTurmaRelatorioMatematicaNumber(codigoTurmaEol, proficiency, term);

            foreach (var sondagem in listaAlunosTurma)
            {
                List<MathStudentItemNumbersResult> pollTotal = new List<MathStudentItemNumbersResult>();

                MathStudentItemNumbersResult item1 = new MathStudentItemNumbersResult();
                item1.Idea = "Familiares ou Frequentes";
                item1.Result = ConverteTextoPollMatematica(sondagem.Familiares, true);
                pollTotal.Add(item1);

                MathStudentItemNumbersResult item2 = new MathStudentItemNumbersResult();
                item2.Idea = "Opacos";
                item2.Result = ConverteTextoPollMatematica(sondagem.Opacos, true);
                pollTotal.Add(item2);

                MathStudentItemNumbersResult item3 = new MathStudentItemNumbersResult();
                item3.Idea = "Transparentes";
                item3.Result = ConverteTextoPollMatematica(sondagem.Transparentes, true);
                pollTotal.Add(item3);

                MathStudentItemNumbersResult item4 = new MathStudentItemNumbersResult();
                item4.Idea = "Terminam em Zero";
                item4.Result = ConverteTextoPollMatematica(sondagem.TerminamZero, true);
                pollTotal.Add(item4);

                MathStudentItemNumbersResult item5 = new MathStudentItemNumbersResult();
                item5.Idea = "Algarismos Iguais";
                item5.Result = ConverteTextoPollMatematica(sondagem.Algarismos, true);
                pollTotal.Add(item5);

                MathStudentItemNumbersResult item6 = new MathStudentItemNumbersResult();
                item6.Idea = "Processos de Generalização";
                item6.Result = ConverteTextoPollMatematica(sondagem.Processo, true);
                pollTotal.Add(item6);

                MathStudentItemNumbersResult item7 = new MathStudentItemNumbersResult();
                item7.Idea = "Zeros Intercalados";
                item7.Result = ConverteTextoPollMatematica(sondagem.ZeroIntercalados, true);
                pollTotal.Add(item7);

                result.Add(
                    new PollReportMathStudentNumbersItem()
                    {
                        Code = sondagem.AlunoEolCode,
                        StudentName = sondagem.AlunoNome,
                        Poll = pollTotal
                    }
                );

            }

            return result;
        }
    }
}
