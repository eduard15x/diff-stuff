import { Col, Row } from "react-bootstrap";
import MessageContainer from "./MessageContainer";
import PropTypes from "prop-types";
import SendMessage from "./SendMessage";

const ChatRoom = ({ messages, sendMessage }) => {
  return (
    <div>
      <Row className="px-5 py-5">
        <Col sm={12}>
          <h2>Chat Room</h2>
        </Col>

        <Col></Col>
      </Row>
      <Row className="px-5 py-5">
        <Col sm={12}>
          <MessageContainer messages={messages} />
        </Col>
        <Col sm={12}>
          <SendMessage sendMessage={sendMessage} />
        </Col>
      </Row>
    </div>
  );
};

ChatRoom.propTypes = {
  messages: PropTypes.arrayOf(
    PropTypes.shape({
      message: PropTypes.string,
      username: PropTypes.string.isRequired,
    })
  ),
  sendMessage: PropTypes.func.isRequired,
};

export default ChatRoom;
