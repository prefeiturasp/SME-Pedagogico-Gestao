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
    Descricao: "Língua Portuguesa"    
  },
  DISCIPLINA_MATEMATICA: {
    Codigo: 2,
    Descricao: "Matemática"    
  },
  PossuiDisciplina(disciplina, listaDisciplinas){
    for(var disciplinaAtual in listaDisciplinas){
      if (disciplina.Codigo === listaDisciplinas[disciplinaAtual].codigoComponenteCurricular)
        return true;
    }
    return false;    
  }
};
