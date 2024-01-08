import { useSelector } from "react-redux" // alternative to mapStateToProps
import { useDispatch } from "react-redux" // alternative to mapDispatchToProps
import { buyCake } from "../redux"

const HooksCakeContainer = () => {
  const numberOfCakes = useSelector(currentState => currentState.cakeReducer.numberOfCakes) // alternative to mapStateToProps
  const dispatch = useDispatch() // alternative to mapDispatchToProps
  return ( 
    <div>
      <h2>Number of cakes - {numberOfCakes}</h2>

      <button onClick={() => dispatch(buyCake())}>
        Buy cake 
      </button>
    </div>
  )
}

export default HooksCakeContainer