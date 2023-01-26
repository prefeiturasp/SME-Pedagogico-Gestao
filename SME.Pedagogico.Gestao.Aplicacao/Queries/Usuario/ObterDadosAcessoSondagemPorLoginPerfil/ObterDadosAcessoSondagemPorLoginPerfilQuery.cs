using System;
using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System.Collections.Generic;
using FluentValidation;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterDadosAcessoSondagemPorLoginPerfilQuery : IRequest<PerfilAcessoSondagemDto>
    {
        public ObterDadosAcessoSondagemPorLoginPerfilQuery(string login, Guid perfil)
        {
            Login = login;
            Perfil = perfil;
        }
        public string Login { get; set; }
        public Guid Perfil { get; set; }
    }
    
    public class ObterDadosAcessoSondagemPorLoginPerfilQueryValidator : AbstractValidator<ObterDadosAcessoSondagemPorLoginPerfilQuery>
    {
        public ObterDadosAcessoSondagemPorLoginPerfilQueryValidator()
        {
            RuleFor(c => c.Login)
                .NotEmpty()
                .WithMessage("O login deve ser informado para a busca dos acessos da sondagem na API EOL.");

            RuleFor(c => c.Perfil)
                .NotEmpty()
                .WithMessage("O perfil deve ser informado para a busca dos acessos da sondagem na API EOL.");
        }
    }
}
