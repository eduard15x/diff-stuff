type ButtonProps = {
  onClick: () => void;
};

const Button2: React.FC<ButtonProps> = ({ onClick }) => {
  return <button onClick={onClick}>Button2 for admin</button>;
};

export default Button2;
