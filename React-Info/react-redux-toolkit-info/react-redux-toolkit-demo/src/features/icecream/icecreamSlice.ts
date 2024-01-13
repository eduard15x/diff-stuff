import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { ordered as cakeOrdered } from '../cake/cakeSlice';

type InitialState = {
    numberOfIcecreams: number;
}

const initialState: InitialState = {
    numberOfIcecreams: 30
};

const icecreamSlice = createSlice({
    name: 'icecream',
    initialState: initialState,
    reducers: {
        ordered: (state) => {
            state.numberOfIcecreams--;
        },
        restocked: (state, action: PayloadAction<number>) => {
            state.numberOfIcecreams += action.payload;
        }
    },
    // first way - with mapping
    // extraReducers: {
    //     ['cake/ordered']: (state) => {
    //         state.numberOfIcecreams--;
    //     }
    // }
    extraReducers: (builder) => {
        builder.addCase(cakeOrdered, state => {
            state.numberOfIcecreams--;
        })
    }
});


export default icecreamSlice.reducer;
export const { ordered, restocked } = icecreamSlice.actions;