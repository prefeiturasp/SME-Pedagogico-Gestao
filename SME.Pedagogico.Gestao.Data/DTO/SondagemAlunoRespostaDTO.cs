using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Data
{
    public class SondagemAlunoRespostaDTO
    {
        public Guid Id { get; set; }
        public string PerguntaId { get; set; }
        public string RespostaId { get; set; }
        public long HoraGuid 
        { 
            get 
            {
                var parts = Id.ToByteArray();
                var result = new byte[8];
                Array.Copy(parts, 0, result, 4, 2);
                Array.Copy(parts, 2, result, 6, 2);
                Array.Copy(parts, 4, result, 2, 2);
                Array.Copy(parts, 6, result, 0, 2);

                var ticks = BitConverter.ToInt64(result, 0);
                return ticks;
            }
        }
    }
}
