import { useState } from "react";
import { Button, Col, Form, Row } from "react-bootstrap";
import PropTypes from "prop-types";

const WaitingRoom = ({ joinChatRoom }) => {
  const [username, setUsername] = useState("");
  const [chatRoom, setChatRoom] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    joinChatRoom(username, chatRoom);
  };
  return (
    <Form onSubmit={handleSubmit}>
      <Row className="px-5 py-5">
        <Col sm={12}>
          <Form.Group>
            <Form.Control
              placeholder="Username"
              onChange={(e) => setUsername(e.target.value)}
            />
            <Form.Control
              placeholder="Chat Room"
              onChange={(e) => setChatRoom(e.target.value)}
            />
          </Form.Group>
        </Col>

        <Col sm={12}>
          <hr />
          <Button variant="success" type="submit">
            Join
          </Button>
        </Col>
      </Row>
    </Form>
  );
};
WaitingRoom.propTypes = {
  joinChatRoom: PropTypes.func.isRequired,
};

export default WaitingRoom;
