// PERFORMANCE & OPTIMIZATION
// useMemo Hook
// WHAT
// is a hook that will only recompute the cached value when one of the dependencies has changed, avoidind expensive calculation on render

// difference useMemo vs useCallback
// useMemo invokes the provided function and caches the result
// useCallback caches the provided function

import { useState, useMemo } from "react";

const HookUseMemo = () => {
  const [counterOne, setCounterOne] = useState(0);
  const [counterTwo, setCounterTwo] = useState(0);

  const incrementOne = () => {
    setCounterOne(counterOne + 1);
  };

  const incrementTwo = () => {
    setCounterTwo(counterTwo + 1);
  };

  const isEven = useMemo(() => {
    let i = 0;

    while ( i < 200000000) i++;
    return counterOne % 2 === 0;
  }, [counterOne]);

  return (
    <div>
      <div>
        <button onClick={incrementOne}>Count One - {counterOne}</button>
        <span>{isEven ? 'is even' : 'is odd'}</span>
      </div>


      {/* The recalculation of the isEven doesnt apply when counter two button is clicked */}
      <div>
        <button onClick={incrementTwo}>Count Two - {counterTwo}</button>
        <span></span>
      </div>
    </div>
  );
};

export default HookUseMemo;
