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

const escolherComponentesMatematica = (props, updatePollStudent) => {
  if (
    props.poll.pollTypeSelected === "Numeric" &&
    (props.poll.pollYear === "1" ||
      props.poll.pollYear === "2" ||
      props.poll.pollYear === "3")
  ) {
    return (
      <StudentPollMathAlfabetizacaoCard
        students={props.poll.studentsPollMathNumbers}
        updatePollStudent={updatePollStudent}
        editLock1S={props.pollOptionSelectLock.poll_1s_lock}
        editLock2S={props.pollOptionSelectLock.poll_2s_lock}
      />
    );
  }

  const Component =
    componenteMatematica[props.poll.pollYear][props.poll.pollTypeSelected];
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

const escolherComponentes = (props, updatePollStudent) => {
  if (
    Number(props.poll.pollYear) > 3 &&
    props.poll.selectedFilter.schoolYear === 2022
  ) {
    return <NovaSondagemMatematicaAutoral />;
  }

  switch (props.poll.pollSelected) {
    case ClassRoomEnum.ClassPTAutoral:
      return <SondagemPortuguesAutoral />;
    case ClassRoomEnum.ClassMTAutoral:
      return <SondagemMatematicaAutoral />;
    case ClassRoomEnum.ClassPT:
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
    case ClassRoomEnum.ClassMT:
      return escolherComponentesMatematica(props, updatePollStudent);
    default:
      return "";
  }
};

export const componentRenderPoll = (props, updatePollStudent) => {
  return escolherComponentes(props, updatePollStudent);
};
