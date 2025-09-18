import React, { Suspense } from "react";

const RemoteAppHeader = React.lazy(() => import("remote_app/Header"));
const RemoteAppButton = React.lazy(() => import("remote_app/Button"));

const RemoteAppAnotherReactTable = React.lazy(
  () => import("remote_app_another_react/Table")
);

// const RemoteAppAnotherVueButton = React.lazy(
//   () => import("remote_app_another_vue/Button")
// );

// const RemoteAppAnotherVueButtonElement = React.lazy(
//   () => import("remote_app_another_vue/ButtonElement")
// );

const LoadingSpinner = () => (
  <div>
    <div>Loading Spinner ...</div>
  </div>
);

const RemoteComponentWrapper = () => {
  return (
    <div>
      <h2>Header Remote App</h2>
      <Suspense fallback={<LoadingSpinner />}>
        <RemoteAppHeader />
      </Suspense>

      <br />
      <hr />
      <br />
      <hr />
      <h2>Button Remote App</h2>

      <Suspense fallback={<LoadingSpinner />}>
        <RemoteAppButton
          text="Import this button in host from remote"
          onClick={() => console.log("test remote react button")}
        />
      </Suspense>

      <br />
      <hr />
      <br />
      <hr />
      <h2>Table Remote App Another React</h2>
      <Suspense fallback={<LoadingSpinner />}>
        <RemoteAppAnotherReactTable data={["Row 1", "Row 2", "Row 3"]} />
      </Suspense>

      <br />
      <hr />
      <br />
      <hr />
      <h2>Button Remote App Another Vue</h2>
      {/* <Suspense fallback={<LoadingSpinner />}>
        <RemoteAppAnotherVueButton
          text="Import this button in host from another vue remote"
        />
      </Suspense> */}
      {/* <Suspense fallback={<LoadingSpinner />}>
        <RemoteAppAnotherVueButtonElement text="Import this button in host from another vue remote" />
      </Suspense> */}
    </div>
  );
};

export default RemoteComponentWrapper;
