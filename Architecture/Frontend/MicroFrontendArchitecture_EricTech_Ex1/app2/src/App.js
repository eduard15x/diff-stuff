import React from "react";
// const Button = React.lazy(() => import("app1/Button"));
const Title = React.lazy(() => import("app3-vite-react-ts/Title"));

function App() {
  return (
    <div className="App">
      <h1>My App 2</h1>
      {/* <React.Suspense fallback="Loading Button...">
        <Button text={"app2"} />
      </React.Suspense> */}

      <React.Suspense fallback="Loading Title...">
        <Title text={"app2 title component"} />
      </React.Suspense>
    </div>
  );
}

export default App;
