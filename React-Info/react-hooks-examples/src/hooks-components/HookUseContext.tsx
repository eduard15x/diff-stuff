// CONTEXT API
// CONTEXT - provides a way to pass data through the component tree without having to pass props manually
// example: render from app component(parent) a username to a low level nested component (on the 3rd level for example), is very bad to pass the props to this because scalability
//
//              APP COMPONENT
//    |               |               |
//  COMP A          COMP B          COMP C
//                    |               |
//                  COMP D          COMP E
//                                    |
//                                  COMP F - this should get the info from app component


// STEPS to consume Context value with Context API
// 1.Create the context - in highest level component (App.tsx)
// 2.Provide the context with a value
// 3.Consume the context value






import { useContext } from "react"
import { UserContext, ChannelContext } from "../App"

const HookUseContext = () => {

  const user = useContext(UserContext);
  const channel = useContext(ChannelContext);

  return (
    <div>
      {/* Context API - bad practice */}
      {/* <UserContext.Consumer>
        {
          user => { 
            return (
              <ChannelContext.Consumer>
                  {
                    channel => {
                      return <div>User Context value {user} and Channel context value { channel }</div>
                    }
                  }
              </ChannelContext.Consumer>
            )
          }
        }
      </UserContext.Consumer> */}


      {/* useContext hook */}
      <div>
        <p>User - { user }</p>
        <p>Channel - { channel }</p>
      </div>

    </div>
  )
}

export default HookUseContext