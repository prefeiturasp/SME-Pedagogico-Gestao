using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterCodigoCorrelacaoQuery : IRequest<Guid>
    {
        public TipoRelatorio TipoRelatorio { get; set; }

        public string UsuarioRf { get; set; }
        public TipoFormatoRelatorio Formato { get; set; }

        public ObterCodigoCorrelacaoQuery(TipoRelatorio tipoRelatorio, string usuarioRf, TipoFormatoRelatorio formato)
        {
            TipoRelatorio = tipoRelatorio;
            UsuarioRf = usuarioRf;
            Formato = formato;
        }
    }
}
