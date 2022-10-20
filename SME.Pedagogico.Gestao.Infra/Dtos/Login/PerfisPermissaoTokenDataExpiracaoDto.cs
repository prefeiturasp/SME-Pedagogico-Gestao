    using System;
    using System.Collections.Generic;

    namespace SME.Pedagogico.Gestao.Infra
    {
        public class PerfisPermissaoTokenDataExpiracaoDto
        {
            public PerfisPorPrioridadeDto PerfisUsuario { get; set; }
            public DateTime DataExpiracaoToken { get; set; }
            public string Token { get; set; }
            public IEnumerable<MenuPermissaoDto> Permissoes { get; set; }
        }
    }
