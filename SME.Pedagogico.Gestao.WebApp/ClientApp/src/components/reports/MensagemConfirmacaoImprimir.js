import React from "react";
import MensagemInformacao from "../messaging/MensagemInformacao";

function MensagemConfirmacaoImprimir({ exibir, acaoFeedBack, linkPdf }) {
  const titulo = "Geração de relatório";
  const mesagemPrincipal =
    "Relatório gerado com sucesso. Clique no botão Download para baixar o PDF.";

  return (
    <MensagemInformacao
      acaoFeedBack={acaoFeedBack}
      exibir={exibir}
      mesagemPrincipal={mesagemPrincipal}
      titulo={titulo}
      linkPdf={linkPdf}
    />
  );
}

export default MensagemConfirmacaoImprimir;
