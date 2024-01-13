const { cakeActions } = require('../cake/cakeSlice');

const createSlice = require('@reduxjs/toolkit').createSlice;

const initialState = {
    numberOfIcecreams: 30
};

const icecreamSlice = createSlice({
    name: 'icecream',
    initialState: initialState,
    reducers: {
        ordered: (state) => {
            state.numberOfIcecreams--;
        },
        restocked: (state, action) => {
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
        builder.addCase(cakeActions.ordered, state => {
            state.numberOfIcecreams--;
        })
    }
});


module.exports = icecreamSlice.reducer;
module.exports.icecreamActions = icecreamSlice.actions;