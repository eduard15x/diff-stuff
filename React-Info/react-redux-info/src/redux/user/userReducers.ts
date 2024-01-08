import { FETCH_USERS_REQUEST, FETCH_USERS_SUCCESS, FETCH_USERS_ERROR } from "./userTypes"

const initialState = {
    loading: true,
    users: [],
    error: ''
}

const userReducer = (previousState = initialState, action) => {
    switch(action.type) {
        case FETCH_USERS_REQUEST:
            return {
                ...previousState,
                loading: true,
            }

        case FETCH_USERS_SUCCESS:
            return {
                loading: false,
                users: action.payload,
                error: ''
            }

        case FETCH_USERS_ERROR:
            return {
                loading: false,
                users: [],
                error: action.payload
            }

        default:
            return previousState;
    }
}

export default userReducer;