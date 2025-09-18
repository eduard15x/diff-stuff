// import { useState } from 'react'
// import reactLogo from './assets/react.svg'
// import viteLogo from '/vite.svg'
import "./App.css";
import RemoteComponentWrapper from "./components/RemoteComponentWrapper";
import RemoteVueComponentWrapper from "./components/RemoteVueComponentWrapper";

function App() {
  // const [count, setCount] = useState(0)

  return (
    <div>
      <div>Hello host, i will import remote components</div>

      <RemoteComponentWrapper />
      <RemoteVueComponentWrapper />
    </div>
  );
}

export default App;
