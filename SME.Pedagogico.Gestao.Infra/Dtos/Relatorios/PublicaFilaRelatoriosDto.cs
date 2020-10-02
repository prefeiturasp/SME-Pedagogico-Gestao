using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Infra
{
    public class PublicaFilaRelatoriosDto
    {
        public PublicaFilaRelatoriosDto(string fila, string exchange, object mensagem, string rota, Guid codigoCorrelacao, string codigoRfUsuario, bool notificarErroUsuario = false)
        {
            Fila = fila;
            Exchange = exchange;
            Mensagem = mensagem;
            Rota = rota;
            CodigoCorrelacao = codigoCorrelacao;
            NotificarErroUsuario = notificarErroUsuario;
            UsuarioLogadoRF = codigoRfUsuario;
        }

        public string Fila { get; set; }
        public string Exchange { get; set; }
        public object Mensagem { get; set; }
        public string Rota { get; set; }
        public Guid CodigoCorrelacao { get; set; }
        public bool NotificarErroUsuario { get; set; }
        public string UsuarioLogadoRF { get; }
    }
}
