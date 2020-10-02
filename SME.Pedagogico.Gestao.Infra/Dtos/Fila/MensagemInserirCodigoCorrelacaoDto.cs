using SME.Pedagogico.Gestao.Dominio;
using SME.Pedagogico.Gestao.Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Infra
{
    public class MensagemInserirCodigoCorrelacaoDto
    {
        public MensagemInserirCodigoCorrelacaoDto(TipoRelatorio tipoRelatorio)
        {
            TipoRelatorio = tipoRelatorio;
        }

        public TipoRelatorio TipoRelatorio { get; set; }
    }
}
