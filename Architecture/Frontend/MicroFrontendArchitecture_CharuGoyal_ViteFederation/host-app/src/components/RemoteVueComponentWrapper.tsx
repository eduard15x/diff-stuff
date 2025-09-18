import React, { useEffect, useRef } from "react";

const RemoteVueComponentWrapper = () => {
  const buttonRef = useRef<HTMLElement>(null);

  useEffect(() => {
    // Import and register the remote Vue button element
    import("remote_app_another_vue/ButtonElement").then(() => {
      if (buttonRef.current) {
        const handleClick = () => {
          console.log("Button clicked!");
        };
        buttonRef.current.addEventListener("click", handleClick);
        // Cleanup
        return () => {
          buttonRef.current?.removeEventListener("click", handleClick);
        };
      }
    });
  }, []);

  return (
    <div>
      <h2>Vue Button from Remote</h2>
      {React.createElement("vue-remote-button", {
        ref: buttonRef,
        text: "Click me from Vue!",
      })}
    </div>
  );
};

export default RemoteVueComponentWrapper;
