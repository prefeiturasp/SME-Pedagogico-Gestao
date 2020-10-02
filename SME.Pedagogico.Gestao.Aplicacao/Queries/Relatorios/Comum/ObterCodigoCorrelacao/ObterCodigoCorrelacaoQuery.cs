using MediatR;
using SME.Pedagogico.Gestao.Dominio;
using System;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterCodigoCorrelacaoQuery : IRequest<Guid>
    {
        public TipoRelatorio TipoRelatorio{ get; set; }

        public string UsuarioRf { get; set; }

        public ObterCodigoCorrelacaoQuery(TipoRelatorio tipoRelatorio, string usuarioRf)
        {
            TipoRelatorio = tipoRelatorio;
            UsuarioRf = usuarioRf;
        }
    }
}
