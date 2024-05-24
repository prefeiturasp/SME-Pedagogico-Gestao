import React from "react";

import PollReportBreadcrumb from "../PollReportBreadcrumb";
import PollReportPortugueseGrid from "../PollReportPortugueseGrid";
import PollReportMathGrid from "../PollReportMathGrid";
import RelatorioPortuguesAutoral from "../RelatorioAutoral/RelatorioPortuguesAutoral";
import RelatorioMatematicaConsolidado from "../RelatorioMatematicaConsolidado";
import RelatorioConsolidadoCapacidadeLeitura from "../RelatorioConsolidadeCapacidadeLeitura/RelatorioConsolidadoCapacidadeLeitura";
import RelatorioPorTurmaLeituraVozAlta from "../RelatorioPorTurmaLeituraVozAlta/RelatorioPorTurmaLeituraVozAlta";
import RelatorioMatematicaPorTurma from "../RelatorioMatematicaPorTurma/RelatorioMatematicaPorTurma";
import RelatorioPorTurmaProducaoTexto from "../RelatorioPorTurmaProducaoTexto/RelatorioPorTurmaProducaoTexto";
import RelatorioPorTurmaCapacidadeLeitura from "../RelatorioPorTurmaCapacidadeLeitura/RelatorioPorTurmaCapacidadeLeitura";

import { GrupoDto } from "../../dtos/grupoDto";
import { DISCIPLINES_ENUM } from "../../../Enums";

export const montarPlanilha = (props, reportData, classroomReport) => {
  const montarRelatorioConsolidadosAcimaDoQuartoAno = (dados) => {
    switch (props.pollReport.selectedFilter.grupoId) {
      case GrupoDto.CAPACIDADE_LEITURA:
        return (
          <div className="mb-4">
            <RelatorioConsolidadoCapacidadeLeitura dados={dados} />
          </div>
        );
      case GrupoDto.LEITURA_EM_VOZ_ALTA:
        return <RelatorioPortuguesAutoral dados={dados} />;
      case GrupoDto.PRODUCAO_DE_TEXTO:
        return <RelatorioPortuguesAutoral dados={dados} />;
      default:
        break;
    }
  };

  const montarRelatorioPorTurmaPortuguesAcimaDoQuartoAno = (dados) => {
    switch (props.pollReport.selectedFilter.grupoId) {
      case GrupoDto.CAPACIDADE_LEITURA:
        return (
          <div className="mb-4">
            <RelatorioPorTurmaCapacidadeLeitura
              ordens={dados.ordens}
              perguntas={dados.perguntas}
              alunos={dados.alunos}
            />
          </div>
        );
      case GrupoDto.LEITURA_EM_VOZ_ALTA:
        return (
          <div className="mb-4">
            <RelatorioPorTurmaLeituraVozAlta
              perguntas={dados.perguntas}
              alunos={dados.alunos}
            />
          </div>
        );
      case GrupoDto.PRODUCAO_DE_TEXTO:
        return (
          <div className="mb-4">
            <RelatorioPorTurmaProducaoTexto
              perguntas={dados.perguntas}
              alunos={dados.alunos}
            />
          </div>
        );
      default:
        break;
    }
  };

  const montarPortugues = () => {
    const CodigoCurso =
      props.pollReport.selectedFilter &&
      props.pollReport.selectedFilter.CodigoCurso;
    const ehCapacidadeLeitura =
      props.pollReport.selectedFilter.grupoId === GrupoDto.CAPACIDADE_LEITURA;

    if (Number(CodigoCurso) >= 4) {
      if (classroomReport) {
        return montarRelatorioPorTurmaPortuguesAcimaDoQuartoAno(reportData);
      }
      if (ehCapacidadeLeitura) {
        return (
          reportData &&
          reportData.relatorioPorOrdem.map((dados) =>
            montarRelatorioConsolidadosAcimaDoQuartoAno(dados)
          )
        );
      }

      return montarRelatorioConsolidadosAcimaDoQuartoAno(reportData);
    }
    return (
      <PollReportPortugueseGrid
        className="mt-3"
        classroomReport={classroomReport}
        total={props.pollReport.data.total}
        consideraNovaOpcao={props.pollReport.data.consideraNovaOpcaoRespostaSemPreenchimento}
        data={reportData}
      />
    );
  };

  const montarDados = () => {
    const ehPortugues =
      props.pollReport.selectedFilter.discipline ===
      DISCIPLINES_ENUM.DISCIPLINA_PORTUGUES.Descricao;
    const codigoCursoMaiorSete =
      Number(props.pollReport.selectedFilter.CodigoCurso) >= 7;

    if (ehPortugues) {
      return montarPortugues();
    }
    if (codigoCursoMaiorSete) {
      if (classroomReport) {
        return (
          <RelatorioMatematicaPorTurma
            alunos={reportData.alunos}
            perguntas={reportData.perguntas}
          />
        );
      }
      return (
        reportData &&
        reportData.perguntas &&
        reportData.perguntas.map((dados) => (
          <RelatorioMatematicaConsolidado dados={dados} />
        ))
      );
    }

    return (
      <PollReportMathGrid
        className="mt-3"
        classroomReport={classroomReport}
        data={reportData}
      />
    );
  };

  return (
    <>
      <PollReportBreadcrumb className="mt-4" name="Planilha" />
      {!!reportData && montarDados()}
    </>
  );
};
