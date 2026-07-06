namespace InfoDat;

public enum MarkerKind
{
    Table,
    Column
}

public class Marker
{
    public MarkerKind Kind { get; }
    public string Table { get; }
    public string? Column { get; }

    public Marker(string table)
    {
        Kind = MarkerKind.Table;
        Table = table;
    }

    public Marker(string table, string column)
    {
        Kind = MarkerKind.Column;
        Table = table;
        Column = column;
    }

    public override string ToString()
    {
        return Kind == MarkerKind.Table ? Table : $"{Table}.{Column}";
    }
}

public class VersionSignature
{
    public int Version { get; init; }
    public Marker[] Markers { get; init; } = Array.Empty<Marker>();
}

public static class VersionRegistry
{
    // newest first, the first fully matched signature wins
    public static readonly VersionSignature[] All =
    {
        new()
        {
            Version = Versioning.V1703,
            Markers = new[]
            {
                new Marker("TblCardCollectionTitle"),
                new Marker("DT_Item", "IIsUnusableDemoSvr"),
                new Marker("TblServantType", "SGrade"),
                new Marker("DT_SkillEnhancementMaterial", "mType")
            }
        },
        new()
        {
            // base tables to tell an R2 param db from anything else
            Version = Versioning.V1602,
            Markers = new[]
            {
                new Marker("DT_Item"),
                new Marker("DT_Skill")
            }
        }
    };
}
