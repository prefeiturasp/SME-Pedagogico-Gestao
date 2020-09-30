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
        private readonly IRepositorioCorrelacaoRelatorio repositorioCorrelacaoRelatorio;

        public GerarRelatorioCommandHandler(IServicoFila servicoFila, IRepositorioCorrelacaoRelatorio repositorioCorrelacaoRelatorio)
        {
            this.servicoFila = servicoFila ?? throw new System.ArgumentNullException(nameof(servicoFila));
            this.repositorioCorrelacaoRelatorio = repositorioCorrelacaoRelatorio ?? throw new System.ArgumentNullException(nameof(repositorioCorrelacaoRelatorio));
        }

        public Task<bool> Handle(GerarRelatorioCommand request, CancellationToken cancellationToken)
        {
            var correlacao = new RelatorioCorrelacao(request.TipoRelatorio, request.IdUsuarioLogado, request.Formato);
            repositorioCorrelacaoRelatorio.Salvar(correlacao);

            servicoFila.PublicaFilaWorkerServidorRelatorios(new PublicaFilaRelatoriosDto(RotasRabbit.RotaRelatoriosSolicitados, request.Filtros, request.TipoRelatorio.Name(), correlacao.Codigo, request.UsuarioLogadoRf, false, request.PerfilUsuario));

            return Task.FromResult(true);
        }
    }
}
