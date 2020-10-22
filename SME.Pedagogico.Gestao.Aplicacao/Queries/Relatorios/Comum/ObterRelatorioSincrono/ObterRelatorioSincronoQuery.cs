using MediatR;
using SME.Pedagogico.Gestao.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class ObterRelatorioSincronoQuery : IRequest<string>
    {
        public ObterRelatorioSincronoQuery(TipoRelatorio tipoRelatorio, object filtros, string usuarioRf, TipoFormatoRelatorio formato = TipoFormatoRelatorio.Pdf)
        {
            TipoRelatorio = tipoRelatorio;
            Filtros = filtros;
            UsuarioLogadoRf = usuarioRf;
            Formato = formato;
        }

        public object Filtros { get; set; }
        public TipoRelatorio TipoRelatorio { get; set; }
        public string UsuarioLogadoRf { get; }
        public TipoFormatoRelatorio Formato { get; set; }
    }
}
