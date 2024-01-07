import { useState, useEffect } from "react"

const HookUseEffect = () => {
    const [count, setCount] = useState<number>(0);
    const [name, setName] = useState<string>('');


    useEffect(() => {
        console.log('useEffect - updating document title');
        document.title = `you click ${count} times`
    }, [count]); // this executes only when count it changes, so updating name doesnt execute a side effect

    return (
        <div>
            <h1>useEffect hook with example</h1>
            <p>It causes side effects</p>
            <p>It executes the function passed as an argument to the side effect every time the component renders</p>

            <div>
                Count is {count}
            </div>

            <button onClick={() => setCount(count + 1)}>
                Increment count
            </button>

            <h2>Conditional run effects</h2>
            <p>This can be made with second parameter to useEffect in the array</p>
            <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
        </div>
    )
}

export default HookUseEffect