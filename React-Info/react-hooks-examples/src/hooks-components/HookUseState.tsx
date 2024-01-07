import { useState } from "react";

interface UserName {
    firstName: string;
    lastName: string;
}

const HookUseState = () => {
    // for ex1
    const [count, setCount] = useState<number>(0);
    // for ex2
    const [name, setName] = useState<UserName>({
        firstName: '',
        lastName: ''
    });

    const handleIncrement = () => {
        for (let i = 0; i < 5; i++) {
            setCount(prevCount => prevCount + 1);
        }
    };


  return (
    <div>
        <h1>useState hook</h1>
        <p></p>

        <div>
            Count is {count}
        </div>

        <button onClick={() => setCount(count + 1)}>
            Increment count
        </button>

        <br />

        <button onClick={() => setCount(count - 1)}>
            Decrement count
        <br />
        </button>

        <p><strong>Treaky example</strong>, careful when using hooks into loops</p>
        <button onClick={handleIncrement}>
            Increment by 5
        </button>

        <br />
        <h2>useState in form with objects</h2>

        <form>
            <input type="text" value={name.firstName} onChange={e => setName({ ...name, firstName: e.target.value })} />
            <input type="text" value={name.lastName} onChange={e => setName({ ...name, lastName: e.target.value })} />

            <p>FirstName = { name.firstName }</p>
            <p>FirstName = { name.lastName }</p>
            <p>JSON Stringify: { JSON.stringify(name) }</p>
        </form>
    </div>
  );
}

export default HookUseState