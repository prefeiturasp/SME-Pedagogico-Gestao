using Dapper;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using MoreLinq.Extensions;
using Npgsql;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class SondagemAutoralBusiness
    {
        private readonly IServicoTelemetria servicoTelemetria;
        private readonly string connectionString;

        public SondagemAutoralBusiness(IServicoTelemetria servicoTelemetria)
        {
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
                return await Task.FromResult(periodos.Select(x => (PeriodoDto)x));
            }
        }

        public async Task<bool> ConsultarSePeriodoEstaAberto(int bimestre, string anoLetivo)
        {
            bool periodoAberto = false;

            using (var contexto = new SMEManagementContextData())
            {
                var periodos = await contexto.PeriodoDeAberturas
                    .Where(x => x.Bimestre.Equals(bimestre) && x.Ano.Equals(anoLetivo) && DateTime.Now >= x.DataInicio && DateTime.Now <= x.DataFim)
                    .ToListAsync();

                if (periodos?.Count() > 0)
                    periodoAberto = true;
            }

            return await Task.FromResult(periodoAberto);
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

                if (alunoSondagemMatematicaDto.FirstOrDefault().AnoLetivo < 2022)
                    await SalvarSonsagemMatermaticaPorPeriodo(alunoSondagemMatematicaDto, listaIdPeriodos, filtroSondagem);
                else
                    await SalvarSonsagemMatermaticaPorBimestre(alunoSondagemMatematicaDto, filtroSondagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SalvarSonsagemMatermaticaPorBimestre(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto,
            FiltrarListagemMatematicaDTO filtroSondagem)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var lista = ObterListaDeIdsDeAlunoPorTurma(filtroSondagem.CodigoTurma, filtroSondagem.Bimestre);

                foreach (var aluno in alunoSondagemMatematicaDto)
                {
                    if (!filtroSondagem.Bimestre.HasValue)
                        throw new ArgumentNullException("bimestre", "Necessário informa o bimestre para gravar Sondagem a partir de 2022");

                    if (aluno.Respostas != null)
                    {
                        if (string.IsNullOrEmpty(aluno.Id))
                        {
                            var id = ObterIdDoAlunoSePossuirSondagem(aluno.CodigoAluno, lista);

                            if (id.HasValue)
                                aluno.Id = id.ToString();
                        }

                        //-> Primeira sondagem do aluno
                        var sondagem = await ObterSondagemAutoralMatematicaPorAlunoId(filtroSondagem, contexto, aluno.Id);

                        if (string.IsNullOrEmpty(aluno.Id) || (!string.IsNullOrEmpty(aluno.Id) && sondagem == null))
                        {
                            var novaSondagem = CriaNovaSondagem(new List<AlunoSondagemMatematicaDto>() { aluno }, null, filtroSondagem);
                            novaSondagem.PeriodoId = novaSondagem.PeriodoId ?? string.Empty;

                            await contexto.Sondagem.AddAsync(novaSondagem);
                            await contexto.SaveChangesAsync();

                            continue;
                        }

                        //-> Aluno já possui sondagem
                        AdicionaOUAlteraAlunosERespostas(contexto, sondagem, aluno, filtroSondagem.Bimestre);

                        contexto.Sondagem.Update(sondagem);
                        await contexto.SaveChangesAsync();

                        continue;
                    }
                }
            }
        }

        private async Task SalvarSonsagemMatermaticaPorPeriodo(IEnumerable<AlunoSondagemMatematicaDto> alunoSondagemMatematicaDto,
            IEnumerable<string> listaIdPeriodos, FiltrarListagemMatematicaDTO filtroSondagem)
        {
            foreach (var periodoId in listaIdPeriodos)
            {
                using (var contexto = new SMEManagementContextData())
                {
                    var sondagem = await ObterSondagemAutoralMatematicaPorPeriodo(filtroSondagem, periodoId, contexto);

                    if (sondagem != null)
                    {
                        foreach (var aluno in alunoSondagemMatematicaDto)
                            AdicionaOUAlteraAlunosERespostas(contexto, sondagem, aluno, filtroSondagem.Bimestre);

                        contexto.Sondagem.Update(sondagem);
                        await contexto.SaveChangesAsync();

                        continue;
                    }

                    var novaSondagem = CriaNovaSondagem(alunoSondagemMatematicaDto, periodoId, filtroSondagem);
                    await contexto.Sondagem.AddAsync(novaSondagem);
                    await contexto.SaveChangesAsync();
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
            var alunoSondagem = sondagem.AlunosSondagem
                .Where(a => a.CodigoAluno.Equals(aluno.CodigoAluno) && a.Id.ToString() == aluno.Id).FirstOrDefault();

            //-> Criar aluno e respostas caso não exista
            if (alunoSondagem == null)
            {
                if (sondagem.AnoLetivo < 2022)
                {
                    if (sondagem.PeriodoId.Length == 0)
                        return;

                    if (!aluno.Respostas.Any(c => c.PeriodoId == sondagem.PeriodoId))
                    {
                        var alunoNovoSondagem = CriaNovoAlunoSondagem(sondagem, aluno, bimestre);
                        sondagem.AlunosSondagem.Add(alunoNovoSondagem);
                        return;
                    }
                }
                else
                {
                    if (bimestre.GetValueOrDefault() == 0)
                        return;

                    if (!aluno.Respostas.Any(c => c.Bimestre == bimestre))
                    {
                        var alunoNovoSondagem = CriaNovoAlunoSondagem(sondagem, aluno, bimestre);
                        sondagem.AlunosSondagem.Add(alunoNovoSondagem);
                        return;
                    }
                }
            }

            //-> Atualizar aluno e respostas caso existam
            if (aluno.Respostas != null)
            {
                AtualizaNovasRespostas(aluno, alunoSondagem, sondagem.PeriodoId, sondagem.AnoLetivo, bimestre);
                RemoveRespostasSemValor(contexto, aluno, alunoSondagem);
            }
        }

        private static void AtualizaNovasRespostas(AlunoSondagemMatematicaDto aluno, SondagemAluno alunoSondagem, string periodoId, int anoLetivo, int? bimestre)
        {
            foreach (var respostaAluno in aluno.Respostas)
            {
                var respostaSondagemAluno = alunoSondagem.ListaRespostas
                    .Where(x => x.PerguntaId == respostaAluno.Pergunta).FirstOrDefault();

                //-> Criar respostas caso não existam
                if (respostaSondagemAluno == null)
                {
                    var respostaNova = CriaNovaRespostaAluno(alunoSondagem, respostaAluno);
                    alunoSondagem.ListaRespostas.Add(respostaNova);
                    continue;
                }

                if (anoLetivo < 2022)
                {
                    if (periodoId.Length == 0)
                        continue;

                    if (!aluno.Respostas.Any(c => c.PeriodoId == periodoId))
                    {
                        var respostaNova = CriaNovaRespostaAluno(alunoSondagem, respostaAluno);
                        alunoSondagem.ListaRespostas.Add(respostaNova);
                        continue;
                    }
                }
                else 
                {
                    if (bimestre.GetValueOrDefault() == 0)
                        continue;

                    if (!aluno.Respostas.Any(c => c.Bimestre == bimestre))
                    {
                        var respostaNova = CriaNovaRespostaAluno(alunoSondagem, respostaAluno);
                        alunoSondagem.ListaRespostas.Add(respostaNova);
                        continue;
                    }
                }

                //-> Atualiar com a nova resposta
                respostaSondagemAluno.RespostaId = respostaAluno.Resposta;
            }
        }

        private static void RemoveRespostasSemValor(SMEManagementContextData contexto, AlunoSondagemMatematicaDto aluno, SondagemAluno alunoSondagem)
        {
            var ListaRespostasRemovidas = new List<SondagemAlunoRespostas>();

            if (alunoSondagem.ListaRespostas.Any(x => x.RespostaId != ""))
            {
                foreach (var alunoResposta in alunoSondagem.ListaRespostas)
                {
                    var respostaSondagem = aluno.Respostas
                        .Where(x => x.Pergunta == alunoResposta.PerguntaId && x.Resposta != "").FirstOrDefault();

                    if (respostaSondagem == null)
                        ListaRespostasRemovidas.Add(alunoResposta);
                }

                if (ListaRespostasRemovidas.Count > 0)
                    contexto.SondagemAlunoRespostas.RemoveRange(ListaRespostasRemovidas);
            }
            else
                contexto.SondagemAluno.Remove(alunoSondagem);
        }

        private Sondagem CriaNovaSondagem(IEnumerable<AlunoSondagemMatematicaDto> ListaAlunosSondagemDto, string periodoId, FiltrarListagemMatematicaDTO alunoFiltro)
        {
            var listaAlunosComRespostaDto = ListaAlunosSondagemDto.Where(x => x.Respostas != null).ToList();
            var bimestre = listaAlunosComRespostaDto.FirstOrDefault().Respostas.FirstOrDefault().Bimestre;

            if (listaAlunosComRespostaDto == null || listaAlunosComRespostaDto.Count == 0)
                return null;

            var listaAlunosComRespostasDoPeriodoDto = new List<AlunoSondagemMatematicaDto>();

            if (listaAlunosComRespostaDto.FirstOrDefault().AnoLetivo < 2022)
                listaAlunosComRespostasDoPeriodoDto = listaAlunosComRespostaDto.Where(a => a.Respostas.Any(r => r.PeriodoId == periodoId)).ToList();
            else
                listaAlunosComRespostasDoPeriodoDto = listaAlunosComRespostaDto.Where(c => c.Bimestre == bimestre).ToList();

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
            var resposta = new SondagemAlunoRespostas
            {
                Id = Guid.NewGuid(),
                PerguntaId = respostaDto.Pergunta,
                RespostaId = respostaDto.Resposta,
                SondagemAlunoId = aluno.Id,
                Bimestre = respostaDto.Bimestre
            };

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

            var listaRespostasAluno = Enumerable.Empty<AlunoRespostaDto>();

            if (alunoDto.AnoLetivo < 2022)
                listaRespostasAluno = alunoDto.Respostas.Where(r => r.PeriodoId == sondagem.PeriodoId);
            else
                listaRespostasAluno = alunoDto.Respostas.Where(c => c.Bimestre == bimestre);

            foreach (var respostaAluno in listaRespostasAluno)
            {
                var resposta = CriaNovaRespostaAluno(aluno, respostaAluno);
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
                        perguntaId = ObterPerguntaDaSondagem(alunoDto);

                    foreach (var periodo in periodos)
                    {
                        if (alunoDto.Respostas.Any(r => r.PeriodoId == periodo.Id))
                            periodosRespostas.Add(periodo.Id);
                    }
                }
            };

            return await Task.FromResult(perguntaId);
        }

        private string ObterPerguntaDaSondagem(AlunoSondagemMatematicaDto alunoDto)
        {
            var resposta = alunoDto.Respostas.First();
            return resposta.Pergunta;
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
                var alunoSalvar = await CriarObjetoSalvar(contexto, resposta, alunoAutoral);
                await AdicicionarOuAlterar(contexto, alunoSalvar);
            }
        }

        private async Task<SondagemAutoral> CriarObjetoSalvar(SMEManagementContextData contexto, AlunoRespostaDto resposta, SondagemAutoral alunoAutoral)
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
                context.SondagemAutoral.Update(sondagemAutoral);
        }

        private static async Task<Sondagem> ObterSondagemAutoralMatematicaPorPeriodo(FiltrarListagemMatematicaDTO filtrarListagemDto, string periodoId, SMEManagementContextData contexto)
        {
            return await contexto.Sondagem.Where(s => s.PeriodoId == periodoId &&
                s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                s.CodigoDre == filtrarListagemDto.CodigoDre &&
                s.CodigoUe == filtrarListagemDto.CodigoUe &&
                s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                s.CodigoTurma == filtrarListagemDto.CodigoTurma)
                .Include(x => x.AlunosSondagem)
                .ThenInclude(x => x.ListaRespostas)
                .FirstOrDefaultAsync();
        }

        private static async Task<Sondagem> ObterSondagemAutoralMatematicaPorAlunoId(FiltrarListagemMatematicaDTO filtrarListagemDto,
            SMEManagementContextData contexto, string alunoId)
        {
            if (string.IsNullOrEmpty(alunoId))
                return null;

            return await contexto.Sondagem.Where(s => s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                s.Bimestre == filtrarListagemDto.Bimestre &&
                s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                s.CodigoDre == filtrarListagemDto.CodigoDre &&
                s.CodigoUe == filtrarListagemDto.CodigoUe &&
                s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                s.CodigoTurma == filtrarListagemDto.CodigoTurma &&
                // TODO s.AlunosSondagem.Any(a => a.ListaRespostas.Any(lr => lr.PerguntaId.Equals(filtrarListagemDto.PerguntaId)) && a.Id.ToString().Equals(alunoId)))
                s.AlunosSondagem.Any(a => a.Id.ToString() == alunoId))
                .Include(x => x.AlunosSondagem)
                .ThenInclude(x => x.ListaRespostas)
                .ThenInclude(x => x.Resposta)
                .FirstOrDefaultAsync();
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
                    s.CodigoTurma == filtrarListagemDto.CodigoTurma)
                    .Include(x => x.AlunosSondagem)
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
                     inner join ""SondagemAlunoRespostas"" sar
                         on sar.""SondagemAlunoId"" = sa.""Id""
                     where s.""CodigoTurma"" = @turmaCodigo
                       and sa.""CodigoAluno"" = @alunoCodigo
                       and sar.""PerguntaId"" = @perguntaId";

            using (var conexao = new NpgsqlConnection(connectionString))
            {
                var result = await conexao.QueryAsync<SondagemAlunoRespostaDTO>(sql, new { turmaCodigo, alunoCodigo, perguntaId }, queryName: "Obter Respostas");
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

                return await Task.FromResult(agrupamentoSondagem);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel obter os dados da sondagem, {ex.Message}");
            }
        }

        private List<Tuple<string, Guid>> ObterListaDeIdsDeAlunoPorTurma(string codigoTurma, int? bimestre)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var lista = contexto.SondagemAluno.Where(x => x.ListaRespostas.Any(lr => lr.Bimestre == bimestre) 
                    && x.Sondagem.CodigoTurma == codigoTurma)
                    .Select(a => new Tuple<string, Guid>(a.CodigoAluno, a.Id))
                    .ToList();

                return lista;
            }
        }

        private static Guid? ObterIdDoAlunoSePossuirSondagem(string codigoAluno, List<Tuple<string, Guid>> listaAlunos)
        {
            return listaAlunos.FirstOrDefault(x => x.Item1 == codigoAluno)?.Item2;
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
                    sql += $@" and(pae.""FimVigencia"" is null and extract(year from pae.""InicioVigencia"") <= {anoLetivo})";
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

                return await Task.FromResult(perguntas);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel obter as perguntas da sondagem, {ex.Message}");
            }
        }
    }
}
