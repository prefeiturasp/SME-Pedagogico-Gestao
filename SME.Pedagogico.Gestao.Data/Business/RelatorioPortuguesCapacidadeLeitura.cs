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

public class RelatorioPortuguesCapacidadeLeitura
{
    private AlunosAPI alunoAPI;

    public RelatorioPortuguesCapacidadeLeitura()
    {
        alunoAPI = new AlunosAPI(new EndpointsAPI());
    }

    public async Task<List<OrdemDTO>> ObterRelatorioCapacidadeLeitura(RelatorioPortuguesFiltroDto filtro)
    {
        using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
        {
            var query = MontaQueryConsolidadoCapacidadeLeitura(filtro);
            var DatasPeriodo = await BuscaDatasPeriodoFixoAnual(filtro, conexao);
            int totalDeAlunos = await BuscaTotalDeAlunosEOl(filtro, DatasPeriodo);

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

         }); ;

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
                        Quantidade = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas)
                    };

                    pergunta.Total.Porcentagem = (pergunta.Total.Quantidade > 0 ? (pergunta.Total.Quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
                    pergunta.Respostas = new List<RespostaDTO>();

                    var listaPr = x.Where(y => y.PerguntaId == x.Key).ToList();

                    foreach (var item in listaPr)
                    {
                        var resposta = new RespostaDTO();
                        resposta.Nome = item.RespostaDescricao;
                        resposta.quantidade = item.QtdRespostas;
                        resposta.porcentagem = (item.QtdRespostas > 0 ? (item.QtdRespostas * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
                        pergunta.Respostas.Add(resposta);
                    }

                    var respostaSempreenchimento = CriaRespostaSemPreenchimento(totalDeAlunos, pergunta.Total.Quantidade);
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

    private static async Task<int> BuscaTotalDeAlunosEOl(RelatorioPortuguesFiltroDto filtro, IEnumerable<DatasPeriodoFixoAnualDTO> DatasPeriodo)
    {
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
    private static string MontaQueryConsolidadoCapacidadeLeitura(RelatorioPortuguesFiltroDto filtro)
    {
        var queryRelatorio = @"
    select
    o.""Id"" as ""OrdermId"",
    o.""Descricao"" as ""Ordem"",
    p.""Id"" as ""PerguntaId"",
	p.""Descricao"" as ""PerguntaDescricao"",
	r.""Id"" as ""RespostaId"", 
	r.""Descricao"" as ""RespostaDescricao"" ,
	gp.""Ordenacao"",
	count(tabela.""RespostaId"") as ""QtdRespostas""
from
    ""Ordem""  as o 
   inner join ""GrupoOrdem"" gp on 
   gp.""OrdemId"" = o.""Id"" and 
   gp.""GrupoId"" = @GrupoId
   inner join ""OrdemPergunta"" op on
    op.""GrupoId"" = @GrupoId
   inner join ""Pergunta"" p on
	 p.""Id"" = op.""PerguntaId"" 
inner join ""PerguntaResposta"" pr on
	pr.""PerguntaId"" = p.""Id""
inner join ""Resposta"" r on
	r.""Id"" = pr.""RespostaId""
left join (
	select
	    s.""OrdemId"",
		s.""AnoLetivo"",
		s.""AnoTurma"",
		per.""Descricao"",
		c.""Descricao"",
		sa.""NomeAluno"",
		p.""Id"" as ""PerguntaId"",
		p.""Descricao"" as ""PerguntaDescricao"",
		r.""Id"" as ""RespostaId"",
		r.""Descricao"" as ""RespostaDescricao""
	from
		""SondagemAlunoRespostas"" sar
	inner join ""SondagemAluno"" sa on
		sa.""Id"" = ""SondagemAlunoId""
	inner join ""Sondagem"" s on
		s.""Id"" = sa.""SondagemId""
	inner join ""Pergunta"" p on
		p.""Id"" = sar.""PerguntaId""
	inner join ""Resposta"" r on
		r.""Id"" = sar.""RespostaId""
	inner join ""Periodo"" per on
		per.""Id"" = s.""PeriodoId""
	inner join ""ComponenteCurricular"" c on
		c.""Id"" = s.""ComponenteCurricularId""
    
	where
		s.""Id"" in (
		select
			s.""Id""
		from
			""Sondagem"" s
		where
		        s.""GrupoId"" = @GrupoId
		    and s.""ComponenteCurricularId"" = @ComponenteCurricularId";
        var query = new StringBuilder();
        query.Append(queryRelatorio);
        if (!string.IsNullOrEmpty(filtro.CodigoDre))
            query.AppendLine(@" and ""CodigoDre"" =  @CodigoDRE");
        if (!string.IsNullOrEmpty(filtro.CodigoUe))
            query.AppendLine(@"and ""CodigoUe"" =  @CodigoEscola");

        query.Append(@"
			and s.""AnoLetivo"" = @AnoLetivo
			and s.""AnoTurma"" = @AnoTurma
		        ) ) as tabela on
	p.""Id"" = tabela.""PerguntaId"" and
	r.""Id""= tabela.""RespostaId"" and
    o.""Id"" = tabela.""OrdemId""
group by
	o.""Id"",
    o.""Descricao"",
    r.""Id"",
	r.""Descricao"",
	p.""Id"",
	p.""Descricao"",
	gp.""Ordenacao""
order by
   gp.""Ordenacao"",
   o.""Descricao"",
   p.""Descricao"",
   r.""Descricao""");

        return query.ToString();
    }

    private static async Task<IEnumerable<DatasPeriodoFixoAnualDTO>> BuscaDatasPeriodoFixoAnual(RelatorioPortuguesFiltroDto filtro, NpgsqlConnection conexao)
    {
        var queryPeriodoFixoAnual = QueryPeriodoFixoAnual;


        var DatasPeriodo = await conexao.QueryAsync<DatasPeriodoFixoAnualDTO>(queryPeriodoFixoAnual.ToString(),
          new
          {
              PeriodoId = filtro.PeriodoId,
              AnoLetivo = filtro.AnoLetivo,

          });
        return DatasPeriodo;
    }


    private const string QueryPeriodoFixoAnual = @"select
										     ""DataInicio"",
											 ""DataFim""
										      from
										     ""PeriodoFixoAnual""
											  where
											""PeriodoId"" = @PeriodoId
											and ""Ano"" = @AnoLetivo";
}

