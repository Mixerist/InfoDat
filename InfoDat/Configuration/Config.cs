namespace InfoDat;

public class Config
{
    public string ConnectionString { get; set; }
    public string EtcFilePath { get; set; }
    public bool ReplaceInfoDat { get; set; }
    public bool EncryptInfoDat { get; set; }
    public int Encoding { get; set; }
    public int? ClientVersion { get; set; } // null = detect from db
}