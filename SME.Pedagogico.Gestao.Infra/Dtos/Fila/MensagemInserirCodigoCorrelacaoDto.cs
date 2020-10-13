using SME.Pedagogico.Gestao.Dominio;

namespace SME.Pedagogico.Gestao.Infra
{
    public class MensagemInserirCodigoCorrelacaoDto
    {
        public MensagemInserirCodigoCorrelacaoDto(TipoRelatorio tipoRelatorio, TipoFormatoRelatorio formato)
        {
            TipoRelatorio = tipoRelatorio;
            Formato = formato;
        }

        public TipoRelatorio TipoRelatorio { get; set; }
        public TipoFormatoRelatorio Formato { get; set; }
    }
}
