# InfoDat

[🇷🇺 Русский](README.md) · 🇰🇷 **한국어** · [🇨🇳 中文](README.zh.md)

데이터베이스에서 직접 **R2 Online** 게임 클라이언트용 **Info.dat** 파일을 자동으로 생성하는 프로그램입니다.

## 🎮 지원 클라이언트 버전

여러 **R2 Online** 클라이언트 버전을 지원합니다. 버전은 데이터베이스 스키마에 따라 자동으로 판별되거나 `ClientVersion` 매개변수로 직접 지정할 수 있습니다.

- **1602**
- **1703**

## ⚙️ 사용법

1. [최신 릴리스](https://github.com/Mixerist/InfoDat/releases/latest)를 다운로드하거나 실행 파일을 직접 빌드하세요.
2. 실행: `InfoDat.exe`
3. 실행이 완료되면 **Info.dat** 파일이 생성됩니다.
    - `ReplaceInfoDat` 옵션이 켜져 있으면 클라이언트의 **Info.dat** 파일이 자동으로 교체됩니다.

## ⚙️ 설정

애플리케이션은 **JSON** 형식의 설정 파일을 사용합니다.  
`Config.json` 파일 예시:

```json
{
    "ConnectionString": "Data Source=(local);Database=FNLParm;Integrated Security=sspi;",
    "EtcFilePath": "D:\\R2\\R2 PTS\\etc\\etc.rfs",
    "ReplaceInfoDat": false,
    "Encoding": 1251,
    "ClientVersion": null
}
```

### 매개변수

| 매개변수 | 설명 | 값 / 예시 |
|---|---|---|
| `ConnectionString` | 데이터베이스(SQL Server) 연결 문자열. 주요 구성 요소: `Data Source` — 서버 주소(`(local)`, `127.0.0.1`), `Database` — DB 이름, `Integrated Security` — 인증 방식(Windows 인증의 경우 `sspi`). | `Data Source=(local);Database=FNLParm;Integrated Security=sspi;` |
| `EtcFilePath` | 클라이언트의 `etc.rfs` 파일 경로. `ReplaceInfoDat = true`일 때 클라이언트의 `Info.dat`를 교체하는 데만 사용됩니다. JSON에서는 슬래시를 이중 슬래시(`\\`)로 이스케이프합니다. | `D:\\R2\\R2 PTS\\etc\\etc.rfs` |
| `ReplaceInfoDat` | 클라이언트의 `Info.dat`를 직접 교체할지 여부. | `true` — 덮어쓰기(`EtcFilePath` 필요), `false` — 변경하지 않음 |
| `Encoding` | 텍스트 데이터 인코딩(Windows 코드 페이지 번호). | `1251` — Windows-1251(키릴 문자), `65001` — UTF-8 |
| `ClientVersion` | `Info.dat`를 생성할 대상 클라이언트 버전. | `null` — DB 스키마 기반 자동 판별(기본값), `1602` / `1703` — 직접 지정 |

올바른 `ConnectionString`은 다음 사이트에서 생성할 수 있습니다: <a href="https://www.aireforge.com/tools/sql-server-connection-string-generator" target="_blank" rel="noopener noreferrer">SQL Server Connection String Generator</a>.

`Encoding` 값 목록은 Microsoft 문서를 참고하세요: <a href="https://learn.microsoft.com/ko-kr/windows/win32/intl/code-page-identifiers" target="_blank" rel="noopener noreferrer">Code Page Identifiers</a>.
