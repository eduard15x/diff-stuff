import React from "react";
const Button = React.lazy(() => import("app1/Button"));

function App() {
  return (
    <div className="App">
      <h1>My App 2</h1>
      <React.Suspense fallback="Loading Button...">
        <Button text={"app2"} />
      </React.Suspense>
    </div>
  );
}

export default App;
