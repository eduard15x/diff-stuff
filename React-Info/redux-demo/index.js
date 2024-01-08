const redux = require('redux');
const reduxLogger = require('redux-logger');
console.log('CAKE SHOP APP');


// Cake shop

// entities
//     -shop -> stores cakes on shelf
//     -shopkeeper -> at the front of the store
//     -customer -> at the store entrance

// activities
//     -customer - buy a cake
//     shopkeeper -> remove a cake from the shelf
//                -> receipt to keep track



// Cake Shop Scenario              Redux               Purpose
// Shop                             Store               holds the state of app
// Intention to BUY_CAKE            Action              describe what happened
// Shopkeeper                       Reducer             ties the store and actions together





const createStore = redux.createStore;
const combineReducers = redux.combineReducers; // create combined reducers into one
const applyMiddleware = redux.applyMiddleware;
const logger = reduxLogger.createLogger(); // middleware

// I
// define action
const BUY_CAKE = 'BUY_CAKE';
const BUY_ICECREAM = 'BUY_ICECREAM';

// action creator -> a function that returns an action
function buyCake() {
    return {
        type: BUY_CAKE,
        info: 'first redux action'
    };
};

function buyIcecream() {
    return {
        type: BUY_ICECREAM,
        info: 'second redux action'
    };
};

function reset() {
    return {
        type: 'RESET',
        info: 'state reset'
    };
};


// II
// (previousState, action) => newState
// const initialState = {
//     numberOfCakes: 10,
//     numberOfIcecreams: 20
// };

const initialCakeState = {
    numberOfCakes: 10
}

const initialIcecreamState = {
    numberOfIcecreams: 20
}

// reducer function
// const reducer = (previousState = initialState, action) => {
//     switch(action.type) {
//         case BUY_CAKE:
//             return {
//                 ...previousState,
//                 numberOfCakes: previousState.numberOfCakes - 1
//             }

//         case BUY_ICECREAM:
//             return {
//                 ...previousState,
//                 numberOfIcecreams: previousState.numberOfIcecreams - 1
//             }
            
//         case 'RESET':
//             return {
//                 ...previousState,
//                 numberOfCakes: 10,
//                 numberOfIcecreams: 20
//             }

//         default:
//             return previousState
//     }
// };

const cakeReducer = (previousState = initialCakeState, action) => {
    switch(action.type) {
        case BUY_CAKE:
            return {
                ...previousState,
                numberOfCakes: previousState.numberOfCakes - 1
            }

        default:
            return previousState
    }
};

const icecreamReducer = (previousState = initialIcecreamState, action) => {
    switch(action.type) {
        case BUY_ICECREAM:
            return {
                ...previousState,
                numberOfIcecreams: previousState.numberOfIcecreams - 1
            }

        default:
            return previousState
    }
};



// III
// store

const rootReducer = combineReducers({
    cake: cakeReducer,
    icecream: icecreamReducer
});

const store = createStore(rootReducer, applyMiddleware(logger)); // create the store with the redux-logger middleware



console.log('Initial state', store.getState());

// const unsubscribe = store.subscribe(() => console.log('Updated store', store.getState()));  -> we do not need this function anymore because redux-logger-middleware does this by default
const unsubscribe = store.subscribe(() => {});

store.dispatch(buyCake());
store.dispatch(buyCake());
store.dispatch(buyCake());
store.dispatch(buyIcecream());
store.dispatch(buyIcecream());

store.dispatch(reset());
store.dispatch(buyCake());

unsubscribe();