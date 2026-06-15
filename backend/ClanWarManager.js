class ClanWarManager {
    constructor() {
        this.activeWars = [];
    }

    startWar(clanAId, clanBId, duration) {
        const war = {
            id: Date.now().toString(),
            clanA: clanAId,
            clanB: clanBId,
            scoreA: 0,
            scoreB: 0,
            endTime: Date.now() + duration
        };
        this.activeWars.push(war);
        console.log(`[ClanWar] Война началась между ${clanAId} и ${clanBId}`);
        return war;
    }

    registerVictory(clanId, matchScore) {
        const war = this.activeWars.find(w => w.clanA === clanId || w.clanB === clanId);
        if (war && Date.now() < war.endTime) {
            if (war.clanA === clanId) war.scoreA += matchScore;
            else war.scoreB += matchScore;
        }
    }
}

module.exports = { ClanWarManager };
