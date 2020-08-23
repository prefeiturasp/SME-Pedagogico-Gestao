using Microsoft.Extensions.Configuration;
using MoreLinq;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.DTO.Matematica;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Models.Autoral;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public class SondagemAutoralBusiness
    {
        private string _token;
        public SondagemAutoralBusiness(IConfiguration config)
        {
            var createToken = new CreateToken(config);
            _token = createToken.CreateTokenProvisorio();
        }

        public IEnumerable<PerguntaDto> ObterPerguntas(int anoEscolar)
        {
            using (var contexto = new SMEManagementContextData())
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
        }

        public IEnumerable<PeriodoDto> ObterPeriodoMatematica()
        {
            using (var contexto = new SMEManagementContextData())
            {
                var periodos = contexto.Periodo.Where(x => x.TipoPeriodo == Models.Enums.TipoPeriodoEnum.Semestre);

                return periodos.Select(x => (PeriodoDto)x);
            }
        }

        public IEnumerable<AlunoSondagemMatematicaDto> ObterListagemAutoral(int anoEscolar, string codigoTurma, Guid componenteCurricular)
        {
            using (var contexto = new SMEManagementContextData())
            {
                var autoral = contexto.SondagemAutoral.Where(x => x.ComponenteCurricular.Id.Equals(componenteCurricular)
                                                                    && x.AnoTurma == anoEscolar
                                                                    && (codigoTurma == null ? true : x.CodigoTurma.Equals(codigoTurma)));

                var listagem = new List<AlunoSondagemMatematicaDto>();

                foreach (var aluno in autoral)
                {
                    var alunoLista = listagem.FirstOrDefault(x => x.CodigoAluno.Equals(aluno.CodigoAluno));

                    if (alunoLista != null)
                        AdicionarRespostaAluno(aluno, alunoLista);
                    else
                        AdicionarNovoAlunoListagem(listagem, aluno);
                }

                return listagem;
            }
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
                PeriodoId = aluno.Periodo.Id,
                Respostas = new List<AlunoRespostaDto>()
                {
                    new AlunoRespostaDto
                    {
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
