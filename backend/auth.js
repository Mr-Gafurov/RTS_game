const { calculateELO } = require('./Matchmaking');

// Имитация базы данных
// ВАЖНО: В продакшене использовать переменные окружения и bcrypt для паролей
const users = [
    {
        email: "ttajhacker@gmail.com",
        password: process.env.ADMIN_PASSWORD,
        role: "Superadmin"
    }
];

if (!process.env.ADMIN_PASSWORD) {
    console.warn("WARNING: ADMIN_PASSWORD is not set! Admin login will not work.");
}

function authenticate(email, password) {
    const user = users.find(u => u.email === email && u.password === password);
    return user || null;
}

module.exports = { users, authenticate };
