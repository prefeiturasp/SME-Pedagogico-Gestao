using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterPermissaoMenuPorPerfilQuery : IRequest<List<MenuPermissaoDto>>
    {
        public ObterPermissaoMenuPorPerfilQuery(Guid perfilCodigo)
        {
            PerfilCodigo = perfilCodigo;
        }

        public Guid PerfilCodigo { get; set; }
    }
}
