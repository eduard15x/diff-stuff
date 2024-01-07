// PERFORMANCE & OPTIMIZATION
// useCallback Hook
// WHAT
// is a hook that will return a memoized version of the callback function that only changes if ony of the dependencies has changed
// this is good for caching function, is checking previous function if props/state has been changed so it will render again if true, else it will not run again
// WHY
// bcs it is useful when passing callbacks to optimized child components that rely on reference equality to prevent unnecessary renders.
// HOW

import { useCallback, useState } from "react";

const HookUseCallback = () => {
  const [age, setAge] = useState(25);
  const [salary, setSalary] = useState(2500);

  const incrementAge = useCallback(() => {
    setAge(age + 1);
  }, [age]);

  const incrementSalary = useCallback(() => {
    setSalary(salary + 1);
  }, [salary]);

  return (
    <div>
      {/*
            <Title />
            <Count text='Age' count={age} />
            <Button handleClick={incrementAge}> Increment Age </Button>
            <Count text='Salary' count={salary} />
            <Button handleClick={incrementSalary}> Increment Salary </Button>
        */}
    </div>
  );
};

export default HookUseCallback;
