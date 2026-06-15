const express = require('express');
const router = express.Router();
const { users, authenticate } = require('../auth');

// Логин
router.post('/login', (req, res) => {
    const { email, password } = req.body;
    const user = authenticate(email, password);
    if (user) {
        res.json({ success: true, user: { email: user.email, role: user.role }, token: "mock-jwt-token" });
    } else {
        res.status(401).json({ success: false, message: "Invalid credentials" });
    }
});

// Получение статистики (только для админов)
router.get('/stats', (req, res) => {
    // В реальности здесь будет обращение к Colyseus gameServer
    res.json({
        activeRooms: 5,
        playersOnline: 42,
        serverUptime: "2d 4h",
        cpuUsage: "12%"
    });
});

// Управление пользователями (только для Superadmin)
router.get('/users', (req, res) => {
    res.json(users);
});

router.post('/users/create', (req, res) => {
    const { email, password, role } = req.body;
    users.push({ email, password, role });
    res.json({ success: true });
});

// Бан игрока
router.post('/players/ban', (req, res) => {
    const { playerId, reason } = req.body;
    console.log(`[Admin] Игрок ${playerId} забанен. Причина: ${reason}`);
    res.json({ success: true });
});

// Отправка подарков
router.post('/players/gift', (req, res) => {
    const { playerId, itemType, amount } = req.body;
    console.log(`[Admin] Отправлен подарок игроку ${playerId}: ${itemType} x${amount}`);
    res.json({ success: true });
});

// Получение данных игрока
router.get('/players/:id', (req, res) => {
    const playerId = req.params.id;
    // Mock data
    res.json({
        id: playerId,
        email: "player@example.com",
        elo: 1250,
        gold: 50000,
        level: 15
    });
});

// Обновление данных игрока
router.post('/players/update', (req, res) => {
    const { playerId, elo, gold } = req.body;
    console.log(`[Admin] Данные игрока ${playerId} обновлены: ELO=${elo}, Gold=${gold}`);
    res.json({ success: true });
});

// Глобальное уведомление
router.post('/broadcast', (req, res) => {
    const { message } = req.body;
    console.log(`[Admin] Глобальное сообщение: ${message}`);
    // В реальности - broadcast через Colyseus
    res.json({ success: true });
});

// Управление Live-ивентами
router.post('/events/start', (req, res) => {
    const { eventType, multiplier, duration } = req.body;
    console.log(`[Admin] Запущен ивент: ${eventType}, Множитель: ${multiplier}, Длительность: ${duration}м`);
    res.json({ success: true });
});

module.exports = router;
