import { type } from "jquery";

export const types = {
  SELECIONAR_GRUPO: "SELECIONAR_GRUPO",
  SETAR_GRUPOS: "SETAR_GRUPOS",
  SETAR_ORDEM_SELECIONADA: "SETAR_ORDEM_SELECIONADA",
  SETAR_ALUNOS: "SETAR_ALUNOS",
  SETAR_PERIODOS: "SETAR_PERIODOS",
  SETAR_PERGUNTAS: "SETAR_PERGUNTAS",
};

const initialState = {
  grupoSelecionado: null,
  grupos: [],
  ordemSelecionada: null,
  perguntas: [],
  alunos: [],
  periodos: [],
};

export const actionCreators = {
  selecionar_grupo: (grupo) => ({
    type: types.SELECIONAR_GRUPO,
    payload: grupo,
  }),
  setar_grupos: (grupos) => ({
    type: types.SETAR_GRUPOS,
    payload: grupos,
  }),
  setar_ordem_selecionada: (ordemId) => ({
    type: types.SETAR_ORDEM_SELECIONADA,
    payload: ordemId,
  }),
  setar_alunos: (alunos) => ({
    type: types.SETAR_ALUNOS,
    payload: alunos,
  }),
  setar_periodos: (periodos) => ({
    type: types.SETAR_PERIODOS,
    payload: periodos,
  }),
  setar_perguntas: (perguntas) => ({
    type: types.SETAR_PERGUNTAS,
    payload: perguntas,
  })
};

export const reducer = (state, action) => {
  state = state || initialState;

  switch (action.type) {
    case types.SELECIONAR_GRUPO:
      return { ...state, grupoSelecionado: action.payload };
    case types.SETAR_GRUPOS:
      return { ...state, grupos: action.payload };
    case types.SETAR_ORDEM_SELECIONADA:
      return { ...state, ordemSelecionada: action.payload };
    case types.SETAR_ALUNOS:
      return { ...state, alunos: action.payload };
    case types.SETAR_PERIODOS:
      return { ...state, periodos: action.payload };
    case types.SETAR_PERGUNTAS:
      return { ...state, perguntas: action.payload };
    default:
      return state;
  }
};
