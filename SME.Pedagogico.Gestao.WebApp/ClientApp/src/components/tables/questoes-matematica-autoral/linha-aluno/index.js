import { Form, Tooltip } from "antd";
import React from "react";
import { NumeroChamadaTexto } from "../styles";
import { RadioButton } from "./styles";

const LinhaAluno = (props) => {
  const { aluno, dadosLinha } = props;
  const { ehPergunta, ehResposta, perguntaId, repostaId } = dadosLinha;

  const form = Form.useFormInstance();
  const nomeCampo = `${perguntaId}-${aluno.codigoAluno}`;

  const repostaSelecionada = ehResposta
    ? aluno?.respostas?.find((r) => r?.pergunta === perguntaId)
    : null;

  if (repostaSelecionada && repostaSelecionada?.resposta === repostaId) {
    form.setFieldValue(nomeCampo, repostaId);
  }

  const handleOnClick = () => {
    const valores = form.getFieldsValue();
    const valorSelecionado = valores[nomeCampo];

    if (valorSelecionado === repostaId) {
      form.setFieldValue(nomeCampo, undefined);
      form.getFieldInstance(nomeCampo).input.checked = false;
    }
  }

  return ehPergunta ? (
    <Tooltip title={aluno?.nomeAluno} placement="bottomRight">
      <NumeroChamadaTexto>{aluno?.numeroChamada}</NumeroChamadaTexto>
    </Tooltip>
  ) : (
    <Form.Item name={nomeCampo} getValueProps={() => null}>
      <RadioButton
        type="radio"
        name={nomeCampo}
        value={repostaId}
        onClick={() => handleOnClick()}
        defaultChecked={repostaSelecionada?.resposta === repostaId}
      />
    </Form.Item>
  );
};

export default React.memo(LinhaAluno);
