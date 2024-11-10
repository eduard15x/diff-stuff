import PropTypes from "prop-types";

const MessageContainer = ({ messages }) => {
  return (
    <div>
      {messages && messages.length > 0
        ? messages.map((msg, index) => (
            <table
              key={index}
              style={{ border: "1px solid black", width: "100%" }}
            >
              <tbody>
                <tr>
                  <td>
                    {msg.msg} - {msg.username}
                  </td>
                </tr>
              </tbody>
            </table>
          ))
        : "No message"}
    </div>
  );
};

MessageContainer.propTypes = {
  messages: PropTypes.arrayOf(
    PropTypes.shape({
      msg: PropTypes.string,
      username: PropTypes.string.isRequired,
    })
  ),
};

export default MessageContainer;
