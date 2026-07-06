using System.Data.SqlClient;
using static InfoDat.Program;

namespace InfoDat;

public static class VersionDetector
{
    public static int Detect(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        foreach (var signature in VersionRegistry.All)
        {
            var hits = signature.Markers.Count(m => Exists(connection, m));

            if (hits == signature.Markers.Length)
            {
                return signature.Version;
            }

            if (hits > 0)
            {
                // some markers present but not all, most likely a half-migrated db
                Log($"Warning: db partially matches {signature.Version} ({hits}/{signature.Markers.Length} markers), skipping it");
            }
        }

        throw new InvalidOperationException("Unknown db schema, could not detect the client version");
    }

    public static void Validate(string connectionString, int version)
    {
        var signature = VersionRegistry.All.FirstOrDefault(s => s.Version == version)
            ?? throw new InvalidOperationException($"Unknown client version {version}");

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var missing = signature.Markers.Where(m => !Exists(connection, m)).ToArray();

        if (missing.Length > 0)
        {
            throw new InvalidOperationException(
                $"Db does not match version {version}, missing: {string.Join(", ", missing.Select(m => m.ToString()))}");
        }
    }

    private static bool Exists(SqlConnection connection, Marker marker)
    {
        var sql = marker.Kind == MarkerKind.Table
            ? "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @table"
            : "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @table AND COLUMN_NAME = @column";

        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@table", marker.Table);

        if (marker.Kind == MarkerKind.Column)
        {
            command.Parameters.AddWithValue("@column", marker.Column!);
        }

        return (int)command.ExecuteScalar() > 0;
    }
}
