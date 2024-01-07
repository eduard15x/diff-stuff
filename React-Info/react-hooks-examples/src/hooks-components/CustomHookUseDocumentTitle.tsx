// custom hooks
// are basically javascript functions whose names start with the 'use'
// a custom hook can also call other hooks
// WHY
// to share logic between two or multiple components

import { useState } from "react"
import useDocumentTitle from "../hooks/useDocumentTitle";


const CustomHookUseDocumentTitle = () => {
    const [count, setCount] = useState(0);

    useDocumentTitle(count);

    return (
    <div>
        <p>Count = { count }</p>

        <button onClick={() => setCount(count + 1)}>
            Increment
        </button>
    </div>
  )
}

export default CustomHookUseDocumentTitle