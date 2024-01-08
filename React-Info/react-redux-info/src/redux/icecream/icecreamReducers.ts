import { BUY_ICECREAM } from "./icecreamTypes";

const initialState = {
    numberOfIcecreams: 20
}

const icecreamReducer = (previousState = initialState, action) => {
    switch(action.type) {
        case BUY_ICECREAM:
            return {
                ...previousState,
                numberOfIcecreams: previousState.numberOfIcecreams - 1
            }

        default:
            return previousState;
    }
}

export default icecreamReducer;