import React from "react";
import { useDispatch, useSelector } from "react-redux";

import MensagemInformacao from "./MensagemInformacao";
import { actionCreators as dadosGerais } from "../../store/DadosGerais";

const MensagemInformacaoGeral = () => {
  const { exibir, titulo, mensagem } = useSelector(
    (store) => store.dadosGerais
  );

  const dispatch = useDispatch();
  const setExibirMensagem = (exibir) =>
    dispatch(dadosGerais.setExibirMensagemInformacao({ exibir }));

  return (
    <MensagemInformacao
      exibir={exibir}
      titulo={titulo}
      mensagemPrincipal={mensagem}
      acaoFeedBack={() => setExibirMensagem(false)}
    />
  );
};

export default MensagemInformacaoGeral;
