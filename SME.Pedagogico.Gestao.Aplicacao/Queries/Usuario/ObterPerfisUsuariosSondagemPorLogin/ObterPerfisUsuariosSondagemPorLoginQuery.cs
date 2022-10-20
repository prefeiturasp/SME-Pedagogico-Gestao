using FluentValidation;
using MediatR;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterPerfisUsuariosSondagemPorLoginQuery : IRequest<PerfisUsuarioSondagemDto>
    {
        public ObterPerfisUsuariosSondagemPorLoginQuery(string login)
        {
            Login = login;
        }
        public string Login { get; set; }
    }

    public class ObterPerfisUsuariosSondagemPorLoginQueryValidator : AbstractValidator<ObterPerfisUsuariosSondagemPorLoginQuery>
    {
        public ObterPerfisUsuariosSondagemPorLoginQueryValidator()
        {
            RuleFor(c => c.Login)
                .NotEmpty()
                .WithMessage("O login deve ser informado para a autenticação na API EOL.");
        }
    }
}
