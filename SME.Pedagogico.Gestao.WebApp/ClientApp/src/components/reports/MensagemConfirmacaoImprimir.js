import React from "react";
import MensagemInformacao from "../messaging/MensagemInformacao";

function MensagemConfirmacaoImprimir({ exibir, acaoFeedBack }) {
  const titulo = "Informações Salvas";
  const mesagemPrincipal =
    "Solicitação de geração do relatório gerada com sucesso. Em breve você receberá uma notificação no ";
  const palavraEmNegrito = "SGP";
  const mensagemFinal = " com o resultado.";

  return (
    <MensagemInformacao
      acaoFeedBack={acaoFeedBack}
      exibir={exibir}
      mensagemFinal={mensagemFinal}
      mesagemPrincipal={mesagemPrincipal}
      palavraEmNegrito={palavraEmNegrito}
      titulo={titulo}
    />
  );
}

export default MensagemConfirmacaoImprimir;
