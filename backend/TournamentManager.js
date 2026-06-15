class TournamentManager {
    constructor() {
        this.tournaments = [];
    }

    createTournament(name, startTime, prizePool) {
        const tournament = {
            id: Date.now().toString(),
            name,
            startTime,
            prizePool,
            participants: [],
            brackets: [],
            status: 'upcoming' // upcoming, active, finished
        };
        this.tournaments.push(tournament);
        return tournament;
    }

    registerPlayer(tournamentId, player) {
        const tournament = this.tournaments.find(t => t.id === tournamentId);
        if (tournament && tournament.status === 'upcoming') {
            tournament.participants.push(player);
            return true;
        }
        return false;
    }

    generateBrackets(tournamentId) {
        const tournament = this.tournaments.find(t => t.id === tournamentId);
        if (tournament) {
            // Простая логика генерации пар для 1/8, 1/4 и т.д.
            console.log(`[Tournament] Сетка сгенерирована для ${tournament.name}`);
        }
    }
}

module.exports = { TournamentManager };
