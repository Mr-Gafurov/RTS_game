const UserSchema = {
    email: { type: String, required: true, unique: true },
    password: { type: String, required: true },
    role: { type: String, enum: ['Superadmin', 'Admin', 'Worker'], default: 'Worker' },
    stats: {
        elo: { type: Number, default: 1000 },
        wins: { type: Number, default: 0 },
        losses: { type: Number, default: 0 },
        rank: { type: Number, default: 1 }
    },
    inventory: [String],
    unlockedTechs: [String],
    clanId: String,
    createdAt: { type: Date, default: Date.now }
};

module.exports = UserSchema;
