# 🎖️ GENERALS: MOBILE COMMAND — ROADMAP

> **Для Jules:** Это рабочий план разработки. Перед началом любой сессии — прочитай текущий раздел "Статус", открой упомянутые файлы и проверь что реально реализовано, а что нет. Обновляй статусы (⬜ → 🔄 → ✅) после каждой выполненной задачи. Не описывай нереализованные функции в README.md как готовые.

**Движок:** Unity 6.4 (C#) · **Backend:** Node.js + Colyseus · **Версия документа:** 1.0

---

## Легенда статусов

| Статус | Значение |
|---|---|
| ⬜ | Не начато |
| 🔄 | В работе |
| ✅ | Готово и проверено |
| ❌ | Есть проблема / баг |

---

## 🗺 Обзор стадий

| Стадия | Название | Результат | Статус |
|---|---|---|---|
| 1 | Прототип: одиночная игра против ИИ-бота | Играбельная база vs бот, 1 карта, 3 юнита, строительство, ресурсы | 🔄 |
| 2 | Три фракции (США, Китай, ГЛА) | Уникальные юниты, здания, способности генералов для каждой фракции | ⬜ |
| 3 | Уровни сложности и карты | Лёгкий/Средний/Сложный бот, несколько карт, прокачка генерала | ⬜ |
| 4 | Шлифовка и монетизация | Звук, эффекты, баланс, магазин косметики, публикация в сторах | ⬜ |
| 5 | Онлайн-мультиплеер | 1v1 онлайн, матчмейкинг, ELO, лидерборды | ⬜ |

**Правило:** не переходи к следующей стадии, пока текущая не играбельна целиком.

---

## ⚠️ ПЕРВЫМ ДЕЛОМ — Reality Check

Перед началом работы по любой стадии выполни:

1. Прочитай `AGENTS.md`, `README.md`, `PROJECT_PASSPORT.md`, `GRAPHICS_STATUS.md`, `API_REFERENCE.md`
2. Прочитай **каждый** `.cs` файл в `Assets/Scripts/` и **каждый** `.js` файл в `backend/`
3. Создай `REALITY_CHECK.md`: для каждой фичи из README/PASSPORT отметь:
   - ✅ IMPLEMENTED — реальная рабочая логика существует
   - 🟡 STUB — файл есть, но заглушка/пусто/TODO
   - ❌ NOT STARTED — файла нет
4. Перепиши `README.md` — оставь только то что РЕАЛЬНО работает. Всё нереализованное (морские бои, спектатор-режим, кланы, герои-генералы) перенеси в `ROADMAP_FUTURE.md`
5. Обнови таблицу статусов ниже в этом файле на основе реальной проверки

---

# СТАДИЯ 1 — Прототип: одиночная игра против ИИ-бота

**Цель:** играбельная игра 1 на 1 против бота. Без мультиплеера, без нескольких фракций. Сесть и поиграть — построить базу, производить юниты, атаковать бота, бот атакует в ответ. Кто разрушил базу противника — победил.

## 1.1 Ядро игрового движка (Unity)

| Задача | Файл | Статус |
|---|---|---|
| Состояния игры (старт/бой/пауза/конец) | `Assets/Scripts/Core/GameManager.cs` | ⬜ |
| Базовый класс юнита (HP, урон, скорость) | `Assets/Scripts/Units/BaseUnit.cs` | ⬜ |
| Базовый класс здания (HP, цена, очередь) | `Assets/Scripts/Buildings/BaseBuilding.cs` | ⬜ |
| Пехотный юнит | `Assets/Scripts/Units/Infantry.cs` | ⬜ |
| Танковый юнит | `Assets/Scripts/Units/Tank.cs` | ⬜ |
| Дальнобойный юнит | `Assets/Scripts/Units/Artillery.cs` | ⬜ |
| Менеджер ресурсов (золото, энергия) | `Assets/Scripts/Core/ResourceManager.cs` | ⬜ |
| Размещение зданий тачем | `Assets/Scripts/Buildings/BuildingPlacer.cs` | ⬜ |
| Выбор юнитов (тап + drag box) | `Assets/Scripts/Units/UnitSelectionManager.cs` | ⬜ |
| Движение по NavMesh | `Assets/Scripts/Units/UnitMovement.cs` | ⬜ |
| Система боя (дальний/ближний) | `Assets/Scripts/Combat/AttackSystem.cs` | ⬜ |
| Казармы — производство пехоты | `Assets/Scripts/Buildings/Barracks.cs` | ⬜ |
| Завод — производство техники | `Assets/Scripts/Buildings/Factory.cs` | ⬜ |
| Командный центр (главное здание) | `Assets/Scripts/Buildings/CommandCenter.cs` | ⬜ |
| Склад ресурсов | `Assets/Scripts/Buildings/SupplyDepot.cs` | ⬜ |

## 1.2 ИИ-бот (противник)

| Задача | Файл | Статус |
|---|---|---|
| Главный контроллер бота | `Assets/Scripts/AI/AIController.cs` | ⬜ |
| Логика строительства бота | `Assets/Scripts/AI/AIBuildingStrategy.cs` | ⬜ |
| Управление юнитами бота | `Assets/Scripts/AI/AIUnitCommander.cs` | ⬜ |
| Сбор ресурсов ботом | `Assets/Scripts/AI/AIResourceCollector.cs` | ⬜ |
| Параметры сложности (пока 1 уровень — Easy) | `Assets/Scripts/AI/AIDifficultySettings.cs` | ⬜ |

**Логика Easy-бота:** строит CommandCenter → Barracks (30 сек) → Factory (90 сек) → первая атака на 4-й минуте. FSM: `BUILDING → TRAINING → ATTACKING`.

## 1.3 Карта и окружение

| Задача | Файл | Статус |
|---|---|---|
| Базовая карта 512x512 | `Assets/Scripts/Core/MapGenerator.cs` | ⬜ |
| Точки сбора ресурсов | `Assets/Scripts/Core/ResourceNode.cs` | ⬜ |
| Туман войны | `Assets/Scripts/Core/FogOfWar.cs` | ⬜ |
| Камера: drag/pinch/zoom для мобилки | `Assets/Scripts/Core/CameraController.cs` | ⬜ |
| Мини-карта | `Assets/Scripts/UI/MiniMap.cs` | ⬜ |

## 1.4 Интерфейс (HUD)

| Задача | Файл | Статус |
|---|---|---|
| Цвета фракций и UI токены | `design/tokens/colors.json` | ⬜ |
| Шрифты и размеры | `design/tokens/typography.json` | ⬜ |
| Прототип боевого HUD | `design/screens/hud.html` | ⬜ |
| HUD в Unity (ресурсы, здоровье базы) | `Assets/Scripts/UI/HUDManager.cs` | ⬜ |
| Панель выбора зданий | `Assets/Scripts/UI/BuildMenuUI.cs` | ⬜ |
| Панель выбранных юнитов | `Assets/Scripts/UI/UnitSelectionUI.cs` | ⬜ |
| Главное меню (Старт/Выход) | `Assets/Scenes/MainMenu.unity` | ⬜ |

## 1.5 Локальный бекенд (сохранения, без мультиплеера)

| Задача | Файл | Статус |
|---|---|---|
| Express сервер (порт 4000) | `backend/server.js` | ⬜ |
| Заготовка комнат (для Стадии 5) | `backend/routes/rooms.js` | ⬜ |
| Сохранение/загрузка (PlayerPrefs) | `Assets/Scripts/Core/SaveSystem.cs` | ⬜ |
| Настройки (звук, графика, управление) | `Assets/Scripts/Core/SettingsManager.cs` | ⬜ |

## 1.6 Графика и 3D-модели

| Задача | Файл | Статус |
|---|---|---|
| Спецификация всех ассетов для генерации/поиска | `design/asset-specs.json` | ⬜ |
| Визуальный чеклист ассетов | `design/asset-checklist.html` | ⬜ |
| Импорт low-poly моделей (Kenney/Quaternius) | `Assets/Models/` | ⬜ |
| Текстуры земли (grass/sand/road) | `Assets/Textures/Terrain/` | ⬜ |
| UI-иконки юнитов и зданий | `Assets/UI/Icons/` | ⬜ |

---

## 🤖 Сессии для Стадии 1

Выполняй по очереди. Перед каждой сессией читай файлы из предыдущих сессий.

### Сессия 1-A: Ресурсы, камера, сохранения

```
Проверь существующие файлы в Assets/Scripts/. Затем создай:

- Assets/Scripts/Core/ResourceManager.cs: управление Gold (старт 1000, макс 9999) 
  и Power. Методы AddResource, SpendResource, CanAfford. Событие OnResourceChanged.
- Assets/Scripts/Core/CameraController.cs: мобильная RTS-камера — touch drag для 
  панорамирования, pinch для зума (мин 5, макс 30 units высоты), double-tap для центрирования.
- Assets/Scripts/Core/SaveSystem.cs: сохранение/загрузка через PlayerPrefs 
  (золото, размещённые здания, живые юниты).

design/screens/hud.html: прототип мобильного HUD (375x667px телефон-фрейм). 
Верх: счётчик золота, шкала энергии, supply ratio. Низ: 5 слотов юнитов с HP-барами. 
Низ-право: миникарта 150x150. Право: очередь строительства. 
Тёмная военная тема из design/tokens/colors.json.
```

### Сессия 1-B: Строительство базы

```
Проверь ResourceManager.cs и существующие файлы. Затем создай:

- Assets/Scripts/Buildings/BuildingPlacer.cs: тап выбирает тип здания из меню, 
  призрак-превью показывает зелёным/красным валидность размещения, 
  тап подтверждает, списывает стоимость через ResourceManager.
- Assets/Scripts/Buildings/CommandCenter.cs: главное здание, 2000HP, 
  если разрушено = game over, даёт 20 Power.
- Assets/Scripts/Buildings/Barracks.cs: 500HP, цена 500 золота, 
  производит Infantry каждые 15 сек (очередь до 5).
- Assets/Scripts/Buildings/Factory.cs: 800HP, цена 800 золота, 
  производит Tank каждые 25 сек.
- Assets/Scripts/UI/BuildMenuUI.cs: панель Unity UI, 4 кнопки зданий 
  с иконкой+ценой+названием, появляется по тапу.
```

### Сессия 1-C: Движение и бой юнитов

```
Проверь существующие скрипты юнитов. Затем создай:

- Assets/Scripts/Units/UnitMovement.cs: NavMeshAgent, тап по земле — движение 
  выделенных юнитов, групповое построение при движении нескольких юнитов.
- Assets/Scripts/Units/UnitSelectionManager.cs: тап — выбор одного юнита, 
  drag-box — выбор нескольких, Ctrl+тап — добавить к выбору, тап по пустой 
  земле — снять выделение.
- Assets/Scripts/Combat/AttackSystem.cs: юниты автоатакуют врагов в радиусе. 
  Дальние юниты (Artillery) останавливаются и стреляют. Ближние (Infantry) 
  преследуют. Tank — средняя дальность.
- Assets/Scripts/UI/UnitSelectionUI.cs: нижняя панель с портретами выбранных 
  юнитов, HP-барами, кнопкой атаки.
```

### Сессия 1-D: ИИ-противник

```
Проверь все существующие скрипты. Затем создай:

- Assets/Scripts/AI/AIController.cs: главный мозг бота, тикает каждые 5 сек, 
  решает следующее действие.
- Assets/Scripts/AI/AIBuildingStrategy.cs: бот строит CommandCenter → 
  Barracks (30 сек) → Factory (90 сек) → атака на 3-й минуте. 
  FSM: BUILDING → TRAINING → ATTACKING.
- Assets/Scripts/AI/AIUnitCommander.cs: при 5+ юнитах бот отправляет волну 
  на базу игрока. При атаке на свою базу — отправляет защитников.
- Сложность Easy: первая атака через 4 минуты, строит медленно.
```

### Сессия 1-E: Графика и ассеты

```
Проверь Assets/Scripts/Units/ и Assets/Scripts/Buildings/ для точных имён классов. 
Затем создай design/asset-specs.json — полный список 3D-моделей и графики для 
Стадии 1. Для каждого ассета: name (= имя C# класса), type, faction, description 
(для Meshy.ai), poly_budget (юниты 500-1500 трисов, здания 1500-3000), 
size_meters, reference_search (для Kenney.nl/Quaternius).

Покрой: Infantry, Tank, Artillery, CommandCenter, Barracks, Factory, SupplyDepot, 
текстуры земли (grass/sand/road), UI-иконки (отдельно на каждый юнит/здание), 
иконки миникарты.

Также создай design/asset-checklist.html — визуальный чеклист с галочками 
по категориям.
```

### Сессия 1-F: Финальная проверка Стадии 1

```
Прочитай ВСЕ файлы в Assets/Scripts/, backend/, design/. Для каждой задачи 
из раздела "Стадия 1" этого ROADMAP.md проверь — реально реализовано рабочим 
кодом (✅), заглушка (🟡) или не существует (⬜).

Обнови таблицы статусов в ROADMAP.md соответственно.

Напиши краткий честный отчёт: что работает end-to-end, что сломано, 
что осталось доделать перед переходом на Стадию 2.

design/dashboard.html: визуальный дашборд — карточки фракций, HUD-мокап 
в телефон-фрейме, дерево файлов проекта, диаграмма стека 
(Unity 6.4 → Node.js:4000), статус по каждой задаче Стадии 1.
```

---

# СТАДИЯ 2 — Три фракции (США, Китай, ГЛА)

**Начинать только после полной играбельности Стадии 1.**

| Задача | Файл | Статус |
|---|---|---|
| ScriptableObject данных фракции | `Assets/Scripts/Core/FactionData.cs` | ⬜ |
| Выбор фракции перед матчем | `Assets/Scripts/UI/FactionSelector.cs` | ⬜ |
| США: Paladin (тяжёлый танк), Ranger (снайпер), Chinook (вертолёт) | `Assets/Scripts/Units/USA/` | ⬜ |
| Китай: Overlord (мега-танк), RedGuard (пехота), MiG (самолёт) | `Assets/Scripts/Units/China/` | ⬜ |
| ГЛА: Scorpion (лёгкий танк), Terrorist (смертник), SCUDLauncher | `Assets/Scripts/Units/GLA/` | ⬜ |
| Уникальные здания фракций (2-3 на фракцию) | `Assets/Scripts/Buildings/Factions/` | ⬜ |
| Суперспособность генерала (1 на фракцию) | `Assets/Scripts/Generals/GeneralsPower.cs` | ⬜ |
| UI фракций в своих цветах | `design/screens/faction-ui.html` | ⬜ |
| Таблица баланса всех 9+ юнитов | `design/balance/unit-stats.json` | ⬜ |

---

# СТАДИЯ 3 — Уровни сложности и карты

| Задача | Файл | Статус |
|---|---|---|
| Лёгкий/Средний/Сложный режим | `Assets/Scripts/AI/DifficultyManager.cs` | ⬜ |
| Сложный бот: все юниты, фланги, ложные атаки | `Assets/Scripts/AI/AIController.cs` (расширение) | ⬜ |
| Карта 2: Пустыня | `Assets/Scenes/Map02_Desert.unity` | ⬜ |
| Карта 3: Город | `Assets/Scenes/Map03_City.unity` | ⬜ |
| Прокачка генерала (очки за победы) | `Assets/Scripts/Generals/GeneralRankSystem.cs` | ⬜ |
| Экран выбора карты/сложности | `design/screens/map-select.html` | ⬜ |

---

# СТАДИЯ 4 — Шлифовка и монетизация

| Задача | Файл | Статус |
|---|---|---|
| Звуковые эффекты (выстрелы, взрывы, голоса) | `Assets/Audio/SFX/` | ⬜ |
| Фоновая музыка (Suno AI, 3 трека на фракцию) | `Assets/Audio/Music/` | ⬜ |
| Particle-эффекты (взрывы, дым) | `Assets/Effects/` | ⬜ |
| Магазин косметики (без pay-to-win) | `backend/routes/shop.js` | ⬜ |
| PlayFab: аккаунты, статистика, достижения | `Assets/Scripts/Core/PlayFabManager.cs` | ⬜ |
| Публикация Google Play (бета) | `BUILD_ANDROID.md` | ⬜ |
| Публикация App Store | `BUILD_IOS.md` | ⬜ |

---

# СТАДИЯ 5 — Онлайн-мультиплеер

**Начинать только когда одиночная игра отполирована и есть живые игроки.**

| Задача | Файл | Статус |
|---|---|---|
| Серверная игровая комната (Colyseus) | `backend/rooms/GameRoom.js` | ⬜ |
| Синхронизация состояния в Unity | `Assets/Scripts/Network/NetworkManager.cs` | ⬜ |
| Матчмейкинг по рейтингу | `backend/services/matchmaking.js` | ⬜ |
| ELO-рейтинг | `backend/services/elo.js` | ⬜ |
| Лидерборд | `backend/routes/leaderboard.js` | ⬜ |
| Компенсация задержки (lag compensation) | `Assets/Scripts/Network/LagCompensation.cs` | ⬜ |

---

## 📌 Памятка

- **Перед началом любой задачи** — прочитай существующие файлы, не пиши с нуля то что уже есть
- **После завершения задачи** — обнови статус в таблице (⬜ → ✅) в этом файле
- **README.md** должен всегда отражать ТОЛЬКО реально существующий код
- **Нереализованные фичи** — в `ROADMAP_FUTURE.md`, не в README
- **Не переходи к следующей стадии**, пока текущая не полностью играбельна

---

*Generals: Mobile Command · Roadmap v1.0*
