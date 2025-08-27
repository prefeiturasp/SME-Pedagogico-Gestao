using System;
using System.Collections.Generic;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using System.Threading.Tasks;
using System.Linq;
using MoreLinq;
using Npgsql;
using Dapper;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio.CapacidadeLeitura;
using SME.Pedagogico.Gestao.Data.Relatorios.Querys;
using SME.Pedagogico.Gestao.Data.Relatorios;
using SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma;
using SME.Pedagogico.Gestao.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.DTO.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Graficos.Portugues;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;

public class RelatorioPortuguesCapacidadeLeitura
{
    private AlunosAPI alunoAPI;
    public RelatorioPortuguesCapacidadeLeitura()
    {
        alunoAPI = new AlunosAPI(new EndpointsAPI());

    }

    public async Task<RelatorioConsolidadoCapacidadeLeituraDTO> ObterRelatorioCapacidadeLeitura(RelatorioPortuguesFiltroDto filtro)
    {
        var filtrosRelatorio = CriaMapFiltroRelatorio(filtro);
        int totalDeAlunos = await ConsultaTotalDeAlunos.BuscaTotalDeAlunosEOl(filtrosRelatorio);
        var query = ConsultasRelatorios.MontaQueryConsolidadoCapacidadeLeitura(filtro);
        var relatorio = new RelatorioConsolidadoCapacidadeLeituraDTO();
        var ListaPerguntaEhRespostasRelatorio = await RetornaListaDehPerguntasEhRespostas(filtro, query);
        var consideraNovaOpcaoResposta_SemPreenchimento = NovaOpcaoRespostaSemPreenchimento.ConsideraOpcaoRespostaSemPreenchimento(filtro.AnoLetivo,filtro.DescricaoPeriodo);

        var relatorioAgrupado = ListaPerguntaEhRespostasRelatorio.GroupBy(p => p.OrdermId).ToList();
        relatorio.RelatorioPorOrdem = RetornaRelatorioPorOrdens(totalDeAlunos, relatorioAgrupado, consideraNovaOpcaoResposta_SemPreenchimento);
        relatorio.Graficos = CriaGraficosConsolidados(relatorio);
        return relatorio;

    }

    private List<GraficoOrdem> CriaGraficosConsolidados(RelatorioConsolidadoCapacidadeLeituraDTO relatorio)
    {
        var listaGraficos = new List<GraficoOrdem>();
        relatorio.RelatorioPorOrdem.ForEach(o =>
        {
            var graficoOrdem = new GraficoOrdem();
            graficoOrdem.Ordem = o.Ordem;
            graficoOrdem.perguntasGrafico = new List<Grafico>();
            o.Perguntas.ForEach(p =>
            {
                var grafico = new Grafico();
                grafico.NomeGrafico = p.Nome;


                p.Respostas.ForEach(r =>
                {
                    var barra = new GraficoBarra();
                    barra.Label = r.Nome;
                    barra.Value = r.quantidade;
                    grafico.Barras.Add(barra);
                });

                graficoOrdem.perguntasGrafico.Add(grafico);
            });
            listaGraficos.Add(graficoOrdem);
        });

        return listaGraficos;
    }

    private static async Task<IEnumerable<OrdemPerguntaRespostaDTO>> RetornaListaDehPerguntasEhRespostas(RelatorioPortuguesFiltroDto filtro, string query)
    {
        using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
        {
            var ListaPerguntaEhRespostasRelatorio = await conexao.QueryAsync<OrdemPerguntaRespostaDTO>(query.ToString(),
         new
         {
             AnoTurma = filtro.AnoEscolar,
             CodigoEscola = filtro.CodigoUe,
             CodigoDRE = filtro.CodigoDre,
             AnoLetivo = filtro.AnoLetivo,
             PeriodoId = filtro.PeriodoId,
             filtro.ComponenteCurricularId,
             GrupoId = filtro.GrupoId

         });
            return ListaPerguntaEhRespostasRelatorio;
        }
    }

    private List<OrdemDTO> RetornaRelatorioPorOrdens(int totalDeAlunos, List<IGrouping<string, OrdemPerguntaRespostaDTO>> relatorioAgrupado, bool consideraNovaOpcaoResposta_SemPreenchimento)
    {
        var ListaOrdens = new List<OrdemDTO>();
        relatorioAgrupado.ForEach(ordemItem =>
        {

            var ordem = new OrdemDTO();
            ordem.Ordem = ordemItem.Where(y => y.OrdermId == ordemItem.Key).First().Ordem;
            ordem.Perguntas = new List<PerguntaDTO>();

            var relatorioAgrupadoPergunta = ordemItem.GroupBy(x => x.PerguntaId);

            relatorioAgrupadoPergunta.ForEach(x =>
            {
                var pergunta = new PerguntaDTO();
                var totalRespostas = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas);

                totalDeAlunos = totalDeAlunos >= totalRespostas ? totalDeAlunos : totalRespostas;

                pergunta.Nome = x.Where(y => y.PerguntaId == x.Key).First().PerguntaDescricao;
                pergunta.Total = new TotalDTO()
                {
                    Quantidade = totalDeAlunos,
                };

                pergunta.Respostas = new List<RespostaDTO>();

                pergunta.Total.Porcentagem = (pergunta.Total.Quantidade > 0 ? (pergunta.Total.Quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");

                var listaPr = x.Where(y => y.PerguntaId == x.Key).ToList();

                foreach (var item in listaPr)
                {
                    var resposta = new RespostaDTO();
                    resposta.Nome = item.RespostaDescricao;
                    resposta.quantidade = item.QtdRespostas;
                    resposta.porcentagem = (item.QtdRespostas > 0 ? (item.QtdRespostas * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
                    pergunta.Respostas.Add(resposta);
                }

                if (!consideraNovaOpcaoResposta_SemPreenchimento)
                {
                    var respostaSemPreenchimento = pergunta.Respostas.Find(resp => resp.Nome == "Sem preenchimento");

                    if (respostaSemPreenchimento == null)
                    {
                        respostaSemPreenchimento = new RespostaDTO();
                        pergunta.Respostas.Add(respostaSemPreenchimento);
                    }

                    CarregarRespostaSemPreenchimento(totalDeAlunos, totalRespostas, respostaSemPreenchimento);
                }

                ordem.Perguntas.Add(pergunta);
            });
            ListaOrdens.Add(ordem);
        });
        return ListaOrdens;
    }

    public async Task<RelatorioCapacidadeLeituraPorTurma> ObterRelatorioCapacidadeLeituraPorTurma(RelatorioPortuguesFiltroDto filtro)
    {
        var consideraNovaOpcaoResposta_SemPreenchimento =  NovaOpcaoRespostaSemPreenchimento.ConsideraOpcaoRespostaSemPreenchimento(filtro.AnoLetivo,filtro.DescricaoPeriodo);;
        var filtrosRelatorio = CriaMapFiltroRelatorio(filtro);
        var periodos = await ConsultaTotalDeAlunos.BuscaDatasPeriodoFixoAnual(filtrosRelatorio);

        if (periodos.Count() == 0)
            throw new Exception("Periodo fixo anual nao encontrado");
        var alunosEol = await alunoAPI.ObterAlunosAtivosPorTurmaEPeriodo(filtro.CodigoTurma, periodos.First().DataFim);
        var queryPorTurma = ConsultasRelatorios.QueryRelatorioPorTurmaPortuguesCapacidadeDeLeitura();
        var listaAlunoRespostas = await RetornaListaRespostasAlunoPorTurma(filtrosRelatorio, queryPorTurma);
        var relatorio = await CriaRelatorioAlunos(filtrosRelatorio, alunosEol, listaAlunoRespostas);

        using (var contexto = new SMEManagementContextData())
        {
            await CriaGraficosRelatorio(relatorio, contexto, consideraNovaOpcaoResposta_SemPreenchimento);
        }
        relatorio.Alunos = relatorio.Alunos.OrderBy(x => x.NomeAluno).ToList();

        return relatorio;

    }
    
    private static async Task CriaGraficosRelatorio(RelatorioCapacidadeLeituraPorTurma relatorio, SMEManagementContextData contexto, bool consideraNovaOpcaoResposta_SemPreenchimento)
    {
        var perguntasBanco = await contexto.PerguntaResposta.Include(x => x.Pergunta).Include(y => y.Resposta).Where(pr => relatorio.Perguntas.Any(p => p.Id == pr.Pergunta.Id)).ToListAsync();
        relatorio.Graficos = new List<GraficoOrdem>();
        relatorio.Ordens.ForEach(o =>
        {
            var graficoOrdem = new GraficoOrdem();
            graficoOrdem.Ordem = o.Nome;
            graficoOrdem.perguntasGrafico = new List<Grafico>();
            relatorio.Perguntas.ForEach(p =>
            {
                var grafico = new Grafico();
                grafico.NomeGrafico = p.Nome;

                var listaRespostas = perguntasBanco.Where(x => x.Pergunta.Id == p.Id);

                listaRespostas.ForEach(r =>
                {
                    var barra = new GraficoBarra();
                    barra.Label = r.Resposta.Descricao;
                    barra.Value = relatorio.Alunos.Count(x => x.Ordens.Any(ordem => ordem.Id == o.Id && ordem.Perguntas.Any(pr => pr.Id == p.Id && pr.Valor == r.Resposta.Descricao)));
                    grafico.Barras.Add(barra);
                });
                if (!consideraNovaOpcaoResposta_SemPreenchimento) 
                {
                    var barraAlunosSemPreenchimento = new GraficoBarra();
                    barraAlunosSemPreenchimento.Label = "Sem Preenchimento";
                    barraAlunosSemPreenchimento.Value = relatorio.Alunos.Count() - grafico.Barras.Sum(x => x.Value);
                    grafico.Barras.Add(barraAlunosSemPreenchimento);
                }
                graficoOrdem.perguntasGrafico.Add(grafico);
            });
            relatorio.Graficos.Add(graficoOrdem);
        });
    }

    private async Task<RelatorioCapacidadeLeituraPorTurma> CriaRelatorioAlunos(filtrosRelatorioDTO filtrosRelatorio, IEnumerable<AlunosNaTurmaDTO> alunosEol, IEnumerable<AlunoPerguntaRespostaDTO> listaAlunoRespostas)
    {
        var relatorio = new RelatorioCapacidadeLeituraPorTurma();
        await IncluiOrdensEPerguntasNoRelatorio(filtrosRelatorio, relatorio);

        var alunosAgrupados = listaAlunoRespostas.GroupBy(x => x.CodigoAluno);
        relatorio.Alunos = new List<AlunoPorTurmaCapacidadeLeituraDTO>();
        alunosEol.ForEach(alunoRetorno =>
        {
            var aluno = new AlunoPorTurmaCapacidadeLeituraDTO();
            aluno.CodigoAluno = alunoRetorno.CodigoAluno;
            aluno.NomeAluno = alunoRetorno.NomeAlunoRelatorio;
            aluno.Ordens = new List<OrdemPorAlunoCapacidadeLeituraDTO>();
            var alunoRespostas = alunosAgrupados.Where(x => x.Key == aluno.CodigoAluno.ToString()).ToList();
            relatorio.Ordens.ForEach(o =>
            {
                var ordemDto = new OrdemPorAlunoCapacidadeLeituraDTO()
                {
                    Id = o.Id,
                    Nome = o.Nome,
                    Perguntas = new List<PerguntaRespostaPorAluno>()
                };

                ordemDto.Perguntas = relatorio.Perguntas.Select(p => new PerguntaRespostaPorAluno
                {
                    Id = p.Id,
                    Valor = RetornaRespostaAluno(listaAlunoRespostas, p.Id, o.Id, alunoRetorno.CodigoAluno.ToString())
                }).ToList();
                aluno.Ordens.Add(ordemDto);
            });
            relatorio.Alunos.Add(aluno);
        });
        return relatorio;
    }

    private static string RetornaRespostaAluno(IEnumerable<AlunoPerguntaRespostaDTO> listaAlunoRespostas, string PerguntaId, string OrdemId, string CodigoAluno)
    {
        var alunoResposta = listaAlunoRespostas.Where(x => x.PerguntaId == PerguntaId && OrdemId == x.OrdemId && x.CodigoAluno == CodigoAluno.ToString()).FirstOrDefault();
        if (alunoResposta != null)
            return alunoResposta.RespostaDescricao;
        return string.Empty;
    }

    private static async Task<IEnumerable<AlunoPerguntaRespostaDTO>> RetornaListaRespostasAlunoPorTurma(filtrosRelatorioDTO filtro, string QueryAlunosRespostas)
    {
        using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
        {
            var listaAlunoRespostas = await conexao.QueryAsync<AlunoPerguntaRespostaDTO>(QueryAlunosRespostas.ToString(),
            new
            {
                GrupoId = filtro.GrupoId,
                CodigoTurmaEol = filtro.CodigoTurmaEol,
                AnoLetivo = filtro.AnoLetivo,
                PeriodoId = filtro.PeriodoId,
                ComponenteCurricularId = filtro.ComponenteCurricularId

            });

            return listaAlunoRespostas;

        }
    }


    private async Task IncluiOrdensEPerguntasNoRelatorio(filtrosRelatorioDTO filtro, RelatorioCapacidadeLeituraPorTurma relatorio)
    {
        using (var contexto = new SMEManagementContextData())
        {
            var listaOrdemPergunta = await contexto.OrdemPergunta.Include(x => x.Pergunta).Where(y => y.GrupoId == filtro.GrupoId).OrderBy(x => x.OrdenacaoNaTela).ToListAsync();

            relatorio.Perguntas = listaOrdemPergunta.Select(x => new PerguntasRelatorioDTO
            {
                Id = x.PerguntaId,
                Nome = x.Pergunta.Descricao
            }).ToList();

            var grupos = await contexto.Grupo.Include(x => x.Ordem).Where(x => x.Id == filtro.GrupoId).FirstOrDefaultAsync();
            relatorio.Ordens = grupos.Ordem.OrderBy(x => x.Ordenacao).Select(x => new OrdemRelatorioPorTurmaDTO
            {
                Id = x.Id,
                Nome = x.Descricao
            }).ToList();
        }
    }

    private void  CarregarRespostaSemPreenchimento(int totalDeAlunos, int quantidadeTotalRespostasPergunta, RespostaDTO respostaSemPreenchimento)
    {
        respostaSemPreenchimento.Nome = "Sem preenchimento";
        respostaSemPreenchimento.quantidade = totalDeAlunos - quantidadeTotalRespostasPergunta;
        respostaSemPreenchimento.porcentagem = (respostaSemPreenchimento.quantidade > 0 ? (respostaSemPreenchimento.quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
        respostaSemPreenchimento.porcentagem = respostaSemPreenchimento.porcentagem;
    }

    private filtrosRelatorioDTO CriaMapFiltroRelatorio(RelatorioPortuguesFiltroDto filtro)
    {
        var filtroRelatorio = new filtrosRelatorioDTO()
        {
            AnoEscolar = filtro.AnoEscolar,
            AnoLetivo = filtro.AnoLetivo,
            CodigoDre = filtro.CodigoDre,
            CodigoUe = filtro.CodigoUe,
            ComponenteCurricularId = filtro.ComponenteCurricularId,
            PeriodoId = filtro.PeriodoId,
            GrupoId = filtro.GrupoId,
            CodigoTurmaEol = filtro.CodigoTurma

        };

        return filtroRelatorio;
    }
}

