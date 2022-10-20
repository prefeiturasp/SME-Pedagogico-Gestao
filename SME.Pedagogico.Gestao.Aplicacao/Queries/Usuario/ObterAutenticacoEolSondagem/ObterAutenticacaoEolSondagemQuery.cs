using FluentValidation;
using MediatR;
using SME.Pedagogico.Gestao.Infra;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterAutenticacaoEolSondagemQuery : IRequest<UsuarioAutenticacaoRetornoDto>
    {
        public ObterAutenticacaoEolSondagemQuery(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class ObterAutenticacaoEolSondagemQueryValidator : AbstractValidator<ObterAutenticacaoEolSondagemQuery>
    {
        public ObterAutenticacaoEolSondagemQueryValidator()
        {
            RuleFor(c => c.Login)
                .NotEmpty()
                .WithMessage("O login deve ser informado para a autenticação na API EOL.");

            RuleFor(c => c.Senha)
                .NotEmpty()
                .WithMessage("A senha deve ser informado para a autenticação na API EOL.");
        }
    }
}
