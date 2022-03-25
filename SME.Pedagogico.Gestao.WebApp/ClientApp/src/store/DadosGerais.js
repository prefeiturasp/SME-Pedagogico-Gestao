export const types = {
  EXIBIR_MENSAGEM_INFORMACAO: "EXIBIR_MENSAGEM_INFORMACAO",
};

const initialState = {
  exibir: false,
  titulo: "Informações Salvas",
  mensagem: "Seus dados de sondagem foram salvos com sucesso.",
};

export const actionCreators = {
  setExibirMensagemInformacao: (exibirMensagemInformacao) => ({
    type: types.EXIBIR_MENSAGEM_INFORMACAO,
    exibirMensagemInformacao,
  }),
};

export const reducer = (state, action) => {
  state = state || initialState;

  switch (action.type) {
    case types.EXIBIR_MENSAGEM_INFORMACAO:
      const exibir = action.exibirMensagemInformacao.exibir;
      const titulo =
        action.exibirMensagemInformacao.titulo || initialState.titulo;
      const mensagem =
        action.exibirMensagemInformacao.mensagem || initialState.mensagem;

      return {
        ...state,
        exibir,
        titulo,
        mensagem,
      };
    default:
      return state;
  }
};
