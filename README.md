# InfoDat

Программа для автоматической генерации **Info.dat** файла для клиента игры **R2 Online** напрямую из базы данных.

## 🎮 Поддерживаемая версия клиента

- Клиент **R2 Online** версии **1703**.

## ⚙️ Использование

1. Скачайте или соберите исполняемый файл.
2. Запустите: `InfoDat.exe`
3. В результате работы будет создан файл **Info.dat**.
    - Если включена опция `ReplaceInfoDat`, файл автоматически заменится в клиенте.

## ⚙️ Конфигурация

Приложение использует файл настроек в формате **JSON**.  
Пример файла `config.json`:

```json
{
    "ConnectionString": "Data Source=(local);Database=FNLParm;Integrated Security=sspi;",
    "EtcFilePath": "D:\\R2\\R2 PTS\\etc\\etc.rfs",
    "ReplaceInfoDat": false,
    "Encoding": 1251
}
```

### Параметры

- **`ConnectionString`**  
  Строка подключения к базе данных (SQL Server).
    - Пример:
      ```
      Data Source=(local);Database=FNLParm;Integrated Security=sspi;
      ```
    - Поддерживаются стандартные параметры SQL Server:
        - `Data Source` — адрес сервера (например, `(local)` или `127.0.0.1`).
        - `Database` — имя базы данных.
        - `Integrated Security` — тип авторизации (`sspi` для Windows-аутентификации).
    - ✅ Корректный `ConnectionString` можно сгенерировать на сайте:  
      [SQL Server Connection String Generator](https://www.aireforge.com/tools/sql-server-connection-string-generator)

- **`EtcFilePath`**  
  Путь к файлу `etc.rfs` клиента **R2 Online**.
    - Используется **только если** `ReplaceInfoDat = true`.
    - Нужен для автоматической замены сгенерированного файла `Info.dat` в клиенте игры.
    - В JSON необходимо указывать путь с **двойными обратными слешами** (`\\`).
    - Пример:
      ```
      D:\\R2\\R2 PTS\\etc\\etc.rfs
      ```

- **`ReplaceInfoDat`**  
  Флаг, указывающий, нужно ли заменять существующий `Info.dat`.
    - Возможные значения:
        - `true` — перезаписать файл `Info.dat` в клиенте (требуется корректный `EtcFilePath`).
        - `false` — не заменять существующий файл.

- **`Encoding`**  
  Кодировка, используемая для текстовых данных.
    - Значение задаётся в виде числового идентификатора кодовой страницы (Windows Code Page).
    - Пример:
        - `1251` — Windows-1251 (кириллица).
        - `65001` — UTF-8.  
