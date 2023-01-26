using FluentValidation;
using MediatR;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQuery : IRequest<PerfisPermissaoTokenDataExpiracaoDto>
    {
        public ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQuery(string login)
        {
            Login = login;
        }
        public string Login { get; set; }
    }

    public class ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQueryValidator : AbstractValidator<ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQuery>
    {
        public ObterPerfisPermissoesTokenDataExpiracaoUsuariosSondagemPorLoginQueryValidator()
        {
            RuleFor(c => c.Login)
                .NotEmpty()
                .WithMessage("O login deve ser informado para a autenticação na API EOL.");
        }
    }
}
