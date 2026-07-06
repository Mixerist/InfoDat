using System.Reflection;

namespace InfoDat;

[AttributeUsage(AttributeTargets.Property)]
public class VersionedAttribute : Attribute
{
    public int MinVersion { get; set; }
    public int MaxVersion { get; set; } = int.MaxValue;
}

public static class Versioning
{
    public const int V1602 = 1602;
    public const int V1703 = 1703;

    public static bool IsActive(PropertyInfo member, int version)
    {
        var versioned = member.GetCustomAttribute<VersionedAttribute>();

        return versioned == null || (version >= versioned.MinVersion && version <= versioned.MaxVersion);
    }
}
