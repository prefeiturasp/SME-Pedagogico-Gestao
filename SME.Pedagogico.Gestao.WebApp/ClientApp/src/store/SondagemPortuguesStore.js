export const types = {
  SELECIONAR_GRUPO: "SELECIONAR_GRUPO",
  SETAR_GRUPOS: "SETAR_GRUPOS",
  SETAR_ORDEM_SELECIONADA: "SETAR_ORDEM_SELECIONADA",
  SETAR_ALUNOS: "SETAR_ALUNOS",
  SETAR_PERIODOS: "SETAR_PERIODOS",
  SETAR_PERGUNTAS: "SETAR_PERGUNTAS",
  ATUALIZAR_RESPOSTA: "ATUALIZAR_RESPOSTA",
  SETAR_BIMESTRES: "SETAR_BIMESTRES",
  SETAR_ALUNOS_PORTUGUES: "SETAR_ALUNOS_PORTUGUES",
  //
  LISTAR_GRUPOS: "LISTAR_GRUPOS",
  LISTAR_COMPONENTE_CURRICULAR: "LISTAR_COMPONENTE_CURRICULAR",
  LISTAR_BIMESTRES: "LISTAR_BIMESTRES",
  LISTAR_PERGUNTAS_PORTUGUES: "LISTAR_PERGUNTAS_PORTUGUES",
  LISTAR_SEQUENCIA_ORDENS: "LISTAR_SEQUENCIA_ORDENS",
  LISTAR_ALUNOS_PORTUGUES: "LISTAR_ALUNOS_PORTUGUES",
  SALVAR_SONDAGEM_PORTUGUES: "SALVAR_SONDAGEM_PORTUGUES",
  INSERIR_SEQUENCIA_ORDENS: "INSERIR_SEQUENCIA_ORDENS",
  REMOVER_SEQUENCIA_ORDENS: "REMOVER_SEQUENCIA_ORDENS",
  OBTER_SEQUENCIA_ORDEM: "OBTER_SEQUENCIA_ORDEM",
  LIMPAR_TODAS_ORDENS_SELECIONADAS: "LIMPAR_TODAS_ORDENS_SELECIONADAS",
  SETAR_PERIODO_SELECIONADO: "SETAR_PERIODO_SELECIONADO",
  SETAR_EM_EDICAO: "SETAR_EM_EDICAO",
  SALVAR_FUNCAO_SALVAMENTO: "SALVAR_FUNCAO_SALVAMENTO",
  SALVAR_FILTROS_CONSULTA_SALVAMENTO: "SALVAR_FILTROS_CONSULTA_SALVAMENTO",
  SETAR_SEQUENCIA_ORDENS: "SETAR_SEQUENCIA_ORDENS",
  LIMPAR_RESPOSTAS_ALUNOS: "LIMPAR_RESPOSTAS_ALUNOS",
}

const initialState = {
  grupoSelecionado: null,
  grupos: [],
  ordemSelecionada: null,
  perguntas: [],
  alunos: [],
  periodos: [],
  sequenciaOrdens: [],
  componenteCurricular: null,
  sequenciaOrdem: [],
  emEdicao: false,
  periodoSelecionado: null,
  salvar: null,
  filtros: {},
};

export const actionCreators = {
  listarGrupos: () => ({ type: types.LISTAR_GRUPOS }),
  listarComponenteCurricular: () => ({ type: types.LISTAR_COMPONENTE_CURRICULAR }),
  listarBimestres: () => ({ type: types.LISTAR_BIMESTRES }),
  listarPerguntasPortugues: (sequenciaOrdem, grupoId) => ({
    type: types.LISTAR_PERGUNTAS_PORTUGUES,
    payload: { sequenciaOrdem, grupoId },
  }),
  listarSequenciaOrdens: (filtros) => ({
    type: types.LISTAR_SEQUENCIA_ORDENS,
    payload: filtros,
  }),
  listarAlunosPortugues: (filtros) => ({
    type: types.LISTAR_ALUNOS_PORTUGUES,
    payload: filtros,
  }),
  salvarSondagemPortugues: ({ alunos, filtro, novaOrdem, novoPeriodoId }) => ({
    type: types.SALVAR_SONDAGEM_PORTUGUES,
    payload: { alunos, filtro, novaOrdem, novoPeriodoId },
  }),
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
  setar_emEdicao: (emEdicao) => ({
    type: types.SETAR_EM_EDICAO,
    payload: emEdicao,
  }),
  setar_periodos: (periodos) => ({
    type: types.SETAR_PERIODOS,
    payload: periodos,
  }),
  setar_sequencia_ordens: (sequencias) => ({
    type: types.SETAR_SEQUENCIA_ORDENS,
    payload: sequencias,
  }),
  atualizar_resposta: (atualizarDto) => ({
    type: types.ATUALIZAR_RESPOSTA,
    payload: atualizarDto,
  }),
  inserir_sequencia_ordem: (ordemId) => ({
    type: types.INSERIR_SEQUENCIA_ORDENS,
    payload: ordemId,
  }),
  limpar_todas_ordens_selecionadas: () => ({
    type: types.LIMPAR_TODAS_ORDENS_SELECIONADAS
  }),
  setar_periodo_selecionado: (periodoSelecionado) => ({
    type: types.SETAR_PERIODO_SELECIONADO,
    payload: periodoSelecionado,
  }),
  salvar_funcao_salvamento: (salvar) => ({
    type: types.SALVAR_FUNCAO_SALVAMENTO,
    payload: salvar
  }),
  salvar_filtros_consulta_salvamento: (filtros) => ({
    type: types.SALVAR_FILTROS_CONSULTA_SALVAMENTO,
    payload: filtros,
  }),
  limpar_respostas_alunos: () => ({
    type: types.LIMPAR_RESPOSTAS_ALUNOS
  }),
  remover_sequencia_ordens: (ordemId) => ({
    type: types.REMOVER_SEQUENCIA_ORDENS,
    payload: ordemId
  })
};

export const reducer = (state, action) => {
  state = state || initialState;

  switch (action.type) {
    case types.SELECIONAR_GRUPO:
      return { ...state, grupoSelecionado: action.payload };
    case types.SETAR_GRUPOS:
      return { ...state, grupos: action.payload };
    case types.SETAR_COMPONENTE_CURRICULAR:
      return { ...state, componenteCurricular: action.payload };
    case types.SETAR_BIMESTRES:
      return { ...state, periodos: action.payload };
    case types.SETAR_PERGUNTAS:
      return { ...state, perguntas: action.payload };
    case types.SETAR_SEQUENCIA_ORDENS:
      return { ...state, sequenciaOrdens: action.payload };
    case types.SETAR_ALUNOS_PORTUGUES:
      return { ...state, alunos: action.payload };
    case types.SETAR_ORDEM_SELECIONADA:
      return { ...state, ordemSelecionada: action.payload };
    case types.SETAR_ALUNOS:
      return { ...state, alunos: action.payload };
    case types.LIMPAR_TODAS_ORDENS_SELECIONADAS:
      return { ...state, sequenciaOrdens: [], ordemSelecionada: null };
    case types.SETAR_PERIODO_SELECIONADO:
      return { ...state, periodoSelecionado: action.payload };
    case types.SETAR_EM_EDICAO:
      return { ...state, emEdicao: action.payload };
    case types.SALVAR_FUNCAO_SALVAMENTO:
      return { ...state, salvar: action.payload };
    case types.SALVAR_FILTROS_CONSULTA_SALVAMENTO:
      return { ...state, filtros: action.payload };
    case types.LIMPAR_RESPOSTAS_ALUNOS:
      const alunosSemResposta = state.alunos.map(aluno => { return { ...aluno, respostas: [] } });

      return { ...state, alunos: alunosSemResposta };

    case types.REMOVER_SEQUENCIA_ORDENS:
      const sequenciaOrdemNova = state.sequenciaOrdens.filter(sequencia => sequencia.ordemId !== action.payload);

      return { ...state, sequenciaOrdens: sequenciaOrdemNova, emEdicao: false };
    case types.INSERIR_SEQUENCIA_ORDENS:
      let sequenciaOrdem = Object.assign([], state.sequenciaOrdens)

      const naLista = sequenciaOrdem.findIndex(ordem => ordem.ordemId === action.payload);
      if (naLista !== -1)
        return { ...state, ordemSelecionada: action.payload, emEdicao: true };

      if (sequenciaOrdem === null || sequenciaOrdem.length === 0) {
        sequenciaOrdem = [];
        sequenciaOrdem.push({ ordemId: action.payload });
        return { ...state, sequenciaOrdens: sequenciaOrdem, ordemSelecionada: action.payload, emEdicao: true };
      }

      for (let i = 0; i < 3; i++) {
        if (sequenciaOrdem[i])
          continue;

        sequenciaOrdem[i] = { ordemId: action.payload };
        break;
      }

      return { ...state, sequenciaOrdens: sequenciaOrdem, ordemSelecionada: action.payload, emEdicao: true }
    case types.ATUALIZAR_RESPOSTA:
      let alunos = Object.assign([], state.alunos);

      const alunoIndex = alunos.findIndex(aluno => aluno.codigoAluno === action.payload.alunoId);

      if (alunoIndex < 0)
        return state;

      const aluno = alunos[alunoIndex];

      const respostaIndex = aluno.respostas ? aluno.respostas
        .findIndex(resposta => resposta.pergunta === action.payload.perguntaId
          && action.payload.periodoId) : -1;

      const resposta = respostaIndex < 0 ? {
        periodoId: action.payload.periodoId,
        pergunta: action.payload.perguntaId,
        resposta: action.payload.respostaId,
      } : aluno.respostas[respostaIndex];

      resposta.resposta = action.payload.respostaId;

      if (!aluno.respostas)
        alunos[alunoIndex].respostas = [];

      if (respostaIndex < 0)
        alunos[alunoIndex].respostas.push(resposta);
      else
        alunos[alunoIndex].respostas[respostaIndex] = resposta;

      return { ...state, alunos };
    default:
      return state;
  }
};
