# InfoDat

[🇷🇺 Русский](README.md) · [🇰🇷 한국어](README.ko.md) · 🇨🇳 **中文**

直接从数据库为 **R2 Online** 游戏客户端自动生成 **Info.dat** 文件的程序。

## 🎮 支持的客户端版本

支持多个 **R2 Online** 客户端版本。版本会根据数据库结构自动识别，也可以通过 `ClientVersion` 参数手动指定。

- **1602**
- **1703**

## ⚙️ 使用方法

1. 下载[最新发行版](https://github.com/Mixerist/InfoDat/releases/latest)，或自行构建可执行文件。
2. 运行：`InfoDat.exe`
3. 运行完成后将生成 **Info.dat** 文件。
    - 如果启用了 `ReplaceInfoDat` 选项，将自动替换客户端中的 **Info.dat** 文件。

## ⚙️ 配置

应用程序使用 **JSON** 格式的配置文件。  
`Config.json` 文件示例：

```json
{
    "ConnectionString": "Data Source=(local);Database=FNLParm;Integrated Security=sspi;",
    "EtcFilePath": "D:\\R2\\R2 PTS\\etc\\etc.rfs",
    "ReplaceInfoDat": false,
    "Encoding": 1251,
    "ClientVersion": null
}
```

### 参数

| 参数 | 说明 | 值 / 示例 |
|---|---|---|
| `ConnectionString` | 数据库（SQL Server）连接字符串。主要组成部分：`Data Source` — 服务器地址（`(local)`、`127.0.0.1`），`Database` — 数据库名称，`Integrated Security` — 认证方式（Windows 身份验证使用 `sspi`）。 | `Data Source=(local);Database=FNLParm;Integrated Security=sspi;` |
| `EtcFilePath` | 客户端 `etc.rfs` 文件的路径。仅在 `ReplaceInfoDat = true` 时用于替换客户端中的 `Info.dat`。在 JSON 中，斜杠需用双斜杠（`\\`）转义。 | `D:\\R2\\R2 PTS\\etc\\etc.rfs` |
| `ReplaceInfoDat` | 是否直接替换客户端中的 `Info.dat`。 | `true` — 覆盖（需要 `EtcFilePath`），`false` — 不修改 |
| `Encoding` | 文本数据的编码（Windows 代码页编号）。 | `1251` — Windows-1251（西里尔文），`65001` — UTF-8 |
| `ClientVersion` | 生成 `Info.dat` 所针对的客户端版本。 | `null` — 根据数据库结构自动识别（默认），`1602` / `1703` — 手动指定 |

可在以下网站生成正确的 `ConnectionString`：<a href="https://www.aireforge.com/tools/sql-server-connection-string-generator" target="_blank" rel="noopener noreferrer">SQL Server Connection String Generator</a>。

`Encoding` 的取值列表请参阅 Microsoft 文档：<a href="https://learn.microsoft.com/zh-cn/windows/win32/intl/code-page-identifiers" target="_blank" rel="noopener noreferrer">Code Page Identifiers</a>。
