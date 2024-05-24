using MediatR;
using Microsoft.Extensions.Configuration;
using SME.Pedagogico.Gestao.Data.Functionalities;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using SME.Pedagogico.Gestao.Data.Integracao.Endpoints;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterAlunosAtivosDentroPeriodoQueryHandler : IRequestHandler<ObterAlunosAtivosDentroPeriodoQuery, IEnumerable<AlunosNaTurmaDTO>>
    {
        private readonly CreateToken createToken;
        private readonly TurmasAPI turmasAPI;

        public ObterAlunosAtivosDentroPeriodoQueryHandler(IConfiguration configuration)
        {
            createToken = new CreateToken(configuration);
            turmasAPI = new TurmasAPI(new EndpointsAPI());
        }

        public async Task<IEnumerable<AlunosNaTurmaDTO>> Handle(ObterAlunosAtivosDentroPeriodoQuery request, CancellationToken cancellationToken)
        {
            var listaAlunos = await turmasAPI
                .GetAlunosConsideraInativosNaTurma(Convert.ToInt32(request.CodigoTurma), createToken.CreateTokenProvisorio());

            var alunos = listaAlunos.Where(a => ((!a.AlunoInativo && a.DataMatricula.Date < request.Periodo.fim.Date) ||
                                                  (a.AlunoInativo && a.DataMatricula.Date < request.Periodo.fim.Date && a.DataSituacao.Date >= request.Periodo.inicio.Date)) &&
                                                  (SituacaoMatriculaAluno)a.CodigoSituacaoMatricula != SituacaoMatriculaAluno.VinculoIndevido);

            if (alunos == null || !alunos.Any())
                throw new Exception($"Não encontrado alunos para a turma {request.CodigoTurma} do ano letivo {request.AnoLetivo}");

            return alunos;
        }
    }
}
