import { Col, Container, Row } from "react-bootstrap";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import WaitingRoom from "./components/WaitingRoom";
import { useEffect, useState } from "react";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import ChatRoom from "./components/ChatRoom";

function App() {
  const [connection, setConnection] = useState("");
  const [messages, setMessages] = useState([]);
  const [username, setUsername] = useState(""); // Pentru a salva username-ul
  const [chatRoom, setChatRoom] = useState("");

  const sendMessage = async (message) => {
    if (!connection) {
      console.error("Connection not established!");
      return;
    }
    try {
      await connection.invoke("SendMessage", message);
    } catch (error) {
      console.error("Error sending message:", error);
    }
  };

  const handleJoinChatRoom = async (username, chatRoom) => {
    if (!username) return alert("Missing username");
    if (!chatRoom) return alert("Missing chatRoom");

    setUsername(username); // Salvează username-ul pentru reconectare
    setChatRoom(chatRoom); // Salvează numele camerei pentru reconectare

    try {
      // initiate a connection
      const conn = new HubConnectionBuilder()
        .withUrl("http://localhost:5277/chat")
        .configureLogging(LogLevel.Information)
        .withAutomaticReconnect()
        .build();

      conn.onreconnecting((error) => {
        console.log("Reconnecting due to error: ", error);
        // Arată un mesaj de reconectare (opțional)
      });

      conn.onreconnected(async (connectionId) => {
        console.log("Reconnected with connectionId: ", connectionId);
        // După reconectare, alătură-te din nou camerei
        await conn.invoke("JoinSpecificChatRoom", { username, chatRoom });
      });

      conn.onclose((error) => {
        console.error("Connection closed due to error: ", error);
        alert("Connection closed. Attempting to reconnect...");
      });

      // set up the handler
      conn.on("JoinSpecificChatRoom", (username, msg) => {
        console.log("JoinSpecificChatRoom");
        console.log(username);
        console.log(msg);
        setMessages((prevMessages) => [...prevMessages, { username, msg }]);
      });

      // this is the problem, i dont receive it
      conn.on("ReceiveSpecificMessage", (username, msg) => {
        console.log("ReceiveSpecificMessage");
        console.log(username);
        console.log(msg);
        setMessages((prevMessages) => [...prevMessages, { username, msg }]);
      });

      await conn.start();
      await conn.invoke("JoinSpecificChatRoom", { username, chatRoom });

      setConnection(conn);
    } catch (error) {
      console.error(error);
    }
  };

  // useEffect(() => {
  //   handleJoinChatRoom("defaultUsername", "defaultRoom"); // Exemplu inițial
  // }, []);

  return (
    <div>
      <Container>
        <Row className="px-5 my-5">
          <Col sm="12">
            <h1 className="font-weight-light">Welcome to my chat app.</h1>
          </Col>
        </Row>

        {!connection ? (
          <WaitingRoom joinChatRoom={handleJoinChatRoom} />
        ) : (
          <ChatRoom messages={messages} sendMessage={sendMessage} />
        )}
      </Container>
    </div>
  );
}

export default App;
