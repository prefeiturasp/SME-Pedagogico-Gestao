import { store } from "../../../..";
import { showModalConfirmAsync } from "../../../../service/modal-service";
import { CONFIRMACAO_ESTUDANTE_SEM_RESPOSTA_SELECIONADA } from "../../../../utils/constants";

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

export const validouEstudantesSemRespostaMatAutoral = async (alunosSalvar) => {
  const exibirModalConfirmacao = temEstudantesSemResposta(alunosSalvar);
  if (exibirModalConfirmacao) {
    return await showModalConfirmAsync({
        content: CONFIRMACAO_ESTUDANTE_SEM_RESPOSTA_SELECIONADA,
        onOk: null,
        onCancel: null,
    });
  }

  return true;
};
