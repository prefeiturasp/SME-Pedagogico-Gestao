using SME.Pedagogico.Gestao.Dominio;

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
