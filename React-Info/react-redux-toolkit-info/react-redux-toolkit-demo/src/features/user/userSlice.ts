/* eslint-disable @typescript-eslint/no-explicit-any */
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

type UserState = {
    loading: boolean;
    users: [];
    error: string;
}

const initialState: UserState = {
    loading: false,
    users: [],
    error: ''
};

// generated pending, fulfilled and rejected action types
export const fetchUsers = createAsyncThunk<number[]>('user/fetchUsers', () => {
    return axios.get('https://jsonplaceholder.typicode.com/users')
        .then(res => {
            // console.log(res);
            const data = res.data.map((user: any) => user);
            // console.log(data);
            return data;
        })
        .catch(err => {
            console.log(err);
            throw err;
        });
});

const userSlice = createSlice({
    name: 'user',
    initialState: initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder.addCase(fetchUsers.pending, state => {
            state.loading = true;
        });

        builder.addCase(fetchUsers.fulfilled, (state, action) => {
            state.loading = false;
            state.users = action.payload;
            state.error = '';
        });

        builder.addCase(fetchUsers.rejected, (state, action) => {
            state.loading = false;
            state.users = [];
            state.error = action.error.message || 'There was an error on your request.';
        });
    }
});

export default userSlice.reducer;