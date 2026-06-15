const { Room } = require('colyseus');

class ChatRoom extends Room {
    onCreate(options) {
        this.onMessage("send_message", (client, message) => {
            console.log(`[Chat] Сообщение от ${client.sessionId}: ${message.text}`);
            this.broadcast("message", {
                senderId: client.sessionId,
                text: message.text,
                channel: message.channel || "global",
                timestamp: Date.now()
            });
        });
    }

    onJoin(client, options) {
        console.log(`[Chat] Игрок ${client.sessionId} вошел в чат`);
    }

    onLeave(client, consented) {
        console.log(`[Chat] Игрок ${client.sessionId} покинул чат`);
    }
}

module.exports = { ChatRoom };
