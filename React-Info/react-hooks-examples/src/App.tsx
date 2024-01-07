import './App.css'
import DataFetching from './hooks-components/DataFetching'
import HookUseEffect from './hooks-components/HookUseEffect'
import HookUseState from './hooks-components/HookUseState'

function App() {

  return (
    <div>
      <h1>Hook List</h1>

      <HookUseState />

      <HookUseEffect />

      <DataFetching />
    </div>
  )
}

export default App
