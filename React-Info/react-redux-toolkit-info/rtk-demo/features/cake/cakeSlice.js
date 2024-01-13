const createSlice = require('@reduxjs/toolkit').createSlice;

const initialState = {
    numberOfCakes: 10
}

const cakeSlice = createSlice({
    name: 'cake',
    initialState: initialState,
    reducers: {
        ordered: (state) => {
            // we can dirrectly mutate the sate
            state.numberOfCakes--; // this is using under the hood inner library
        },
        restocked: (state) => {
            state.numberOfCakes = initialState.numberOfCakes;
        },
        orderAmmount: (state, action) => {
            if (state.numberOfCakes < action.payload) {
                console.log('Total number of available cakes is:', state.numberOfCakes);
            } else {
                state.numberOfCakes -= action.payload;
            }
        },
        restockAmmount: (state, action) => {
            state.numberOfCakes += action.payload;
        }
    }
});

module.exports = cakeSlice.reducer;
module.exports.cakeActions = cakeSlice.actions;