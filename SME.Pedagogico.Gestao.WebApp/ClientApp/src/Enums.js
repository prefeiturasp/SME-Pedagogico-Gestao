export const ROLES_ENUM = {
  PROFESSOR: "Professor",
  COORDENADOR_PEDAGOGICO: "CP",
  ADM_DRE: "Adm DRE",
  DIRETOR: "Diretor",
  AD: "AD",
  ADMIN: "Admin",
  DIPED: "DIPED",
  DIEFEM: "DIEFEM",
  COPED: "COPED",
  ADM_SME: "ADM SME",
  ADM_COTIC: "ADM COTIC",
  EditarEConsultar: (Role) => {
    return (
      Role === ROLES_ENUM.AD ||
      Role === ROLES_ENUM.PROFESSOR ||
      Role === ROLES_ENUM.COORDENADOR_PEDAGOGICO ||
      Role === ROLES_ENUM.ADMIN ||
      Role === ROLES_ENUM.ADM_SME ||
      Role === ROLES_ENUM.ADM_COTIC
    );
  },
  ApenasConsultas: (Role) => {
    return Role === ROLES_ENUM.COPED || Role === ROLES_ENUM.DIEFEM;
  },
  ApenasRelatorios: (Role) =>
    ROLES_ENUM.IsDRE(Role) || Role === ROLES_ENUM.DIRETOR,
  IsUE: (Role) => {
    return (
      Role === ROLES_ENUM.AD ||
      Role === ROLES_ENUM.PROFESSOR ||
      Role === ROLES_ENUM.COORDENADOR_PEDAGOGICO ||
      Role === ROLES_ENUM.DIRETOR
    );
  },
  IsDRE: (Role) => {
    return Role === ROLES_ENUM.ADM_DRE || Role === ROLES_ENUM.DIPED;
  },
  IsSME: (Role) => {
    return (
      Role === ROLES_ENUM.ADMIN ||
      Role === ROLES_ENUM.ADM_SME ||
      Role === ROLES_ENUM.ADM_COTIC ||
      Role === ROLES_ENUM.COPED ||
      Role === ROLES_ENUM.DIEFEM
    );
  },
};

export const DISCIPLINES_ENUM = {
  DISCIPLINA_PORTUGUES: {
    Codigo: 138,
    Descricao: "Língua Portuguesa",
  },
  DISCIPLINA_MATEMATICA: {
    Codigo: 2,
    Descricao: "Matemática",
  },
  DISCIPLINA_REGENCIA_CLAS_F_I: {
    Codigo: 508,
    Descricao: "REGENCIA CLAS.F I",
  },
  DISCIPLINA_REG_CLASSE_CICLO_ALFAB_INTERD_5HRS: {
    Codigo: 1105,
    Descricao: "REG CLASSE CICLO ALFAB / INTERD 5HRS",
  },
  DISCIPLINA_REG_CLASSE_CICLO_ALFAB_INTERD_4HRS: {
    Codigo: 1112,
    Descricao: "REG CLASSE CICLO ALFAB / INTERD 4HRS",
  },
  DISCIPLINA_REG_CLASSE_ESPECIAL_DIURNO: {
    Codigo: 1115,
    Descricao: "REG CLASSE ESPECIAL DIURNO",
  },
  DISCIPLINA_REG_CLASSE_ALFAB_INTEGRAL_TARDE: {
    Codigo: 1121,
    Descricao: "REG CLASSE ALFAB_INTEGRAL TARDE",
  },
  DISCIPLINA_REG_CLASSE_ALFAB_INTEGRAL_MANHA: {
    Codigo: 1124,
    Descricao: "REG CLASSE ALFAB_INTEGRAL MANHA",
  },
  DISCIPLINA_REG_CLASSE_SP_INTEGRAL_1A5_ANOS: {
    Codigo: 1213,
    Descricao: "REG CLASSE SP INTEGRAL 1A5 ANOS",
  },
  DISCIPLINA_REG_CLASSE_SURDO_CEGUEIRA: {
    Codigo: 1301,
    Descricao: "REG CLASSE SURDOCEGUEIRA",
  },
  PossuiDisciplina(disciplina, listaDisciplinas) {
    for (var disciplinaAtual in listaDisciplinas) {
      if (
        disciplina.Codigo ===
        listaDisciplinas[disciplinaAtual].codigoComponenteCurricular
      )
        return true;
    }
    return false;
  },
  PossuiDisciplinaRegencia(listaDisciplinas) {
    var disciplinasRegencia = [
      DISCIPLINES_ENUM.DISCIPLINA_REGENCIA_CLAS_F_I.Codigo,
      DISCIPLINES_ENUM.DISCIPLINA_REG_CLASSE_CICLO_ALFAB_INTERD_5HRS.Codigo,
      DISCIPLINES_ENUM.DISCIPLINA_REG_CLASSE_CICLO_ALFAB_INTERD_4HRS.Codigo,
      DISCIPLINES_ENUM.DISCIPLINA_REG_CLASSE_ESPECIAL_DIURNO.Codigo,
      DISCIPLINES_ENUM.DISCIPLINA_REG_CLASSE_ALFAB_INTEGRAL_TARDE.Codigo,
      DISCIPLINES_ENUM.DISCIPLINA_REG_CLASSE_ALFAB_INTEGRAL_MANHA.Codigo,
      DISCIPLINES_ENUM.DISCIPLINA_REG_CLASSE_SP_INTEGRAL_1A5_ANOS.Codigo,
      DISCIPLINES_ENUM.DISCIPLINA_REG_CLASSE_SURDO_CEGUEIRA.Codigo,
    ];

    for (var disciplinaAtual in listaDisciplinas) {
      if (
        disciplinasRegencia.includes(
          listaDisciplinas[disciplinaAtual].codigoComponenteCurricular
        )
      )
        return true;
    }
    return false;
  },
};
