﻿using MediatR;
using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Dominio.Entidades;
using SME.Pedagogico.Gestao.Dominio.Enumerados;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class GerarRelatorioCommand : IRequest<bool>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoRelatorio">Endpoint do relatório no servidor de relatórios, descrito na tag DisplayName</param>
        /// <param name="filtros">Classe de filtro vindo do front</param>
        public GerarRelatorioCommand(TipoRelatorio tipoRelatorio, object filtros, Usuario usuario, TipoFormatoRelatorio formato = TipoFormatoRelatorio.Pdf)
        {
            TipoRelatorio = tipoRelatorio;
            Filtros = filtros;
            IdUsuarioLogado = usuario.Id;
            UsuarioLogadoRf = usuario.CodigoRf;
            Formato = formato;
        }

        /// <summary>
        /// Classe de filtro vindo do front
        /// </summary>
        public object Filtros { get; set; }
        public TipoRelatorio TipoRelatorio { get; set; }
        public long IdUsuarioLogado { get; set; }
        public string UsuarioLogadoRf { get; }
        public TipoFormatoRelatorio Formato { get; set; }
    }
}
