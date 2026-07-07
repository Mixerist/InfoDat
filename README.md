# InfoDat

🇷🇺 **Русский** · [🇰🇷 한국어](README.ko.md) · [🇨🇳 中文](README.zh.md)

Программа для автоматической генерации **Info.dat** файла для клиента игры **R2 Online** напрямую из базы данных.

## 🎮 Поддерживаемые версии клиента

Поддерживается несколько версий клиента **R2 Online**. Версия определяется автоматически по схеме базы данных, либо задаётся вручную параметром `ClientVersion`.

- **1602**
- **1703**

## ⚙️ Использование

1. Скачайте [последний релиз](https://github.com/Mixerist/InfoDat/releases/latest) или соберите исполняемый файл самостоятельно.
2. Запустите: `InfoDat.exe`
3. В результате работы будет создан файл **Info.dat**.
    - Если включена опция `ReplaceInfoDat`, файл автоматически заменится в клиенте.

## ⚙️ Конфигурация

Приложение использует файл настроек в формате **JSON**.  
Пример файла `Config.json`:

```json
{
    "ConnectionString": "Data Source=(local);Database=FNLParm;Integrated Security=sspi;",
    "EtcFilePath": "D:\\R2\\R2 PTS\\etc\\etc.rfs",
    "ReplaceInfoDat": false,
    "Encoding": 1251,
    "ClientVersion": null
}
```

### Параметры

| Параметр | Описание | Значения / пример |
|---|---|---|
| `ConnectionString` | Строка подключения к базе данных (SQL Server). Основные части: `Data Source` — адрес сервера (`(local)`, `127.0.0.1`), `Database` — имя БД, `Integrated Security` — тип авторизации (`sspi` для Windows-аутентификации). | `Data Source=(local);Database=FNLParm;Integrated Security=sspi;` |
| `EtcFilePath` | Путь к файлу `etc.rfs` клиента. Используется только при `ReplaceInfoDat = true` для замены `Info.dat` в клиенте. В JSON слеши экранируются двойными слешами (`\\`). | `D:\\R2\\R2 PTS\\etc\\etc.rfs` |
| `ReplaceInfoDat` | Заменять ли `Info.dat` прямо в клиенте. | `true` — перезаписать (нужен `EtcFilePath`), `false` — не трогать |
| `Encoding` | Кодировка текстовых данных (номер кодовой страницы Windows). | `1251` — Windows-1251 (кириллица), `65001` — UTF-8 |
| `ClientVersion` | Версия клиента, под которую генерируется `Info.dat`. | `null` — автоопределение по схеме БД (по умолчанию), `1602` / `1703` — задать явно |

Сгенерировать корректный `ConnectionString` можно на сайте: <a href="https://www.aireforge.com/tools/sql-server-connection-string-generator" target="_blank" rel="noopener noreferrer">SQL Server Connection String Generator</a>.

Список значений `Encoding` — в справочнике Microsoft: <a href="https://learn.microsoft.com/ru-ru/windows/win32/intl/code-page-identifiers" target="_blank" rel="noopener noreferrer">Code Page Identifiers</a>.
