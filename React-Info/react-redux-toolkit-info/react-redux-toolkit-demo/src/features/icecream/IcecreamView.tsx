// import { useSelector } from "react-redux";
import { useAppSelector } from "../../app/hooks";

const IcecreamView: React.FC = () => {
  const numOfIcecreams = useAppSelector((state) => state.icecream.numberOfIcecreams);

  return (
    <div>
        <h1>Icecream View</h1>
        <h2>Numbers of icecreams: { numOfIcecreams }</h2>
        <button>Order icecream</button>
        <button>Restock</button>
    </div>
  )
}

export default IcecreamView;