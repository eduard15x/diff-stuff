/* eslint-disable @typescript-eslint/no-explicit-any */
// import { useSelector, useDispatch } from "react-redux";
import { ordered, restocked, restockAmmount } from "./cakeSlice";
import { useAppSelector, useAppDispatch } from "../../app/hooks";

const CakeView: React.FC = () => {
  const numOfCakes = useAppSelector((state: any) => state.cake.numberOfCakes);

  const dispatch = useAppDispatch();

  return (
    <div>
        <h1>Cake View</h1>

        <h2>Number of cakes: { numOfCakes } </h2>
        <button onClick={() => dispatch(ordered())}>Order one cake</button>
        <button onClick={() => dispatch(restocked())}>Restock all cakes</button>
        <button onClick={() => dispatch(restockAmmount(5))}>Restock amount</button>
    </div>
  )
};

export default CakeView;