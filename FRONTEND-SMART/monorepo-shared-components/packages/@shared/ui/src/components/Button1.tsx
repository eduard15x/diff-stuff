type ButtonProps = {
  onClick: () => void;
};

const Button1: React.FC<ButtonProps> = ({ onClick }) => {
  return <button onClick={onClick}>Button1</button>;
};

export default Button1;
