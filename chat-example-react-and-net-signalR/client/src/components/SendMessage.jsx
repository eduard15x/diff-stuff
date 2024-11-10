import PropTypes from "prop-types";
import { useState } from "react";
import { Button, Form, FormControl, InputGroup } from "react-bootstrap";

const SendMessage = ({ sendMessage }) => {
  const [msg, setMsg] = useState("");

  const handleSendMessage = (e) => {
    e.preventDefault();
    console.log(msg);
    sendMessage(msg);
    setMsg("");
  };

  return (
    <Form onSubmit={handleSendMessage}>
      <InputGroup className="mb-3">
        <InputGroup.Text>Chat</InputGroup.Text>
        <Form.Control
          placeholder="Type a message"
          onChange={(e) => setMsg(e.target.value)}
          value={msg}
        />
        <Button variant="primary" type="submit" disabled={msg === ""}>
          Send
        </Button>
      </InputGroup>
    </Form>
  );
};

SendMessage.propTypes = {
  sendMessage: PropTypes.func.isRequired,
};

export default SendMessage;
