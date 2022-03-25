import React from "react";
import MensagemInformacao from "../messaging/MensagemInformacao";
import { useSelector } from "react-redux";

function MensagemConfirmacaoImprimir({
  exibir,
  acaoFeedBack,
  linkPdf,
  messageType,
}) {
  const messageError = useSelector((store) => store.pollReport.messageError);

  const titulo = "Geração de relatório";
  const mensagemPrincipal =
    messageType === "success"
      ? "Relatório gerado com sucesso. Clique no botão Download para baixar o PDF."
      : messageError;

  return (
    <MensagemInformacao
      acaoFeedBack={acaoFeedBack}
      exibir={exibir}
      mesagemPrincipal={mensagemPrincipal}
      titulo={titulo}
      linkPdf={linkPdf}
    />
  );
}

export default MensagemConfirmacaoImprimir;
