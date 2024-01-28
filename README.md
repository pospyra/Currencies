# Currency Exchange Service

Данный проект представляет собой сервис, выдающий текущий курс валюты через HTTP REST API. 

## Особенности

- **GET /currencies**: Возвращает список курсов обмена с поддержкой пагинации.

- **GET /currency/{id}**: Возвращает курс обмена для указанного идентификатора валюты. Этот эндпоинт защищен аутентификацией Bearer.

- **POST /user:** Регистрация пользователя в системе.

- **POST /user/login:** Авторизация пользователя в системе.

## Используемые технологии

- ASP.NET Core
- SQLite Database
- Entity Framework Core 
- Bearer Token Authentication
- Внешний источник данных: [Центральный банк России](http://www.cbr.ru/scripts/XML_daily.asp)

## Начало работы

1. Клонируйте репозиторий.

2. Обновите `ConnectionStrings` в файле `appsettings.json`, находящийся в ConsoleApp и Currencies.WebApi, изменив путь к базе данных в соответствии с местоположением вашего проекта.
   _Обратите внимание, что база данных создастся автоматически при запуске проекта._

   ```json
   "ConnectionStrings": {
       "CurrenciesDBConnection": "Ваш\\Путь\\Currencies\\Currencies.DAL\\DataBase\\currencies.db"
   },

3. Откройте меню "Настройка начальных проектов" и выберите "Несколько запускаемых проектов". Укажите "Запуск" для ConsoleApp и Currencies.WebApi.
   
![image](https://github.com/pospyra/Currencies/assets/68563967/45282101-f60a-4949-bfdc-0b09df67a7b4)

4. Запустите проект.

5. Для записи текущих курсов валют в базу данных, выберите опцию **1** в консольном контроллере.
