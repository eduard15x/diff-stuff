const store = require('./app/store');
const cakeActions = require('./features/cake/cakeSlice').cakeActions;
const icecreamActions = require('./features/icecream/icecreamSlice').icecreamActions;
const fetchUsers = require('./features/user/userSlice').fetchUsers;

console.log('Initial state.', store.getState());

// const unsubscribe = store.subscribe(() => {
//     console.log('Updated state', store.getState());
// }); -> this is handled by redux-logger middleware

store.dispatch(cakeActions.ordered());
store.dispatch(cakeActions.ordered());
// store.dispatch(cakeActions.restocked());
// store.dispatch(cakeActions.orderAmmount(22));
// store.dispatch(cakeActions.restockAmmount(26));

// store.dispatch(icecreamActions.ordered());
// store.dispatch(icecreamActions.ordered());
// store.dispatch(icecreamActions.restocked(5));

// unsubscribe(); -> is handled by logger middleware

// logger middleware for redux-toolkit
// mpm i redux-logger



// async thunk
// https://jsonplaceholder.typicode.com/userssdf
store.dispatch(fetchUsers());