// Store SondagemAutoral
export const types = {
  LISTAR_PERIODOS: "LISTAR_PERIODOS",
  SETAR_PERIODOS: "SETAR_PERIODOS",
  LISTAR_PERGUNTAS: "LISTAR_PERGUNTAS",
  SETAR_PERGUNTAS: "SETAR_PERGUNTAS",
  LISTAR_ALUNOS_AUTORAL_MATEMATICA: "LISTAR_ALUNOS_AUTORAL_MATEMATICA",
  SETAR_ALUNOS_AUTORAL_MATEMATICA: "SETAR_ALUNOS_AUTORAL_MATEMATICA",
  SALVAR_SONDAGEM_AUTORAL_MATEMATICA: "SALVAR_SONDAGEM_AUTORAL_MATEMATICA",
  SETAR_SONDAGEM_AUTORAL_MATEMATICA: "SETAR_SONDAGEM_AUTORAL_MATEMATICA",
  SETAR_ALUNOS_AUTORAL_MATEMATICA_PRE_SALVAR:
    "SETAR_ALUNOS_AUTORAL_MATEMATICA_PRE_SALVAR",
};
const initialState = {
  listaPeriodos: [],
  listaPerguntas: null,
  listaAlunosAutoralMatematica: [],
  period: null,
};

export const actionCreators = {
  listarPeriodos: () => ({ type: types.LISTAR_PERIODOS }),
  listarPerguntas: (anoEscolar) => ({
    type: types.LISTAR_PERGUNTAS,
    anoEscolar,
  }),
  listaAlunosAutoralMatematica: (filtro) => ({
    type: types.LISTAR_ALUNOS_AUTORAL_MATEMATICA,
    filtro,
  }),
  salvaSondagemAutoralMatematica: (alunos, filtro) => ({
    type: types.SALVAR_SONDAGEM_AUTORAL_MATEMATICA,
    payload: { alunos, filtro },
  }),
  setarSondagemAutoralMatematica: () => ({
    type: types.SETAR_SONDAGEM_AUTORAL_MATEMATICA,
  }),
  setarAlunosAutoralmatematicaPreSalvar: (alunos) => ({
    type: types.SETAR_ALUNOS_AUTORAL_MATEMATICA_PRE_SALVAR,
    alunos,
  }),
};

export const reducer = (state, action) => {
  state = state || initialState;
  switch (action.type) {
    case types.SETAR_PERIODOS:
      return {
        ...state,
        listaPeriodos: action.listaPeriodos,
      };
    case types.SETAR_PERGUNTAS:
      return {
        ...state,
        listaPerguntas: action.listaPerguntas,
      };
    case types.SETAR_ALUNOS_AUTORAL_MATEMATICA_PRE_SALVAR: {
      return {
        ...state,
        listaAlunosAutoralMatematica: action.alunos,
      };
    }
    case types.SETAR_ALUNOS_AUTORAL_MATEMATICA:
      return {
        ...state,
        listaAlunosAutoralMatematica: action.listaAlunosAutoralMatematica,
      };
    case types.SET_PERIOD:
      return {
        ...state,
        period: action.listPeriod,
      };

    default:
      return state;
  }
};
