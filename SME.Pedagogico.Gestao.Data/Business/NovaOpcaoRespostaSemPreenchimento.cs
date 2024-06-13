using System.Linq;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public static class NovaOpcaoRespostaSemPreenchimento
    {
        private const int TERCEIRO_BIMESTRE = 3;
        private const int NAO_TEM_BIMESTRE = 0;
        private const string SEGUNDO_SEMESTRE = "2° Semestre";
        private const string DESCRICAO_SEMESTRE = "Semestre";
        private const int ANO_LETIVO_DOIS_MIL_VINTE_QUATRO = 2024;
        private const int ANO_LETIVO_DOIS_MIL_VINTE_CINCO = 2025;
        
        public static bool ConsideraOpcaoRespostaSemPreenchimento(int anoLetivo, string descricaoPeriodo)
        {
            return descricaoPeriodo.Contains(DESCRICAO_SEMESTRE) ? ConsideraNovaOpcaoRespostaSemPreenchimentoPrimeiroAoTerceiroAno(anoLetivo,descricaoPeriodo) 
                : ConsideraNovaOpcaoRespostaSemPreenchimentoQuartoAoNonoAno(anoLetivo,descricaoPeriodo);
        }
        private static bool ConsideraNovaOpcaoRespostaSemPreenchimentoPrimeiroAoTerceiroAno(int anoLetivo, string descricaoPeriodo)
        {
            return anoLetivo == ANO_LETIVO_DOIS_MIL_VINTE_QUATRO && descricaoPeriodo == SEGUNDO_SEMESTRE || anoLetivo >= ANO_LETIVO_DOIS_MIL_VINTE_CINCO;
        }
        private static bool ConsideraNovaOpcaoRespostaSemPreenchimentoQuartoAoNonoAno(int anoLetivo, string descricaoPeriodo)
        {
            var bimestreSelecionado = !string.IsNullOrEmpty(descricaoPeriodo) ? int.Parse(descricaoPeriodo.FirstOrDefault().ToString()) : NAO_TEM_BIMESTRE;
            return anoLetivo == ANO_LETIVO_DOIS_MIL_VINTE_QUATRO && bimestreSelecionado >= TERCEIRO_BIMESTRE || anoLetivo >= ANO_LETIVO_DOIS_MIL_VINTE_CINCO;
        }
    }
}