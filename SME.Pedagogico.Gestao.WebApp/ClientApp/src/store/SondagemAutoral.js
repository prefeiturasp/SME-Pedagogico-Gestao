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
}
const initialState = {
    listaPeriodos: [],
    listaPerguntas: null,
    listaAlunosAutoralMatematica: [],
    period: null,
};

export const actionCreators = {
    listarPeriodos: () => ({ type: types.LISTAR_PERIODOS }),
    listarPerguntas: () => ({ type: types.LISTAR_PERGUNTAS }),
    listaAlunosAutoralMatematica: (filtro) => ({ type: types.LISTAR_ALUNOS_AUTORAL_MATEMATICA, filtro }),
    salvaSondagemAutoralMatematica: (alunos) => ({ type: types.SALVAR_SONDAGEM_AUTORAL_MATEMATICA, alunos }),
    setarSondagemAutoralMatematica: () => ({ type: types.SETAR_SONDAGEM_AUTORAL_MATEMATICA })
};

export const reducer = (state, action) => {
    state = state || initialState;
    switch (action.type) {
        case types.SETAR_PERIODOS:
            return ({
                ...state,
                listaPeriodos: action.listaPeriodos
            });
        case types.SETAR_PERGUNTAS:

            return ({
                ...state,
                listaPerguntas: action.listaPerguntas,
            });
        case types.SETAR_ALUNOS_AUTORAL_MATEMATICA:
            return ({
                ...state,
                listaAlunosAutoralMatematica: action.listaAlunosAutoralMatematica,
            });
        case types.SET_PERIOD:
            return ({
                ...state,
                period: action.listPeriod

            })

        default:
            return (state);
    }
};