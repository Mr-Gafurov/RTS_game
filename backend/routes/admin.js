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

module.exports = router;
