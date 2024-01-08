# REDUX

## Three Core Concepts

`Store` -> holds state of app
`Action` -> describe the changes in the state of the app
`Reducer` -> which actually carries out the state transition depending on the action

## Thee Principles

`First Principle`
    - the state of your whole application is stored in an object tree within a single store
    - mantain our app state in a single object which would be managed by redux store

`Second Principle`
    - only way to change the state is to emit an action, an object describing what happened
    - to update the state of your app, you need to let Redux know about that with an action
    - not allowed to directly update the state object (state is immutable)

`Third principle`
    - to specify how the state tree is transformed by actions, you write pure reducers
    - Reducer - (previousState, action) => return newState


            ----->                dispatch->      ------>
REDUX STORE         JAVASCRIPT APP        ACTION          REDUCER
            <-----                <--------       <------




### ACTIONS
- only way your app can interact with the store
- carry some information from your app to the redux store
- plain javascript objects
- have a 'type' property that indicates the type of action being performed
- the 'type' property is typically defined as string constants

### REDUCERS
- specify how the app's state changes in response to actions sent to the store
- function that accepts state and action as arguments, and returns the next state of the app
- (previousState, action) => newState

### REDUX STORE
- one store for the entire app
- Responsabilities:
    -holds app state
    -allow access to state via getState()
    -allow state to be updated via dispatch(action)
    -registers listeners via subscribe(listener)
    -handles unregistering of listeners via the function returned by subscribe(listener)







### MIDDLEWARE
- the suggested way to extend Redux with custom functionality
- provides a 3rd party extension point between dispatching an action, and the moment it reaches the reducer
- use middleware for logging, crash reporting, performing asynchrounous tasks etc





### ASYNC ACTIONS
- async APi calls to fetch data from an endpoint and use that data in your app
`axios` - library to make request
`redux-thunk` - middleware