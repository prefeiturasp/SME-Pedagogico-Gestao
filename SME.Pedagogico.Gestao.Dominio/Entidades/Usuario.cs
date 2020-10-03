using System;

namespace SME.Pedagogico.Gestao.Dominio.Entidades
{
    public class Usuario
    {
        public long Id { get; set; }
        public string CodigoRf { get; set; }
        public DateTime? ExpiracaoRecuperacaoSenha { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public Guid PerfilAtual { get; set; }

        public Guid? TokenRecuperacaoSenha { get; set; }
        public DateTime UltimoLogin { get; set; }
    }
}
