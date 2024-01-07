import axios from "axios";
import { useState, useEffect, useReducer } from "react";

const initialState = {
  loading: true,
  error: "",
  post: {},
};

const reducer = (currentState, action) => {
  switch (action.type) {
    case "FETCH_SUCCESS":
      return {
        loading: false,
        error: "",
        post: action.payload,
      };
    case "FETCH_ERROR":
      return {
        loading: false,
        error: "Something went wrong",
        post: {},
      };
    default:
      return currentState;
  }
};

const DataFetchingUseReducer = () => {
  // classic way
  //   const [loading, setLoading] = useState(true);
  //   const [error, setError] = useState("");
  //   const [post, setPost] = useState({});

  //   useEffect(() => {
  //     axios
  //       .get("https://jsonplaceholder.typicode.com/posts/1")
  //       .then((res) => {
  //         setLoading(false);
  //         setPost(res.data);
  //         setError("");
  //         console.log(res);
  //       })
  //       .catch((err) => {
  //         setLoading(false);
  //         setPost({});
  //         setError("Something went wrong.");
  //         console.error(err);
  //       });
  //   }, []);

  //   return (
  //     <div>
  //       {loading ? "loading" : post.title}

  //       {error ? error : null}
  //     </div>
  //   );

  // useReducer fetch data WAY
  const [state, dispatch] = useReducer(reducer, initialState);

  useEffect(() => {
    axios
      .get("https://jsonplaceholder.typicode.com/posts/1")
      .then((res) => {
        dispatch({ type: 'FETCH_SUCCESS', payload: res.data});
      })
      .catch((err) => {
        dispatch({ type: 'FETCH_ERROR'});
        console.error(err);
      });
  }, []);

  return (
    <div>
        {state.loading ? "loading" : state.post.title}

        {state.error ? state.error : null}
    </div>
  );
};

export default DataFetchingUseReducer;
