const mongoose = require('mongoose');

// Примечание: В реальном проекте мы бы использовали MongoDB, здесь используем схему как описание структуры
const ClanSchema = {
    name: String,
    tag: String,
    leaderId: String,
    members: [
        {
            userId: String,
            role: String // Leader, Officer, Member
        }
    ],
    points: Number,
    description: String,
    level: Number
};

module.exports = ClanSchema;
