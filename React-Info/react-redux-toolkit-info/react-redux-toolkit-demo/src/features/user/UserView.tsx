import { useEffect } from "react";
// import { useSelector, useDispatch } from "react-redux";
import { fetchUsers } from "./userSlice";
import { useAppSelector, useAppDispatch } from "../../app/hooks";

const UserView = () => {
  const dispath = useAppDispatch();
  const user = useAppSelector((state) => state.user);
  console.log(user)

  useEffect(() => {
    dispath(fetchUsers());
  }, []); // this will run when component will mount


  return (
    <div>
      <h1>User View</h1>
      <h2>Number of users: </h2>
      <h2>List of users</h2>
      {
        user.loading && <p>Loading...</p>
      }

      {
        !user.loading && user.error ? <p>{user.error}</p> : null
      }

      {
        !user.loading && user.users.length > 0 ? (
          <ul>
            {
              user.users.map((user: any) => (
                <li key={user.id}>
                  User have id {user.id} and name {user.name}
                </li>
              ))
            }
          </ul>
        ) : null
      }
    </div>
  );
};

export default UserView;
