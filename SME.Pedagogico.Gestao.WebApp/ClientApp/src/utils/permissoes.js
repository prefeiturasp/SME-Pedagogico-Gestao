class Permissoes {
  EditarEConsultar(user) {
    return (
      user.permissoes["/"].podeConsultar && user.permissoes["/"].podeAlterar
    );
  }

  ApenasConsultas(user) {
    return user.permissoes["/"].podeConsultar;
  }
  ApenasRelatorios(user) {
    return !user.permissoes["/"].podeConsultar;
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
