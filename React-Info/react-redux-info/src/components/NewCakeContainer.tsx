import { connect } from "react-redux";
import { buyCake } from "../redux";
import { useState } from "react";

const NewCakeContainer = (props) => {
    const [number, setNumber] = useState(1);

  return (
    <div>
      <h2>Number of cakes {props.numberOfCakes}</h2>

      <br />
      <input type="text" value={number} onChange={(e) => setNumber(e.target.value)} />

      <button onClick={() => props.buyCakeExampleInPropsComponent(number)}>Buy {number} cake</button>
    </div>
  );
};

// when you want to access the redux state to your components you define mapStateToProps function
const mapStateToProps = (currentState) => {
  return {
    numberOfCakes: currentState.cakeReducer.numberOfCakes,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    buyCakeExampleInPropsComponent: (number) => dispatch(buyCake(number)),
  };
};

// connect - connect react component to the redux store
export default connect(mapStateToProps, mapDispatchToProps)(NewCakeContainer);
