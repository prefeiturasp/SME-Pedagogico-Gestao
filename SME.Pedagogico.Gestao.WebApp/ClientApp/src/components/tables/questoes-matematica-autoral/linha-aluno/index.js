import { Form, Tooltip } from "antd";
import React from "react";
import { NumeroChamadaTexto } from "../styles";
import { Label, RadioButton } from "./styles";

const LinhaAluno = (props) => {
  const { aluno, dadosLinha } = props;
  const { ehPergunta, ehResposta, perguntaId, repostaId } = dadosLinha;

  const form = Form.useFormInstance();
  const nomeCampo = `${perguntaId}-${aluno.codigoAluno}`;

  const repostaSelecionada = ehResposta
    ? aluno?.respostas?.find((r) => r?.pergunta === perguntaId)
    : null;

  const temRespostaMarcada =
    repostaSelecionada?.resposta && repostaSelecionada?.resposta !== repostaId;

  const temOutraOpcaoSelecionada = () => {
    const temRadioMarcado = document.querySelector(
      `table input[name='${nomeCampo}']:checked`
    );

    const checkedRadios = document.querySelectorAll(
      `table input[name='${nomeCampo}']:not(:checked)`
    );

    if (temRadioMarcado) {
      checkedRadios.forEach((radio) => radio.classList.add("light-border"));
    } else {
      checkedRadios.forEach((radio) => radio.classList.remove("light-border"));
    }
  };

  const handleOnClick = () => {
    const valorSelecionado = form.getFieldValue(nomeCampo);

    if (valorSelecionado === repostaId) {
      form.setFieldValue(nomeCampo, undefined);
      form.getFieldInstance(nomeCampo).input.checked = false;
    }

    temOutraOpcaoSelecionada();
  };

  if (repostaSelecionada && repostaSelecionada?.resposta === repostaId) {
    form.setFieldValue(nomeCampo, repostaId);
  }

  return ehPergunta ? (
    <Tooltip title={aluno?.nomeAluno} placement="bottomRight">
      <NumeroChamadaTexto>{aluno?.numeroChamada}</NumeroChamadaTexto>
    </Tooltip>
  ) : (
    <Label htmlFor={`${repostaId}-${aluno.codigoAluno}`}>
      <Form.Item name={nomeCampo} getValueProps={() => null}>
        <RadioButton
          type="radio"
          name={nomeCampo}
          value={repostaId}
          onClick={() => handleOnClick()}
          id={`${repostaId}-${aluno.codigoAluno}`}
          className={temRespostaMarcada ? "light-border" : ""}
          defaultChecked={repostaSelecionada?.resposta === repostaId}
        />
      </Form.Item>
    </Label>
  );
};

export default React.memo(LinhaAluno);
