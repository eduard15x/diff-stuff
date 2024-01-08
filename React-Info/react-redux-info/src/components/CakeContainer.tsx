import { connect } from "react-redux";
import { buyCake } from "../redux";

const CakeContainer = (props) => {
  return (
    <div>
      <h2>Number of cakes { props.numberOfCakes }</h2>

      <button onClick={props.buyCakeExampleInPropsComponent}>Buy cake</button>
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
    buyCakeExampleInPropsComponent: () => dispatch(buyCake()),
  };
};

// connect - connect react component to the redux store
export default connect(mapStateToProps, mapDispatchToProps)(CakeContainer);
