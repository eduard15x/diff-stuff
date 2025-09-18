import React from "react";
import { Suspense } from "react";

// const RemoteTitle = React.lazy(() => import("app3-vite-react-ts/Title"));

const Title = React.lazy(() => import("app3/Title"));

function App() {
  return (
    <div>
      <h1>imported app from another project micro frontend</h1>
      <Suspense fallback={<div>Loading remote...</div>}>
        <Title text="test1" />
      </Suspense>
    </div>
  );
}

export default App;
