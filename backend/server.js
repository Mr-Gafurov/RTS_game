const http = require('http');
const express = require('express');
const cors = require('cors');
const path = require('path');
const { Server } = require('colyseus');
const { GameRoom } = require('./rooms/GameRoom');
const adminRoutes = require('./routes/admin');

const port = process.env.PORT || 4000;
const app = express();

app.use(cors());
app.use(express.json());

// Статические файлы (Админ-панель)
app.use(express.static(path.join(__dirname, 'public')));

// Маршруты API
app.use('/api/admin', adminRoutes);

const server = http.createServer(app);
const gameServer = new Server({
  server,
});

gameServer.define('battle_room', GameRoom);

app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname, 'public', 'admin_dashboard.html'));
});

gameServer.listen(port);
console.log(`[Backend] Сервер запущен на порту ${port}`);
console.log(`[Backend] Админ-панель доступна по адресу: http://localhost:${port}`);
