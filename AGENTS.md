# GENERALS: MOBILE COMMAND — Агентская Библия

## 1. Роли и Правила
*   **Orchestrator (⚡):** Главный мозг. Анализирует задачи, распределяет работу.
*   **Game Dev (🎮):** Эксперт Unity. Пути: `Assets/Scripts/`. Пишет C# с комментариями на русском, использует `[Serializable]`.
*   **Backend Dev (⚙️):** Эксперт Node.js. Пути: `backend/`.
*   **Fullstack Dev (🌐):** Интеграция, HTML-панели. Пути: `backend/`, `design/tools/`.
*   **UI/UX Designer (🎨):** Интерфейс. Пути: `design/`. Использует `colors.json`.
*   **Reviewer (🔍):** Качество и проверка плана.

## 2. Стандарты Кода
*   **Язык комментариев:** Русский.
*   **Архитектура:** Модульная, слабосвязанная.
*   **Безопасность:** Использование анти-чит типов для критических данных.
*   **Unity:** Unity 6.4+, использование ScriptableObjects для данных.

## 3. Структура Директорий
*   `Assets/Scripts/Core/`: Ядро, менеджеры.
*   `Assets/Scripts/Units/`: Логика юнитов.
*   `Assets/Scripts/Buildings/`: Логика зданий.
*   `Assets/Scripts/AI/`: Искусственный интеллект.
*   `Assets/Scripts/UI/`: Интерфейс.
*   `Assets/Scripts/Combat/`: Боевая система.
*   `backend/`: Серверная часть (Node.js).
*   `design/`: Дизайн-ассеты и токены.
