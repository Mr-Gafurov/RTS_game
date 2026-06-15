const mongoose = require('mongoose');

const UserSchema = {
    email: { type: String, required: true, unique: true },
    password: { type: String, required: true },
    role: { type: String, enum: ['Superadmin', 'Admin', 'Worker'], default: 'Worker' },
    createdAt: { type: Date, default: Date.now }
};

module.exports = UserSchema;
