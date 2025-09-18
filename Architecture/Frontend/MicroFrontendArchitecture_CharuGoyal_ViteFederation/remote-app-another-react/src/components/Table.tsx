interface TableProps {
  data: string[];
}

const Table = (props: TableProps) => {
  return (
    <div>
      {props.data.length > 0 ? (
        <div>
          {props.data.map((item) => (
            <div key={item}>This is {item}</div>
          ))}
        </div>
      ) : (
        <div>No Data Found</div>
      )}
    </div>
  );
};

export default Table;
