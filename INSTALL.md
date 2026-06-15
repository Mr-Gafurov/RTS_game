# Инструкция по развертыванию GENERALS: MOBILE COMMAND

## 1. Unity Проект
1. Откройте папку проекта в **Unity 6.4+**.
2. Убедитесь, что установлены пакеты: `NavMeshComponents`, `TextMeshPro`, `AI Navigation`.
3. Скрипты находятся в `Assets/Scripts/`.
4. Базовые сцены (нужно создать): `MainMenu`, `BattleScene`.

## 2. Бэкенд
1. Установите Node.js (v16+).
2. Перейдите в папку `backend/`.
3. Выполните:
   ```bash
   npm install
   npm start
   ```
4. Сервер будет доступен по адресу `http://localhost:4000`.

## 3. Сборка
Используйте кастомные скрипты в Unity для сборки APK (Android) или проекта Xcode (iOS).
