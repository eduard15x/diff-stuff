import React from "react";

const Button = ({text}) => {
  return <button onClick={() => console.log(text)}>Button 1</button>;
};

export default Button;
