const { calculateELO } = require('./Matchmaking');

// Имитация базы данных
// ВАЖНО: В продакшене использовать переменные окружения и bcrypt для паролей
const users = [
    {
        email: "ttajhacker@gmail.com",
        password: process.env.ADMIN_PASSWORD || "change_me_in_production",
        role: "Superadmin"
    }
];

function authenticate(email, password) {
    const user = users.find(u => u.email === email && u.password === password);
    return user || null;
}

module.exports = { users, authenticate };
