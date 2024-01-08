import { connect } from "react-redux";
import { buyIcecream } from "../redux";

const IcecreamContainer = (props) => {
  return (
    <div>
      <h2>Number of icecreams { props.numberOfIcecreams }</h2>

      <button onClick={props.buyIcecreamExampleInPropsComponent}>Buy icecream</button>
    </div>
  );
};

// when you want to access the redux state to your components you define mapStateToProps function
const mapStateToProps = (currentState) => {
  return {
    numberOfIcecreams: currentState.icecreamReducer.numberOfIcecreams,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    buyIcecreamExampleInPropsComponent: () => dispatch(buyIcecream()),
  };
};

// connect - connect react component to the redux store
export default connect(mapStateToProps, mapDispatchToProps)(IcecreamContainer);
