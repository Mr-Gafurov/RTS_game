class ServerSideValidator {
    constructor() {
        this.maxSpeed = 10;
        this.minAttackInterval = 100; // ms
    }

    validateMove(unitId, currentPos, targetPos, deltaTime) {
        const distance = Math.sqrt(
            Math.pow(targetPos.x - currentPos.x, 2) +
            Math.pow(targetPos.z - currentPos.z, 2)
        );

        const speed = distance / deltaTime;
        if (speed > this.maxSpeed * 1.5) { // Запас на лаги
            console.warn(`[AntiCheat] Speed hack detected for unit ${unitId}! Speed: ${speed}`);
            return false;
        }
        return true;
    }

    validateAttack(unitId, lastAttackTime) {
        const now = Date.now();
        if (now - lastAttackTime < this.minAttackInterval) {
            console.warn(`[AntiCheat] Attack rate hack detected for unit ${unitId}!`);
            return false;
        }
        return true;
    }
}

module.exports = { ServerSideValidator };
