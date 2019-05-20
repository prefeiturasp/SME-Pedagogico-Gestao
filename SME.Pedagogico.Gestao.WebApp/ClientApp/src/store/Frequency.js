

export const types = {
    FREQUENCY_EFFECT_REQUEST: "FREQUENCY_EFFECT_REQUEST",
    RESPONSE_FREQUENCY: "RESPONSE_FREQUENCY",
    GET_STUDENTS: "GET_STUDENTS",
}


 export const actionCreators = {
     getStudents: () => ({ type: types.GET_STUDENTS }),
     frequencyeffect: (eff) => ({ type: types.FREQUENCY_EFFECT_REQUEST, eff })
};

const initialState = {
    students: [],
    effectFrequency: {
        students: [],
        checked: false,
    }
};


export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case types.GET_STUDENTS:
            var students = [
                {
                    "codigoAluno": 7138321,
                    "nomeAluno": "ALECSANDRO APARECIDO RODRIGUES",
                    "dataNascimento": "04/10/1985 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:54",
                    "numeroAlunoChamada": 2,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 2030251,
                    "nomeAluno": "CLAUDIA RAMOS DE LIMA",
                    "dataNascimento": "21/04/1975 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:54",
                    "numeroAlunoChamada": 6,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 4186159,
                    "nomeAluno": "JULIA NAOMI MARQUES DA SILVA",
                    "dataNascimento": "21/02/2003 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:54",
                    "numeroAlunoChamada": 12,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7131802,
                    "nomeAluno": "MAURA APARECIDA DE PAULA",
                    "dataNascimento": "06/04/1971 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:54",
                    "numeroAlunoChamada": 16,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7179915,
                    "nomeAluno": "MIZAEL DE JESUS SENHORINHO",
                    "dataNascimento": "13/11/1976 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:55",
                    "numeroAlunoChamada": 17,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 503783,
                    "nomeAluno": "PATRICIA DOS SANTOS COSTA",
                    "dataNascimento": "07/06/1983 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:55",
                    "numeroAlunoChamada": 18,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7065278,
                    "nomeAluno": "REGIANE DOS SANTOS FREIRE",
                    "dataNascimento": "02/04/1977 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:55",
                    "numeroAlunoChamada": 20,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7021040,
                    "nomeAluno": "ROSILAINE CAROMANO MANTOANI",
                    "dataNascimento": "11/01/1966 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:55",
                    "numeroAlunoChamada": 21,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7174710,
                    "nomeAluno": "ROZILDA MARIA SILVA MEIRA",
                    "dataNascimento": "11/04/1978 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:55",
                    "numeroAlunoChamada": 22,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 2463216,
                    "nomeAluno": "SIDNEI RAMOS DE LIMA",
                    "dataNascimento": "01/10/1981 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:55",
                    "numeroAlunoChamada": 25,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 5825228,
                    "nomeAluno": "VALDELICE DA SILVA SANTOS",
                    "dataNascimento": "31/07/1978 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:06:55",
                    "numeroAlunoChamada": 26,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 2832696,
                    "nomeAluno": "GUILHERME EZEQUIEL SANTOS DOS ANJOS",
                    "dataNascimento": "02/02/2003 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:37:29",
                    "numeroAlunoChamada": 10,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 3207459,
                    "nomeAluno": "IURY GABRIEL CUNHA SILVA PORTELLA",
                    "dataNascimento": "22/08/2003 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:37:29",
                    "numeroAlunoChamada": 11,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 3062141,
                    "nomeAluno": "LUCAS GONCALVES DA SILVA",
                    "dataNascimento": "27/01/2002 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "27/11/2018 15:37:29",
                    "numeroAlunoChamada": 13,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 3902394,
                    "nomeAluno": "SAMUEL BARROS DA SILVA",
                    "dataNascimento": "04/07/2002 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "08/01/2019 09:55:05",
                    "numeroAlunoChamada": 24,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 4614356,
                    "nomeAluno": "VANESSA GONCALVES DE ARAUJO",
                    "dataNascimento": "30/06/2003 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "23/01/2019 11:56:55",
                    "numeroAlunoChamada": 27,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7253736,
                    "nomeAluno": "AGNALDO DA CRUZ",
                    "dataNascimento": "04/06/1967 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "31/01/2019 10:50:42",
                    "numeroAlunoChamada": 1,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 5881925,
                    "nomeAluno": "MARIA GRACIENE BASILIO DA SILVA",
                    "dataNascimento": "18/04/1984 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "31/01/2019 17:35:31",
                    "numeroAlunoChamada": 14,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 5975785,
                    "nomeAluno": "DANYELA PATRICIA BRITO DE SIQUEIRA",
                    "dataNascimento": "24/12/1992 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "08/02/2019 18:35:32",
                    "numeroAlunoChamada": 7,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 6510312,
                    "nomeAluno": "ZULMA KAREN SALINAS YUCRA",
                    "dataNascimento": "14/02/1995 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "08/02/2019 18:36:44",
                    "numeroAlunoChamada": 28,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 4064847,
                    "nomeAluno": "ANA PAULA FERMI GARIGLIO",
                    "dataNascimento": "01/09/1977 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "18/02/2019 12:08:17",
                    "numeroAlunoChamada": 3,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 6324954,
                    "nomeAluno": "EVA GONCALVES FERREIRA",
                    "dataNascimento": "16/11/1992 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "19/02/2019 20:59:14",
                    "numeroAlunoChamada": 8,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 3059956,
                    "nomeAluno": "PEDRO HENRIQUE OLIVEIRA LOPEZ",
                    "dataNascimento": "12/01/2003 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "21/02/2019 14:18:46",
                    "numeroAlunoChamada": 19,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7295179,
                    "nomeAluno": "MARIA REGINA SILVEIRA DE LIMA",
                    "dataNascimento": "29/07/1962 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "26/02/2019 19:35:34",
                    "numeroAlunoChamada": 15,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7303841,
                    "nomeAluno": "FRANCISCO ELTON PESSOA DE OLIVEIRA",
                    "dataNascimento": "12/01/1978 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "11/03/2019 15:35:47",
                    "numeroAlunoChamada": 9,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 7310847,
                    "nomeAluno": "CLAUDIA APARECIDA LIBERATO MENDES",
                    "dataNascimento": "07/07/1963 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "20/03/2019 11:58:23",
                    "numeroAlunoChamada": 5,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 272518,
                    "nomeAluno": "CARLA GOMES DA SILVA",
                    "dataNascimento": "08/07/1983 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "25/03/2019 15:58:39",
                    "numeroAlunoChamada": 4,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 4190707,
                    "nomeAluno": "RYAN GOMES DA SILVA",
                    "dataNascimento": "11/03/2004 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "25/03/2019 15:59:23",
                    "numeroAlunoChamada": 23,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 1636677,
                    "nomeAluno": "DAYANE DE SOUZA CAVALCANTI",
                    "dataNascimento": "02/03/1988 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "02/04/2019 13:40:12",
                    "numeroAlunoChamada": 29,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
                {
                    "codigoAluno": 3442245,
                    "nomeAluno": "GABRIELA DE ALMEIDA",
                    "dataNascimento": "17/11/2001 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 1,
                    "situacaoMatricula": "Ativo",
                    "dataSituacao": "10/04/2019 11:22:06",
                    "numeroAlunoChamada": 31,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                },
        
                {
                    "codigoAluno": 3531703,
                    "nomeAluno": "JOSE DANIEL FERREIRA DA SILVA GOMES",
                    "dataNascimento": "11/04/1986 00:00:00",
                    "nomeSocialAluno": null,
                    "codigoSituacaoMatricula": 3,
                    "situacaoMatricula": "Transferido",
                    "dataSituacao": "10/04/2019 20:25:42",
                    "numeroAlunoChamada": 30,
                    "possuiDeficiencia": false,
                    "qtdFaltas": 0
                }
            ]
            return ({ ...state, students: students });
        case types.RESPONSE_FREQUENCY:
            return ({ ...state, students: [] });
        default:
            return (state);
    }

}
