using FluentValidation;
using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoQueryDTO;
using System;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterAlunosAtivosDentroPeriodoQuery : IRequest<IEnumerable<AlunosNaTurmaDTO>>
    {
        public ObterAlunosAtivosDentroPeriodoQuery(string codigoTurma, int anoLetivo, (DateTime inicio, DateTime fim)? periodo)
        {
            CodigoTurma = codigoTurma;
            AnoLetivo = anoLetivo;
            Periodo = periodo ?? (DateTime.Now.Date, DateTime.Now.Date);            
        }

        public string CodigoTurma { get; set; }
        public int AnoLetivo { get; set; }
        public (DateTime inicio, DateTime fim) Periodo { get; set; }        
    }

    public class ObterAlunosAtivosDentroPeriodoQueryValidator : AbstractValidator<ObterAlunosAtivosDentroPeriodoQuery>
    {
        public ObterAlunosAtivosDentroPeriodoQueryValidator()
        {
            RuleFor(x => x.CodigoTurma)
                .NotEmpty()
                .WithMessage("O código da turma deve ser informado.");

            RuleFor(x => x.AnoLetivo)
                .InclusiveBetween(2014, DateTime.Now.Year)
                .WithMessage("O ano letivo é inválido.");
        }
    }
}
