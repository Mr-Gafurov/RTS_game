# API Reference — GENERALS: MOBILE COMMAND

## Core Managers
- `GameManager`: Управление состояниями (Battle, Paused, etc).
- `ResourceManager`: Управление валютой и энергией игрока.
- `NetworkManager`: Синхронизация с Colyseus бэкендом.
- `MissionManager`: Логика кампаний и сценариев.
- `FogOfWarManager`: Система тумана войны.

## Unit Systems
- `BaseUnit`: Базовый класс для всех юнитов.
- `UnitMovement`: Навигация (NavMesh) для земли и воды.
- `UnitVeterancy`: Система опыта и рангов (0-3).
- `GeneralHero`: Прокачка и таланты уникальных героев.

## Multiplayer & Backend
- `ServerSideValidator`: Проверка действий на стороне Node.js.
- `Matchmaking`: Расчет ELO и подбор соперников.
- `ChatRoom`: WebSocket чат (Глобальный/Клан).

## Esports & Community
- `SpectatorManager`: Режим наблюдателя.
- `ReplayManager`: Запись и воспроизведение команд.
