using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Models.Academic;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class SondagemMatematica
    {
        private string _token;
        private AlunosAPI alunoAPI;
        public IConfiguration _config;
        private TurmasAPI TurmaApi;

        public SondagemMatematica(IConfiguration config)
        {
            alunoAPI = new AlunosAPI(new EndpointsAPI());
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
            TurmaApi = new TurmasAPI(new EndpointsAPI());
        }

        public async Task InsertPoolCMAsync(List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                foreach (var student in dadosSondagem)
                {
                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
                        var studentPoolCM = db.MathPoolCMs.Where(x =>
                                                                x.TurmaEolCode == student.CodigoEolTurma &&
                                                                 x.AlunoEolCode == student.CodigoEolAluno &&
                                                                 x.Semestre == semestre).FirstOrDefault();

                        if (studentPoolCM == null)
                        {
                            var newStudentPoolCM = new MathPoolCM();
                            newStudentPoolCM.AlunoEolCode = student.CodigoEolAluno;
                            newStudentPoolCM.AlunoNome = student.NomeAluno;
                            newStudentPoolCM.DreEolCode = student.CodigoEolDRE;
                            newStudentPoolCM.EscolaEolCode = student.CodigoEolEscola;
                            newStudentPoolCM.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            newStudentPoolCM.TurmaEolCode = student.CodigoEolTurma;
                            newStudentPoolCM.AnoLetivo = Convert.ToInt32(student.AnoLetivo);
                            newStudentPoolCM.Semestre = semestre;

                            MapValuesPoolCM(student, ref newStudentPoolCM);
                            await db.MathPoolCMs.AddAsync(newStudentPoolCM);
                        }
                        else
                        {
                            MapValuesPoolCM(student, ref studentPoolCM);
                            db.MathPoolCMs.Update(studentPoolCM);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private void MapValuesPoolCM(SondagemMatematicaOrdemDTO studentDTO,
                                     ref MathPoolCM studentPoolCM)
        {
            if (studentPoolCM.Semestre == 1)
            {

                if (studentPoolCM.AnoTurma == 2)
                {
                    studentPoolCM.Ordem3Ideia = studentDTO.Ideia3Semestre1;
                    studentPoolCM.Ordem3Resultado = studentDTO.Resultado3Semestre1;
                }
                else
                {
                    studentPoolCM.Ordem4Ideia = studentDTO.Ideia4Semestre1;
                    studentPoolCM.Ordem4Resultado = studentDTO.Resultado4Semestre1;
                    studentPoolCM.Ordem5Ideia = studentDTO.Ideia5Semestre1;
                    studentPoolCM.Ordem5Resultado = studentDTO.Resultado5Semestre1;
                    studentPoolCM.Ordem6Ideia = studentDTO.Ideia6Semestre1;
                    studentPoolCM.Ordem6Resultado = studentDTO.Resultado6Semestre1;
                    studentPoolCM.Ordem7Ideia = studentDTO.Ideia7Semestre1;
                    studentPoolCM.Ordem7Resultado = studentDTO.Resultado7Semestre1;
                    studentPoolCM.Ordem8Ideia = studentDTO.Ideia8Semestre1;
                    studentPoolCM.Ordem8Resultado = studentDTO.Resultado8Semestre1;
                }

            }
            else if (studentPoolCM.Semestre == 2)
            {

                if (studentPoolCM.AnoTurma == 2)
                {
                    studentPoolCM.Ordem3Ideia = studentDTO.Ideia3Semestre2;
                    studentPoolCM.Ordem3Resultado = studentDTO.Resultado3Semestre2;
                }
                else
                {
                    studentPoolCM.Ordem4Ideia = studentDTO.Ideia4Semestre2;
                    studentPoolCM.Ordem4Resultado = studentDTO.Resultado4Semestre2;
                    studentPoolCM.Ordem5Ideia = studentDTO.Ideia5Semestre2;
                    studentPoolCM.Ordem5Resultado = studentDTO.Resultado5Semestre2;
                    studentPoolCM.Ordem6Ideia = studentDTO.Ideia6Semestre2;
                    studentPoolCM.Ordem6Resultado = studentDTO.Resultado6Semestre2;
                    studentPoolCM.Ordem7Ideia = studentDTO.Ideia7Semestre2;
                    studentPoolCM.Ordem7Resultado = studentDTO.Resultado7Semestre2;
                    studentPoolCM.Ordem8Ideia = studentDTO.Ideia8Semestre2;
                    studentPoolCM.Ordem8Resultado = studentDTO.Resultado8Semestre2;
                }
            }
        }

        public async Task<IEnumerable<AlunoSondagemMatematicaDto>> ObterAlunos(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            var listaSondagem = await ObterSondagemAutoralMatematicaBimestre(filtrarListagemDto);

            var alunos = (await TurmaApi.GetAlunosNaTurma(Convert.ToInt32(filtrarListagemDto.CodigoTurma), filtrarListagemDto.AnoLetivo, _token))
                              .Where(x => x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5)
                              .ToList();

            if (alunos == null || !alunos.Any())
                throw new Exception($"Não encontrado alunos para a turma {filtrarListagemDto.CodigoTurma} do ano letivo {filtrarListagemDto.AnoLetivo}");

            var listagem = new List<AlunoSondagemMatematicaDto>();
            if (listaSondagem.Count > 0)
                MapearAlunosListagemMatematica(listagem, listaSondagem, filtrarListagemDto.Bimestre);

            AdicionarAlunosEOL(filtrarListagemDto, alunos, listagem);

            return listagem.OrderBy(x => x.NumeroChamada);
        }

        private static async Task<List<Sondagem>> ObterSondagemAutoralMatematicaBimestre(FiltrarListagemMatematicaDTO filtrarListagemDto)
        {
            try
            {
                using (var contexto = new SMEManagementContextData())
                {
                    var subPerguntas = filtrarListagemDto.Perguntas != null ? filtrarListagemDto.Perguntas.Split(',').ToArray() : new string[] { filtrarListagemDto.PerguntaId };

                    var listaSondagem = await contexto.Sondagem.Where(s => s.AnoLetivo == filtrarListagemDto.AnoLetivo &&
                                                              s.AnoTurma == filtrarListagemDto.AnoEscolar &&
                                                              s.CodigoDre == filtrarListagemDto.CodigoDre &&
                                                              s.CodigoUe == filtrarListagemDto.CodigoUe &&
                                                              s.ComponenteCurricularId.Equals(filtrarListagemDto.ComponenteCurricular.ToString()) &&
                                                              s.AlunosSondagem.Any(a => a.ListaRespostas.Any(lr => subPerguntas.Contains(lr.PerguntaId))) &&
                                                              s.CodigoTurma == filtrarListagemDto.CodigoTurma).Where(s => s.AlunosSondagem.Any(a => a.ListaRespostas.Any(lr => lr.Bimestre == filtrarListagemDto.Bimestre))).
                                                              Include(x => x.AlunosSondagem).ThenInclude(x => x.ListaRespostas).ThenInclude(x => x.Resposta).ToListAsync();

                    return listaSondagem;
                }
            }
            catch(Exception ex)
            {
                throw ex;
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
                    a.ListaRespostas.Where(x => x.Bimestre == bimestre).ToList().ForEach(r =>
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

                    if (alunoDto.Respostas.Count() > 0)
                    {
                        listaAlunosDto.Add(alunoDto);
                        listCodigoAlunoEol.Add(a.CodigoAluno);
                    }
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

        public async Task<IEnumerable<PerguntaDto>> ObterPerguntas(int anoEscolar, int anoLetivo, int grupo)
        {
            try
            {
                var retornoSondagem = new List<SondagemMatematicaOrdemDTO>();

                using (SMEManagementContextData db = new SMEManagementContextData())
                {
                    var perguntas = (GrupoPerguntaEnum)grupo == GrupoPerguntaEnum.Numeros 
                                    ? await ObterPerguntasGrupoNumeros(db, anoEscolar, anoLetivo, grupo)
                                    : await ObterPerguntasGrupoCACM(db, anoEscolar, anoLetivo, grupo);

                    if (perguntas == null || !perguntas.Any())
                        throw new Exception("Não foi possivel obter as perguntas da sondagem");

                    return perguntas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<PerguntaDto>> ObterPerguntasGrupoCACM(SMEManagementContextData db, int anoEscolar, int anoLetivo, int grupo)
        {
            try
            {
                var perguntasAlfabetizacao = new List<PerguntaAlfabetizacaoDto>();

                var sql = $@"select p.""Id"" as ""PerguntaPrincipalId"",
                                    p.""Descricao"" as ""PerguntaPrincipalDescricao"", 
                                    pae.""Ordenacao"" as ""PerguntaPrincipalOrdenacao"",
                                    ps.""Id"" as ""PerguntaSecundariaId"",                                    
                                    ps.""Descricao"" as ""PerguntaSecundariaDescricao"",                                     
                                    pae2.""Ordenacao"" as ""PerguntaSecundariaOrdenacao"",                                   
                                    rs.""Id"" as ""RespostaId"", 
                                    rs.""Descricao"" as ""RespostaDescricao"", 
                                    prs.""Ordenacao"" as ""RespostaOrdenacao""
                            from ""PerguntaAnoEscolar"" pae
                            join ""Pergunta"" p on p.""Id"" = pae.""PerguntaId""
                            join ""Pergunta"" ps on ps.""PerguntaId"" = pae.""PerguntaId""
                            join ""PerguntaAnoEscolar"" pae2 on pae2.""PerguntaId"" = ps.""Id""
                            join ""PerguntaResposta"" prs on prs.""PerguntaId"" = ps.""Id""
                            join ""Resposta"" rs on rs.""Id"" = prs.""RespostaId""
                            where pae.""AnoEscolar"" in ({anoEscolar}) and pae.""Grupo"" = {grupo}";

                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    db.Database.OpenConnection();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var pergunta = new PerguntaAlfabetizacaoDto() 
                                {
                                    PerguntaPrincipalId = reader["PerguntaPrincipalId"].ToString(),
                                    PerguntaPrincipalDescricao = reader["PerguntaPrincipalDescricao"].ToString(),
                                    PerguntaPrincipalOrdenacao = int.Parse(reader["PerguntaPrincipalOrdenacao"].ToString()),
                                    PerguntaSecundariaId = reader["PerguntaSecundariaId"].ToString(),
                                    PerguntaSecundariaDescricao = reader["PerguntaSecundariaDescricao"].ToString(),
                                    PerguntaSecundariaOrdenacao = int.Parse(reader["PerguntaSecundariaOrdenacao"].ToString()),
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

                var perguntasRespostas = perguntasAlfabetizacao.GroupBy(g => new { g.PerguntaPrincipalId, g.PerguntaPrincipalDescricao, g.PerguntaPrincipalOrdenacao }, (key, group) =>
                new PerguntaDto()
                {
                    Id = key.PerguntaPrincipalId,
                    Descricao = key.PerguntaPrincipalDescricao,
                    Ordenacao = key.PerguntaPrincipalOrdenacao,
                    Perguntas = group.GroupBy(g => new { g.PerguntaSecundariaId, g.PerguntaSecundariaDescricao, g.PerguntaSecundariaOrdenacao }, (key2, group2) =>
                    new PerguntaDto()
                    {
                        Id = key2.PerguntaSecundariaId,
                        Descricao = key2.PerguntaSecundariaDescricao,
                        Ordenacao = key2.PerguntaSecundariaOrdenacao,
                        Respostas = group2.Select(s => new RespostaDto()
                        {
                            Id = s.RespostaId,
                            Descricao = s.RespostaDescricao,
                            Ordenacao = s.RespostaOrdenacao
                        }).OrderBy(o=> o.Ordenacao)
                    }).OrderBy(o => o.Ordenacao)
                }).ToList();

                return perguntasRespostas;               
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<PerguntaDto>> ObterPerguntasGrupoNumeros(SMEManagementContextData db, int anoEscolar, int anoLetivo, int grupo)
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
                            where pae.""AnoEscolar"" in ({anoEscolar}) and pae.""Grupo"" = {grupo}
                            and (pae.""FimVigencia"" is null and extract(year from pae.""InicioVigencia"") <= {anoLetivo})";

                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    db.Database.OpenConnection();
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

                var perguntasRespostas = perguntasAlfabetizacao.GroupBy(g => new { g.PerguntaPrincipalId, g.PerguntaPrincipalDescricao, g.PerguntaPrincipalOrdenacao }, (key, group) =>
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

                return perguntasRespostas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
               

        public async Task<List<SondagemMatematicaOrdemDTO>> ListPoolCMAsync(FiltroSondagemMatematicaDTO filtroSondagem)
        {
            try
            {
                var retornoSondagem = new List<SondagemMatematicaOrdemDTO>();

                using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
                {
                    var sondagemDaTurma = db.MathPoolCMs
                                                        .Where(x => x.TurmaEolCode.Equals(filtroSondagem.TurmaEolCode))
                                                        .ToList();


                    var turmApi = new TurmasAPI(new EndpointsAPI());

                    var classroomStudentsFromAPI = await turmApi.GetAlunosNaTurma(Convert.ToInt32(filtroSondagem.TurmaEolCode), _token);

                    classroomStudentsFromAPI = classroomStudentsFromAPI.Where(x => x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5).ToList();
                    if (classroomStudentsFromAPI == null)
                    {
                        return null;
                    }

                    foreach (var studentClassRoom in classroomStudentsFromAPI)
                    {
                        var studentDTO = new SondagemMatematicaOrdemDTO();
                        if (sondagemDaTurma != null)
                        {
                            var studentPollsMath = sondagemDaTurma.Where(x => x.AlunoEolCode == studentClassRoom.CodigoAluno.ToString()).ToList();
                            studentDTO.NomeAluno = studentClassRoom.NomeAluno;
                            studentDTO.CodigoEolAluno = studentClassRoom.CodigoAluno.ToString();
                            studentDTO.NumeroAlunoChamada = studentClassRoom.NumeroAlunoChamada.ToString();
                            studentDTO.AnoLetivo = filtroSondagem.AnoLetivo;
                            studentDTO.CodigoEolDRE = filtroSondagem.DreEolCode;
                            studentDTO.CodigoEolEscola = filtroSondagem.EscolaEolCode;
                            studentDTO.AnoTurma = filtroSondagem.AnoTurma;
                            studentDTO.CodigoEolTurma = filtroSondagem.TurmaEolCode;

                            if (studentPollsMath?.Count > 0)
                            {
                                for (int semestre = 1; semestre <= 2; semestre++)
                                {
                                    var studentPollMath = studentPollsMath
                                                            .Where(s => s.Semestre == semestre)
                                                            .FirstOrDefault();

                                    if (semestre.Equals(1))
                                    {
                                        if (studentPollMath.AnoTurma == (int)AnoTurmaEnum.SegundoAno)
                                        {
                                            studentDTO.Ideia3Semestre1 = studentPollMath.Ordem3Ideia;
                                            studentDTO.Resultado3Semestre1 = studentPollMath.Ordem3Resultado;
                                        }
                                        else
                                        {
                                            studentDTO.Ideia4Semestre1 = studentPollMath.Ordem4Ideia;
                                            studentDTO.Ideia5Semestre1 = studentPollMath.Ordem5Ideia;
                                            studentDTO.Ideia6Semestre1 = studentPollMath.Ordem6Ideia;
                                            studentDTO.Ideia7Semestre1 = studentPollMath.Ordem7Ideia;
                                            studentDTO.Ideia8Semestre1 = studentPollMath.Ordem8Ideia;
                                            studentDTO.Resultado4Semestre1 = studentPollMath.Ordem4Resultado;
                                            studentDTO.Resultado6Semestre1 = studentPollMath.Ordem5Resultado;
                                            studentDTO.Resultado7Semestre1 = studentPollMath.Ordem6Resultado;
                                            studentDTO.Resultado5Semestre1 = studentPollMath.Ordem7Resultado;
                                            studentDTO.Resultado8Semestre1 = studentPollMath.Ordem8Resultado;
                                        }
                                    }
                                    else if (semestre.Equals(2))
                                    {
                                        if (studentPollMath.AnoTurma == (int)AnoTurmaEnum.SegundoAno)
                                        {
                                            studentDTO.Ideia3Semestre2 = studentPollMath.Ordem3Ideia;
                                            studentDTO.Resultado3Semestre2 = studentPollMath.Ordem3Resultado;
                                        }
                                        else
                                        {
                                            studentDTO.Ideia4Semestre2 = studentPollMath.Ordem4Ideia;
                                            studentDTO.Ideia5Semestre2 = studentPollMath.Ordem5Ideia;
                                            studentDTO.Ideia6Semestre2 = studentPollMath.Ordem6Ideia;
                                            studentDTO.Ideia7Semestre2 = studentPollMath.Ordem7Ideia;
                                            studentDTO.Ideia8Semestre2 = studentPollMath.Ordem8Ideia;
                                            studentDTO.Resultado4Semestre2 = studentPollMath.Ordem4Resultado;
                                            studentDTO.Resultado6Semestre2 = studentPollMath.Ordem5Resultado;
                                            studentDTO.Resultado7Semestre2 = studentPollMath.Ordem6Resultado;
                                            studentDTO.Resultado5Semestre2 = studentPollMath.Ordem7Resultado;
                                            studentDTO.Resultado8Semestre2 = studentPollMath.Ordem8Resultado;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                AddEmptyCMPoolTo(studentDTO);
                            }

                            retornoSondagem.Add(studentDTO);
                        }
                    }
                }
                return retornoSondagem.OrderBy(r => Convert.ToInt32(r.NumeroAlunoChamada)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PollReportMathResult> BuscarDadosRelatorioMatematicaAsync(string proficiency, string semestre, string anoLetivo, string codigoDre, string codigoEscola, string anoTurma, Periodo periodo)
        {
            if (proficiency.Equals("Campo Multiplicativo", StringComparison.InvariantCultureIgnoreCase))
            {
                return await BuscaDadosRelatorioMatCMAsync(semestre, anoLetivo, codigoDre, codigoEscola, anoTurma, periodo);
            }
            else if (proficiency.Equals("Campo Aditivo", StringComparison.InvariantCultureIgnoreCase))
            {
                return await BuscaDadosRelatorioMatCAAsync(semestre, anoLetivo, codigoDre, codigoEscola, anoTurma, periodo);
            }
            else if (proficiency.Equals("Números", StringComparison.InvariantCultureIgnoreCase))
            {
                return await BuscaDadosRelatorioMatNumeros(semestre, anoLetivo, codigoDre, codigoEscola, anoTurma, periodo);
            }

            return default;
        }

        private async Task<PollReportMathResult> BuscaDadosRelatorioMatNumeros(string semestre, string anoLetivo, string codigoDre, string codigoEscola, string anoTurma, Periodo periodo)
        {
            using (SMEManagementContextData db = new SMEManagementContextData())
            {
                IQueryable<MathPoolNumber> query = db.Set<MathPoolNumber>();
                var numbers = new PollReportMathItem();
                var relatorioRetorno = new PollReportMathResult();
                var numberCharts = new List<MathNumeroChartDataModel>();
                int totalAlunos = 0;
                totalAlunos = await ObterQuantidadeAlunoTotal(anoLetivo, codigoDre, codigoEscola, anoTurma, periodo, totalAlunos, db);

                query = db.MathPoolNumbers
                          .Where(x => x.AnoLetivo.ToString() == anoLetivo
                       && x.Semestre.ToString() == semestre.Substring(0, 1));

                if (query.Count() > 1)
                {
                    query = MontaFiltrosGenericosNumeros(codigoDre, codigoEscola, anoTurma, query);

                    var familiaresAgrupados = query.GroupBy(fu => fu.Familiares)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var opacosAgrupados = query.GroupBy(fu => fu.Opacos)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    var transparentesAgrupados = query.GroupBy(fu => fu.Transparentes)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var terminamZeroAgrupados = query.GroupBy(fu => fu.TerminamZero)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    var algarismosAgrupados = query.GroupBy(fu => fu.Algarismos)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var processoAgrupados = query.GroupBy(fu => fu.Processo)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    var zeroIntercaladosAgrupados = query.GroupBy(fu => fu.ZeroIntercalados)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();

                    CreateNumberItem(familiaresAgrupados, grupo: "Familiares/Frequentes", ref numbers, ref numberCharts, totalAlunos);
                    CreateNumberItem(opacosAgrupados, grupo: "Opacos", ref numbers, ref numberCharts, totalAlunos);
                    CreateNumberItem(transparentesAgrupados, grupo: "Transparentes", ref numbers, ref numberCharts, totalAlunos);
                    CreateNumberItem(terminamZeroAgrupados, grupo: "Terminam em zero", ref numbers, ref numberCharts, totalAlunos);
                    CreateNumberItem(algarismosAgrupados, grupo: "Algarismos iguais", ref numbers, ref numberCharts, totalAlunos);
                    CreateNumberItem(processoAgrupados, grupo: "Processo de generalização", ref numbers, ref numberCharts, totalAlunos);
                    CreateNumberItem(zeroIntercaladosAgrupados, grupo: "Zero intercalado", ref numbers, ref numberCharts, totalAlunos);

                    relatorioRetorno.Results = numbers;
                    relatorioRetorno.ChartNumberData.AddRange(numberCharts);

                    return relatorioRetorno;
                }

                return default;
            }
        }

        private IQueryable<MathPoolNumber> MontaFiltrosGenericosNumeros(string codigoDre, string codigoEscola, string anoTurma, IQueryable<MathPoolNumber> query)
        {
            if (!string.IsNullOrWhiteSpace(codigoDre))
            {
                query = query.Where(u => u.DreEolCode == codigoDre);
            }

            if (!string.IsNullOrWhiteSpace(codigoEscola))
            {
                query = query.Where(u => u.EscolaEolCode == codigoEscola);
            }

            if (!string.IsNullOrWhiteSpace(anoTurma))
            {
                query = query.Where(u => u.AnoTurma.ToString() == anoTurma);
            }

            return query;
        }

        private async Task<PollReportMathResult> BuscaDadosRelatorioMatCMAsync(string semestre, string anoLetivo, string codigoDre, string codigoEscola, string anoTurmaParam, Periodo periodo)
        {
            var listReturn = new List<PollReportMathItem>();

            int quantidadeAlunoTotal = 0;

            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                quantidadeAlunoTotal = await ObterQuantidadeAlunoTotal(anoLetivo, codigoDre, codigoEscola, anoTurmaParam, periodo, quantidadeAlunoTotal, db);

                IQueryable<MathPoolCM> query = db.Set<MathPoolCM>();
                var ideasAndResults = new PollReportMathItem();
                var relatorioRetorno = new PollReportMathResult();
                var ideaCharts = new List<MathIdeaChartDataModel>();
                var resultCharts = new List<MathResultChartDataModel>();
                var anoTurma = Convert.ToInt32(anoTurmaParam);

                query = db.MathPoolCMs
                          .Where(x => x.AnoLetivo.ToString() == anoLetivo
                       && x.Semestre.ToString() == semestre.Substring(0, 1));

                if (query.Count() <= 1)
                    return default;

                query = MontaFiltrosGenericosCM(codigoDre, codigoEscola, anoTurmaParam, query);

                if (anoTurma == (int)AnoTurmaEnum.SegundoAno)
                {
                    var ordem3IdeiaAgrupados = query.GroupBy(fu => fu.Ordem3Ideia)
                                        .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                        .ToList();
                    var ordem3ResultadoAgrupados = query.GroupBy(fu => fu.Ordem3Resultado)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();

                    CreateIdeaItem(ordem3IdeiaAgrupados, order: "3", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                    CreateResultItem(ordem3ResultadoAgrupados, order: "3", ref ideasAndResults, ref resultCharts, PollTypeEnum.CM, anoTurma, quantidadeAlunoTotal);
                }
                else
                {
                    if (anoTurma == (int)AnoTurmaEnum.TerceiroAno)
                    {
                        var ordem4IdeiaAgrupados = query.GroupBy(fu => fu.Ordem4Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                        var ordem4ResultadoAgrupados = query.GroupBy(fu => fu.Ordem4Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                        CreateIdeaItem(ordem4IdeiaAgrupados, order: "4", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                        CreateResultItem(ordem4ResultadoAgrupados, order: "4", ref ideasAndResults, ref resultCharts, PollTypeEnum.CM, anoTurma, quantidadeAlunoTotal);
                    }


                    var ordem5IdeiaAgrupados = query.GroupBy(fu => fu.Ordem5Ideia)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                    var ordem5ResultadoAgrupados = query.GroupBy(fu => fu.Ordem5Resultado)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                    CreateIdeaItem(ordem5IdeiaAgrupados, order: "5", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                    CreateResultItem(ordem5ResultadoAgrupados, order: "5", ref ideasAndResults, ref resultCharts, PollTypeEnum.CM, anoTurma, quantidadeAlunoTotal);


                    if (anoTurma != (int)AnoTurmaEnum.TerceiroAno)
                    {
                        var ordem6IdeiaAgrupados = query.GroupBy(fu => fu.Ordem6Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                        var ordem6ResultadoAgrupados = query.GroupBy(fu => fu.Ordem6Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                        CreateIdeaItem(ordem6IdeiaAgrupados, order: "6", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                        CreateResultItem(ordem6ResultadoAgrupados, order: "6", ref ideasAndResults, ref resultCharts, PollTypeEnum.CM, anoTurma, quantidadeAlunoTotal);

                        var ordem7IdeiaAgrupados = query.GroupBy(fu => fu.Ordem7Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                        var ordem7ResultadoAgrupados = query.GroupBy(fu => fu.Ordem7Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                        CreateIdeaItem(ordem7IdeiaAgrupados, order: "7", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                        CreateResultItem(ordem7ResultadoAgrupados, order: "7", ref ideasAndResults, ref resultCharts, PollTypeEnum.CM, anoTurma, quantidadeAlunoTotal);
                    }


                    if (anoTurma != (int)AnoTurmaEnum.TerceiroAno && anoTurma != (int)AnoTurmaEnum.QuartoAno)
                    {
                        var ordem8IdeiaAgrupados = query.GroupBy(fu => fu.Ordem8Ideia)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                        var ordem8ResultadoAgrupados = query.GroupBy(fu => fu.Ordem8Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() }).ToList();
                        CreateIdeaItem(ordem8IdeiaAgrupados, order: "8", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                        CreateResultItem(ordem8ResultadoAgrupados, order: "8", ref ideasAndResults, ref resultCharts, PollTypeEnum.CM, anoTurma, quantidadeAlunoTotal);
                    }

                }

                ideasAndResults.IdeaResults = ideasAndResults.IdeaResults.OrderBy(i => Convert.ToInt32(i.OrderName)).ToList();
                ideasAndResults.ResultResults = ideasAndResults.ResultResults.OrderBy(i => Convert.ToInt32(i.OrderName)).ToList();

                relatorioRetorno.ChartIdeaData.AddRange(ideaCharts.OrderBy(i => Convert.ToInt32(i.Order)));
                relatorioRetorno.ChartResultData.AddRange(resultCharts.OrderBy(i => Convert.ToInt32(i.Order)));

                ideasAndResults.IdeaResults.ForEach(ideia =>
                {
                    double somatorio = ideia.CorrectIdeaQuantity + ideia.NotAnsweredIdeaQuantity + ideia.IncorrectIdeaQuantity;

                    ideia.SemPreenchimento = somatorio > quantidadeAlunoTotal ? 0 : quantidadeAlunoTotal - somatorio;

                    var porcentagem = ideia.SemPreenchimento == 0 ? 0 : 100 - ((somatorio / (double)quantidadeAlunoTotal) * 100);

                    ideia.SemPreenchimentoPorcentagem = porcentagem;
                });

                ideasAndResults.ResultResults.ForEach(result =>
                {
                    double somatorio = result.CorrectResultQuantity + result.IncorrectResultQuantity + result.NotAnsweredResultQuantity;

                    result.SemPreenchimento = somatorio > quantidadeAlunoTotal ? 0 : quantidadeAlunoTotal - somatorio;

                    var porcentagem = result.SemPreenchimento == 0 ? 0 : 100 - ((somatorio / (double)quantidadeAlunoTotal) * 100);

                    result.SemPreenchimentoPorcentagem = porcentagem;
                });

                relatorioRetorno.Results = ideasAndResults;

                return relatorioRetorno;
            }
        }

        private async Task<int> ObterQuantidadeAlunoTotal(string anoLetivo, string codigoDre, string codigoEscola, string anoTurmaParam, Periodo periodo, int quantidadeAlunoTotal, SMEManagementContextData db)
        {
            var periodoFixo = db.PeriodoFixoAnual.FirstOrDefault(fixo => fixo.Ano == Convert.ToInt32(anoLetivo) && fixo.PeriodoId.Equals(periodo.Id));

            if (periodoFixo == null)
                throw new Exception("Não foi encontrado periodo de abertura da sondagem para os filtros informados");

            quantidadeAlunoTotal = await alunoAPI.ObterTotalAlunosAtivosPorPeriodo(new Integracao.DTO.FiltroTotalAlunosAtivos
            {
                AnoLetivo = Convert.ToInt32(anoLetivo),
                AnoTurma = Convert.ToInt32(anoTurmaParam),
                DataFim = periodoFixo.DataFim,
                DataInicio = periodoFixo.DataInicio,
                DreId = codigoDre,
                UeId = codigoEscola
            });

            if (quantidadeAlunoTotal == 0)
                throw new Exception("Não foi possivel obter os alunos ativos para o filtro especificado");
            return quantidadeAlunoTotal;
        }

        private IQueryable<MathPoolCM> MontaFiltrosGenericosCM(string codigoDre, string codigoEscola, string anoTurma, IQueryable<MathPoolCM> query)
        {
            if (!string.IsNullOrWhiteSpace(codigoDre))
            {
                query = query.Where(u => u.DreEolCode == codigoDre);
            }

            if (!string.IsNullOrWhiteSpace(codigoEscola))
            {
                query = query.Where(u => u.EscolaEolCode == codigoEscola);
            }

            if (!string.IsNullOrWhiteSpace(anoTurma))
            {
                query = query.Where(u => u.AnoTurma.ToString() == anoTurma);
            }

            return query;
        }

        private async Task<PollReportMathResult> BuscaDadosRelatorioMatCAAsync(string semestre,
                                                                               string anoLetivo,
                                                                               string codigoDre,
                                                                               string codigoEscola,
                                                                               string anoTurmaParam,
                                                                               Periodo periodo)
        {
            var listReturn = new List<PollReportMathItem>();

            int quantidadeAlunoTotal = 0;

            using (SMEManagementContextData db = new SMEManagementContextData())
            {
                quantidadeAlunoTotal = await ObterQuantidadeAlunoTotal(anoLetivo, codigoDre, codigoEscola, anoTurmaParam, periodo, quantidadeAlunoTotal, db);

                IQueryable<MathPoolCA> query = db.Set<MathPoolCA>();
                var ideasAndResults = new PollReportMathItem();
                var relatorioRetorno = new PollReportMathResult();
                var ideaCharts = new List<MathIdeaChartDataModel>();
                var resultCharts = new List<MathResultChartDataModel>();
                var anoTurma = Convert.ToInt32(anoTurmaParam);

                query = db.MathPoolCAs
                          .Where(x => x.AnoLetivo.ToString() == anoLetivo
                       && x.Semestre.ToString() == semestre.Substring(0, 1));

                if (query.Count() > 1)
                {
                    query = MontaFiltrosGenericosCA(codigoDre, codigoEscola, anoTurmaParam, query);

                    var ordem1Ideia = query.GroupBy(fu => fu.Ordem1Ideia)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var ordem1Resultado = query.GroupBy(fu => fu.Ordem1Resultado)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    var ordem2Ideia = query.GroupBy(fu => fu.Ordem2Ideia)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                    var ordem2Resultado = query.GroupBy(fu => fu.Ordem2Resultado)
                                                .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                .ToList();

                    if (anoTurma != (int)AnoTurmaEnum.SegundoAno)
                    {
                        var ordem3Ideia = query.GroupBy(fu => fu.Ordem3Ideia)
                                            .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                            .ToList();
                        var ordem3Resultado = query.GroupBy(fu => fu.Ordem3Resultado)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();

                        CreateIdeaItem(ordem3Ideia, order: "3", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                        CreateResultItem(ordem3Resultado, order: "3", ref ideasAndResults, ref resultCharts, PollTypeEnum.CA, anoTurma, quantidadeAlunoTotal);
                        if (anoTurma != (int)AnoTurmaEnum.PrimeiroAno && anoTurma != (int)AnoTurmaEnum.TerceiroAno)
                        {
                            var ordem4Ideia = query.GroupBy(fu => fu.Ordem4Ideia)
                                                    .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                    .ToList();
                            var ordem4Resultado = query.GroupBy(fu => fu.Ordem4Resultado)
                                                        .Select(g => new MathGroupByDTO() { Label = g.Key, Value = g.Count() })
                                                        .ToList();

                            CreateIdeaItem(ordem4Ideia, order: "4", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                            CreateResultItem(ordem4Resultado, order: "4", ref ideasAndResults, ref resultCharts, PollTypeEnum.CA, anoTurma, quantidadeAlunoTotal);
                        }
                    }

                    CreateIdeaItem(ordem1Ideia, order: "1", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);
                    CreateIdeaItem(ordem2Ideia, order: "2", ref ideasAndResults, ref ideaCharts, quantidadeAlunoTotal);

                    CreateResultItem(ordem1Resultado, order: "1", ref ideasAndResults, ref resultCharts, PollTypeEnum.CA, anoTurma, quantidadeAlunoTotal);
                    CreateResultItem(ordem2Resultado, order: "2", ref ideasAndResults, ref resultCharts, PollTypeEnum.CA, anoTurma, quantidadeAlunoTotal);


                    ideasAndResults.IdeaResults = ideasAndResults.IdeaResults.OrderBy(i => Convert.ToInt32(i.OrderName)).ToList();
                    ideasAndResults.ResultResults = ideasAndResults.ResultResults.OrderBy(i => Convert.ToInt32(i.OrderName)).ToList();

                    ideasAndResults.IdeaResults.ForEach(ideia =>
                    {
                        double somatorio = ideia.CorrectIdeaQuantity + ideia.NotAnsweredIdeaQuantity + ideia.IncorrectIdeaQuantity;

                        ideia.SemPreenchimento = somatorio >= quantidadeAlunoTotal ? 0 : quantidadeAlunoTotal - somatorio;
                        var porcentagem = ideia.SemPreenchimento == 0 ? 0 : (100.00 / quantidadeAlunoTotal) * ideia.SemPreenchimento;
                        ideia.SemPreenchimentoPorcentagem = porcentagem;
                    });

                    ideasAndResults.ResultResults.ForEach(result =>
                    {
                        double somatorio = result.CorrectResultQuantity + result.IncorrectResultQuantity + result.NotAnsweredResultQuantity;

                        result.SemPreenchimento = somatorio >= quantidadeAlunoTotal ? 0 : quantidadeAlunoTotal - somatorio;
                        result.SemPreenchimentoPorcentagem = result.SemPreenchimento == 0 ? 0 : (100.00 / quantidadeAlunoTotal) * result.SemPreenchimento;
                    });

                    relatorioRetorno.Results = ideasAndResults;
                    relatorioRetorno.ChartIdeaData.AddRange(ideaCharts.OrderBy(i => Convert.ToInt32(i.Order)));
                    relatorioRetorno.ChartResultData.AddRange(resultCharts.OrderBy(i => Convert.ToInt32(i.Order)));

                    return relatorioRetorno;
                }

                return default;
            }
        }

        private static IQueryable<MathPoolCA> MontaFiltrosGenericosCA(string codigoDre, string codigoEscola, string anoTurma, IQueryable<MathPoolCA> query)
        {
            if (!string.IsNullOrWhiteSpace(codigoDre))
            {
                query = query.Where(u => u.DreEolCode == codigoDre);
            }

            if (!string.IsNullOrWhiteSpace(codigoEscola))
            {
                query = query.Where(u => u.EscolaEolCode == codigoEscola);
            }

            if (!string.IsNullOrWhiteSpace(anoTurma))
            {
                query = query.Where(u => u.AnoTurma.ToString() == anoTurma);
            }

            return query;
        }

        private void CreateIdeaItem(List<MathGroupByDTO> ordemIdeia,
                                    string order,
                                    ref PollReportMathItem ideasAndResults,
                                    ref List<MathIdeaChartDataModel> ideaCharts,
                                    int totalAlunos = 0)
        {
            var ideaResults = new List<IdeaChartDTO>();
            var ideaRetorno = new MathItemIdea();
            var ideaChart = new MathIdeaChartDataModel();

            foreach (var item in ordemIdeia)
            {
                if (!item.Label.Trim().Equals(""))
                {
                    if (item.Label.Equals("A", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ideaRetorno.CorrectIdeaQuantity = item.Value;
                    }
                    else if (item.Label.Equals("E", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ideaRetorno.IncorrectIdeaQuantity = item.Value;
                    }
                    else if (item.Label.Equals("NR", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ideaRetorno.NotAnsweredIdeaQuantity = item.Value;
                    }
                }
            }

            if (totalAlunos == 0)
                totalAlunos = ideaRetorno.CorrectIdeaQuantity + ideaRetorno.IncorrectIdeaQuantity + ideaRetorno.NotAnsweredIdeaQuantity;

            if (totalAlunos < 1)
            {
                ideaRetorno.CorrectIdeaPercentage = 0;
                ideaRetorno.IncorrectIdeaPercentage = 0;
                ideaRetorno.NotAnsweredIdeaPercentage = 0;
            }
            else
            {
                ideaRetorno.CorrectIdeaPercentage = ((double)ideaRetorno.CorrectIdeaQuantity / totalAlunos) * 100;
                ideaRetorno.IncorrectIdeaPercentage = ((double)ideaRetorno.IncorrectIdeaQuantity / totalAlunos) * 100;
                ideaRetorno.NotAnsweredIdeaPercentage = ((double)ideaRetorno.NotAnsweredIdeaQuantity / totalAlunos) * 100;
            }
            ideaRetorno.OrderName = order;

            ideasAndResults.IdeaResults.Add(ideaRetorno);
            ideaResults.Add(new IdeaChartDTO() { Description = "Acertou", Quantity = ideaRetorno.CorrectIdeaQuantity });
            ideaResults.Add(new IdeaChartDTO() { Description = "Errou", Quantity = ideaRetorno.IncorrectIdeaQuantity });
            ideaResults.Add(new IdeaChartDTO() { Description = "Não Resolveu", Quantity = ideaRetorno.NotAnsweredIdeaQuantity });
            ideaResults.Add(new IdeaChartDTO() { Description = "Sem preenchimento", Quantity = (totalAlunos - (ideaRetorno.CorrectIdeaQuantity + ideaRetorno.IncorrectIdeaQuantity + ideaRetorno.NotAnsweredIdeaQuantity)) });

            ideaChart.Order = order;
            ideaChart.Idea.AddRange(ideaResults);
            ideaCharts.Add(ideaChart);
        }

        private void CreateResultItem(List<MathGroupByDTO> ordemResult,
                                      string order,
                                      ref PollReportMathItem ideasAndResults,
                                      ref List<MathResultChartDataModel> resultCharts,
                                      PollTypeEnum pollType,
                                      int classroomYear,
                                      int totalAlunos = 0)
        {
            var resultRetorno = new MathItemResult();
            var resultResults = new List<ResultChartDTO>();
            var resultChart = new MathResultChartDataModel();

            foreach (var item in ordemResult)
            {
                if (!item.Label.Trim().Equals(""))
                {
                    if (item.Label.Equals("A"))
                    {
                        resultRetorno.CorrectResultQuantity = item.Value;
                    }
                    else if (item.Label.Equals("E"))
                    {
                        resultRetorno.IncorrectResultQuantity = item.Value;
                    }
                    else if (item.Label.Equals("NR"))
                    {
                        resultRetorno.NotAnsweredResultQuantity = item.Value;
                    }
                }
            }

            if (totalAlunos == 0)
                totalAlunos = resultRetorno.CorrectResultQuantity + resultRetorno.IncorrectResultQuantity + resultRetorno.NotAnsweredResultQuantity;

            if (totalAlunos < 1)
            {
                resultRetorno.CorrectResultPercentage = 0;
                resultRetorno.IncorrectResultPercentage = 0;
                resultRetorno.NotAnsweredResultPercentage = 0;
            }
            else
            {
                resultRetorno.CorrectResultPercentage = ((double)resultRetorno.CorrectResultQuantity / totalAlunos) * 100;
                resultRetorno.IncorrectResultPercentage = ((double)resultRetorno.IncorrectResultQuantity / totalAlunos) * 100;
                resultRetorno.NotAnsweredResultPercentage = ((double)resultRetorno.NotAnsweredResultQuantity / totalAlunos) * 100;
            }
            resultRetorno.OrderName = order;
            resultRetorno.OrderTitle = OrderTitle(pollType, classroomYear, int.Parse(order));

            ideasAndResults.ResultResults.Add(resultRetorno);
            resultResults.Add(new ResultChartDTO() { Description = "Acertou", Quantity = resultRetorno.CorrectResultQuantity });
            resultResults.Add(new ResultChartDTO() { Description = "Errou", Quantity = resultRetorno.IncorrectResultQuantity });
            resultResults.Add(new ResultChartDTO() { Description = "Não Resolveu", Quantity = resultRetorno.NotAnsweredResultQuantity });
            resultResults.Add(new ResultChartDTO() { Description = "Sem preenchimento", Quantity = (totalAlunos - (resultRetorno.CorrectResultQuantity + resultRetorno.IncorrectResultQuantity + resultRetorno.NotAnsweredResultQuantity)) });

            resultChart.Order = order;
            resultChart.Result.AddRange(resultResults);
            resultCharts.Add(resultChart);
        }

        private void CreateNumberItem(List<MathGroupByDTO> ordemIdeia,
                                  string grupo,
                                  ref PollReportMathItem numerosResults,
                                  ref List<MathNumeroChartDataModel> numerosCharts, int totalAlunosEol)
        {
            var numberRetorno = new MathNumberResult();
            var numeroResults = new List<NumeroChartDTO>();
            var numeroCharts = new MathNumeroChartDataModel();

            foreach (var item in ordemIdeia)
            {
                if (!item.Label.Trim().Equals(""))
                {
                    if (item.Label.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                    {
                        numberRetorno.EscreveConvencionalmenteResultado = item.Value;
                        numberRetorno.EscreveConvencionalmenteText = "Escreve convencionalmente";
                    }
                    else if (item.Label.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        numberRetorno.NaoEscreveConvencionalmenteResultado = item.Value;
                        numberRetorno.NaoEscreveConvencionalmenteText = "Não escreve convencionalmente";
                    }


                }
            }

            var ideaTotalStudents = numberRetorno.EscreveConvencionalmenteResultado + numberRetorno.NaoEscreveConvencionalmenteResultado;

            numberRetorno.SemPreenchimentoText = "Sem Preenchimento";
            numberRetorno.SemPreenchimentoResultado = totalAlunosEol - ideaTotalStudents;
            numberRetorno.TotalDeAlunos = totalAlunosEol;
            numberRetorno.TotalPorcentagem = 100;

            if (ideaTotalStudents > 0)
            {
                numberRetorno.EscreveConvencionalmentePercentage = ((double)numberRetorno.EscreveConvencionalmenteResultado / totalAlunosEol) * 100;
                numberRetorno.NaoEscreveConvencionalmentePercentage = ((double)numberRetorno.NaoEscreveConvencionalmenteResultado / totalAlunosEol) * 100;
                numberRetorno.SemPreenchimentoPorcentagem = ((double)numberRetorno.SemPreenchimentoResultado / totalAlunosEol) * 100;
            }
            else
            {
                numberRetorno.EscreveConvencionalmentePercentage = 0;
                numberRetorno.NaoEscreveConvencionalmentePercentage = 0;
                numberRetorno.SemPreenchimentoPorcentagem = 0;
            }

            numberRetorno.GroupName = grupo;

            numerosResults.NumerosResults.Add(numberRetorno);
            numeroResults.Add(new NumeroChartDTO() { Description = "Escreve convencionalmente", Quantity = numberRetorno.EscreveConvencionalmenteResultado });
            numeroResults.Add(new NumeroChartDTO() { Description = "Não escreve convencionalmente", Quantity = numberRetorno.NaoEscreveConvencionalmenteResultado });
            numeroResults.Add(new NumeroChartDTO() { Description = "Sem Preenchimento", Quantity = numberRetorno.SemPreenchimentoResultado });
            numeroCharts.Order = grupo;
            numeroCharts.Numbers.AddRange(numeroResults);
            numerosCharts.Add(numeroCharts);
        }

        /// <summary>
        /// Método para retornar os títulos corretos das ordens da spmdagem de matemática
        /// </summary>
        /// <param name="pollType">Tipo da Sondagem de Matemática CA, CM, Numeric</param>
        /// <param name="classroomYear">Ano da Turma</param>
        /// <returns></returns>
        private string OrderTitle(PollTypeEnum pollType, int classroomYear, int orderNumber)
        {
            string orderTitle = string.Empty;

            switch (classroomYear)
            {
                case 1:
                    switch (pollType)
                    {
                        case PollTypeEnum.CA:
                            orderTitle = "COMPOSIÇÃO";
                            break;
                        default:
                            orderTitle = string.Empty;
                            break;
                    }
                    break;
                case 2:
                    switch (pollType)
                    {
                        case PollTypeEnum.CA:
                            switch (orderNumber)
                            {
                                case 1:
                                    orderTitle = "COMPOSIÇÃO";
                                    break;
                                case 2:
                                    orderTitle = "TRANSFORMAÇÃO";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                        case PollTypeEnum.CM:
                            switch (orderNumber)
                            {
                                case 3:
                                    orderTitle = "PROPORCIONALIDADE";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (pollType)
                    {
                        case PollTypeEnum.CA:
                            switch (orderNumber)
                            {
                                case 1:
                                    orderTitle = "COMPOSIÇÃO";
                                    break;
                                case 2:
                                    orderTitle = "TRANSFORMAÇÃO";
                                    break;
                                case 3:
                                    orderTitle = "COMPARAÇÃO";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                        case PollTypeEnum.CM:
                            switch (orderNumber)
                            {
                                case 4:
                                    orderTitle = "CONFIGURAÇÃO RETANGULAR";
                                    break;
                                case 5:
                                    orderTitle = "PROPORCIONALIDADE";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (pollType)
                    {
                        case PollTypeEnum.CA:
                            switch (orderNumber)
                            {
                                case 1:
                                    orderTitle = "COMPOSIÇÃO";
                                    break;
                                case 2:
                                    orderTitle = "TRANSFORMAÇÃO";
                                    break;
                                case 3:
                                    orderTitle = "COMPOSIÇÃO DE TRANSF.";
                                    break;
                                case 4:
                                    orderTitle = "COMPARAÇÃO";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                        case PollTypeEnum.CM:
                            switch (orderNumber)
                            {
                                case 5:
                                    orderTitle = "CONFIGURAÇÃO RETANGULAR";
                                    break;
                                case 6:
                                    orderTitle = "PROPORCIONALIDADE";
                                    break;
                                case 7:
                                    orderTitle = "COMBINATÓRIA";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (pollType)
                    {
                        case PollTypeEnum.CA:
                            switch (orderNumber)
                            {
                                case 1:
                                    orderTitle = "COMPOSIÇÃO";
                                    break;
                                case 2:
                                    orderTitle = "TRANSFORMAÇÃO";
                                    break;
                                case 3:
                                    orderTitle = "COMPOSIÇÃO DE TRANSF.";
                                    break;
                                case 4:
                                    orderTitle = "COMPARAÇÃO";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                        case PollTypeEnum.CM:
                            switch (orderNumber)
                            {
                                case 5:
                                    orderTitle = "COMBINATÓRIA";
                                    break;
                                case 6:
                                    orderTitle = "CONFIGURAÇÃO RETANGULAR";
                                    break;
                                case 7:
                                    orderTitle = "PROPORCIONALIDADE";
                                    break;
                                case 8:
                                    orderTitle = "MULTIPLICAÇÃO COMPARATIVA";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                    }
                    break;
                case 6:
                    switch (pollType)
                    {
                        case PollTypeEnum.CA:
                            switch (orderNumber)
                            {
                                case 1:
                                    orderTitle = "COMPOSIÇÃO";
                                    break;
                                case 2:
                                    orderTitle = "TRANSFORMAÇÃO";
                                    break;
                                case 3:
                                    orderTitle = "COMPOSIÇÃO DE TRANSF.";
                                    break;
                                case 4:
                                    orderTitle = "COMPARAÇÃO";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                        case PollTypeEnum.CM:
                            switch (orderNumber)
                            {
                                case 5:
                                    orderTitle = "COMBINATÓRIA";
                                    break;
                                case 6:
                                    orderTitle = "CONFIGURAÇÃO RETANGULAR";
                                    break;
                                case 7:
                                    orderTitle = "PROPORCIONALIDADE";
                                    break;
                                case 8:
                                    orderTitle = "MULTIPLICAÇÃO COMPARATIVA";
                                    break;
                                default:
                                    orderTitle = string.Empty;
                                    break;
                            }
                            break;
                    }
                    break;
                default:
                    break;

            }


            return orderTitle;
        }
        public async Task<List<SondagemMatematicaOrdemDTO>> ListPoolCAAsync(FiltroSondagemMatematicaDTO filtroSondagem)
        {
            try
            {
                var retornoSondagem = new List<SondagemMatematicaOrdemDTO>();

                using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
                {
                    var sondagemDaTurma = db.MathPoolCAs
                                            .Where(x => x.TurmaEolCode.Equals(filtroSondagem.TurmaEolCode))
                                            .ToList();


                    var turmApi = new TurmasAPI(new EndpointsAPI());

                    var classroomStudentsFromAPI = await turmApi.GetAlunosNaTurma(Convert.ToInt32(filtroSondagem.TurmaEolCode), _token);

                    classroomStudentsFromAPI = classroomStudentsFromAPI.Where(x => x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5).ToList();
                    if (classroomStudentsFromAPI == null)
                    {
                        return null;
                    }

                    foreach (var studentClassRoom in classroomStudentsFromAPI)
                    {
                        var studentDTO = new SondagemMatematicaOrdemDTO();
                        if (sondagemDaTurma != null)
                        {
                            var studentPollsMath = sondagemDaTurma.Where(x => x.AlunoEolCode == studentClassRoom.CodigoAluno.ToString()).ToList();
                            studentDTO.NomeAluno = studentClassRoom.NomeAluno;
                            studentDTO.CodigoEolAluno = studentClassRoom.CodigoAluno.ToString();
                            studentDTO.NumeroAlunoChamada = studentClassRoom.NumeroAlunoChamada.ToString();
                            studentDTO.AnoLetivo = filtroSondagem.AnoLetivo;
                            studentDTO.CodigoEolDRE = filtroSondagem.DreEolCode;
                            studentDTO.CodigoEolEscola = filtroSondagem.EscolaEolCode;
                            studentDTO.AnoTurma = filtroSondagem.AnoTurma;
                            studentDTO.CodigoEolTurma = filtroSondagem.TurmaEolCode;

                            if (studentPollsMath?.Count > 0)
                            {
                                for (int semestre = 1; semestre <= 2; semestre++)
                                {
                                    var studentPollMath = studentPollsMath
                                                            .Where(s => s.Semestre == semestre)
                                                            .FirstOrDefault();

                                    if (semestre.Equals(1))
                                    {
                                        studentDTO.Ideia1Semestre1 = studentPollMath.Ordem1Ideia;
                                        studentDTO.Ideia2Semestre1 = studentPollMath.Ordem2Ideia;
                                        studentDTO.Resultado1Semestre1 = studentPollMath.Ordem1Resultado;
                                        studentDTO.Resultado2Semestre1 = studentPollMath.Ordem2Resultado;

                                        if (studentPollMath.AnoTurma != (int)AnoTurmaEnum.SegundoAno)
                                        {
                                            studentDTO.Resultado3Semestre1 = studentPollMath.Ordem3Resultado;
                                            studentDTO.Resultado4Semestre1 = studentPollMath.Ordem4Resultado;
                                            studentDTO.Ideia3Semestre1 = studentPollMath.Ordem3Ideia;
                                            studentDTO.Ideia4Semestre1 = studentPollMath.Ordem4Ideia;
                                        }
                                    }
                                    else if (semestre.Equals(2))
                                    {
                                        studentDTO.Ideia1Semestre2 = studentPollMath.Ordem1Ideia;
                                        studentDTO.Ideia2Semestre2 = studentPollMath.Ordem2Ideia;
                                        studentDTO.Resultado1Semestre2 = studentPollMath.Ordem1Resultado;
                                        studentDTO.Resultado2Semestre2 = studentPollMath.Ordem2Resultado;

                                        if (studentPollMath.AnoTurma != (int)AnoTurmaEnum.SegundoAno)
                                        {
                                            studentDTO.Resultado3Semestre2 = studentPollMath.Ordem3Resultado;
                                            studentDTO.Resultado4Semestre2 = studentPollMath.Ordem4Resultado;
                                            studentDTO.Ideia3Semestre2 = studentPollMath.Ordem3Ideia;
                                            studentDTO.Ideia4Semestre2 = studentPollMath.Ordem4Ideia;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                AddEmptyCAPoolTo(studentDTO);
                            }

                            retornoSondagem.Add(studentDTO);
                        }
                    }
                }
                return retornoSondagem.OrderBy(r => Convert.ToInt32(r.NumeroAlunoChamada)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SondagemMatematicaNumerosDTO>> ListPoolNumerosAsync(FiltroSondagemMatematicaDTO filtroSondagem)
        {
            try
            {
                var retornoSondagem = new List<SondagemMatematicaNumerosDTO>();

                using (SMEManagementContextData db = new SMEManagementContextData())
                {
                    var sondagemDaTurma = db.MathPoolNumbers
                        .Where(x => x.TurmaEolCode.Equals(filtroSondagem.TurmaEolCode))
                        .ToList();

                    var turmApi = new TurmasAPI(new EndpointsAPI());

                    var classroomStudentsFromAPI = await turmApi
                        .GetAlunosNaTurma(Convert.ToInt32(filtroSondagem.TurmaEolCode), _token);

                    classroomStudentsFromAPI = classroomStudentsFromAPI
                        .Where(x => x.CodigoSituacaoMatricula == 1 || x.CodigoSituacaoMatricula == 10 || x.CodigoSituacaoMatricula == 6 || x.CodigoSituacaoMatricula == 13 || x.CodigoSituacaoMatricula == 5).ToList();

                    if (classroomStudentsFromAPI == null)
                        return null;

                    foreach (var studentClassRoom in classroomStudentsFromAPI)
                    {
                        var studentDTO = new SondagemMatematicaNumerosDTO();
                        if (sondagemDaTurma != null)
                        {
                            var studentPollsMath = sondagemDaTurma
                                .Where(x => x.AlunoEolCode == studentClassRoom.CodigoAluno.ToString())
                                .ToList();

                            studentDTO.NomeAluno = studentClassRoom.NomeAluno;
                            studentDTO.CodigoEolAluno = studentClassRoom.CodigoAluno.ToString();
                            studentDTO.NumeroAlunoChamada = studentClassRoom.NumeroAlunoChamada.ToString();
                            studentDTO.AnoLetivo = filtroSondagem.AnoLetivo;
                            studentDTO.CodigoEolDRE = filtroSondagem.DreEolCode;
                            studentDTO.CodigoEolEscola = filtroSondagem.EscolaEolCode;
                            studentDTO.AnoTurma = filtroSondagem.AnoTurma;
                            studentDTO.CodigoEolTurma = filtroSondagem.TurmaEolCode;

                            if (studentPollsMath?.Count > 0)
                            {
                                for (int semestre = 1; semestre <= 2; semestre++)
                                {
                                    var studentPollMath = studentPollsMath
                                        .Where(s => s.Semestre == semestre)
                                        .FirstOrDefault();

                                    if (semestre.Equals(1))
                                    {
                                        studentDTO.Familiares1S = studentPollMath.Familiares;
                                        studentDTO.Opacos1S = studentPollMath.Opacos;
                                        studentDTO.Processo1S = studentPollMath.Processo;
                                        studentDTO.TerminamZero1S = studentPollMath.TerminamZero;
                                        studentDTO.Transparentes1S = studentPollMath.Transparentes;
                                        studentDTO.ZeroIntercalados1S = studentPollMath.ZeroIntercalados;
                                        studentDTO.Algarismos1S = studentPollMath.Algarismos;
                                    }
                                    else if (semestre.Equals(2))
                                    {
                                        studentDTO.Familiares2S = studentPollMath.Familiares;
                                        studentDTO.Opacos2S = studentPollMath.Opacos;
                                        studentDTO.Processo2S = studentPollMath.Processo;
                                        studentDTO.TerminamZero2S = studentPollMath.TerminamZero;
                                        studentDTO.Transparentes2S = studentPollMath.Transparentes;
                                        studentDTO.ZeroIntercalados2S = studentPollMath.ZeroIntercalados;
                                        studentDTO.Algarismos2S = studentPollMath.Algarismos;
                                    }
                                }
                            }
                            else
                                AddEmptyNumberPoolTo(studentDTO);

                            retornoSondagem.Add(studentDTO);
                        }
                    }
                }

                return retornoSondagem
                    .OrderBy(r => Convert.ToInt32(r.NumeroAlunoChamada))
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        private void AddEmptyNumberPoolTo(SondagemMatematicaNumerosDTO studentDTO)
        {
            studentDTO.Familiares1S = string.Empty;
            studentDTO.Opacos1S = string.Empty;
            studentDTO.Processo1S = string.Empty;
            studentDTO.TerminamZero1S = string.Empty;
            studentDTO.Transparentes1S = string.Empty;
            studentDTO.ZeroIntercalados1S = string.Empty;
            studentDTO.Algarismos1S = string.Empty;
            studentDTO.Familiares2S = string.Empty;
            studentDTO.Opacos2S = string.Empty;
            studentDTO.Processo2S = string.Empty;
            studentDTO.TerminamZero2S = string.Empty;
            studentDTO.Transparentes2S = string.Empty;
            studentDTO.ZeroIntercalados2S = string.Empty;
            studentDTO.Algarismos2S = string.Empty;
        }

        private void AddEmptyCAPoolTo(SondagemMatematicaOrdemDTO studentDTO)
        {
            var anoTurma = Convert.ToInt32(studentDTO.AnoTurma);

            studentDTO.Ideia1Semestre1 = string.Empty;
            studentDTO.Ideia2Semestre1 = string.Empty;
            studentDTO.Resultado1Semestre1 = string.Empty;
            studentDTO.Resultado2Semestre1 = string.Empty;
            studentDTO.Ideia1Semestre2 = string.Empty;
            studentDTO.Ideia2Semestre2 = string.Empty;
            studentDTO.Resultado1Semestre2 = string.Empty;
            studentDTO.Resultado2Semestre2 = string.Empty;

            if (anoTurma != (int)AnoTurmaEnum.SegundoAno)
            {
                studentDTO.Ideia3Semestre1 = string.Empty;
                studentDTO.Ideia4Semestre1 = string.Empty;
                studentDTO.Ideia3Semestre2 = string.Empty;
                studentDTO.Ideia4Semestre2 = string.Empty;
                studentDTO.Resultado3Semestre1 = string.Empty;
                studentDTO.Resultado4Semestre1 = string.Empty;
                studentDTO.Resultado3Semestre2 = string.Empty;
                studentDTO.Resultado4Semestre2 = string.Empty;
            }
        }

        private void AddEmptyCMPoolTo(SondagemMatematicaOrdemDTO studentDTO)
        {
            var anoTurma = Convert.ToInt32(studentDTO.AnoTurma);

            if (anoTurma == (int)AnoTurmaEnum.SegundoAno)
            {
                studentDTO.Ideia3Semestre1 = string.Empty;
                studentDTO.Ideia3Semestre2 = string.Empty;
                studentDTO.Resultado3Semestre1 = string.Empty;
                studentDTO.Resultado3Semestre2 = string.Empty;
            }
            else
            {
                studentDTO.Ideia4Semestre1 = string.Empty;
                studentDTO.Ideia5Semestre1 = string.Empty;
                studentDTO.Ideia6Semestre1 = string.Empty;
                studentDTO.Ideia7Semestre1 = string.Empty;
                studentDTO.Ideia8Semestre1 = string.Empty;
                studentDTO.Resultado4Semestre1 = string.Empty;
                studentDTO.Resultado6Semestre1 = string.Empty;
                studentDTO.Resultado7Semestre1 = string.Empty;
                studentDTO.Resultado5Semestre1 = string.Empty;
                studentDTO.Resultado8Semestre1 = string.Empty;
                studentDTO.Ideia5Semestre2 = string.Empty;
                studentDTO.Ideia4Semestre2 = string.Empty;
                studentDTO.Ideia6Semestre2 = string.Empty;
                studentDTO.Ideia7Semestre2 = string.Empty;
                studentDTO.Ideia8Semestre2 = string.Empty;
                studentDTO.Resultado4Semestre2 = string.Empty;
                studentDTO.Resultado6Semestre2 = string.Empty;
                studentDTO.Resultado7Semestre2 = string.Empty;
                studentDTO.Resultado5Semestre2 = string.Empty;
                studentDTO.Resultado8Semestre2 = string.Empty;
            }
        }

        public async Task InsertPoolNumerosAsync(List<SondagemMatematicaNumerosDTO> dadosSondagem)
        {
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                foreach (var student in dadosSondagem)
                {
                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
                        var studentPoolNumeros = db.MathPoolNumbers.Where(x =>
                                                                            x.TurmaEolCode == student.CodigoEolTurma &&
                                                                             x.AlunoEolCode == student.CodigoEolAluno &&
                                                                             x.Semestre == semestre).FirstOrDefault();

                        if (studentPoolNumeros == null)
                        {
                            var newStudentPoolNumeros = new MathPoolNumber();
                            newStudentPoolNumeros.AlunoEolCode = student.CodigoEolAluno;
                            newStudentPoolNumeros.AlunoNome = student.NomeAluno;
                            newStudentPoolNumeros.DreEolCode = student.CodigoEolDRE;
                            newStudentPoolNumeros.EscolaEolCode = student.CodigoEolEscola;
                            newStudentPoolNumeros.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            newStudentPoolNumeros.TurmaEolCode = student.CodigoEolTurma;
                            newStudentPoolNumeros.AnoLetivo = Convert.ToInt32(student.AnoLetivo);
                            newStudentPoolNumeros.Semestre = semestre;

                            MapValuesPoolNumbers(student, ref newStudentPoolNumeros);
                            await db.MathPoolNumbers.AddAsync(newStudentPoolNumeros);
                        }
                        else
                        {

                            MapValuesPoolNumbers(student, ref studentPoolNumeros);
                            db.MathPoolNumbers.Update(studentPoolNumeros);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private void MapValuesPoolNumbers(SondagemMatematicaNumerosDTO studentDTO, ref MathPoolNumber studentPoolNumeros)
        {
            if (studentPoolNumeros.Semestre == 1)
            {
                studentPoolNumeros.Familiares = studentDTO.Familiares1S;
                studentPoolNumeros.Opacos = studentDTO.Opacos1S;
                studentPoolNumeros.Transparentes = studentDTO.Transparentes1S;
                studentPoolNumeros.TerminamZero = studentDTO.TerminamZero1S;
                studentPoolNumeros.Algarismos = studentDTO.Algarismos1S;
                studentPoolNumeros.Processo = studentDTO.Processo1S;
                studentPoolNumeros.ZeroIntercalados = studentDTO.ZeroIntercalados1S;
            }
            else if (studentPoolNumeros.Semestre == 2)
            {
                studentPoolNumeros.Familiares = studentDTO.Familiares2S;
                studentPoolNumeros.Opacos = studentDTO.Opacos2S;
                studentPoolNumeros.Transparentes = studentDTO.Transparentes2S;
                studentPoolNumeros.TerminamZero = studentDTO.TerminamZero2S;
                studentPoolNumeros.Algarismos = studentDTO.Algarismos2S;
                studentPoolNumeros.Processo = studentDTO.Processo2S;
                studentPoolNumeros.ZeroIntercalados = studentDTO.ZeroIntercalados2S;
            }
        }

        public async Task InsertPoolCAAsync(List<SondagemMatematicaOrdemDTO> dadosSondagem)
        {
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                foreach (var student in dadosSondagem)
                {
                    for (int semestre = 1; semestre <= 2; semestre++)
                    {
                        var studentPoolCA = db.MathPoolCAs.Where(x =>
                                                                x.TurmaEolCode == student.CodigoEolTurma &&
                                                                 x.AlunoEolCode == student.CodigoEolAluno &&
                                                                 x.Semestre == semestre).FirstOrDefault();

                        if (studentPoolCA == null)
                        {
                            var newStudentPoolCA = new MathPoolCA();
                            newStudentPoolCA.AlunoEolCode = student.CodigoEolAluno;
                            newStudentPoolCA.AlunoNome = student.NomeAluno;
                            newStudentPoolCA.DreEolCode = student.CodigoEolDRE;
                            newStudentPoolCA.EscolaEolCode = student.CodigoEolEscola;
                            newStudentPoolCA.AnoTurma = Convert.ToInt32(student.AnoTurma);
                            newStudentPoolCA.TurmaEolCode = student.CodigoEolTurma;
                            newStudentPoolCA.AnoLetivo = Convert.ToInt32(student.AnoLetivo);
                            newStudentPoolCA.Semestre = semestre;

                            MapValuesPoolCA(student, ref newStudentPoolCA);
                            await db.MathPoolCAs.AddAsync(newStudentPoolCA);
                        }
                        else
                        {
                            MapValuesPoolCA(student, ref studentPoolCA);
                            db.MathPoolCAs.Update(studentPoolCA);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        private void MapValuesPoolCA(SondagemMatematicaOrdemDTO studentDTO, ref MathPoolCA studentPoolCA)
        {
            if (studentPoolCA.Semestre == 1)
            {
                studentPoolCA.Ordem1Ideia = studentDTO.Ideia1Semestre1;
                studentPoolCA.Ordem1Resultado = studentDTO.Resultado1Semestre1;
                studentPoolCA.Ordem2Ideia = studentDTO.Ideia2Semestre1;
                studentPoolCA.Ordem2Resultado = studentDTO.Resultado2Semestre1;

                if (studentPoolCA.AnoTurma != (int)AnoTurmaEnum.SegundoAno)
                {
                    studentPoolCA.Ordem3Ideia = studentDTO.Ideia3Semestre1;
                    studentPoolCA.Ordem3Resultado = studentDTO.Resultado3Semestre1;
                    studentPoolCA.Ordem4Ideia = studentDTO.Ideia4Semestre1;
                    studentPoolCA.Ordem4Resultado = studentDTO.Resultado4Semestre1;
                }
            }
            else if (studentPoolCA.Semestre == 2)
            {
                studentPoolCA.Ordem1Ideia = studentDTO.Ideia1Semestre2;
                studentPoolCA.Ordem1Resultado = studentDTO.Resultado1Semestre2;
                studentPoolCA.Ordem2Ideia = studentDTO.Ideia2Semestre2;
                studentPoolCA.Ordem2Resultado = studentDTO.Resultado2Semestre2;

                if (studentPoolCA.AnoTurma != (int)AnoTurmaEnum.SegundoAno)
                {
                    studentPoolCA.Ordem3Ideia = studentDTO.Ideia3Semestre2;
                    studentPoolCA.Ordem3Resultado = studentDTO.Resultado3Semestre2;
                    studentPoolCA.Ordem4Ideia = studentDTO.Ideia4Semestre2;
                    studentPoolCA.Ordem4Resultado = studentDTO.Resultado4Semestre2;
                }
            }
        }
    }
}
