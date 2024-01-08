import { Provider } from 'react-redux'
import CakeContainer from './components/CakeContainer'
import store from './redux/store'
import HooksCakeContainer from './components/HooksCakeContainer'
import IcecreamContainer from './components/IcecreamContainer'
import NewCakeContainer from './components/NewCakeContainer'
import UserContainer from './components/UserContainer'

function App() {

  return (
    <Provider store={store}>
      <div>
        <CakeContainer />
        <IcecreamContainer />
        <NewCakeContainer />

        <UserContainer />

        <HooksCakeContainer />
      </div>
    </Provider>
    
  )
}

export default App
