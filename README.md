# 🔍 Project.CarParser — Парсер объявлений с умной фильтрацией и управлением пользователями

Project.CarParser — это полнофункциональное веб-приложение, предназначенное для автоматического парсинга объявлений с выбранного сайта, хранения и быстрого поиска свежей информации. Проект построен на современном стеке: **.NET (Backend)** и **React (Frontend)**, с акцентом на масштабируемость, производительность и расширяемость.

---

## 🚀 Возможности

- ⚙️ **Автоматический парсинг** _(в разработке)_: Получение свежих объявлений с целевого сайта по заданному расписанию.
- 🧠 **Умная фильтрация** _(в разработке)_: Быстрый поиск и сортировка по ключевым параметрам (цена, регион, марка и т.д.).
- 🗄️ **Хранение в БД** _(в разработке)_: Все данные сохраняются в базе для мгновенного доступа и повторного анализа.
- 👥 **Менеджмент пользователей** _(в разработке)_: Авторизация, роли, история запросов и персональные настройки.
- 📈 **Масштабируемость** _(в разработке)_: Архитектура проекта позволяет легко добавлять новые источники и расширять функциональность.

---

## 🛠️ Технологии

| Компонент   | Стек                                  |
| ----------- | ------------------------------------- |
| Backend     | .NET 7, ASP.NET Core Web API          |
| Frontend    | React, TypeScript, Axios, TailwindCSS |
| База данных | PostgreSQL / MS SQL (на выбор)        |
| Парсинг     | HtmlAgilityPack / AngleSharp          |
| Авторизация | JWT, ASP.NET Identity _(в планах)_    |
| Деплой      | Docker, Nginx, CI/CD _(в планах)_     |

---

## 📦 Структура проекта

Project.CarParser/
├── src/ # ASP.NET Core
│ ├── Core/
│ | ├── Project.CarParser.Application/
│ | └── Project.CarParser.Domain/
│ ├── Infrastracture/
│ ├── Persistence/
│ | └── Project.CarParser.Persistence/
│ └── API/
│ | └── Project.CarParser.API
|
├── client/ # React + TypeScript
│ ├── src/
│ ├── components/
│ │ ├── pages/
│ │ └── services/
├── Project.CarParser.sln
└── README.md

---

## 🧭 Планы на будущее

- 🔐 Реализация авторизации и ролей
- 📲 Уведомления о новых объявлениях (Telegram, Email, SMS)
- 📊 Панель администратора с аналитикой
- 🧩 API для внешних интеграций

---

## 📌 Установка и запуск

```bash
# Клонируем репозиторий
git clone https://github.com/StefanStrauberg/Project.CarParser.git
cd autoscout

# Backend
cd src/API/Project.CarParser.API/
dotnet restore
dotnet run

# Frontend
cd ../../../client
npm install
npm start
```
