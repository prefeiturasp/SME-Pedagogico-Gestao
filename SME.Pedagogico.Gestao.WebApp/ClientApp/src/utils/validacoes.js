import { store } from "..";
import { showModalError } from "../service/modal-service";
import { ALERTA_ESTUDANTE_SEM_RESPOSTA_SELECIONADA } from "./constants";

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

export const validouEstudantesSemRespostaUnicaMatematica = (estudantes) => {
  let continuar = true;

  const exibirModalErro = temEstudantesSemRespostaUnicaMatematica(estudantes);

  if (exibirModalErro) {
    showModalError({
      content: ALERTA_ESTUDANTE_SEM_RESPOSTA_SELECIONADA,
    });
    continuar = false;
  }

  return continuar;
};

export const validouEstudantesSemRespostaMatematicaCACM = (estudantes) => {
  let continuar = true;

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
      showModalError({
        content: ALERTA_ESTUDANTE_SEM_RESPOSTA_SELECIONADA,
      });
      continuar = false;
    }
  }

  return continuar;
};
