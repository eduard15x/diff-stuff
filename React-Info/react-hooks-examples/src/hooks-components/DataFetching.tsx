import axios from "axios"
import { useState, useEffect } from "react"

const DataFetching = () => {
    const [id, setId] = useState<number>(1);
    const [idFromButtonClick, setIdFromButtonClick] = useState<unknown>(1);
    // const [posts, setPosts] = useState<unknown>([]);
    const [post, setPost] = useState<unknown>({});

    const handleClick = () => {
        setIdFromButtonClick(id);
    }

    // useEffect(() => {
    //     axios.get('https://jsonplaceholder.typicode.com/posts')
    //         .then(res => {
    //             console.log(res);
    //             setPosts(res.data);
    //         })
    //         .catch(err => {
    //             console.error(err);
    //         });
    // }, [])

    useEffect(() => {
        axios.get('https://jsonplaceholder.typicode.com/posts/' + id)
            .then(res => {
                console.log(res);
                setPost(res.data);
            })
            .catch(err => {
                console.error(err);
            })
    }, [idFromButtonClick])


  return (
    <div>
        <h1>Data Fetching Example</h1>

        <h2>List</h2>
        <ul>
            <li>Commented</li>
            {/* {
                posts.map((post) => (
                    <li key={post.id}>{ post.title}</li>
                ))
            } */}
        </ul>


        {/* Get single post */}
        <input type="text" value={id} onChange={(e) => setId(Number(e.target.value))} />
        <button onClick={handleClick}>Fetch Post</button>
        <div>
            <h2>Single Post</h2>

            <p>Title: {post.title}</p>
        </div>
    </div>
  )
}

export default DataFetching