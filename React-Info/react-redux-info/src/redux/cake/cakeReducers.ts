import { BUY_CAKE } from "./cakeTypes";

const initialState = {
    numberOfCakes: 10
};


const cakeReducer = (previousState = initialState, action) => {
    switch(action.type) {
        case BUY_CAKE:
            return {
                ...previousState,
                numberOfCakes: previousState.numberOfCakes - action.payload
            }

        default:
            return previousState;
    }
}

export default cakeReducer;