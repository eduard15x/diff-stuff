import axios from "axios";
import {
  FETCH_USERS_REQUEST,
  FETCH_USERS_SUCCESS,
  FETCH_USERS_ERROR,
} from "./userTypes";

export const fetchUserRequest = () => {
  return {
    type: FETCH_USERS_REQUEST,
  };
};

export const fetchUserSuccess = (users) => {
  return {
    type: FETCH_USERS_SUCCESS,
    payload: users,
  };
};

export const fetchUserError = (error) => {
  return {
    type: FETCH_USERS_ERROR,
    payload: error,
  };
};

export const fetchUsers = () => {
  return (dispatch) => {
    dispatch(fetchUserRequest)
    axios.get("https://jsonplaceholder.typicode.com/users")
        .then((res) => {
          console.log(res);
          const users = res.data
          dispatch(fetchUserSuccess(users))
        })
        .catch((err) => {
          console.error(err);
          const errorMsg = err.message
          dispatch(fetchUserError(errorMsg))
        });
  };
};
