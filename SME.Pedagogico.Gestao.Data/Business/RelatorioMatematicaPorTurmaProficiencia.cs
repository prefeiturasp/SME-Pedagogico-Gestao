using Dapper;
using MoreLinq;
using Npgsql;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.DTO.Matematica.Relatorio;
using SME.Pedagogico.Gestao.Data.DTO.RelatorioPorTurma;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Data.Relatorios;
using SME.Pedagogico.Gestao.Data.Relatorios.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class RelatorioMatematicaPorTurmaProficiencia
    {
        private filtrosRelatorioDTO _filtro;
        private int _grupo;
        private List<DatasPeriodoFixoAnualDTO> _listaDePeriodos;
        private List<AlunosNaTurmaDTO> _listaDeAlunosAtivos;
        private List<AlunoPerguntaRespostaProficienciaDTO> _listaAlunoPerguntaResposta;

        private const string TITULO_BARRA_SEM_PREENCHIMENTO = "Sem Preenchimento";

        public RelatorioMatematicaPorTurmaProficiencia(filtrosRelatorioDTO filtro, int grupo)
        {
            this._filtro = filtro;
            this._grupo = grupo;
        }

        public async Task<RelatorioMatematicaPorTurmaProficienciaDTO> ObtenhaDTO()
        {
            await this.CarregueAlunosAtivos();

            return new RelatorioMatematicaPorTurmaProficienciaDTO()
            {
                Alunos = await ObtenhaListaDeAlunosResposta(),
                Graficos = ObtenhaListaDeGrafico()
            };
        }

        private async Task CarregaPeriodos()
        {
            this._listaDePeriodos = (await ConsultaTotalDeAlunos.BuscaDatasPeriodoFixoAnual(this._filtro)).ToList();

            if (this._listaDePeriodos is null || this._listaDePeriodos.Count() == 0)
                throw new Exception("Periodo fixo anual nao encontrado");
        }

        private async Task CarregueAlunosAtivos()
        {
            await this.CarregaPeriodos();

            var alunoApi = new AlunosAPI(new EndpointsAPI());

            this._listaDeAlunosAtivos = (await alunoApi.ObterAlunosAtivosPorTurmaEPeriodo(
                                                            this._filtro.CodigoTurmaEol,
                                                            this._listaDePeriodos.First().DataFim))
                                                            .OrderBy(aluno => aluno.NomeAluno)
                                                            .ToList();

            if (this._listaDeAlunosAtivos is null || this._listaDeAlunosAtivos.Count() == 0)
                throw new Exception("Não possui alunos ativos para turma e período");
        }

        private async Task<List<AlunoPorTurmaRelatorioProficienciaDTO>> ObtenhaListaDeAlunosResposta()
        {
            var retorno = new List<AlunoPorTurmaRelatorioProficienciaDTO>();

            await this.CarregueListaPerguntaRespostas();

            foreach(AlunosNaTurmaDTO aluno in this._listaDeAlunosAtivos)
            {
                retorno.Add(ObtenhaAlunoPorTurma(aluno));
            }

            return retorno;
        }

        private AlunoPorTurmaRelatorioProficienciaDTO ObtenhaAlunoPorTurma(AlunosNaTurmaDTO aluno)
        {
            return new AlunoPorTurmaRelatorioProficienciaDTO()
            {
                CodigoAluno = aluno.CodigoAluno,
                NomeAluno = aluno.NomeAlunoRelatorio,
                Perguntas = ObtenhaListaDePerguntas(aluno)
            };
        }

        private List<PerguntasRelatorioProficienciaDTO> ObtenhaListaDePerguntas(AlunosNaTurmaDTO aluno)
        {
            var listaRetorno = new List<PerguntasRelatorioProficienciaDTO>();
            var listaPerguntaResportaAluno = ObtenhaPerguntaRespostaPorAluno(aluno.CodigoAluno);
            var grupoPerguntaResposta = listaPerguntaResportaAluno.GroupBy(dto => dto.PerguntaId);

            grupoPerguntaResposta.ForEach(agrupador => 
            {
                var listaPorPergunta = listaPerguntaResportaAluno.Where(dto => dto.PerguntaId == agrupador.Key).ToList();
                var dtoAlunoPergunta = listaPorPergunta.FirstOrDefault();
                var dtoPerguntaRelatorio = new PerguntasRelatorioProficienciaDTO()
                {
                    NomePergunta = dtoAlunoPergunta.PerguntaDescricao,
                    Ordenacao = dtoAlunoPergunta.OrdemPergunta,
                    subPerguntas = ObtenhaListaDeSubPergunta(listaPorPergunta)
                };

                listaRetorno.Add(dtoPerguntaRelatorio);
            });

            return listaRetorno;
        }

        private List<SubPerguntaRelatorioDTO> ObtenhaListaDeSubPergunta(List<AlunoPerguntaRespostaProficienciaDTO> listaPergunta)
        {
            var listaRetorno = new List<SubPerguntaRelatorioDTO>();

            foreach (AlunoPerguntaRespostaProficienciaDTO dto in listaPergunta)
            {
                var dtoSubPergunta = new SubPerguntaRelatorioDTO()
                {
                    NomeSubPergunta = dto.SubPerguntaDescricao,
                    Resposta = dto.RespostaDescricao
                };

                listaRetorno.Add(dtoSubPergunta);
            }

            return listaRetorno;
        }

        private List<AlunoPerguntaRespostaProficienciaDTO> ObtenhaPerguntaRespostaPorAluno(int codigoAluno)
        {
            return this._listaAlunoPerguntaResposta.FindAll(alunoPR => alunoPR.CodigoAluno == codigoAluno.ToString());
        }

        private async Task CarregueListaPerguntaRespostas()
        {
            string sql = ConsultasRelatorios.QueryRelatorioPorTurmaMatematicaProficiencia();

            using (var conexao = new NpgsqlConnection(Environment.GetEnvironmentVariable("sondagemConnection")))
            {
                this._listaAlunoPerguntaResposta = (await conexao.QueryAsync<AlunoPerguntaRespostaProficienciaDTO>(
                                                                sql,
                                                                new
                                                                {
                                                                    CodigoTurmaEol = this._filtro.CodigoTurmaEol,
                                                                    AnoLetivo = this._filtro.AnoLetivo,
                                                                    ComponenteCurricularId = this._filtro.ComponenteCurricularId,
                                                                    Grupo = this._grupo,
                                                                    Bimestre = this._filtro.Bimestre
                                                                })).ToList();
            }
        }

        private List<GraficosRelatorioProficienciaDTO> ObtenhaListaDeGrafico()
        {
            var listaDeRetorno = new List<GraficosRelatorioProficienciaDTO>();
            var grupadorPorPergunta = this._listaAlunoPerguntaResposta.GroupBy(dto => dto.PerguntaId);

            grupadorPorPergunta.ForEach(agrupador => 
            {
                var listaPorPergunta = this._listaAlunoPerguntaResposta.Where(dto => dto.PerguntaId == agrupador.Key).ToList();

                listaDeRetorno.Add(ObtenhaGraficoDto(listaPorPergunta));
            });

            return listaDeRetorno;
        }

        private GraficosRelatorioProficienciaDTO ObtenhaGraficoDto(List<AlunoPerguntaRespostaProficienciaDTO> listaPorPergunta)
        {
            var alunoPerguntaResposta = listaPorPergunta.FirstOrDefault();

            return new GraficosRelatorioProficienciaDTO()
            {
                Nome = alunoPerguntaResposta.PerguntaDescricao,
                Ordenacao = alunoPerguntaResposta.OrdemPergunta,
                ListaDeGrafico = ObtenhaListaDeGrafico(listaPorPergunta)
            };
        }

        private List<GraficosRelatorioDTO> ObtenhaListaDeGrafico(List<AlunoPerguntaRespostaProficienciaDTO> listaPorPergunta)
        {
            var listaGrafico = new List<GraficosRelatorioDTO>();
            var grupoPorSubPergunta = listaPorPergunta.GroupBy(dto => dto.SubPerguntaId);

            grupoPorSubPergunta.ForEach(grupoSubPergunta =>
            {
                var listDeSubPergunta = listaPorPergunta.Where(pergunta => pergunta.SubPerguntaId == grupoSubPergunta.Key).ToList();
                var subPergunta = listDeSubPergunta.FirstOrDefault();
                var grafico = new GraficosRelatorioDTO()
                {
                    nomeGrafico = subPergunta.SubPerguntaDescricao,
                    Barras = ObtenhaListaDeBarrasGrafico(listDeSubPergunta)
                };

                listaGrafico.Add(grafico);
            });

            return listaGrafico;
        }

        private List<BarrasGraficoDTO> ObtenhaListaDeBarrasGrafico(List<AlunoPerguntaRespostaProficienciaDTO> listaPorSubPergunta)
        {
            var listaRetorno = new List<BarrasGraficoDTO>();
            var grupoPorResposta = listaPorSubPergunta.GroupBy(dto => dto.RespostaId);

            grupoPorResposta.ForEach(grupoReposta =>
            {
                var listaDeResposta = listaPorSubPergunta.Where(subPergunta => subPergunta.RespostaId == grupoReposta.Key).ToList();
                var resposta = listaDeResposta.FirstOrDefault();

                listaRetorno.Add(ObtenhaBarraGraficoDto(resposta.RespostaDescricao, listaDeResposta.Count()));
            });

            listaRetorno.Add(ObtenhaBarraSemPreenchimento(listaPorSubPergunta.Count()));

            return listaRetorno;
        }

        private BarrasGraficoDTO ObtenhaBarraSemPreenchimento(int totalResposta)
        {
            var valor = this._listaDeAlunosAtivos.Count() - totalResposta;

            return ObtenhaBarraGraficoDto(TITULO_BARRA_SEM_PREENCHIMENTO, valor);
        }

        private BarrasGraficoDTO ObtenhaBarraGraficoDto(string descricao, int valor)
        {
            return new BarrasGraficoDTO()
            {
                label = descricao,
                value = valor
            };
        }
    }
}
