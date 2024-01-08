import { useEffect } from "react"
import { connect } from "react-redux"
import { fetchUsers } from "../redux/user/userActions"

const UserContainer = ({ userData,  fetchUsers }) => {

    useEffect(() => {
        fetchUsers();
    }, [])

    return userData.loading ? (
        <h2>Request is loading</h2>
    ) : userData.error ? (
        <h2>{userData.error}</h2>
    ) : (
        <div>
            <h2>User List</h2>
            <ul>
                {
                userData && userData.users && userData.users.map((user) => (
                    <li key={user.id}>{ user.name }</li>
                ))
                }
            </ul>
        </div>
    )
}

const mapStateToProps = state => {
    return {
        userData: state.user
    }
}

const mapDispatchToProps = dispatch => {
    return {
        fetchUsers: () => dispatch(fetchUsers())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UserContainer);