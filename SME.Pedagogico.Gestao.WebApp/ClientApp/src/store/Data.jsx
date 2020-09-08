export const types = {
  SET_NEW_DATA: "SET_NEW_DATA",
  RESET_NEW_DATA: "RESET_NEW_DATA",
};

const initialState = {
  newDataToSave: false,
};

export const actionCreators = {
  set_new_data_state: () => ({ type: types.SET_NEW_DATA }),
  reset_new_data_state: () => ({ type: types.RESET_NEW_DATA }),
};

export const reducer = (state, action) => {
  state = state || initialState;

  switch (action.type) {
    case types.SET_NEW_DATA:
      return { ...state, newDataToSave: true };
    case types.RESET_NEW_DATA:
      return { ...state, newDataToSave: false };
    default:
      return state;
  }
};
