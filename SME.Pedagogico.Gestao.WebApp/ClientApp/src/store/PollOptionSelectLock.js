export const types = {
    SET_POLL_1B_LOCK: "SET_POLL_1B_LOCK",
    SET_POLL_2B_LOCK: "SET_POLL_2B_LOCK",
    SET_POLL_3B_LOCK: "SET_POLL_3B_LOCK",
    SET_POLL_4B_LOCK: "SET_POLL_4B_LOCK",

    SET_POLL_1S_LOCK: "SET_POLL_1S_LOCK",
    SET_POLL_2S_LOCK: "SET_POLL_2S_LOCK",

    RESET_POLL_LOCK:"RESET_POLL_LOCK"
}

const initialState = {
    poll_1b_lock: true,
    poll_2b_lock: true,
    poll_3b_lock: true,
    poll_4b_lock: true,

    poll_1s_lock: true,
    poll_2s_lock: true,
}

export const actionCreators = {
    set_poll_1b_lock: (poll_1b_lock) => ({ type: types.SET_POLL_1B_LOCK, poll_1b_lock }),
    set_poll_2b_lock: (poll_2b_lock) => ({ type: types.SET_POLL_2B_LOCK, poll_2b_lock }),
    set_poll_3b_lock: (poll_3b_lock) => ({ type: types.SET_POLL_3B_LOCK, poll_3b_lock }),
    set_poll_4b_lock: (poll_4b_lock) => ({ type: types.SET_POLL_4B_LOCK, poll_4b_lock }),

    set_poll_1s_lock: (poll_1s_lock) => ({ type: types.SET_POLL_1S_LOCK, poll_1s_lock }),
    set_poll_2s_lock: (poll_2s_lock) => ({ type: types.SET_POLL_2S_LOCK, poll_2s_lock }),

    reset_poll_lock: () => ({ type: types.RESET_POLL_LOCK }),
}

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        
        case types.SET_POLL_1B_LOCK:
            return ({ ...state, poll_1b_lock: action.poll_1b_lock });
        case types.SET_POLL_2B_LOCK:
            return ({ ...state, poll_2b_lock: action.poll_2b_lock });
        case types.SET_POLL_3B_LOCK:
            return ({ ...state, poll_3b_lock: action.poll_3b_lock });
        case types.SET_POLL_4B_LOCK:
            return ({ ...state, poll_4b_lock: action.poll_4b_lock });

        case types.SET_POLL_1S_LOCK:
            return ({ ...state, poll_1s_lock: action.poll_1s_lock });
        case types.SET_POLL_2S_LOCK:
            return ({ ...state, poll_2s_lock: action.poll_2s_lock });

        case types.RESET_POLL_LOCK:
            return ({ ...state, poll_1b_lock: true, poll_2b_lock: true, poll_3b_lock: true, poll_4b_lock: true, poll_1s_lock: true, poll_2s_lock: true,});
        
        default:
            return (state);
    }
}