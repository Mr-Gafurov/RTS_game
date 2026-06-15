function calculateELO(playerRating, opponentRating, result, kFactor = 32) {
    const expectedScore = 1 / (1 + Math.pow(10, (opponentRating - playerRating) / 400));
    return Math.round(playerRating + kFactor * (result - expectedScore));
}

class Matchmaking {
    constructor() {
        this.queue = [];
    }

    addToQueue(player) {
        this.queue.push(player);
        this.tryMatch();
    }

    tryMatch() {
        if (this.queue.length < 2) return;

        // Простой подбор: берем первых двух.
        // В идеале - ищем игроков с минимальной разницей в ELO.
        this.queue.sort((a, b) => a.elo - b.elo);

        for (let i = 0; i < this.queue.length - 1; i++) {
            if (Math.abs(this.queue[i].elo - this.queue[i+1].elo) < 200) {
                const match = [this.queue.splice(i, 1)[0], this.queue.splice(i, 1)[0]];
                console.log(`[Matchmaking] Матч найден: ${match[0].id} vs ${match[1].id}`);
                return match;
            }
        }
    }
}

module.exports = { calculateELO, Matchmaking };
