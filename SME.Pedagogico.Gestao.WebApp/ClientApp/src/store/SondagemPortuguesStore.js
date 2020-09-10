export const types = {
    SELECIONAR_GRUPO: "SELECIONAR_GRUPO",
    SETAR_GRUPOS: "SETAR_GRUPOS",
    SETAR_ORDEM_SELECIONADA: "SETAR_ORDEM_SELECIONADA",
    SETAR_ALUNOS: "SETAR_ALUNOS",
    SETAR_PERIODOS: "SETAR_PERIODOS",
    SETAR_PERGUNTAS: "SETAR_PERGUNTAS",
    ATUALIZAR_RESPOSTA: "ATUALIZAR_RESPOSTA",
    //
    LISTAR_GRUPOS: "LISTAR_GRUPOS",
    LISTAR_COMPONENTE_CURRICULAR: "LISTAR_COMPONENTE_CURRICULAR",
    LISTAR_BIMESTRES: "LISTAR_BIMESTRES",
    LISTAR_PERGUNTAS_PORTUGUES: "LISTAR_PERGUNTAS_PORTUGUES",
    LISTAR_SEQUENCIA_ORDENS: "LISTAR_SEQUENCIA_ORDENS",
    LISTAR_ALUNOS_PORTUGUES: "LISTAR_ALUNOS_PORTUGUES",
    SALVAR_SONDAGEM_PORTUGUES: "SALVAR_SONDAGEM_PORTUGUES"
}

const initialState = {
    grupoSelecionado: null,
    grupos: [],
    ordemSelecionada: null,
    perguntas: [],
    alunos: [],
    periodos: [],
    sequenciaOrdens: [],
    componenteCurricular: null
};

export const actionCreators = {
    listarGrupos: () => ({ type: types.LISTAR_GRUPOS }),
    listarComponenteCurricular: () => ({ type: types.LISTAR_COMPONENTE_CURRICULAR }),
    listarBimestres: () => ({ type: types.LISTAR_BIMESTRES }),
    listarPerguntasPortugues: (sequenciaOrdem) => ({
        type: types.LISTAR_PERGUNTAS_PORTUGUES,
        payload: sequenciaOrdem,
    }),
    listarSequenciaOrdens: (filtros) => ({
        type: types.LISTAR_SEQUENCIA_ORDENS,
        payload: filtros,
    }),

    listarAlunosPortugues: (filtros) => ({
        type: types.LISTAR_ALUNOS_PORTUGUES,
        payload: filtros,
    }),

    salvarSondagemPortugues: (alunos, filtro) => ({
        type: types.SALVAR_SONDAGEM_PORTUGUES,
        payload: { alunos, filtro },
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
    setar_periodos: (periodos) => ({
        type: types.SETAR_PERIODOS,
        payload: periodos,
    }),
   
    atualizar_resposta: (atualizarDto) => ({
        type: types.ATUALIZAR_RESPOSTA,
        payload: atualizarDto,
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
           
            
      //


        case types.SETAR_ORDEM_SELECIONADA:
            return { ...state, ordemSelecionada: action.payload };
        case types.SETAR_ALUNOS:
            return { ...state, alunos: action.payload };

        case types.ATUALIZAR_RESPOSTA:
            const alunos = Object.assign([], state.alunos);

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
