class Permissoes {
  PodeVisualizarSondagem(user) {
    return user.podeConsultar;
  }
  IsUE(user) {
    return !user.possuiPerfilSmeOuDre;
  }

  IsDRE(user) {
    return user.possuiPerfilDre;
  }
  IsSME(user) {
    return user.possuiPerfilSme;
  }
}

export default new Permissoes();
