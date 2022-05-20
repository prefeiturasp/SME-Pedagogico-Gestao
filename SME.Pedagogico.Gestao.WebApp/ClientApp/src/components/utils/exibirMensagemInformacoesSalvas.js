import { store } from "../../index";
import { actionCreators as dadosGerais } from "../../store/DadosGerais";

export const exibirMensagemInformacoesSalvas = () => {
  store.dispatch(
    dadosGerais.setExibirMensagemInformacao({
      exibir: true,
    })
  );
};
