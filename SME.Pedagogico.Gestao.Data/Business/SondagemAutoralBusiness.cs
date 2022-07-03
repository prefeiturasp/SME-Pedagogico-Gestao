using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoreLinq;
using MoreLinq.Extensions;
using Npgsql;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class SondagemAutoralBusiness
    {
        private string _token;
        private TurmasAPI TurmaApi;
        private readonly IServicoTelemetria servicoTelemetria;
        private string connectionString;

        public SondagemAutoralBusiness(IConfiguration config, IServicoTelemetria servicoTelemetria)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
            TurmaApi = new TurmasAPI(new EndpointsAPI());
            connectionString = Environment.GetEnvironmentVariable("sondagemConnection");

            this.servicoTelemetria = servicoTelemetria ?? throw new ArgumentNullException(nameof(servicoTelemetria));
        }

        public async Task<IEnumerable<PerguntaDto>> ObterPerguntas(int anoEscolar, int anoLetivo)
        {
            List<PerguntaDto> perguntas = new List<PerguntaDto>();
            IEnumerable<PerguntaDto> retorno = null;
            using (var contexto = new SMEManagementContextData())
            {
                perguntas = await ObterPerguntas(anoEscolar, perguntas, anoLetivo, contexto);
            }
            retorno = perguntas.OrderBy(x => x.Ordenacao);
            if (retorno == null)
                retorno = new List<PerguntaDto>();
            return retorno;
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

        private List<AlunosNaTurmaDTO> VerificaSituacaoMatriculaERetornaAlunosTurma(List<AlunosNaTurmaDTO> alunosTurma,int anoLetivo, int? bimestre)
        {
            DateTime periodoFimBimestre = DateTime.MinValue;
            DateTime periodoInicioBimestre = DateTime.MinValue;

            if (bimestre != null)
            {
                using (var contexto = new SMEManagementContextData())
                {
                   periodoFimBimestre = contexto.PeriodoFixoAnual.Where(p => p.TipoPeriodo == Models.Enums.TipoPeriodoEnum.Bimestre &&
                   p.Ano == anoLetivo && p.Descricao.Contains(bimestre.ToString())).Select(pa=> pa.DataFim).FirstOrDefault();
                   periodoInicioBimestre = contexto.PeriodoFixoAnual.Where(p => p.TipoPeriodo == Models.Enums.TipoPeriodoEnum.Bimestre &&
                  p.Ano == anoLetivo && p.Descricao.Contains(bimestre.ToString())).Select(pa => pa.DataInicio).FirstOrDefault();
                };
            }

            return alunosTurma.Where(x => x.CodigoSituacaoMatricula == (int)SituacaoMatriculaAluno.Rematriculado
                                       || x.CodigoSituacaoMatricula == (int)SituacaoMatriculaAluno.Ativo
                                       || x.CodigoSituacaoMatricula == (int)SituacaoMatriculaAluno.PendenteRematricula
                                       || x.CodigoSituacaoMatricula == (int)SituacaoMatriculaAluno.SemContinuidade
                                       || x.CodigoSituacaoMatricula == (int)SituacaoMatriculaAluno.Concluido
                                       || (periodoFimBimestre > DateTime.MinValue && SituacoesAlunoInativo().Contains(x.CodigoSituacaoMatricula)
                                       && (x.DataSituacao >= periodoFimBimestre || x.DataSituacao <= periodoFimBimestre && x.DataSituacao >= periodoInicioBimestre))).ToList();
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

        private List<int> SituacoesAlunoInativo()
        {
            return new List<int>
            {
                (int)SituacaoMatriculaAluno.Desistente,
                (int)SituacaoMatriculaAluno.Transferido,
                (int)SituacaoMatriculaAluno.VinculoIndevido,
                (int)SituacaoMatriculaAluno.Falecido,
                (int)SituacaoMatriculaAluno.NaoCompareceu,
                (int)SituacaoMatriculaAluno.Deslocamento,
                (int)SituacaoMatriculaAluno.Cessado,
                (int)SituacaoMatriculaAluno.RemanejadoSaida,
                (int)SituacaoMatriculaAluno.ReclassificadoSaida
            };
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
            using (var contexto = new SMEManagementContextData())
            {
                var lista = ObterListaDeIdsDeAlunoPorTurma(filtroSondagem.CodigoTurma, filtroSondagem.Bimestre);
                foreach (var aluno in alunoSondagemMatematicaDto)
                {
                    if (!filtroSondagem.Bimestre.HasValue)
                        throw new ArgumentNullException("bimestre", "Necessário informa o bimestre para gravar Sondagem a partir de 2022");

                    if (aluno.Id == null && aluno.Respostas != null)
                    {                        
                        var id = ObterIdDoAlunoSePossuirSondagem(aluno.CodigoAluno, lista);

                        if (id.HasValue)
                            aluno.Id = id.ToString();
                    }

                    if (aluno.Id == null)
                    {
                        if (aluno.Respostas != null)
                        {
                            var novaSondagem = CriaNovaSondagem(new List<AlunoSondagemMatematicaDto>() { aluno }, null, filtroSondagem);
                            novaSondagem.PeriodoId = novaSondagem.PeriodoId == null ? string.Empty : novaSondagem.PeriodoId;
                            contexto.Sondagem.Add(novaSondagem);                           
                        }
                    }
                    else
                    {
                        var sondagem = await ObterSondagemAutoralMatematicaPorId(filtroSondagem, contexto, aluno.Id);
                        if (sondagem != null)
                        {
                            AdicionaOUAlteraAlunosERespostas(contexto, sondagem, aluno, filtroSondagem.Bimestre);
                            contexto.Sondagem.Update(sondagem);
                        }
                        else
                        {
                            var novaSondagem = CriaNovaSondagem(alunoSondagemMatematicaDto, null, filtroSondagem);
                            novaSondagem.PeriodoId = novaSondagem.PeriodoId == null ? string.Empty : novaSondagem.PeriodoId;
                            contexto.Sondagem.Add(novaSondagem);
                        }
                    }
                }

                await contexto.SaveChangesAsync();
            }
        }

        private async Task SalvarSonsagemMatermaticaPorPeriodo(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto, IEnumerable<string> listaIdPeriodos, FiltrarListagemMatematicaDTO filtroSondagem)
        {
            foreach (var periodoId in listaIdPeriodos)
            {
                using (var contexto = new SMEManagementContextData())
                {
                    var sondagem = await ObterSondagemAutoralMatematicaPorPeriodo(filtroSondagem, periodoId, contexto);
                    if (sondagem != null)
                    {
                        foreach (var aluno in alunoSondagemMatematicaDto)
                        {
                            AdicionaOUAlteraAlunosERespostas(contexto, sondagem, aluno, filtroSondagem.Bimestre);
                        }
                        contexto.Sondagem.Update(sondagem);
                        await contexto.SaveChangesAsync();
                    }
                    else
                    {
                        var novaSondagem = CriaNovaSondagem(alunoSondagemMatematicaDto, periodoId, filtroSondagem);
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

        private static void AdicionaOUAlteraAlunosERespostas(SMEManagementContextData contexto, Sondagem sondagem, AlunoSondagemMatematicaDto aluno, int? bimestre)
        {
            var alunoSondagem = sondagem.AlunosSondagem.Where(a => a.CodigoAluno.Equals(aluno.CodigoAluno) && a.Id.ToString() == aluno.Id).FirstOrDefault();
            if (alunoSondagem != null)
            {
                if (aluno.Respostas != null)
                {
                    AtualizaNovasRespostas(aluno, alunoSondagem, sondagem.PeriodoId, bimestre);
                    RemoveRespostasSemValor(contexto, aluno, alunoSondagem);
                }
            }
            else
            {
                if (aluno.Respostas != null && sondagem.AnoLetivo < 2022)
                {
                    if (aluno.Respostas.Any(r => r.PeriodoId == (sondagem.PeriodoId.Length > 0 ? sondagem.PeriodoId : null)))
                    {
                        var alunoNovoSondagem = CriaNovoAlunoSondagem(sondagem, aluno, bimestre);
                        sondagem.AlunosSondagem.Add(alunoNovoSondagem);
                    }
                }
                else if (sondagem.AnoLetivo >= 2022 && aluno.Respostas?.Count() > 0)
                {
                    var alunoNovoSondagem = CriaNovoAlunoSondagem(sondagem, aluno, bimestre);
                    sondagem.AlunosSondagem.Add(alunoNovoSondagem);
                }
            }
        }

        private static void AtualizaNovasRespostas(AlunoSondagemMatematicaDto aluno, SondagemAluno alunoSondagem, string periodoId, int? bimestre)
        {
            foreach (var resposta in aluno.Respostas)
            {
                var respostaSondagem = alunoSondagem.ListaRespostas.Where(x => x.PerguntaId == resposta.Pergunta).FirstOrDefault();
                if (respostaSondagem != null && (aluno.Respostas.Any(r => r.PeriodoId == periodoId) || aluno.Respostas.Any(r => r.Bimestre == bimestre)))
                    respostaSondagem.RespostaId = resposta.Resposta;
                else
                {
                    var respostaNova = CriaNovaRespostaAluno(alunoSondagem, resposta);
                    alunoSondagem.ListaRespostas.Add(respostaNova);
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
                    {
                        ListaRespostasRemovidas.Add(alunoResposta);
                    }
                }
                if (ListaRespostasRemovidas.Count > 0)
                    contexto.SondagemAlunoRespostas.RemoveRange(ListaRespostasRemovidas);
            }
            else
            {
                contexto.SondagemAluno.Remove(alunoSondagem);
            }
        }

        private Sondagem CriaNovaSondagem(IEnumerable<AlunoSondagemMatematicaDto> ListaAlunosSondagemDto, string periodoId, FiltrarListagemMatematicaDTO alunoFiltro)
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
                var aluno = CriaNovoAlunoSondagem(sondagem, alunoDto, bimestre);

                sondagem.AlunosSondagem.Add(aluno);
            };

            return sondagem;
        }

        private static SondagemAlunoRespostas CriaNovaRespostaAluno(SondagemAluno aluno, AlunoRespostaDto respostaDto)
        {
            var resposta = new SondagemAlunoRespostas();
            resposta.Id = Guid.NewGuid();
            resposta.PerguntaId = respostaDto.Pergunta;
            resposta.RespostaId = respostaDto.Resposta;
            resposta.SondagemAlunoId = aluno.Id;
            resposta.Bimestre = respostaDto.Bimestre;
            return resposta;
        }

        private static SondagemAluno CriaNovoAlunoSondagem(Sondagem sondagem, AlunoSondagemMatematicaDto alunoDto, int? bimestre)
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
                var resposta = CriaNovaRespostaAluno(aluno, respostaDto);
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

        private static void MapearRespostas(PerguntaDto pergunta, IEnumerable<PerguntaResposta> respostasDaPergunta)
        {
            pergunta.Respostas = respostasDaPergunta.Select(perguntaResposta => new RespostaDto
            {
                Descricao = perguntaResposta.Resposta.Descricao,
                Id = perguntaResposta.Resposta.Id,
                Ordenacao = perguntaResposta.Ordenacao
            });
        }

        private static async Task<Sondagem> ObterSondagemAutoralMatematicaPorPeriodo(FiltrarListagemMatematicaDTO filtrarListagemDto, string periodoId, SMEManagementContextData contexto)
        {
            return await contexto.Sondagem.Where(s => s.PeriodoId == periodoId &&
                                                      s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                                      s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                                      s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                                      s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                                      s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                                      s.CodigoTurma == filtrarListagemDto.CodigoTurma).
                                                      Include(x => x.AlunosSondagem).ThenInclude(x => x.ListaRespostas).FirstOrDefaultAsync();
        }

        private static async Task<Sondagem> ObterSondagemAutoralMatematicaPorBimestre(FiltrarListagemMatematicaDTO filtrarListagemDto, SMEManagementContextData contexto)
        {
            try
            {
                var retorno = await contexto.Sondagem.Where(s => s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                                 s.Bimestre == filtrarListagemDto.Bimestre &&
                                                 s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                                 s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                                 s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                                 s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                                 s.CodigoTurma == filtrarListagemDto.CodigoTurma &&
                                                 s.AlunosSondagem.Any(a => a.ListaRespostas.Any(lr => lr.PerguntaId.Equals(filtrarListagemDto.PerguntaId)))).
                                                  Include(x => x.AlunosSondagem).ThenInclude(x => x.ListaRespostas).ThenInclude(x => x.Resposta).ToListAsync();

                return retorno.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static async Task<Sondagem> ObterSondagemAutoralMatematicaPorId(FiltrarListagemMatematicaDTO filtrarListagemDto, SMEManagementContextData contexto, string id)
        {
            return await contexto.Sondagem.Where(s => s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                                  s.Bimestre == filtrarListagemDto.Bimestre &&
                                                  s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                                  s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                                  s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                                  s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                                  s.CodigoTurma == filtrarListagemDto.CodigoTurma &&
                                                  s.AlunosSondagem.Any(a => a.ListaRespostas.Any(lr => lr.PerguntaId.Equals(filtrarListagemDto.PerguntaId)) && a.Id.ToString().Equals(id))).
                                                   Include(x => x.AlunosSondagem).ThenInclude(x => x.ListaRespostas).ThenInclude(x => x.Resposta).FirstOrDefaultAsync();
        }

        public static async Task<IEnumerable<Sondagem>> ObterSondagemAutoralMatematica(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var sondagem = await contexto.Sondagem.Where(s => s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                                            s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                                            s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                                            s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                                            s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                                            s.CodigoTurma == filtrarListagemDto.CodigoTurma).
                                                             Include(x => x.AlunosSondagem)
                                                                .ThenInclude(x => x.ListaRespostas)
                                                                .ThenInclude(x => x.Resposta).ToListAsync();

                return sondagem;
            }
        }

        public async Task ExcluirRespostasDivergentes(Guid sondagemAlunoId, string respostaId)
        {
            await servicoTelemetria.RegistrarAsync(async () =>
            {
                using (var conexao = new NpgsqlConnection(connectionString))
                {
                    await conexao.ExecuteScalarAsync(@"delete from ""SondagemAlunoRespostaV2"" 
                                where ""SondagemAlunoId"" = @sondagemAlunoId 
                                  and ""RespostaId"" != @respostaId"
                        , new { sondagemAlunoId, respostaId });

                    conexao.Close();
                }
            }, "delete", "Excluir Respostas Divergentes", "");
        }

        public async Task<IEnumerable<SondagemAlunoRespostaDTO>> ObterRespostasDivergentesPorPergunta(string turmaCodigo, string alunoCodigo, string perguntaId)
        {
            var sql = $@"select sar.""Id""
	                    , sar.""PerguntaId""
	                    , sar.""RespostaId""
                      from ""Sondagem"" s
                     inner join ""SondagemAluno"" sa
                         on sa.""SondagemId"" = s.""Id""
                     inner join ""SondagemAlunoRespostasOld"" sar
                         on sar.""SondagemAlunoId"" = sa.""Id""
                     where s.""CodigoTurma"" = @turmaCodigo
                       and sa.""CodigoAluno"" = @alunoCodigo
                       and sar.""PerguntaId"" = @perguntaId
                       and s.""ComponenteCurricularId"" = @componenteCurricularId";

            using (var conexao = new NpgsqlConnection(connectionString))
            {
                var result = await conexao.QueryAsync<SondagemAlunoRespostaDTO>(sql, new { turmaCodigo, alunoCodigo, perguntaId, componenteCurricularId = "c65b2c0a-7a58-4d40-b474-23f0982f14b1" }, queryName: "Obter Respostas");
                conexao.Close();

                return result;
            }
        }

        public async Task<IEnumerable<SondagemRespostasDivergentesDTO>> ObterRespostasDivergentesPorDre(string dreCodigo)
        {
            var sql = $@"select sar.""CodigoTurma""
	                        , sar.""CodigoAluno""
	                        , sar.""PerguntaId""
	                        , sar.""SondagemAlunoId""
	                        , count(distinct sar.""RespostaId"") Qtd
                          from ""SondagemAlunoRespostaV2"" sar
                         where sar.""CodigoDre"" = @dreCodigo
                        group by sar.""CodigoTurma""
	                        , sar.""CodigoAluno""
	                        , sar.""PerguntaId""
	                        , sar.""SondagemAlunoId""
                        having count(distinct sar.""RespostaId"") > 1 ";

            using (var conexao = new NpgsqlConnection(connectionString))
            {
                var resust = await conexao.QueryAsync<SondagemRespostasDivergentesDTO>(sql, new { dreCodigo }, queryName: "Obter Respostas Divergentes");
                conexao.Close();

                return resust;
            }
        }

        public async Task<IEnumerable<Sondagem>> ObterSondagemAutoralMatematicaBimestre(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            var contexto = new SMEManagementContextData();
            try
            {
                var listaSondagemDto = new List<SondagemAutoralDTO>();
                var sql = new StringBuilder();
                sql.AppendLine($@"select s.""Id"" as SondagemId, sa.""Id"" as SondagemAlunoId, sar.""Id"" SondagemAlunoRespostaId,
                                    s.""AnoLetivo"" as AnoLetivo, s.""AnoTurma"" as AnoTurma,
                                    sa.""CodigoAluno"" as CodigoAluno, sa.""NomeAluno"" as NomeAluno, 
                                    s.""ComponenteCurricularId"" as ComponenteCurricular, s.""CodigoUe"" as CodigoUe,
                                    s.""CodigoDre"" as CodigoDre, s.""CodigoTurma"" as CodigoTurma, sar.""RespostaId"" as RespostaId,
                                    sar.""PerguntaId"" as PerguntaId, s.""PeriodoId"" as PeriodoId, s.""Bimestre"" as Bimestre 
                                    from ""Sondagem"" s 
                                    inner join ""SondagemAluno"" sa on sa.""SondagemId""  = s.""Id"" 
                                    inner join ""SondagemAlunoRespostas"" sar on sar.""SondagemAlunoId"" = sa.""Id"" 
                                    where s.""AnoLetivo"" = {filtrarListagemDto.AnoLetivo} and s.""AnoTurma"" = {filtrarListagemDto.AnoEscolar}
                                    and s.""CodigoDre"" = '{filtrarListagemDto.CodigoDre}' and s.""CodigoUe"" = '{filtrarListagemDto.CodigoUe}' 
                                    and s.""ComponenteCurricularId"" = '{filtrarListagemDto.ComponenteCurricular}' 
                                    and sar.""PerguntaId""  = '{filtrarListagemDto.PerguntaId}'
                                    and s.""CodigoTurma"" = '{filtrarListagemDto.CodigoTurma}'
                                    and sar.""Bimestre""  = {filtrarListagemDto.Bimestre}");

                using (var command = contexto.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql.ToString();

                    contexto.Database.OpenConnection();
                    try
                    {
                        using (var reader = await command.ExecuteReaderAsync("AutoralMatematica"))
                        {
                            var sondagemIdOrdinal = reader.GetOrdinal("SondagemId");
                            var sondagemAlunoIdOrdinal = reader.GetOrdinal("SondagemAlunoId");
                            var sondagemAlunoRespostaIdOrdinal = reader.GetOrdinal("SondagemAlunoRespostaId");
                            var anoLetivoOrdinal = reader.GetOrdinal("AnoLetivo");
                            var anoTurmaOrdinal = reader.GetOrdinal("AnoTurma");
                            var codigoDreOrdinal = reader.GetOrdinal("CodigoDre");
                            var codigoUeOrdinal = reader.GetOrdinal("CodigoUe");
                            var codigoTurmaOrdinal = reader.GetOrdinal("CodigoTurma");
                            var respostaIdOrdinal = reader.GetOrdinal("RespostaId");
                            var perguntaIdOrdinal = reader.GetOrdinal("PerguntaId");
                            var periodoIdOrdinal = reader.GetOrdinal("PeriodoId");
                            var bimestreOrdinal = reader.GetOrdinal("Bimestre");
                            var componenteCurricularOrdinal = reader.GetOrdinal("ComponenteCurricular");
                            var nomeAlunoOrdinal = reader.GetOrdinal("NomeAluno");
                            var codigoAlunoOrdinal = reader.GetOrdinal("CodigoAluno");

                            listaSondagemDto = servicoTelemetria.RegistrarComRetorno<List<SondagemAutoralDTO>>(() =>
                            {
                                var listaSondagem = new List<SondagemAutoralDTO>();
                                while (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        var sondagemDto = new SondagemAutoralDTO()
                                        {
                                            SondagemId = reader.GetGuid(sondagemIdOrdinal),
                                            SondagemAlunoId = reader.GetGuid(sondagemAlunoIdOrdinal),
                                            SondagemAlunoRespostaId = reader.GetGuid(sondagemAlunoRespostaIdOrdinal),
                                            AnoLetivo = reader.GetInt32(anoLetivoOrdinal),
                                            AnoTurma = reader.GetInt32(anoTurmaOrdinal),
                                            CodigoDre = reader.GetString(codigoDreOrdinal),
                                            CodigoUe = reader.GetString(codigoUeOrdinal),
                                            CodigoTurma = reader.GetString(codigoTurmaOrdinal),
                                            RespostaId = reader.GetString(respostaIdOrdinal),
                                            PerguntaId = reader.GetString(perguntaIdOrdinal),
                                            PeriodoId = reader.GetString(periodoIdOrdinal),
                                            Bimestre = reader.GetInt32(bimestreOrdinal),
                                            ComponenteCurricular = reader.GetString(componenteCurricularOrdinal),
                                            NomeAluno = reader.GetString(nomeAlunoOrdinal),
                                            CodigoAluno = reader.GetString(codigoAlunoOrdinal),
                                        };
                                        listaSondagem.Add(sondagemDto);
                                    }
                                    reader.NextResult();
                                }
                                return listaSondagem;
                            }, "mapeamento", "Mapeamento DTO", $"{reader.RecordsAffected}");
                        }
                    }
                    finally
                    {
                        contexto.Database.CloseConnection();
                    }
                }

                var agrupamentoSondagem = servicoTelemetria.RegistrarComRetorno<IEnumerable<Sondagem>>(() =>
                    listaSondagemDto.GroupBy(s => new { s.SondagemId, s.AnoLetivo, s.AnoTurma, s.CodigoDre, s.CodigoUe, s.CodigoTurma, s.Bimestre, s.PeriodoId, s.ComponenteCurricular }
                    , (key, sondagem) =>
                      new Sondagem()
                      {
                          Id = key.SondagemId,
                          AnoLetivo = key.AnoLetivo,
                          AnoTurma = key.AnoTurma,
                          CodigoDre = key.CodigoDre,
                          CodigoUe = key.CodigoUe,
                          CodigoTurma = key.CodigoTurma,
                          Bimestre = key.Bimestre,
                          PeriodoId = key.PeriodoId,
                          ComponenteCurricularId = key.ComponenteCurricular,
                          AlunosSondagem = sondagem.GroupBy(x => new { x.SondagemAlunoId, x.CodigoAluno, x.NomeAluno }
                          , (alunoKey, aluno) => new SondagemAluno()
                          {
                              Id = alunoKey.SondagemAlunoId,
                              CodigoAluno = alunoKey.CodigoAluno,
                              NomeAluno = alunoKey.NomeAluno,
                              ListaRespostas = aluno.Select(lr => new SondagemAlunoRespostas()
                              {
                                  Id = lr.SondagemAlunoRespostaId,
                                  PerguntaId = lr.PerguntaId,
                                  RespostaId = lr.RespostaId,
                                  Bimestre = key.Bimestre

                              }).ToList()
                          }).ToList()
                      }).ToList()
                , "agrupamento", "Agrupamento DTO", "");

                return agrupamentoSondagem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel obter os dados da sondagem, {ex.Message}");
            }
        }

        private  List<Tuple<string, Guid>> ObterListaDeIdsDeAlunoPorTurma(string codigoTurma, int? bimestre)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var lista = contexto.SondagemAluno.Where(x => x.ListaRespostas.Any(lr => lr.Bimestre == bimestre) 
                                                  && x.Sondagem.CodigoTurma == codigoTurma).Select(a => new Tuple<string, Guid>(a.CodigoAluno, a.Id)).ToList();

                return lista;
            }
        }

        private static Guid VerificaSeOAlunoPossuiSondagemERetornaId(string codigoAluno, string codigoTurma, int? bimestre)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var idSondagem = contexto.Sondagem.Where(s => s.AlunosSondagem.Any(a => a.CodigoAluno == codigoAluno && a.ListaRespostas.Any(lr => lr.Bimestre == bimestre)) &&
                                                          s.CodigoTurma == codigoTurma).Select(a => a.AlunosSondagem.FirstOrDefault().Id);

                return idSondagem.FirstOrDefault();
            }
        }
        
        private static Guid? ObterIdDoAlunoSePossuirSondagem(string codigoAluno, List<Tuple<string, Guid>> listaAlunos)
        {
            return listaAlunos.FirstOrDefault(x => x.Item1 == codigoAluno)?.Item2;
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

        private async Task<List<PerguntaDto>> ObterPerguntas(int anoEscolar, List<PerguntaDto> perguntas, int anoLetivo, SMEManagementContextData contexto)
        {
            try
            {
                var perguntasAlfabetizacao = new List<PerguntaAlfabetizacaoDto>();

                var sql = $@"select p.""Id"" as ""PerguntaId"",
							p.""Descricao"" as ""PerguntaDescricao"",
							pae.""Ordenacao"" as ""PerguntaOrdenacao"",
							rs.""Id"" as ""RespostaId"",
							rs.""Descricao"" as ""RespostaDescricao"",
							prs.""Ordenacao"" as ""RespostaOrdenacao""
					from ""PerguntaAnoEscolar"" pae
					join ""Pergunta"" p on p.""Id"" = pae.""PerguntaId""
					join ""PerguntaResposta"" prs on prs.""PerguntaId"" = p.""Id""
					join ""Resposta"" rs on rs.""Id"" = prs.""RespostaId""
					where pae.""AnoEscolar"" in ({anoEscolar}) ";
                if (anoLetivo >= 2022)
                    sql += $@" and(pae.""FimVigencia"" is null and extract(year from pae.""InicioVigencia"") <= { anoLetivo})";
                else
                    sql += $@" and extract(year from pae.""InicioVigencia"") <= {anoLetivo}";

                using (var command = contexto.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    contexto.Database.OpenConnection();
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var pergunta = new PerguntaAlfabetizacaoDto()
                                    {
                                        PerguntaPrincipalId = reader["PerguntaId"].ToString(),
                                        PerguntaPrincipalDescricao = reader["PerguntaDescricao"].ToString(),
                                        PerguntaPrincipalOrdenacao = int.Parse(reader["PerguntaOrdenacao"].ToString()),
                                        RespostaId = reader["RespostaId"].ToString(),
                                        RespostaDescricao = reader["RespostaDescricao"].ToString(),
                                        RespostaOrdenacao = int.Parse(reader["RespostaOrdenacao"].ToString()),
                                    };
                                    perguntasAlfabetizacao.Add(pergunta);
                                }
                                reader.NextResult();
                            }
                        }

                    }
                    finally
                    {
                        contexto.Database.CloseConnection();
                    }
                }

                perguntas = perguntasAlfabetizacao.GroupBy(g => new { g.PerguntaPrincipalId, g.PerguntaPrincipalDescricao, g.PerguntaPrincipalOrdenacao }, (key, group) =>
                new PerguntaDto()
                {
                    Id = key.PerguntaPrincipalId,
                    Descricao = key.PerguntaPrincipalDescricao,
                    Ordenacao = key.PerguntaPrincipalOrdenacao,
                    Respostas = group.Select(s => new RespostaDto()
                    {
                        Id = s.RespostaId,
                        Descricao = s.RespostaDescricao,
                        Ordenacao = s.RespostaOrdenacao
                    }).OrderBy(o => o.Ordenacao)
                }).ToList();

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

            return retorno;
        }
    }
}
