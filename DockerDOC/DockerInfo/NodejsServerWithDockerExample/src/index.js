require('dotenv').config();

const express = require('express');
const app = express();
const PORT = process.env.PORT || 3000;

const FAKE_DB = "fake database to show docker compose example (compose.yaml)"

app.get('/', (req, res) => {
    console.log('Received a request on /');
    res.send('Hello, World!');
});

app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});