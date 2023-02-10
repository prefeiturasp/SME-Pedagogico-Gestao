export const types = {
  LISTAR_PERIODOS: "LISTAR_PERIODOS",
  SETAR_PERIODOS: "SETAR_PERIODOS",
  LISTAR_PERGUNTAS: "LISTAR_PERGUNTAS",
  SETAR_PERGUNTAS: "SETAR_PERGUNTAS",
  SETAR_PERGUNTA_SELECIONADA: "SETAR_PERGUNTA_SELECIONADA",
  LISTAR_ALUNOS_AUTORAL_MATEMATICA: "LISTAR_ALUNOS_AUTORAL_MATEMATICA",
  LIMPAR_ALUNOS_AUTORAL_MATEMATICA: "LIMPAR_ALUNOS_AUTORAL_MATEMATICA",
  SETAR_ALUNOS_AUTORAL_MATEMATICA: "SETAR_ALUNOS_AUTORAL_MATEMATICA",
  SALVAR_SONDAGEM_AUTORAL_MATEMATICA: "SALVAR_SONDAGEM_AUTORAL_MATEMATICA",
  SETAR_SONDAGEM_AUTORAL_MATEMATICA: "SETAR_SONDAGEM_AUTORAL_MATEMATICA",
  SETAR_STATUS_AUTORAL_MATEMATICA: "SETAR_STATUS_AUTORAL_MATEMATICA",
  SETAR_EM_EDICAO: "SETAR_EM_EDICAO",
  SETAR_ALUNOS_AUTORAL_MATEMATICA_PRE_SALVAR:
    "SETAR_ALUNOS_AUTORAL_MATEMATICA_PRE_SALVAR",
  OBTER_PERIODO_ABERTO: "OBTER_PERIODO_ABERTO",
  SETAR_PERIODO_ABERTO: "SETAR_PERIODO_ABERTO",
};
const initialState = {
  listaPeriodos: [],
  listaPerguntas: null,
  listaAlunosAutoralMatematica: [],
  emEdicao: false,
  perguntaSelecionada: null,
  period: null,
  periodoAberto: false,
  statusDadosMatematica: null,
};

export const actionCreators = {
  listarPeriodos: () => ({ type: types.LISTAR_PERIODOS }),
  listarPerguntas: (filtros) => ({
    type: types.LISTAR_PERGUNTAS,
    filtros,
  }),
  setarPerguntas: (perguntas) => ({
    type: types.SETAR_PERGUNTAS,
    payload: perguntas,
  }),
  statusSalvarDados: (status) => ({
    type: types.SETAR_STATUS_AUTORAL_MATEMATICA,
    payload: status,
  }),
  listaAlunosAutoralMatematica: (filtro, bimestre = null) => ({
    type: types.LISTAR_ALUNOS_AUTORAL_MATEMATICA,
    payload: { bimestre, filtro },
  }),
  limparAlunosAutoralMatematica: () => ({
    type: types.LIMPAR_ALUNOS_AUTORAL_MATEMATICA,
  }),
  salvaSondagemAutoralMatematica: (alunos, filtro) => ({
    type: types.SALVAR_SONDAGEM_AUTORAL_MATEMATICA,
    payload: { alunos, filtro },
  }),
  setarEmEdicao: (emEdicao) => ({
    type: types.SETAR_EM_EDICAO,
    payload: emEdicao,
  }),
  setarSondagemAutoralMatematica: () => ({
    type: types.SETAR_SONDAGEM_AUTORAL_MATEMATICA,
  }),
  setarAlunosAutoralmatematicaPreSalvar: (alunos) => ({
    type: types.SETAR_ALUNOS_AUTORAL_MATEMATICA_PRE_SALVAR,
    alunos,
  }),
  setarPerguntaSelecionada: (pergunta) => ({
    type: types.SETAR_PERGUNTA_SELECIONADA,
    payload: pergunta,
  }),
  obterPeriodoAberto: (anoLetivo, bimestre, tipoPeriodicidade) => ({
    type: types.OBTER_PERIODO_ABERTO,
    payload: { anoLetivo, bimestre, tipoPeriodicidade },
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
    case types.SETAR_STATUS_AUTORAL_MATEMATICA: {
      return {
        ...state,
        statusDadosMatematica: action.status,
      };
    }
    case types.SETAR_ALUNOS_AUTORAL_MATEMATICA_PRE_SALVAR: {
      return {
        ...state,
        listaAlunosAutoralMatematica: action.alunos,
      };
    }
    case types.SETAR_EM_EDICAO:
      return {
        ...state,
        emEdicao: action.payload,
      };
    case types.SETAR_ALUNOS_AUTORAL_MATEMATICA:
      return {
        ...state,
        listaAlunosAutoralMatematica: action.listaAlunosAutoralMatematica,
      };
    case types.LIMPAR_ALUNOS_AUTORAL_MATEMATICA:
      return {
        ...state,
        listaAlunosAutoralMatematica: [],
      };
    case types.SET_PERIOD:
      return {
        ...state,
        period: action.listPeriod,
      };
    case types.SETAR_PERGUNTA_SELECIONADA:
      return {
        ...state,
        perguntaSelecionada: action.payload,
      };
    case types.SETAR_PERIODO_ABERTO:
      return {
        ...state,
        periodoAberto: action.periodoAberto,
      };
    default:
      return state;
  }
};
