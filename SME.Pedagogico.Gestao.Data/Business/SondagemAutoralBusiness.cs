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

        public async Task<IEnumerable<PerguntaDto>> ObterPerguntas(int anoEscolar, int anoLetivo)
        {
            List<PerguntaDto> perguntas = default;
            List<PerguntaResposta> perguntasResposta = default;

            using (var contexto = new SMEManagementContextData())
            {
                perguntas = await ObterPerguntas(anoEscolar, perguntas, anoLetivo, contexto);

                perguntasResposta = await ObterPerguntasRespostas(perguntas, perguntasResposta, contexto, anoEscolar);
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

        public async Task<bool> ConsultarSePeriodoEstaAberto(int bimestre, string anoLetivo)
        {
            bool periodoAberto = false;
            using (var contexto = new SMEManagementContextData())
            {
                var periodos = await contexto.PeriodoDeAberturas.Where(x => x.Bimestre.Equals(bimestre) && x.Ano.Equals(anoLetivo) && DateTime.Now >= x.DataInicio && DateTime.Now <= x.DataFim).ToListAsync();
                if (periodos?.Count() > 0)
                    periodoAberto = true;
            }

            return periodoAberto;
        }

        public async Task<IEnumerable<AlunoSondagemMatematicaDto>> ObterListagemAutoral(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            var listaSondagem = new List<Sondagem>();
            if (filtrarListagemDto.AnoLetivo >= 2022)
                listaSondagem = await ObterSondagemAutoralMatematicaBimestre(filtrarListagemDto);
            else
                listaSondagem = await ObterSondagemAutoralMatematica(filtrarListagemDto);

            var listaAlunos = await TurmaApi.GetAlunosNaTurma(Convert.ToInt32(filtrarListagemDto.CodigoTurma), filtrarListagemDto.AnoLetivo, _token);
            var alunos = listaAlunos.Where(x => x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5).ToList();

            if (alunos == null || !alunos.Any())
                throw new Exception($"Não encontrado alunos para a turma {filtrarListagemDto.CodigoTurma} do ano letivo {filtrarListagemDto.AnoLetivo}");

            var listagem = new List<AlunoSondagemMatematicaDto>();
            if (listaSondagem.Count > 0)
                MapearAlunosListagemMatematica(listagem, listaSondagem, filtrarListagemDto.Bimestre);

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

        public async Task SalvarSondagemMatematica(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto)
        {

            if (alunoSondagemMatematicaDto == null || !alunoSondagemMatematicaDto.Any())
                throw new Exception("É necessário realizar a sondagem de pelo menos 1 aluno");
            try
            {
                var periodosRespostas = new List<string>();
                var perguntaId = await ObterPeriodosDasRespostasEhPerguntaDaSondagem(alunoSondagemMatematicaDto, periodosRespostas);
                var listaIdPeriodos = periodosRespostas.Distinct();
                var filtroSondagem = CriaFiltroListagemMatematica(alunoSondagemMatematicaDto, perguntaId);

                if (alunoSondagemMatematicaDto.FirstOrDefault().AnoLetivo >= 2022)
                    await SalvarSonsagemMatermaticaPorBimestre(alunoSondagemMatematicaDto, filtroSondagem);
                else
                    await SalvarSonsagemMatermaticaPorPeriodo(alunoSondagemMatematicaDto, listaIdPeriodos, filtroSondagem);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private async Task SalvarSonsagemMatermaticaPorBimestre(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto, FiltrarListagemMatematicaDTO filtroSondagem)
        {
            try
            {
                using (var contexto = new SMEManagementContextData())
                {
                    var sondagem = await ObterSondagemAutoralMatematica(filtroSondagem, contexto);
                    if (sondagem != null)
                    {
                        foreach (var aluno in alunoSondagemMatematicaDto)
                        {
                            await AdicionaOUAlteraAlunosERespostas(contexto, sondagem, aluno, filtroSondagem.Bimestre);
                        }
                        contexto.Sondagem.Update(sondagem);
                        await contexto.SaveChangesAsync();
                    }

                    else
                    {
                        var novaSondagem = await CriaNovaSondagem(alunoSondagemMatematicaDto, null, filtroSondagem, contexto);
                        novaSondagem.PeriodoId = novaSondagem.PeriodoId ?? string.Empty;
                        contexto.Sondagem.Add(novaSondagem);
                        await contexto.SaveChangesAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async Task SalvarSonsagemMatermaticaPorPeriodo(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto, IEnumerable<string> listaIdPeriodos, FiltrarListagemMatematicaDTO filtroSondagem)
        {
            foreach (var periodoId in listaIdPeriodos)
            {
                using (var contexto = new SMEManagementContextData())
                {
                    var sondagem = await ObterSondagemAutoralMatematica(filtroSondagem,contexto, periodoId);
                    if (sondagem != null)
                    {
                        foreach (var aluno in alunoSondagemMatematicaDto)
                        {
                            await AdicionaOUAlteraAlunosERespostas(contexto, sondagem, aluno,filtroSondagem.Bimestre);
                        }
                        contexto.Sondagem.Update(sondagem);
                        await contexto.SaveChangesAsync();
                    }

                    else
                    {
                        var novaSondagem = await CriaNovaSondagem(alunoSondagemMatematicaDto, periodoId, filtroSondagem, contexto);
                        contexto.Sondagem.Add(novaSondagem);
                        await contexto.SaveChangesAsync();

                    }
                }
            }
        }

        private static FiltrarListagemMatematicaDTO CriaFiltroListagemMatematica(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto, string perguntaId)
        {
            var alunoFiltro = alunoSondagemMatematicaDto.First();
            var filtroSondagem = new FiltrarListagemMatematicaDTO()
            {
                AnoEscolar = alunoFiltro.AnoTurma,
                AnoLetivo = alunoFiltro.AnoLetivo,
                CodigoDre = alunoFiltro.CodigoDre,
                CodigoTurma = alunoFiltro.CodigoTurma,
                CodigoUe = alunoFiltro.CodigoUe,
                ComponenteCurricular = alunoFiltro.ComponenteCurricular,
                PerguntaId = perguntaId,
                Bimestre = alunoFiltro.Bimestre
            };
            return filtroSondagem;
        }

        private async Task AdicionaOUAlteraAlunosERespostas(SMEManagementContextData contexto, Sondagem sondagem, AlunoSondagemMatematicaDto aluno,int? bimestre)
        {
            var alunoSondagem = sondagem.AlunosSondagem.FirstOrDefault(a => a.CodigoAluno == aluno.CodigoAluno);
            if (alunoSondagem != null)
            {
                if (aluno.Respostas == null || aluno.Respostas.Count == 0)
                    contexto.SondagemAluno.Remove(alunoSondagem);
                else
                {
                    await AtualizaNovasRespostas(aluno, alunoSondagem, sondagem.PeriodoId, bimestre,contexto);
                    RemoveRespostasSemValor(contexto, aluno, alunoSondagem);
                }
            }

            else
            {
                if (aluno.Respostas != null && sondagem.AnoLetivo < 2022)
                {
                    if (aluno.Respostas.Any(r => r.PeriodoId == (sondagem.PeriodoId.Length > 0 ? sondagem.PeriodoId : null)))
                    {
                        var alunoNovoSondagem = await CriaNovoAlunoSondagem(sondagem, aluno, bimestre, contexto);
                        sondagem.AlunosSondagem.Add(alunoNovoSondagem);
                    }
                }
                else if(sondagem.AnoLetivo >=2022 && aluno.Respostas?.Count() > 0)
                {
                    var alunoNovoSondagem = await CriaNovoAlunoSondagem(sondagem, aluno, bimestre, contexto);
                    sondagem.AlunosSondagem.Add(alunoNovoSondagem);
                }
            }
        }


        private async Task AtualizaNovasRespostas(AlunoSondagemMatematicaDto aluno, SondagemAluno alunoSondagem, string periodoId, int? bimestre, SMEManagementContextData contexto)
        {
            foreach (var resposta in aluno.Respostas)
            {
                var respostaSondagem = alunoSondagem.ListaRespostas.FirstOrDefault(x => x.PerguntaId == resposta.Pergunta && x.PerguntaAnoEscolar.Id == resposta.PerguntaAnoEscolar);
                if (resposta.PeriodoId == periodoId)
                {
                    if (respostaSondagem != null && aluno.Respostas.Any(r => r.PeriodoId == periodoId))
                        respostaSondagem.RespostaId = resposta.Resposta;
                    else
                    {
                        var perguntaAnoEscolar = await contexto.PerguntaAnoEscolar.FirstOrDefaultAsync(w => w.Id.Equals(resposta.PerguntaAnoEscolar));
                        alunoSondagem.ListaRespostas.Add(CriaNovaRespostaAluno(alunoSondagem, resposta, perguntaAnoEscolar));
                    }                        
                }
                else
                {
                    if (respostaSondagem != null && aluno.Respostas.Any(r => r.Bimestre == bimestre))
                        respostaSondagem.RespostaId = resposta.Resposta;
                    else
                    {
                        var perguntaAnoEscolar = await contexto.PerguntaAnoEscolar.FirstOrDefaultAsync(w => w.Id.Equals(resposta.PerguntaAnoEscolar));
                        alunoSondagem.ListaRespostas.Add(CriaNovaRespostaAluno(alunoSondagem, resposta, perguntaAnoEscolar));
                    }                        
                }
            }
        }

        private static void RemoveRespostasSemValor(SMEManagementContextData contexto, AlunoSondagemMatematicaDto aluno, SondagemAluno alunoSondagem)
        {
            var ListaRespostasRemovidas = new List<SondagemAlunoRespostas>();

            if (alunoSondagem.ListaRespostas.Any(x => x.RespostaId != ""))
            {
                foreach (var alunoResposta in alunoSondagem.ListaRespostas)
                {
                    var respostaSondagem = aluno.Respostas.Where(x => x.Pergunta == alunoResposta.PerguntaId && x.Resposta != "").FirstOrDefault();
                    if (respostaSondagem == null)
                        ListaRespostasRemovidas.Add(alunoResposta);
                }
                if (ListaRespostasRemovidas.Count > 0)
                    contexto.SondagemAlunoRespostas.RemoveRange(ListaRespostasRemovidas);
            }
            else
            {
                contexto.SondagemAluno.Remove(alunoSondagem);
            }
        }


        private async Task<Sondagem> CriaNovaSondagem(IEnumerable<AlunoSondagemMatematicaDto> ListaAlunosSondagemDto, string periodoId, FiltrarListagemMatematicaDTO alunoFiltro, SMEManagementContextData contexto)
        {
            var listaAlunosComRespostaDto = ListaAlunosSondagemDto.Where(x => x.Respostas != null).ToList();
            var bimestre = listaAlunosComRespostaDto.FirstOrDefault().Respostas.FirstOrDefault().Bimestre;
            if (listaAlunosComRespostaDto == null || listaAlunosComRespostaDto.Count == 0)
                return null;


            var listaAlunosComRespostasDoPeriodoDto = new List<AlunoSondagemMatematicaDto>();

            if (listaAlunosComRespostaDto.FirstOrDefault().AnoLetivo >= 2022)
                listaAlunosComRespostasDoPeriodoDto = listaAlunosComRespostaDto.ToList();
            else
                listaAlunosComRespostasDoPeriodoDto = listaAlunosComRespostaDto.Where(a => a.Respostas.Any(r => r.PeriodoId == periodoId)).ToList();

            var sondagem = new Sondagem
            {
                Id = Guid.NewGuid(),
                AnoLetivo = alunoFiltro.AnoLetivo,
                AnoTurma = alunoFiltro.AnoEscolar,
                CodigoDre = alunoFiltro.CodigoDre,
                CodigoUe = alunoFiltro.CodigoUe,
                CodigoTurma = alunoFiltro.CodigoTurma,
                ComponenteCurricularId = alunoFiltro.ComponenteCurricular,
                AlunosSondagem = new List<SondagemAluno>(),
                PeriodoId = periodoId,
                Bimestre = bimestre
            };

            foreach (var alunoDto in listaAlunosComRespostasDoPeriodoDto)
            {
                var aluno = await CriaNovoAlunoSondagem(sondagem, alunoDto, bimestre, contexto);

                sondagem.AlunosSondagem.Add(aluno);
            };

            return sondagem;
        }

        private static SondagemAlunoRespostas CriaNovaRespostaAluno(SondagemAluno aluno, AlunoRespostaDto respostaDto, PerguntaAnoEscolar perguntaAnoEscolar)
        {
            return  new SondagemAlunoRespostas
                    {
                        Id = Guid.NewGuid(),
                        PerguntaId = respostaDto.Pergunta,
                        RespostaId = respostaDto.Resposta,
                        SondagemAlunoId = aluno.Id,
                        Bimestre = respostaDto.Bimestre,
                        PerguntaAnoEscolar = perguntaAnoEscolar
                    };
        }


        private async Task<SondagemAluno> CriaNovoAlunoSondagem(Sondagem sondagem, AlunoSondagemMatematicaDto alunoDto,int? bimestre, SMEManagementContextData contexto)
        {
            var aluno = new SondagemAluno()
            {
                Id = Guid.NewGuid(),
                CodigoAluno = alunoDto.CodigoAluno,
                SondagemId = sondagem.Id,
                NomeAluno = alunoDto.NomeAluno,
                Bimestre = bimestre,
                ListaRespostas = new List<SondagemAlunoRespostas>()
            };

            var listaRespostasPeriodo = new List<AlunoRespostaDto>();

            if (alunoDto.AnoLetivo >= 2022)
                listaRespostasPeriodo = alunoDto.Respostas.ToList();
            else
                listaRespostasPeriodo = alunoDto.Respostas.Where(r => r.PeriodoId == sondagem.PeriodoId).ToList();

            foreach (var respostaDto in listaRespostasPeriodo)
            {
                var perguntaAnoEscolar = await contexto.PerguntaAnoEscolar.FirstOrDefaultAsync(w => w.Id.Equals(respostaDto.PerguntaAnoEscolar));
                var resposta = CriaNovaRespostaAluno(aluno, respostaDto, perguntaAnoEscolar);
                aluno.ListaRespostas.Add(resposta);
            }

            return aluno;
        }

        private async Task<string> ObterPeriodosDasRespostasEhPerguntaDaSondagem(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto, List<string> periodosRespostas)
        {

            string perguntaId = null;
            var periodos = await ObterPeriodoMatematica();
            foreach (var alunoDto in alunoSondagemMatematicaDto)
            {
                if (alunoDto.Respostas != null)
                {
                    if (perguntaId == null)
                        perguntaId = ObterPerguntaDaSondagem(alunoDto, perguntaId);

                    foreach (var periodo in periodos)
                    {
                        if (alunoDto.Respostas.Any(r => r.PeriodoId == periodo.Id))
                        {
                            periodosRespostas.Add(periodo.Id);
                        }
                    }
                }


            };
            return perguntaId;
        }

        private string ObterPerguntaDaSondagem(AlunoSondagemMatematicaDto alunoDto, string perguntaId)
        {
            var resposta = alunoDto.Respostas.First();
            perguntaId = resposta.Pergunta;
            return perguntaId;
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

        private void MapearAlunosListagemMatematica(List<AlunoSondagemMatematicaDto> listagem, List<Sondagem> lsondagem, int? bimestre)
        {

            var listaAlunosDto = new List<AlunoSondagemMatematicaDto>();
            var listCodigoAlunoEol = new List<string>();
            lsondagem.ForEach(s =>
            {

                s.AlunosSondagem.ForEach(a =>
                {
                    var alunoDto = new AlunoSondagemMatematicaDto();

                    alunoDto.Id = a.Id != null ? a.Id.ToString() : null;
                    alunoDto.AnoLetivo = s.AnoLetivo;
                    alunoDto.AnoTurma = s.AnoTurma;
                    alunoDto.CodigoAluno = a.CodigoAluno;
                    alunoDto.NomeAluno = a.NomeAluno;
                    alunoDto.ComponenteCurricular = s.ComponenteCurricularId.ToString();
                    alunoDto.CodigoUe = s.CodigoUe;
                    alunoDto.CodigoDre = s.CodigoDre;
                    alunoDto.Bimestre = bimestre;
                    alunoDto.CodigoTurma = s.CodigoTurma;
                    alunoDto.Respostas = new List<AlunoRespostaDto>();
                    a.ListaRespostas.ForEach(r =>
                    {
                        var Resposta = new AlunoRespostaDto()
                        {
                            Resposta = r.RespostaId,
                            Pergunta = r.PerguntaId,
                            PeriodoId = s.PeriodoId,
                            Bimestre = r.Bimestre
                        };

                        alunoDto.Respostas.Add(Resposta);
                    });

                    listaAlunosDto.Add(alunoDto);
                    listCodigoAlunoEol.Add(a.CodigoAluno);
                });
            });

            foreach (var codigoAluno in listCodigoAlunoEol.Distinct())
            {
                var listaResposta = new List<AlunoRespostaDto>();
                var alunoDto = listaAlunosDto.Where(a => a.CodigoAluno == codigoAluno).FirstOrDefault();
                var listaAlunoResposta = listaAlunosDto.Where(a => a.CodigoAluno == codigoAluno && (a.Bimestre.HasValue ? a.Bimestre.Value : 0) == bimestre).ToList();
                listaAlunoResposta.ForEach(lr =>
                {
                    lr.Respostas.ForEach(r =>
                    {
                        listaResposta.Add(r);
                    });
                });
                alunoDto.Respostas = listaResposta;

                if (alunoDto != null)
                    listagem.Add(alunoDto);
            }
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

        private static void MapearRespostas(PerguntaDto pergunta, IEnumerable<PerguntaResposta> respostasDaPergunta)
        {
            pergunta.Respostas = respostasDaPergunta.Select(perguntaResposta => new RespostaDto
            {
                Descricao = perguntaResposta.Resposta.Descricao,
                Id = perguntaResposta.Resposta.Id,
                Ordenacao = perguntaResposta.Ordenacao
            });
        }

        private static async Task<Sondagem> ObterSondagemAutoralMatematica(FiltrarListagemMatematicaDTO filtrarListagemDto, SMEManagementContextData contexto, string periodoId = "")
        {
            try
            {
                var sondagem = await (from s in contexto.Sondagem
                                      join sa in contexto.SondagemAluno on s.Id equals sa.SondagemId
                                      join sar in contexto.SondagemAlunoRespostas on sa.Id equals sar.SondagemAlunoId
                                      join r in contexto.Resposta on sar.RespostaId equals r.Id
                                      join pae in contexto.PerguntaAnoEscolar on sar.PerguntaAnoEscolar.Id equals pae.Id
                                      where s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                            s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                            s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                            s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                            s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                            s.CodigoTurma == filtrarListagemDto.CodigoTurma &&
                                            string.IsNullOrEmpty(periodoId) || s.PeriodoId == periodoId
                                      select new Sondagem()
                                      {
                                          Id = s.Id,
                                          ComponenteCurricular = s.ComponenteCurricular,
                                          ComponenteCurricularId = s.ComponenteCurricularId,
                                          Periodo = s.Periodo,
                                          PeriodoId = s.PeriodoId,
                                          AnoTurma = s.AnoTurma,
                                          CodigoTurma = s.CodigoTurma,
                                          CodigoUe = s.CodigoUe,
                                          CodigoDre = s.CodigoDre,
                                          AnoLetivo = s.AnoLetivo,
                                          Ordem = s.Ordem,
                                          OrdemId = s.OrdemId,
                                          Grupo = s.Grupo,
                                          GrupoId = s.GrupoId,
                                          SequenciaDeOrdemSalva = s.SequenciaDeOrdemSalva,
                                          Bimestre = s.Bimestre,
                                          AlunosSondagem = s.AlunosSondagem.Select(saa=> new SondagemAluno() 
                                          {
                                              Id = saa.Id,
                                              Bimestre = saa.Bimestre,
                                              CodigoAluno = saa.CodigoAluno,
                                              NomeAluno = saa.NomeAluno,
                                              Sondagem = s,
                                              SondagemId = s.Id,
                                              ListaRespostas = saa.ListaRespostas.Select(lr=> new SondagemAlunoRespostas() 
                                              {
                                                  PerguntaAnoEscolarId = lr.PerguntaAnoEscolarId,
                                                  Bimestre = lr.Bimestre,
                                                  Id = lr.Id,
                                                  Pergunta = lr.Pergunta,
                                                  PerguntaId = lr.PerguntaId,
                                                  PerguntaAnoEscolar = new PerguntaAnoEscolar()
                                                  {
                                                      Id = lr.PerguntaAnoEscolar.Id,
                                                      AnoEscolar = lr.PerguntaAnoEscolar.AnoEscolar,
                                                      Pergunta = lr.PerguntaAnoEscolar.Pergunta,
                                                      Ordenacao = lr.PerguntaAnoEscolar.Ordenacao,
                                                      Excluido = lr.PerguntaAnoEscolar.Excluido,
                                                      InicioVigencia = lr.PerguntaAnoEscolar.InicioVigencia,
                                                      FimVigencia = lr.PerguntaAnoEscolar.FimVigencia,
                                                  },
                                                  Resposta = lr.Resposta,
                                                  RespostaId = lr.RespostaId,
                                                  SondagemAluno = saa,
                                                  SondagemAlunoId = saa.Id
                                              })
                                              .ToList()
                                          }).ToList()

                                      }).FirstOrDefaultAsync();

                return sondagem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task<List<Sondagem>> ObterSondagemAutoralMatematica(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            using (var contexto = new SMEManagementContextData())
            {
                return await contexto.Sondagem.Where(s => s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                                              s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                                              s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                                              s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                                              s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                                              s.CodigoTurma == filtrarListagemDto.CodigoTurma).
                                                              Include(x => x.AlunosSondagem).ThenInclude(x => x.ListaRespostas).ToListAsync();



            }
        }

        private static async Task<List<Sondagem>> ObterSondagemAutoralMatematicaBimestre(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            //Aqui deverá ser feita a modificação da query
            using (var contexto = new SMEManagementContextData())
            {
                return await contexto.Sondagem.Where(s => s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                                          s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                                          s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                                          s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                                          s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                                          s.CodigoTurma == filtrarListagemDto.CodigoTurma).
                                                          Include(x => x.AlunosSondagem).ThenInclude(x => x.ListaRespostas).ThenInclude(x => x.Resposta).ToListAsync();

            }

        }

        private static IEnumerable<PerguntaResposta> ObterRespostaDaPergunta(PerguntaDto pergunta, List<PerguntaResposta> perguntasResposta)
        {
            var respostasDaPergunta = perguntasResposta.Where(perguntaResposta => perguntaResposta.PerguntaAnoEscolar.Id.Equals(pergunta.PerguntaAnoEscolar));

            if (respostasDaPergunta == null || !respostasDaPergunta.Any())
                throw new Exception($"Não foi possivel obter as respostas da pergunta '{pergunta.Descricao}'");

            return respostasDaPergunta;
        }

        private static async Task<List<PerguntaResposta>> ObterPerguntasRespostas(List<PerguntaDto> perguntas, List<PerguntaResposta> perguntasResposta, SMEManagementContextData contexto, int anoEscolar)
        {
            var perguntasRespostas = await (from p in contexto.Pergunta
                                      join pae in contexto.PerguntaAnoEscolar on p.Id equals pae.Pergunta.Id
                                      join pr in contexto.PerguntaResposta on new { PerguntaId = p.Id, PerguntaAnoEscolarId = pae.Id } equals new { PerguntaId = pr.Pergunta.Id, PerguntaAnoEscolarId = pr.PerguntaAnoEscolar.Id }
                                      join r in contexto.Resposta on pr.Resposta.Id equals r.Id
                                      join filtro in perguntas on new { PerguntaId = pr.Pergunta.Id, PerguntaAnoEscolarId = pr.PerguntaAnoEscolar.Id } equals new { PerguntaId = filtro.Id, PerguntaAnoEscolarId = filtro.PerguntaAnoEscolar }
                                      where pae.AnoEscolar == anoEscolar
                                      select new PerguntaResposta
                                      {
                                          Id = pr.Id,
                                          Pergunta = new Pergunta()
                                          {
                                              Id = p.Id,
                                              Descricao = p.Descricao,
                                              OrdemPergunta = p.OrdemPergunta,
                                              ComponenteCurricular = p.ComponenteCurricular,
                                              ComponenteCurricularId = p.ComponenteCurricularId,
                                              Excluido = p.Excluido
                                          },
                                          Resposta = new Resposta()
                                          {
                                              Id = r.Id,
                                              Descricao = r.Descricao,
                                              Excluido = r.Excluido,
                                              Verdadeiro = r.Verdadeiro
                                          },
                                          Ordenacao = pr.Ordenacao,
                                          Excluido = pr.Excluido,
                                          PerguntaAnoEscolar = new PerguntaAnoEscolar()
                                          {
                                              Id = pr.PerguntaAnoEscolar.Id
                                          }
                                      }).ToListAsync();

            if (perguntasRespostas == null || !perguntasRespostas.Any())
                throw new Exception("Não foi possivel obter as respostas da sondagem");

            return perguntasRespostas;
        }

        private async Task<List<PerguntaDto>> ObterPerguntas(int anoEscolar, List<PerguntaDto> perguntas, int anoLetivo, SMEManagementContextData contexto)
        {
            try
            {
                perguntas = await contexto.PerguntaAnoEscolar.Include(x => x.Pergunta).Where(perguntaAnoEscolar => perguntaAnoEscolar.AnoEscolar == anoEscolar
                    && ((perguntaAnoEscolar.FimVigencia == null && (perguntaAnoEscolar.InicioVigencia.HasValue ? perguntaAnoEscolar.InicioVigencia.Value.Year : 0) <= anoLetivo)
                    || (perguntaAnoEscolar.FimVigencia.HasValue ? perguntaAnoEscolar.FimVigencia.Value.Year : 0) >= anoLetivo))
                        .Select(x => MapearPergunta(x)).ToListAsync();

                if (perguntas == null || !perguntas.Any())
                    throw new Exception("Não foi possivel obter as perguntas da sondagem");

                return perguntas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel obter as perguntas da sondagem, {ex.Message}");
            }
        }

        private PerguntaDto MapearPergunta(PerguntaAnoEscolar perguntaAnoEscolar)
        {
            var retorno = (PerguntaDto)perguntaAnoEscolar.Pergunta;

            if (retorno == null)
                return default;

            retorno.Ordenacao = perguntaAnoEscolar.Ordenacao;
            retorno.PerguntaAnoEscolar = perguntaAnoEscolar.Id;

            return retorno;
        }

    }
}
