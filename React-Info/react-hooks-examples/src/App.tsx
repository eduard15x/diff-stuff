import { createContext, useReducer } from 'react'
import './App.css'
import DataFetching from './hooks-components/DataFetching'
import HookUseEffect from './hooks-components/HookUseEffect'
import HookUseState from './hooks-components/HookUseState'
import HookUseContext from './hooks-components/HookUseContext'
import HookUseReducer from './hooks-components/HookUseReducer'
import HooksUseReducerAndUseContext from './hooks-components/HooksUseReducerAndUseContext'
import DataFetchingUseReducer from './hooks-components/DataFetchingUseReducer'


// STEPS to consume Context value with Context API
export const UserContext = createContext();
export const ChannelContext = createContext();




export const CountContext = createContext();

// useReducer + useContext
const initialState = 0;
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


function App() {
  const [count, dispatch] = useReducer(reducer, initialState);

  return (
    <div>
      <h1>Hook List</h1>

      <HookUseState />
 
      <HookUseEffect />

      <DataFetching />



      {/* STEPS to consume Context value with Context API */}
      <UserContext.Provider value={"Eduard-Username"}>
        <ChannelContext.Provider value={"Codevolution"}>
          <HookUseContext />
        </ChannelContext.Provider>
      </UserContext.Provider>


      <HookUseReducer />



      <h1>This is the global count value {count}</h1>
      <CountContext.Provider value={{ countState: count, countDispath: dispatch }}>
        <HooksUseReducerAndUseContext />
      </CountContext.Provider>


      <DataFetchingUseReducer />
    </div>
  )
}

export default App
