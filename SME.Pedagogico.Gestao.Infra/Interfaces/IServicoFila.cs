namespace SME.Pedagogico.Gestao.Infra
{
    public interface IServicoFila
    {
        void PublicaFilaWorkerServidorRelatorios(PublicaFilaRelatoriosDto adicionaFilaDto);
        void PublicaFilaWorkerSgp(PublicaFilaSgpDto publicaFilaSgpDto);
    }
}
