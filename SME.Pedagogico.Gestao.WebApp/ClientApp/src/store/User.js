export const types = {
  LOGIN_REQUEST: "LOGIN_REQUEST",
  SET_USER: "SET_USER",
  UNAUTHORIZED: "UNAUTHORIZED",
  LOGOUT_REQUEST: "LOGOUT_REQUEST",
  LOGOUT_USER: "LOGOUT_USER",
  ON_AUTHENTICATION_REQUEST: "ON_AUTHENTICATION_REQUEST",
  FINISH_AUTHENTICATION_REQUEST: "FINISH_AUTHENTICATION_REQUEST",
  SET_ACTIVE_ROLE: "SET_ACTIVE_ROLE",
  LOGIN_SGP_REQUEST: "LOGIN_SGP_REQUEST",
  SET_REDIRECT_URL: "SET_REDIRECT_URL",
  SET_PROFILE: "SET_PROFILE",
  VALIDATE_PROFILES_TOKEN: "VALIDATE_PROFILES_TOKEN",
  SET_LOADING_PROFILE: "SET_LOADING_PROFILE",
  SET_ERROR: "SET_ERROR",
  GET_URL_FRONT_SGP: "GET_URL_FRONT_SGP",
  SET_URL_FRONT_SGP: "SET_URL_FRONT_SGP",
};
const initialState = {
  name: null,
  username: null,
  email: null,
  token: null,
  session: null,
  refreshToken: null,
  lastAuthentication: null,
  roles: null,
  isAuthenticated: false,
  isUnauthorized: false,
  activeRole: null,
  onAuthenticationRequest: false,
  listOccupations: null,
  redirectUrl: null,
  isLoadingProfile: false,
  msgError: "",
  urlFrontSgp: "",
};

export const actionCreators = {
  login: (credential, history) => ({
    type: types.LOGIN_REQUEST,
    credential,
    history,
  }),
  setUser: (user) => ({ type: types.SET_USER, user }),
  logout: (credential) => ({ type: types.LOGOUT_REQUEST, credential }),
  setActiveRole: (role) => ({ type: types.SET_ACTIVE_ROLE, role }),
  setRedirectUrl: (redirectUrl) => ({
    type: types.SET_REDIRECT_URL,
    redirectUrl,
  }),
  setProfile: (perfilSelecionado, history) => ({
    type: types.SET_PROFILE,
    perfilSelecionado,
    history,
  }),
  validateProfilesToken: ({ perfil, usuario, history }) => ({
    type: types.VALIDATE_PROFILES_TOKEN,
    perfil,
    usuario,
    history,
  }),
  setLoadingProfile: (isLoadingProfile) => ({
    type: types.SET_LOADING_PROFILE,
    isLoadingProfile,
  }),
  setError: (msgError) => ({
    type: types.SET_ERROR,
    msgError,
  }),
  getUrlFrontSgp: (history) => ({
    type: types.GET_URL_FRONT_SGP,
    history,
  }),
  setUrlFrontSgp: (urlFrontSgp) => ({
    type: types.SET_URL_FRONT_SGP,
    urlFrontSgp,
  }),
};

export const reducer = (state, action) => {
  state = state || initialState;

  switch (action.type) {
    case types.SET_USER:
      return {
        ...state,
        ...action.user,
        isUnauthorized: false,
      };
    case types.UNAUTHORIZED:
      return {
        ...state,
        isUnauthorized: true,
      };
    case types.LOGOUT_USER:
      return {
        ...state,
        ...initialState,
      };
    case types.ON_AUTHENTICATION_REQUEST:
      return {
        ...state,
        onAuthenticationRequest: true,
      };
    case types.FINISH_AUTHENTICATION_REQUEST:
      return {
        ...state,
        onAuthenticationRequest: false,
      };
    case types.SET_ACTIVE_ROLE:
      return {
        ...state,
        activeRole: action.role,
      };
    case types.SET_REDIRECT_URL:
      return {
        ...state,
        redirectUrl: action.redirectUrl,
      };
    case types.SET_LOADING_PROFILE:
      return {
        ...state,
        isLoadingProfile: action.isLoadingProfile,
      };
    case types.SET_ERROR:
      return {
        ...state,
        msgError: action.msgError,
      };
    case types.SET_URL_FRONT_SGP:
      return {
        ...state,
        urlFrontSgp: action.urlFrontSgp,
      };
    default:
      return state;
  }
};
