using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoreLinq;
using MoreLinq.Extensions;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class SondagemAutoralBusiness
    {
        private string _token;
        private TurmasAPI TurmaApi;


        public SondagemAutoralBusiness(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
            TurmaApi = new TurmasAPI(new EndpointsAPI());
        }

        public async Task<IEnumerable<PerguntaDto>> ObterPerguntas(int anoEscolar)
        {
            List<PerguntaDto> perguntas = default;
            List<PerguntaResposta> perguntasResposta = default;

            using (var contexto = new SMEManagementContextData())
            {
                perguntas = await ObterPerguntas(anoEscolar, perguntas, contexto);

                perguntasResposta = await ObterPerguntasRespostas(perguntas, perguntasResposta, contexto);
            }

            perguntas.ForEach(pergunta =>
            {
                IEnumerable<PerguntaResposta> respostasDaPergunta = ObterRespostaDaPergunta(pergunta, perguntasResposta);

                MapearRespostas(pergunta, respostasDaPergunta);
            });

            return perguntas.OrderBy(x => x.Ordenacao);

        }

        public async Task<IEnumerable<PeriodoDto>> ObterPeriodoMatematica()
        {
            using (var contexto = new SMEManagementContextData())
            {
                var periodos = await contexto.Periodo.Where(x => x.TipoPeriodo == Models.Enums.TipoPeriodoEnum.Semestre).ToListAsync();

                return periodos.Select(x => (PeriodoDto)x);
            }
        }

        public async Task<IEnumerable<AlunoSondagemMatematicaDto>> ObterListagemAutoral(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            var listaSondagem = await ObterSondagemAutoralMatematica(filtrarListagemDto);

            var listaAlunos = await TurmaApi.GetAlunosNaTurma(Convert.ToInt32(filtrarListagemDto.CodigoTurma), filtrarListagemDto.AnoLetivo, _token);
            var alunos = listaAlunos.Where(x => x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5).ToList();

            if (alunos == null || !alunos.Any())
                throw new Exception($"Não encontrado alunos para a turma {filtrarListagemDto.CodigoTurma} do ano letivo {filtrarListagemDto.AnoLetivo}");

            var listagem = new List<AlunoSondagemMatematicaDto>();
            if (listaSondagem.Count > 0)
                MapearAlunosListagemMatematica2(listagem, listaSondagem);

            AdicionarAlunosEOL(filtrarListagemDto, alunos, listagem);
            return listagem.OrderBy(x => x.NumeroChamada);
        }

        public async Task SalvarSondagem(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto)
        {

            if (alunoSondagemMatematicaDto == null || !alunoSondagemMatematicaDto.Any())
                throw new Exception("É necessário realizar a sondagem de pelo menos 1 aluno");
            try
            {
                using (var contexto = new SMEManagementContextData())
                {
                    await SalvarAluno(alunoSondagemMatematicaDto, contexto);

                    await contexto.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private async Task SalvarAluno(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto, SMEManagementContextData contexto)
        {
            foreach (var aluno in alunoSondagemMatematicaDto)
            {
                var alunoAutoral = (SondagemAutoral)aluno;

                if (aluno.Respostas != null && aluno.Respostas.Any())
                    await SalvarAlunoComResposta(contexto, aluno, alunoAutoral);
            }
        }


        private void MapearAlunosListagemMatematica2(List<AlunoSondagemMatematicaDto> listagem, List<Sondagem> lsondagem)
        {

            var sondagem = lsondagem.First();
            var listaAunosDto = new List<AlunoSondagemMatematicaDto>();
            var listCodigoAlunoEol = new List<string>();
            lsondagem.ForEach(s =>
            {
                var alunoDto = new AlunoSondagemMatematicaDto();
                s.AlunosSondagem.ForEach(a =>
                {
                    alunoDto.AnoLetivo = s.AnoLetivo;
                    alunoDto.AnoTurma = s.AnoTurma;
                    alunoDto.CodigoAluno = a.CodigoAluno;
                    alunoDto.NomeAluno = a.NomeAluno;
                    alunoDto.ComponenteCurricular = s.ComponenteCurricularId.ToString();
                    alunoDto.CodigoUe = s.CodigoUe;
                    alunoDto.CodigoDre = s.CodigoDre;
                    alunoDto.CodigoTurma = s.CodigoTurma;
                    alunoDto.Respostas = new List<AlunoRespostaDto>();
                    a.ListaRespostas.ForEach(r =>
                    {
                        var Resposta = new AlunoRespostaDto()
                        {
                            Resposta = r.RespostaId,
                            Pergunta = r.PerguntaId,
                            PeriodoId = s.PeriodoId
                        };

                        alunoDto.Respostas.Add(Resposta);
                    });

                    listaAunosDto.Add(alunoDto);
                    listCodigoAlunoEol.Add(a.CodigoAluno);
                });
            });

            foreach (var codigoAluno in listCodigoAlunoEol.Distinct())
            {
                var lAluno = listaAunosDto.Where(a => a.CodigoAluno == codigoAluno).FirstOrDefault();
                    listagem.Add(lAluno);
            }
        }

        private void MapearAlunosListagemMatematica(List<AlunoSondagemMatematicaDto> listagem, SondagemAluno aluno, Sondagem sondagem)
        {
            var indexAluno = listagem.FindIndex(x => x.CodigoAluno.Equals(aluno.CodigoAluno.ToString()));

            if (indexAluno >= 0)
                foreach (var resposta in aluno.ListaRespostas)
                    AdicionarRespostaAluno(resposta, listagem, indexAluno, sondagem.PeriodoId);
            else
                AdicionarNovoAlunoListagem(listagem, aluno, sondagem);
        }

        private async Task SalvarAlunoComResposta(SMEManagementContextData contexto, AlunoSondagemMatematicaDto aluno, SondagemAutoral alunoAutoral)
        {
            foreach (var resposta in aluno.Respostas)
            {
                var alunoSalvar = await CriarObtejetoSalvar(contexto, resposta, alunoAutoral, aluno);

                await AdicicionarOuAlterar(contexto, alunoSalvar);
            }
        }

        private async Task<SondagemAutoral> CriarObtejetoSalvar(SMEManagementContextData contexto, AlunoRespostaDto resposta, SondagemAutoral alunoAutoral, AlunoSondagemMatematicaDto aluno)
        {
            var alunoBanco = await contexto.SondagemAutoral
                .FirstOrDefaultAsync(sondagem => sondagem.PerguntaId == resposta.Pergunta
                                                && sondagem.PeriodoId == resposta.PeriodoId
                                                && sondagem.CodigoAluno == alunoAutoral.CodigoAluno
                                                && sondagem.CodigoTurma == alunoAutoral.CodigoTurma);

            if (alunoBanco == null)
                alunoBanco = new SondagemAutoral(alunoAutoral);

            alunoBanco.PerguntaId = resposta.Pergunta;
            alunoBanco.RespostaId = resposta.Resposta;
            alunoBanco.PeriodoId = resposta.PeriodoId;

            return alunoBanco;
        }

        private async Task AdicicionarOuAlterar(SMEManagementContextData context, SondagemAutoral sondagemAutoral)
        {
            if (string.IsNullOrWhiteSpace(sondagemAutoral.Id))
                await context.SondagemAutoral.AddAsync(sondagemAutoral);
            else
            {
                context.SondagemAutoral.Update(sondagemAutoral);
            }
        }

        private void AdicionarAlunosEOL(FiltrarListagemMatematicaDTO filtrarListagemDto, List<AlunosNaTurmaDTO> alunos, List<AlunoSondagemMatematicaDto> listagem)
        {
            alunos.ForEach(aluno =>
            {

                var alunoBanco = listagem.FirstOrDefault(x => x.CodigoAluno.Equals(aluno.CodigoAluno.ToString()));
                if (alunoBanco != null)
                {
                    alunoBanco.NumeroChamada = aluno.NumeroAlunoChamada;
                    return;
                }

                listagem.Add(new AlunoSondagemMatematicaDto
                {
                    CodigoAluno = aluno.CodigoAluno.ToString(),
                    AnoLetivo = filtrarListagemDto.AnoLetivo,
                    AnoTurma = filtrarListagemDto.AnoEscolar,
                    CodigoDre = filtrarListagemDto.CodigoDre,
                    CodigoTurma = filtrarListagemDto.CodigoTurma,
                    CodigoUe = filtrarListagemDto.CodigoUe,
                    NumeroChamada = aluno.NumeroAlunoChamada,
                    ComponenteCurricular = filtrarListagemDto.ComponenteCurricular.ToString(),
                    NomeAluno = aluno.NomeAluno,
                });

                listagem.OrderBy(x => x.NumeroChamada);
            });
        }



        private void AdicionarRespostaAluno(SondagemAlunoRespostas alunoResposta, List<AlunoSondagemMatematicaDto> listagem, int index, string periodoId)
        {
            listagem[index].Respostas.Add(new AlunoRespostaDto
            {
                PeriodoId = periodoId,
                Pergunta = alunoResposta.PerguntaId,
                Resposta = alunoResposta.RespostaId
            });
        }

        private static void MapearRespostas(PerguntaDto pergunta, IEnumerable<PerguntaResposta> respostasDaPergunta)
        {
            pergunta.Respostas = respostasDaPergunta.Select(perguntaResposta => new RespostaDto
            {
                Descricao = perguntaResposta.Resposta.Descricao,
                Id = perguntaResposta.Resposta.Id,
                Ordenacao = perguntaResposta.Ordenacao
            });
        }

        private static async Task<List<Sondagem>> ObterSondagemAutoralMatematica(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            using (var contexto = new SMEManagementContextData())
            {
                try
                {

                    return await contexto.Sondagem.Where(s => s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                                              s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                                              s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                                              s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                                              s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                                              s.CodigoTurma == filtrarListagemDto.CodigoTurma).
                                                              Include(x => x.AlunosSondagem).ThenInclude(x => x.ListaRespostas).
                                                              Where(s => s.AlunosSondagem.Any(a => a.ListaRespostas.Any(lr => lr.PerguntaId == filtrarListagemDto.PerguntaId))).ToListAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        private static IEnumerable<PerguntaResposta> ObterRespostaDaPergunta(PerguntaDto pergunta, List<PerguntaResposta> perguntasResposta)
        {
            var respostasDaPergunta = perguntasResposta.Where(perguntaResposta => perguntaResposta.Pergunta.Id.Equals(pergunta.Id));

            if (respostasDaPergunta == null || !respostasDaPergunta.Any())
                throw new Exception($"Não foi possivel obter as respostas da pergunta '{pergunta.Descricao}'");

            return respostasDaPergunta;
        }

        private static async Task<List<PerguntaResposta>> ObterPerguntasRespostas(List<PerguntaDto> perguntas, List<PerguntaResposta> perguntasResposta, SMEManagementContextData contexto)
        {
            perguntasResposta = await contexto.PerguntaResposta.Include(x => x.Pergunta).Include(x => x.Resposta).Where(resposta => perguntas.Any(z => z.Id.Equals(resposta.Pergunta.Id))).ToListAsync();

            if (perguntasResposta == null || !perguntasResposta.Any())
                throw new Exception("Não foi possivel obter as respostas da sondagem");

            return perguntasResposta;
        }

        private async Task<List<PerguntaDto>> ObterPerguntas(int anoEscolar, List<PerguntaDto> perguntas, SMEManagementContextData contexto)
        {
            perguntas = await contexto.PerguntaAnoEscolar.Include(x => x.Pergunta).Where(perguntaAnoEscolar => perguntaAnoEscolar.AnoEscolar == anoEscolar).Select(x => MapearPergunta(x)).ToListAsync();

            if (perguntas == null || !perguntas.Any())
                throw new Exception("Não foi possivel obter as perguntas da sondagem");

            return perguntas;
        }

        private void AdicionarNovoAlunoListagem(List<AlunoSondagemMatematicaDto> listagem, SondagemAutoral aluno)
        {
            listagem.Add(new AlunoSondagemMatematicaDto
            {
                Id = aluno.Id,
                CodigoAluno = aluno.CodigoAluno,
                NomeAluno = aluno.NomeAluno,
                AnoLetivo = aluno.AnoLetivo,
                AnoTurma = aluno.AnoTurma,
                CodigoDre = aluno.CodigoDre,
                CodigoTurma = aluno.CodigoTurma,
                CodigoUe = aluno.CodigoUe,
                ComponenteCurricular = aluno.ComponenteCurricular.Id,
                Respostas = new List<AlunoRespostaDto>()
                {
                    new AlunoRespostaDto
                    {
                        PeriodoId = aluno.PeriodoId,
                        Pergunta = aluno.PerguntaId,
                        Resposta = aluno.RespostaId
                    }
                }
            });
        }



        private void AdicionarNovoAlunoListagem(List<AlunoSondagemMatematicaDto> listagem, SondagemAluno aluno, Sondagem sondagem)
        {
            var alunoDto = new AlunoSondagemMatematicaDto
            {
                Id = aluno.Id.ToString(),
                CodigoAluno = aluno.CodigoAluno,
                NomeAluno = aluno.NomeAluno,
                AnoLetivo = sondagem.AnoLetivo,
                AnoTurma = sondagem.AnoTurma,
                CodigoDre = sondagem.CodigoDre,
                CodigoTurma = sondagem.CodigoTurma,
                CodigoUe = sondagem.CodigoUe,
                ComponenteCurricular = sondagem.ComponenteCurricularId,
                Respostas = new List<AlunoRespostaDto>()

            };

            foreach (var resp in aluno.ListaRespostas)
            {
                var alunoRespDto = new AlunoRespostaDto()
                {
                    Pergunta = resp.PerguntaId,
                    Resposta = resp.RespostaId,
                    PeriodoId = sondagem.PeriodoId
                };
                alunoDto.Respostas.Add(alunoRespDto);
            }

            listagem.Add(alunoDto);
        }

        private PerguntaDto MapearPergunta(PerguntaAnoEscolar perguntaAnoEscolar)
        {
            var retorno = (PerguntaDto)perguntaAnoEscolar.Pergunta;

            if (retorno == null)
                return default;

            retorno.Ordenacao = perguntaAnoEscolar.Ordenacao;

            return retorno;
        }


    }
}
