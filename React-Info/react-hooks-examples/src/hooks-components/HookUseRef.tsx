/* eslint-disable @typescript-eslint/no-explicit-any */
// useRef Hook
// allows us to access DOM nodes
// one common example - when user open a login form modal, make the first input focused

// Steps for useRef
// 1.Import
// 2.Create a ref variable by calling useRef and passing in the initial value
// 3.Assign the ref to the needed element

import { useEffect, useRef, useState } from "react";

const HookUseRef = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [timer, setTimer] = useState(0);

  const inputRef = useRef<any>(null);
  const intervalRef = useRef<number>();

  const toggleInput = () => setIsOpen(!isOpen);

  useEffect(() => {
    //first example
    inputRef.current.focus();

    // second example
    intervalRef.current = setInterval(() => {
        setTimer(prevTimerState => prevTimerState + 1);
    }, 1000);

    return () => {
        clearInterval(intervalRef.current);
    };

  }, []);

  return (
    <div>
      <button onClick={toggleInput}>Handle input</button>

      <div>
        <input ref={inputRef} type="text" />
      </div>


      <div>
        <h2>Timer - good example of useRef hook</h2>
        <p>Hook timer - {timer}</p>
        <button onClick={() => clearInterval(intervalRef.current)}>Clear hook</button>
      </div>
    </div>
  );
};

export default HookUseRef;
