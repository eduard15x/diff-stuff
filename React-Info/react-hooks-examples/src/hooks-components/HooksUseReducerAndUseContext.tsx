// lets say we have to use same state value in multiple components and change it in each one
// instead of using rewriting same functionality (avoiding DRY) use a useReducer for this context state


//
//     -------------App.js------------
//    |                |              |
//  Comp A          Comp B          Comp C
//  countVal        countVal        countVal
//  useReducer()    useReducer()    useReducer()




import { useContext } from "react"
import { CountContext } from "../App"

const HooksUseReducerAndUseContext = () => {
    const countContext = useContext(CountContext);
  return (
    <div>
        <button onClick={() => countContext.countDispath('increment')}>Increment Global Count Context</button>

        <button onClick={() => countContext.countDispath('decrement')}>Decrement Global Count Context</button>
        hello
    </div>
  )
}

export default HooksUseReducerAndUseContext