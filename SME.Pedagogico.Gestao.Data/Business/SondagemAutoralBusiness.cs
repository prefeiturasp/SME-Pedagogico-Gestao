using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoreLinq;
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

        public IEnumerable<PerguntaDto> ObterPerguntas(int anoEscolar)
        {
            using (var contexto = new SMEManagementContextData())
            {
                try
                {
                               
                    var perguntas = contexto.PerguntaAnoEscolar.Where(perguntaAnoEscolar => perguntaAnoEscolar.AnoEscolar == anoEscolar).Select(x => MapearPergunta(x));

                    if (perguntas == null || !perguntas.Any())
                        throw new Exception("Não foi possivel obter as perguntas da sondagem");

                    var perguntasResposta = contexto.PerguntaResposta.Where(resposta => perguntas.Any(z => z.Id.Equals(resposta.Pergunta.Id)));

                    if (perguntas == null || !perguntas.Any())
                        throw new Exception("Não foi possivel obter as respostas da sondagem");

                    perguntas.ForEach(pergunta =>
                    {
                        var respostasDaPergunta = perguntasResposta.Where(perguntaResposta => perguntaResposta.Pergunta.Id.Equals(pergunta.Id));

                        if (respostasDaPergunta == null || !respostasDaPergunta.Any())
                            throw new Exception($"Não foi possivel obter as respostas da pergunta '{pergunta.Descricao}'");

                        pergunta.Respostas = respostasDaPergunta.Select(perguntaResposta => new RespostaDto
                        {
                            Descricao = perguntaResposta.Resposta.Descricao,
                            Id = perguntaResposta.Resposta.Id,
                            Ordenacao = perguntaResposta.Ordenacao
                        });
                    });

                    return perguntas;
                }


                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public IEnumerable<PeriodoDto> ObterPeriodoMatematica()
        {
            using (var contexto = new SMEManagementContextData())
            {
                var periodos = contexto.Periodo.Where(x => x.TipoPeriodo == Models.Enums.TipoPeriodoEnum.Semestre);

                return periodos.Select(x => (PeriodoDto)x);
            }
        }

        public async Task<IEnumerable<AlunoSondagemMatematicaDto>> ObterListagemAutoral(FiltrarListagemDto filtrarListagemDto)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var autoral = contexto.SondagemAutoral.Where(x => x.ComponenteCurricular.Id.Equals(filtrarListagemDto.ComponenteCurricular)
                                                                    && x.AnoTurma == filtrarListagemDto.AnoEscolar
                                                                    && (filtrarListagemDto.CodigoTurma == null ? true : x.CodigoTurma.Equals(filtrarListagemDto.CodigoTurma)));

                var alunos = await TurmaApi.GetAlunosNaTurma(Convert.ToInt32(filtrarListagemDto.CodigoTurma), filtrarListagemDto.AnoLetivo, _token);

                if (alunos == null || !alunos.Any())
                    throw new Exception($"Não encontrado alunos para a turma {filtrarListagemDto.CodigoTurma} do ano letivo {filtrarListagemDto.AnoLetivo}");

                var listagem = new List<AlunoSondagemMatematicaDto>();

                foreach (var aluno in autoral)
                {
                    var alunoLista = listagem.FirstOrDefault(x => x.CodigoAluno.Equals(aluno.CodigoAluno));
                    
                    if (alunoLista != null)
                        AdicionarRespostaAluno(aluno, alunoLista);
                    else
                        AdicionarNovoAlunoListagem(listagem, aluno);
                }

                AdicionarAlunosEOL(filtrarListagemDto.AnoEscolar, filtrarListagemDto.AnoLetivo, filtrarListagemDto.CodigoDre, filtrarListagemDto.CodigoUe, filtrarListagemDto.CodigoTurma, filtrarListagemDto.ComponenteCurricular, alunos, listagem);

                return listagem;
            }
        }

        private static void AdicionarAlunosEOL(int anoEscolar, int anoLetivo, string codigoDre, string codigoUe, string codigoTurma, Guid componenteCurricular, List<AlunosNaTurmaDTO> alunos, List<AlunoSondagemMatematicaDto> listagem)
        {
            alunos.ForEach(aluno =>
            {
                if (listagem.Any(x => x.CodigoAluno.Equals(aluno.CodigoAluno)))
                    return;

                listagem.Add(new AlunoSondagemMatematicaDto
                {
                    CodigoAluno = aluno.CodigoAluno.ToString(),
                    AnoLetivo = anoLetivo,
                    AnoTurma = anoEscolar,
                    CodigoDre = codigoDre,
                    CodigoTurma = codigoTurma,
                    CodigoUe = codigoUe,
                    ComponenteCurricular = componenteCurricular.ToString(),
                    NomeAluno = aluno.NomeAluno,
                });
            });
        }

        private void AdicionarRespostaAluno(SondagemAutoral aluno, AlunoSondagemMatematicaDto alunoLista)
        {
            alunoLista.Respostas.ToList().Add(new AlunoRespostaDto
            {
                Pergunta = aluno.Pergunta.Id,
                Resposta = aluno.Resposta.Id
            });
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
                        PeriodoId = aluno.Periodo.Id,
                        Pergunta = aluno.Pergunta.Id,
                        Resposta = aluno.Resposta.Id
                    }
                }
            });
        }

        private PerguntaDto MapearPergunta(PerguntaAnoEscolar perguntaAnoEscolar)
        {
            var retorno = (PerguntaDto)perguntaAnoEscolar.Pergunta;

            retorno.Ordenacao = perguntaAnoEscolar.Ordenacao;

            return retorno;
        }
    }
}
