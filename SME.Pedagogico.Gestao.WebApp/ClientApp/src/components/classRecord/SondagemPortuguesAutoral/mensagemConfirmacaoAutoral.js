import React from 'react';
import MesangemConfirmacao from '../../messaging/MensagemConfirmacao';

function MensagemConfirmacaoAutoral({ controleExibicao, acaoPrincipal, acaoSecundaria, exibir }) {

  const tituloPrincipal = "Atenção";
  const mensagem = "Existem alterações que não foram salvas! Deseja salvar agora?";
  const botaoPrincipal = "Sim";
  const botaoSecundario = "Não";
  const tituloFeedBack = "Informações Salvas";
  const feedBack = "Seus dados de sondagem foram salvos com sucesso."

  return <MesangemConfirmacao
    exibir={exibir}
    tituloPrincipal={tituloPrincipal}
    mensagemPrincipal={mensagem}
    botaoPrincipal={botaoPrincipal}
    botaoSecundario={botaoSecundario}
    tituloFeedBack={tituloFeedBack}
    feedBack={feedBack}
    controleExibicao={controleExibicao}
    acaoPrincial={acaoPrincipal}
    acaoSecundaria={acaoSecundaria} />

}

export default MensagemConfirmacaoAutoral;