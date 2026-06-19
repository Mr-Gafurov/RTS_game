const express = require('express');
const router = express.Router();
const { users, authenticate } = require('../auth');

const SECRET_TOKEN = process.env.ADMIN_TOKEN || require('crypto').randomBytes(32).toString('hex');

// Middleware для проверки авторизации
const authMiddleware = (req, res, next) => {
    const token = req.headers['authorization'];
    if (token === SECRET_TOKEN) {
        next();
    } else {
        res.status(403).json({ success: false, message: "Forbidden: Access Denied" });
    }
};

// Логин
router.post('/login', (req, res) => {
    const { email, password } = req.body;
    const user = authenticate(email, password);
    if (user) {
        res.json({ success: true, user: { email: user.email, role: user.role }, token: SECRET_TOKEN });
    } else {
        res.status(401).json({ success: false, message: "Invalid credentials" });
    }
});

// Все маршруты ниже требуют авторизации
router.use(authMiddleware);

// Получение статистики
router.get('/stats', (req, res) => {
    res.json({
        activeRooms: 5,
        playersOnline: 42,
        serverUptime: "2d 4h",
        cpuUsage: "12%"
    });
});

// Управление пользователями
router.get('/users', (req, res) => {
    const sanitizedUsers = users.map(u => ({ email: u.email, role: u.role }));
    res.json(sanitizedUsers);
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

// Глобальное уведомление
router.post('/broadcast', (req, res) => {
    const { message } = req.body;
    console.log(`[Admin] Глобальное сообщение: ${message}`);
    res.json({ success: true });
});

module.exports = router;
