// useReducer - def
// a hook used for state management
// alternative to useState
// useState is buil using useReducer



// useState vs useReducer
//
//
//      SCENARIO                        useState                  useReducer
//  Type of state                   Number, string, bool      Object, Array
//  Number of state transition      One/Two/Three             Many
//  Business logic                  No business Logic         Complex business logic
//  Local vs Global                 Local                     Global


// reduce() vs useReducer()
//  reduce in JavaScript                            |                   useReducer in React
//  -array.reduce(reducer, initialValue)            |                   useReducer(reducer, initialState)
// singleValue = reducer(accumulator, itemValue)    |                   newState = reducer(currentState, action)
// reduce method returns single value               |                   useReducer hook returns a pair of values [newState, dispatch]



import { useReducer } from "react"

const initialState = 0;
// simple useReducer
const reducer = (currentState, action) => {
    switch(action) {
        case 'increment':
            return currentState + 1;
        case 'decrement':
            return currentState - 1;
        case 'reset':
            return initialState;
        default:
            return currentState;
    }
}




const initialStateTwo = {
    firstCounter: 0,
    secondCounter: 100
};
// complex useReducer
const reducerTwo = (currentState, action) => {
    switch(action.type) {
        case 'increment':
            return {
                ...currentState, firstCounter: currentState.firstCounter + action.value
            };
        case 'increment2':
            return {
                ...currentState, secondCounter: currentState.secondCounter + action.value
            };
        case 'decrement':
            return {
                ...currentState, firstCounter: currentState.firstCounter - action.value
            };
        case 'decrement2':
            return {
                ...currentState,  secondCounter: currentState.secondCounter - action.value
            };
        case 'reset':
            return initialStateTwo;
        default:
            return currentState;
    }
}


const HookUseReducer = () => {
    const [count, dispatch] = useReducer(reducer, initialState);
    const [countTwo, dispatchTwo] = useReducer(reducerTwo, initialStateTwo);



    return (
        <>
            {/* This is simple state & action */}
            <div>
                <h1>useReducer - simple state & action</h1>
                <h2>Count is { count }</h2>

                <button onClick={() => dispatch('increment')}>
                    Increment
                </button>
                
                <button onClick={() => dispatch('decrement')}>
                    Decrement
                </button>
                
                <button onClick={() => dispatch('reset')}>
                    Reset
                </button>

            </div>


            {/* This is complex state & action (objects) */}
            <div>
                <h1>useReducer - complex state & action</h1>
                <h2>Counter 1 is { countTwo.firstCounter }</h2>
                <h2>Counter 2 is { countTwo.secondCounter }</h2>

                <button onClick={() => dispatchTwo({ type: 'increment', value: 1 })}>
                    Increment
                </button>

                <button onClick={() => dispatchTwo({ type: 'increment', value: 5 })}>
                    Increment By 5
                </button>
                
                <button onClick={() => dispatchTwo({ type: 'decrement', value: 1 })}>
                    Decrement
                </button>
                
                <button onClick={() => dispatchTwo({ type: 'reset' })}>
                    Reset
                </button>

                <p>Second counter</p>
                <button onClick={() => dispatchTwo({ type: 'increment2', value: 3 })}>
                    Increment By 3
                </button>

            </div>
        </>
    )

}

export default HookUseReducer