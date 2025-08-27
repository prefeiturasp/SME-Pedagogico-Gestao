import React from "react";

import { ClassRoomEnum } from "../../polls/component/ClassRoomHelper";

import StudentPollMathAlfabetizacaoCard from "../../polls/StudentPollMathAlfabetizacaoCard";
import StudentPollPortugueseCard from "../../polls/StudentPollPortugueseCard";
import SondagemMatematicaAutoral from "../SondagemMatematicaAutoral";
import NovaSondagemMatematicaAutoral from "../NovaSondagemMatematicaAutoral";
import SondagemPortuguesAutoral from "../SondagemPortuguesAutoral";

import {
  componenteMatematica,
  escolherPropriedade,
} from "./componentesMatematica";
import NovaSondagemAlfabetizacao from "../../polls/NovaSondagem/novaSondagemAlfabetizacao";
import QuestoesMatematicaAutoral from "../../tables/questoes-matematica-autoral";

const escolherComponentesMatematica = (props, updatePollStudent) => {
  let pollYearRender = props.poll.pollYear;
  if (
    Number(props.poll.selectedFilter?.schoolYear) === 2025 &&
    Number(props.poll.pollYear) >= 4 &&
    Number(props.poll.pollYear) <= 9
  ) {
    pollYearRender = "3";
  }

  const ehNovaSondagem = props.poll.selectedFilter.schoolYear >= 2022;
  const ehNovoComponenteAutoral = props.poll.selectedFilter.schoolYear >= 2023;
  const ehAlfabetizacao = Number(pollYearRender) < 4;
  const ehInterAutoral = Number(pollYearRender) > 3;
  const ehAutoral = props.poll.pollSelected === ClassRoomEnum.ClassMTAutoral;
  const ehTipoNumerico =
    props.poll.pollTypeSelected === escolherPropriedade.Numeric;

  if (ehNovoComponenteAutoral && ehInterAutoral) {
    return <QuestoesMatematicaAutoral />;
  }

  if (ehNovaSondagem && ehAlfabetizacao) {
    return <NovaSondagemAlfabetizacao />;
  }

  if (ehNovaSondagem && ehInterAutoral) {
    return <NovaSondagemMatematicaAutoral />;
  }

  if (ehTipoNumerico) {
    return (
      <StudentPollMathAlfabetizacaoCard
        students={props.poll.studentsPollMathNumbers}
        updatePollStudent={updatePollStudent}
        editLock1S={props.pollOptionSelectLock.poll_1s_lock}
        editLock2S={props.pollOptionSelectLock.poll_2s_lock}
      />
    );
  }

  if (ehAutoral) {
    return <SondagemMatematicaAutoral />;
  }

  const Component =
    componenteMatematica[pollYearRender][props.poll.pollTypeSelected];
  const propriedade = escolherPropriedade[props.poll.pollTypeSelected];

  return (
    <Component
      students={props.poll[propriedade]}
      updatePollStudent={updatePollStudent}
      editLock1S={props.pollOptionSelectLock.poll_1s_lock}
      editLock2S={props.pollOptionSelectLock.poll_2s_lock}
    />
  );
};

const escolherComponentesPortugues = (props, updatePollStudent) => {
  let pollYearRender = props.poll.pollYear;
  const is2025 = Number(props.poll.selectedFilter?.schoolYear) === 2025;
  const isTurma49 =
    Number(props.poll.pollYear) >= 4 && Number(props.poll.pollYear) <= 9;

  // Se for 2025 e turma de 4-9, renderizar como 3 para o componente regular
  if (is2025 && isTurma49) {
    pollYearRender = "3";
  }

  // Se for ClassPTAutoral, mas NÃO for 2025 turma 4–9
  if (
    props.poll.pollSelected === ClassRoomEnum.ClassPTAutoral &&
    !(is2025 && isTurma49)
  ) {
    return <SondagemPortuguesAutoral />;
  }

  // Se for turma ajustada para render: 1-3 ou 4-9 em 2025 (como "3")
  if (
    Number(pollYearRender) === 1 ||
    Number(pollYearRender) === 2 ||
    Number(pollYearRender) === 3
  ) {
    return (
      <StudentPollPortugueseCard
        students={props.poll.students}
        updatePollStudent={updatePollStudent}
        editLock1b={props.pollOptionSelectLock.poll_1b_lock}
        editLock2b={props.pollOptionSelectLock.poll_2b_lock}
        editLock3b={props.pollOptionSelectLock.poll_3b_lock}
        editLock4b={props.pollOptionSelectLock.poll_4b_lock}
      />
    );
  }

  // Para outros casos futuros, retorne o padrão
  return (
    <StudentPollPortugueseCard
      students={props.poll.students}
      updatePollStudent={updatePollStudent}
      editLock1b={props.pollOptionSelectLock.poll_1b_lock}
      editLock2b={props.pollOptionSelectLock.poll_2b_lock}
      editLock3b={props.pollOptionSelectLock.poll_3b_lock}
      editLock4b={props.pollOptionSelectLock.poll_4b_lock}
    />
  );
};

const escolherComponentes = (props, updatePollStudent) => {
  switch (props.poll.pollSelected) {
    case ClassRoomEnum.ClassPTAutoral:
    case ClassRoomEnum.ClassPT:
      return escolherComponentesPortugues(props, updatePollStudent);
    case ClassRoomEnum.ClassMT:
    case ClassRoomEnum.ClassMTAutoral:
      return escolherComponentesMatematica(props, updatePollStudent);
    default:
      return "";
  }
};

export const componentRenderPoll = (props, updatePollStudent) => {
  return escolherComponentes(props, updatePollStudent);
};
