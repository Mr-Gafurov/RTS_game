const { Room } = require('colyseus');

class GameRoom extends Room {
    onCreate(options) {
        this.setState({
            units: {},
            buildings: {},
            resources: {}
        });

        this.onMessage("move", (client, message) => {
            console.log(`[GameRoom] Юнит ${message.id} перемещается в ${message.x}, ${message.z}`);
            // Валидация и обновление состояния
        });

        this.onMessage("attack", (client, message) => {
            console.log(`[GameRoom] Атака от ${message.attackerId} по ${message.targetId}`);
        });
    }

    onJoin(client, options) {
        console.log(`[GameRoom] Игрок ${client.sessionId} присоединился`);
    }

    onLeave(client, consented) {
        console.log(`[GameRoom] Игрок ${client.sessionId} покинул комнату`);
    }

    onDispose() {
        console.log("[GameRoom] Комната удалена");
    }
}

module.exports = { GameRoom };
