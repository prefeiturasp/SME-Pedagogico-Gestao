import { Tooltip } from "antd";
import React from "react";
import { NumeroChamadaTexto } from "../styles";
import { RadioButton } from "./styles";

const LinhaAluno = (props) => {
  const { aluno, dadosLinha } = props;
  const { ehPergunta, pergundaId, repostaId } = dadosLinha;

  return ehPergunta ? (
    <Tooltip title={aluno?.nomeAluno} placement="bottomRight">
      <NumeroChamadaTexto>{aluno?.numeroChamada}</NumeroChamadaTexto>
    </Tooltip>
  ) : (
    <RadioButton
      type="radio"
      value={`${aluno.codigoAluno}-${pergundaId}-${repostaId}`}
      name={`${pergundaId}-${aluno.codigoAluno}`}
    />
  );
};

export default React.memo(LinhaAluno);
