const redux = require('redux');
const thunkMiddleware = require('redux-thunk').thunk;

const createStore = redux.createStore;

const applyMiddleware = redux.applyMiddleware;


const axios = require('axios');





const initialState = {
    loading: true,
    users: [],
    error: ''
};

const FETCH_USERS_REQUEST = 'FETCH_USERS_REQUEST';
const FETCH_USERS_SUCCESS = 'FETCH_USERS_SUCCESS';
const FETCH_USERS_ERROR = 'FETCH_USERS_ERROR';


const fetchUsersRequest = () => {
    return {
        type: FETCH_USERS_REQUEST
    }
}

const fetchUsersSuccess = (users) => {
    return {
        type: FETCH_USERS_SUCCESS,
        payload: users
    }
}

const fetchUsersError = (error) => {
    return {
        type: FETCH_USERS_ERROR,
        payload: error
    }
}


const reducer = (previousState = initialState, action) => {
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


const fetchUsers = () => {
    return function(dispatch) {
        dispatch(fetchUsersRequest())
        axios.get('https://jsonplaceholder.typicode.com/users')
            .then(res => {
                console.log(res);
                const users = res.data.map(user => user.id);
                dispatch(fetchUsersSuccess(users));
            })
            .catch(err => {
                console.error(err);
                dispatch(fetchUsersError(err.error));
            })
    }
};

const store = createStore(reducer, applyMiddleware(thunkMiddleware));

store.subscribe(() => console.log(store.getState()));
store.dispatch(fetchUsers());