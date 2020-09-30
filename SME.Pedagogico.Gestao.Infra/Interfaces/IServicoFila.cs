using SME.Pedagogico.Gestao.Infra.Dtos.Relatorios;
using SME.Pedagogico.Gestao.Infra.Fila;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.Pedagogico.Gestao.Infra.Interfaces
{
    public interface IServicoFila
    {
        void PublicaFilaWorkerServidorRelatorios(PublicaFilaRelatoriosDto adicionaFilaDto);
        void PublicaFilaWorkerSgp(PublicaFilaSgpDto publicaFilaSgpDto);
    }
}
