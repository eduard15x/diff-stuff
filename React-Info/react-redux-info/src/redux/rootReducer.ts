import { combineReducers } from "redux";
import cakeReducer from "./cake/cakeReducers";
import icecreamReducer from "./icecream/icecreamReducers";
import userReducer from "./user/userReducers";

const rootReducer = combineReducers({
    cakeReducer,
    icecreamReducer,
    userReducer
});

export default rootReducer;