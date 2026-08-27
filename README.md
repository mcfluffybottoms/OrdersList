# OrdersList

## Стек технологий

### Backend

* .NET / ASP.NET Core 9
* Entity Framework Core
* SQLite

### Frontend

* React (TypeScript)
* Vite
* React Router

### Инструменты

* Entity Framework Core Migrations
* ESLint
* npm

## Запуск проекта

### Backend

Перед первым запуском примените Entity Framework Core migrations:

```bash
dotnet ef database update
```

Перейдите в папку с .NET-проектом ("src/backend") и выполните:

```bash
dotnet restore
dotnet run
```

Backend будет доступен по адресу:

```text
http://localhost:5050
```

#### API endpoints

Все API-запросы выполняются через:

```text
http://localhost:5050
```

##### Получить список заказов

```text
GET http://localhost:5050/orders
```

Результат (200 Ok):

[
  {
    "id": 1,
    "senderAddress": {
      "locality": "Amsterdam",
      "streetAddress": "Damstraat 10"
    },
    "receiverAddress": {
      "locality": "Rotterdam",
      "streetAddress": "Coolsingel 20"
    },
    "weight": 1000,
    "pickupDate": "2026-08-28"
  }
]

##### Создать заказ

```text
POST http://localhost:5050/orders/create
```

Тело запроса:

{
    "id": 1,
    "senderAddress": {
      "locality": "Amsterdam",
      "streetAddress": "Damstraat 10"
    },
    "receiverAddress": {
      "locality": "Rotterdam",
      "streetAddress": "Coolsingel 20"
    },
    "weight": 1000,
    "pickupDate": "2026-08-28"
}


Результат: 201	- Created

##### Получить заказ по ID

```text
GET http://localhost:5050/orders/{id}
```

Результат (200 Ok):
{
  "id": 1,
  "senderAddress": {
    "locality": "Amsterdam",
    "streetAddress": "Damstraat 10"
  },
  "receiverAddress": {
    "locality": "Rotterdam",
    "streetAddress": "Coolsingel 20"
  },
  "weight": 1000,
  "pickupDate": "2026-08-28"
}

Результат также может быть 404 - not found.

### Frontend

В отдельном терминале перейдите в папку frontend и установите зависимости:

```bash
npm install
```

Запустите React-приложение:

```bash
npm run dev
```

После запуска frontend будет доступен по адресу:

```text
http://localhost:5173
```

### Переменные окружения

Адрес бэкенд-сервера задается в .env

```env
VITE_API_URL=http://localhost:5050
```

В appsettings.json задается адрес фронта:
```json
"FrontendUrl": "http://localhost:5173",
```

### База данных

Перед первым запуском примените Entity Framework Core migrations:

```bash
dotnet ef database update
```

### Запуск

Таким образом, для работы приложения необходимо запустить:

1. Backend — `http://localhost:5050`
2. Frontend — `http://localhost:5173`

Frontend обращается к backend через `http://localhost:5050`.
