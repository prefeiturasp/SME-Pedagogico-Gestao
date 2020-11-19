using SME.Pedagogico.Gestao.Models.Autoral;

namespace SME.Pedagogico.Gestao.Data.DTO.Matematica
{
    public class PeriodoDto
    {
        public string Id { get; set; }
        public string Descricao { get; set; }

        public bool PeriodoAberto { get; set; }


        public static explicit operator PeriodoDto(Periodo periodo) =>
            periodo == null ? null : new PeriodoDto
            {
                Descricao = periodo.Descricao,
                Id = periodo.Id
            };
    }
}
