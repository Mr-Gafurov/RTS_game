const http = require('http');
const express = require('express');
const cors = require('cors');
const { Server } = require('colyseus');
const { GameRoom } = require('./rooms/GameRoom');

const port = process.env.PORT || 4000;
const app = express();

app.use(cors());
app.use(express.json());

const server = http.createServer(app);
const gameServer = new Server({
  server,
});

// Регистрация игровых комнат
gameServer.define('battle_room', GameRoom);

app.get('/', (req, res) => {
  res.send('Generals Mobile Command Backend is running!');
});

gameServer.listen(port);
console.log(`[Backend] Сервер запущен на порту ${port}`);
