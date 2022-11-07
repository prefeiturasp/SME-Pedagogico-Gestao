using System;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Infra
{
    public class PerfilAcessoSondagemDto
    {
        public string Token { get; set; }   
        public DateTime DataExpiracaoToken { get; set; }   
        public IEnumerable<int> Permissoes { get; set; }   
    }
}