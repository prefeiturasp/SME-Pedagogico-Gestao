using MediatR;
using SME.Pedagogico.Gestao.Aplicacao.Commands.Relatorios.NewFolder;
using SME.Pedagogico.Gestao.Dominio.Entidades;
using SME.Pedagogico.Gestao.Infra.Dtos.Relatorios;
using SME.Pedagogico.Gestao.Infra.Extensoes;
using SME.Pedagogico.Gestao.Infra.Fila;
using SME.Pedagogico.Gestao.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Aplicacao.Commands.Relatorios.GerarRelatorio
{
    public class GerarRelatorioCommandHandler : IRequestHandler<GerarRelatorioCommand, bool>
    {
        private readonly IServicoFila servicoFila;

        public GerarRelatorioCommandHandler(IServicoFila servicoFila)
        {
            this.servicoFila = servicoFila ?? throw new System.ArgumentNullException(nameof(servicoFila));
        }

        public Task<bool> Handle(GerarRelatorioCommand request, CancellationToken cancellationToken)
        {
         
            return Task.FromResult(true);
        }
    }
}
