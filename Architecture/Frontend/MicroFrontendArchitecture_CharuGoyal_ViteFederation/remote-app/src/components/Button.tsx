interface ButtonProps {
  text: string;
  onClick?: () => void;
}

const Button = (props: ButtonProps) => {
  return (
    <button className="px-4 py-2" onClick={props.onClick}>
      {props.text}
    </button>
  );
};

export default Button;
