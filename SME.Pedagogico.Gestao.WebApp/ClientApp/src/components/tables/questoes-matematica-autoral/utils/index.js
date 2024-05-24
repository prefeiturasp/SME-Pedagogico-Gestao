import { store } from "../../../..";
import { showModalError } from "../../../../service/modal-service";
import { ALERTA_ESTUDANTE_SEM_RESPOSTA_SELECIONADA } from "../../../../utils/constants";

const temEstudantesSemResposta = (alunosSalvar) => {
  const state = store.getState();
  const listaPerguntas = state?.autoral?.listaPerguntas;
  const qtdPerguntas = listaPerguntas?.length;

  const estudanteSemResposta = alunosSalvar.find((estudante) => {
    const respostas = estudante?.respostas;
    const semResposta = !respostas?.length;

    if (semResposta) return true;
    if (respostas?.length) {
      const semRespostasEmTodasPerguntas =
        respostas.length < qtdPerguntas ||
        respostas.find((item) => !item?.resposta);

      return !!semRespostasEmTodasPerguntas;
    }

    return false;
  });

  if (estudanteSemResposta) return true;

  return false;
};

export const validouEstudantesSemRespostaMatAutoral = (alunosSalvar) => {
  let continuar = true;

  const exibirModalErro = temEstudantesSemResposta(alunosSalvar);

  if (exibirModalErro) {
    showModalError({
      content: ALERTA_ESTUDANTE_SEM_RESPOSTA_SELECIONADA,
    });
    continuar = false;
  }

  return continuar;
};
