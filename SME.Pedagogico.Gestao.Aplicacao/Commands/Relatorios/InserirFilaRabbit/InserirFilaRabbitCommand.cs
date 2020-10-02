using MediatR;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Infra.Dtos.Relatorios;
using System;

namespace SME.Pedagogico.Gestao.Aplicacao
{
    public class InserirFilaRabbitCommand : IRequest<bool>
    {
        public PublicaFilaRelatoriosDto AdicionarFilaDto { get; set; }
      
    }
}
