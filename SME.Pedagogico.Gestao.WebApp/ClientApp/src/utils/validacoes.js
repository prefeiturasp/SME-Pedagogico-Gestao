import { store } from "..";
import { showModalConfirmAsync } from "../service/modal-service";
import { CONFIRMACAO_ESTUDANTE_SEM_RESPOSTA_SELECIONADA } from "./constants";

const temEstudantesSemRespostaUnicaMatematica = (estudantes) => {
  const estudanteSemResposta = estudantes.find((estudante) => {
    const respostas = estudante?.respostas;
    const semResposta = !respostas?.length;

    if (semResposta) return true;

    if (respostas?.length) {
      const semRespostasEmTodasPerguntas = respostas.find(
        (item) => !item?.resposta
      );

      return !!semRespostasEmTodasPerguntas;
    }
    return false;
  });

  return !!estudanteSemResposta;
};

export const validouEstudantesSemRespostaUnicaMatematica = async (estudantes) => {
    const exibirModalConfirmacao = temEstudantesSemRespostaUnicaMatematica(estudantes);

    if (exibirModalConfirmacao) {
        return await showModalConfirmAsync({
            content: CONFIRMACAO_ESTUDANTE_SEM_RESPOSTA_SELECIONADA,
            onOk: null,
            onCancel: null,
        });
    }
  return true;
};

export const validouEstudantesSemRespostaMatematicaCACM = async (estudantes) => {
  const state = store.getState();
  const perguntaSelecionada = state?.autoral?.perguntaSelecionada;

  if (perguntaSelecionada?.perguntas?.length) {
    const semResposta = perguntaSelecionada.perguntas.find((pergunta) => {
      const estudanteSemTodasRespostas = estudantes.find((estudante) => {
        const respostas = estudante?.respostas;
        let semRespostas = !respostas?.length;

        if (semRespostas) return true;

        const respostaParaPergunta = respostas.find(
          (resposta) => resposta?.pergunta === pergunta?.id
        );

        if (!respostaParaPergunta || !respostaParaPergunta?.resposta)
          return true;

        return false;
      });

      return !!estudanteSemTodasRespostas;
    });

    if (semResposta) {
      return await showModalConfirmAsync({
              content: CONFIRMACAO_ESTUDANTE_SEM_RESPOSTA_SELECIONADA,
              onOk: null,
          onCancel: null,
      });
    }
  }

  return true;
};
