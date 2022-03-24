import React from "react";
import PropTypes from "prop-types";
import MensagemInformacao from "../messaging/MensagemInformacao";

function MensagemConfirmacao({
  exibir,
  acaoFeedBack,
  confirmacao,
  botaoSim,
  botaoNao,
}) {
  const titulo = "Atenção";
  const mensagemPrincipal =
    "Essa ação poderá cancelar a geração de relatório. Deseja continuar ?";

  return (
    <MensagemInformacao
      confirmacao={confirmacao}
      acaoFeedBack={acaoFeedBack}
      exibir={exibir}
      mensagemPrincipal={mensagemPrincipal}
      titulo={titulo}
      botaoSim={botaoSim}
      botaoNao={botaoNao}
    />
  );
}

MensagemConfirmacao.defaultProps = {
  acaoFeedBack: () => {},
  exibir: false,
  botaoSim: () => {},
  botaoNao: () => {},
  confirmacao: false,
};

MensagemConfirmacao.propTypes = {
  acaoFeedBack: PropTypes.func,
  exibir: PropTypes.bool,
  botaoSim: PropTypes.func,
  botaoNao: PropTypes.func,
  confirmacao: PropTypes.bool,
};

export default MensagemConfirmacao;
