import React from 'react';
import MesangemConfirmacao from '../../messaging/MensagemConfirmacao';

function MensagemLimparSelecao({ controleExibicao, acaoPrincipal, acaoSecundaria, exibir, tituloFeedBackOp, feedBackOp }) {

  const tituloPrincipal = "Atenção";
  const mensagem = " Você deseja excluir os dados digitados nesta ordem? Não será possível recuperá-los.";
  const botaoPrincipal = "Sim";
  const botaoSecundario = "Não";
  const tituloFeedBack = "Informações Removidas";
  const feedBack = "Seus dados de sondagem foram removidos com sucesso."

  return <MesangemConfirmacao
    exibir={exibir}
    tituloPrincipal={tituloPrincipal}
    mensagemPrincipal={mensagem}
    botaoPrincipal={botaoPrincipal}
    botaoSecundario={botaoSecundario}
    tituloFeedBack={tituloFeedBackOp || tituloFeedBack}
    feedBack={feedBackOp || feedBack}
    controleExibicao={controleExibicao}
    acaoPrincial={acaoPrincipal}
    acaoSecundaria={acaoSecundaria} />

}

export default MensagemLimparSelecao;