using MediatR;
using SME.Pedagogico.Gestao.Data.Integracao.DTO.RetornoNovoSGP;
using System;
using System.Collections.Generic;
using System.Text;

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
