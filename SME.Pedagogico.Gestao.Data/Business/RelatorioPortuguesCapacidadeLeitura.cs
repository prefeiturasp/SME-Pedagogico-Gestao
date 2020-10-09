using System;
using System.Collections.Generic;
using System.Text;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using System.Threading.Tasks;
using System.Linq;
using MoreLinq;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using Npgsql;
using Dapper;
using SME.Pedagogico.Gestao.Data.DTO.Portugues.Relatorio.CapacidadeLeitura;
using SME.Pedagogico.Gestao.Data.Business;
using SME.Pedagogico.Gestao.Data.Relatorios.Querys;
using SME.Pedagogico.Gestao.Data.Relatorios;

public class RelatorioPortuguesCapacidadeLeitura
{
    private AlunosAPI alunoAPI;

    public RelatorioPortuguesCapacidadeLeitura()
    {
        alunoAPI = new AlunosAPI(new EndpointsAPI());

    }

    

    public async Task<List<OrdemDTO>> ObterRelatorioCapacidadeLeitura(RelatorioPortuguesFiltroDto filtro)
    {

        var filtrosRelatorio = CriaMapFiltroRelatorio(filtro);
        int totalDeAlunos = await ConsultaTotalDeAlunos.BuscaTotalDeAlunosEOl(filtrosRelatorio);
        var query = ConsultasRelatorios.MontaQueryConsolidadoCapacidadeLeitura(filtro);
       
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
             ComponenteCurricularId = filtro.ComponenteCurricularId,
             GrupoId = filtro.GrupoId

         });

            var relatorioAgrupado = ListaPerguntaEhRespostasRelatorio.GroupBy(p => p.OrdermId).ToList();

            var ListaOrdens = new List<OrdemDTO>();
            relatorioAgrupado.ForEach(ordemItem =>
            {

                var ordem = new OrdemDTO();
                ordem.Ordem = ordemItem.Where(y => y.OrdermId == ordemItem.Key).First().Ordem;
                ordem.Pergunta = new List<PerguntaDTO>();

                var relatorioAgrupadoPergunta = ordemItem.GroupBy(x => x.PerguntaId);

                relatorioAgrupadoPergunta.ForEach(x =>
                {
                    var pergunta = new PerguntaDTO();
                    pergunta.Nome = x.Where(y => y.PerguntaId == x.Key).First().PerguntaDescricao;
                    pergunta.Total = new TotalDTO()
                    {
                        Quantidade = totalDeAlunos,
                        
                    };

                    pergunta.Total.Porcentagem = (pergunta.Total.Quantidade > 0 ? (pergunta.Total.Quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
                    pergunta.Respostas = new List<RespostaDTO>();
                    var totalRespostas = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas);
                    var listaPr = x.Where(y => y.PerguntaId == x.Key).ToList();

                    foreach (var item in listaPr)
                    {
                        var resposta = new RespostaDTO();
                        resposta.Nome = item.RespostaDescricao;
                        resposta.quantidade = item.QtdRespostas;
                        resposta.porcentagem = (item.QtdRespostas > 0 ? (item.QtdRespostas * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
                        pergunta.Respostas.Add(resposta);
                    }


                    var respostaSempreenchimento = CriaRespostaSemPreenchimento(totalDeAlunos, totalRespostas);
                    pergunta.Respostas.Add(respostaSempreenchimento);



                    ordem.Pergunta.Add(pergunta);
                });
                ListaOrdens.Add(ordem);
            });
            return ListaOrdens;
        }
    }
    private RespostaDTO CriaRespostaSemPreenchimento(int totalDeAlunos, int quantidadeTotalRespostasPergunta)
    {
        var respostaSemPreenchimento = new RespostaDTO();
        respostaSemPreenchimento.Nome = "Sem preenchimento";
        respostaSemPreenchimento.quantidade = totalDeAlunos - quantidadeTotalRespostasPergunta;
        respostaSemPreenchimento.porcentagem = (respostaSemPreenchimento.quantidade > 0 ? (respostaSemPreenchimento.quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
        respostaSemPreenchimento.porcentagem = respostaSemPreenchimento.porcentagem;
        return respostaSemPreenchimento;
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
            PeriodoId = filtro.PeriodoId

        };

        return filtroRelatorio;
    }
}

