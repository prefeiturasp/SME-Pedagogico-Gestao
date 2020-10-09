using System;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using System.Text;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.Integracao.DTO;
using System.Threading.Tasks;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.Relatorios;
using SME.Pedagogico.Gestao.Data.Relatorios.Querys;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioMatematicaAutoral
    {
      

        public async Task<List<PerguntaDTO>> ObterRelatorioMatematicaAutoral(filtrosRelatorioDTO filtro)
        {

               IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtro);
            int totalDeAlunos = await ConsultaTotalDeAlunos.BuscaTotalDeAlunosEOl(filtro);
            var query = ConsultasRelatorios.QueryRelatorioMatematicaAutoral(filtro);


         
            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                return await RetornaRelatorioMatematica(filtro, conexao, query, totalDeAlunos);
            }

        }

        private  async Task<List<PerguntaDTO>> RetornaRelatorioMatematica(filtrosRelatorioDTO filtro, NpgsqlConnection conexao, string query, int totalDeAlunos)
        {
            var ListaPerguntaEhRespostasRelatorio = await conexao.QueryAsync<PerguntasRespostasDTO>(query.ToString(),
                new
                {
                    AnoDaTurma = filtro.AnoEscolar,
                    CodigoEscola = filtro.CodigoUe,
                    CodigoDRE = filtro.CodigoDre,
                    AnoLetivo = filtro.AnoLetivo,
                    PeriodoId = filtro.PeriodoId,
                    ComponenteCurricularId = filtro.ComponenteCurricularId

                });

            var relatorioAgrupado = ListaPerguntaEhRespostasRelatorio.GroupBy(p => p.PerguntaId).ToList();

            var lista = new List<PerguntaDTO>();

            relatorioAgrupado.ForEach(x =>
            {
                var pergunta = new PerguntaDTO();
                CalculaPercentualTotalPergunta(totalDeAlunos, x, pergunta);

                var listaPr = x.Where(y => y.PerguntaId == x.Key).ToList();
                var totalRespostas = x.Where(y => y.PerguntaId == x.Key).Sum(q => q.QtdRespostas);
                CalculaPercentualRespostas(totalDeAlunos, pergunta, listaPr, totalRespostas);
                lista.Add(pergunta);
            });


            return lista;
        }

        private static void CalculaPercentualTotalPergunta(int totalDeAlunos, IGrouping<string, PerguntasRespostasDTO> x, PerguntaDTO pergunta)
        {
            pergunta.Nome = x.Where(y => y.PerguntaId == x.Key).First().PerguntaDescricao;
            pergunta.Total = new TotalDTO()
            {
                Quantidade = totalDeAlunos
            };
           
            pergunta.Total.Porcentagem = (pergunta.Total.Quantidade > 0 ? (pergunta.Total.Quantidade * 100) / (Double)totalDeAlunos : 0).ToString("0.00");
            pergunta.Respostas = new List<RespostaDTO>();
        }

        private void CalculaPercentualRespostas(int totalDeAlunos, PerguntaDTO pergunta, List<PerguntasRespostasDTO> listaPr, int totalRespostas)
        {
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

        private static void IncluiIdDoComponenteCurricularEhDoPeriodoNoFiltro(filtrosRelatorioDTO filtro)
        {
            using (var contexto = new SMEManagementContextData())
            {

                var componenteCurricular = contexto.ComponenteCurricular.Where(x => x.Descricao == filtro.DescricaoDisciplina).FirstOrDefault();

                filtro.ComponenteCurricularId = componenteCurricular.Id;
                var periodo = contexto.Periodo.Where(x => x.Descricao == filtro.DescricaoPeriodo).FirstOrDefault();
                filtro.PeriodoId = periodo.Id;
            }
        }

        


    }
}
