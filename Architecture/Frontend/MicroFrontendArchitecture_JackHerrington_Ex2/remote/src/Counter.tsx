import { createSignal } from "solid-js";

const Counter = () => {
  const [count, setCount] = createSignal(0);

  return (
    <div class="bg-blue-500 text-4xl">
      <p>Count: {count()}</p>
      <button onClick={() => setCount(count() + 1)}>Increment</button>
    </div>
  );
};

export default Counter;
