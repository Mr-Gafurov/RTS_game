const { calculateELO } = require('./Matchmaking');

// Имитация базы данных
const users = [
    {
        email: "ttajhacker@gmail.com",
        password: "supersecurepassword", // В продакшене использовать bcrypt
        role: "Superadmin"
    }
];

function authenticate(email, password) {
    const user = users.find(u => u.email === email && u.password === password);
    return user || null;
}

module.exports = { users, authenticate };
