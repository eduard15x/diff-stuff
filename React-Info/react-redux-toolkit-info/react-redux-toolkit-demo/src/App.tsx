import CakeView from "./features/cake/CakeView";
import UserView from "./features/user/UserView";
import IcecreamView from "./features/icecream/IcecreamView";

function App() {
  return (
    <div>
      <h1>APP COMPONENT</h1>
      <CakeView />
      <IcecreamView />
      <UserView />
    </div>
  );
}

export default App;
