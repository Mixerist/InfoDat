using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using static InfoDat.Program;

namespace InfoDat;

public class Parser
{
    private const string FileName = "Info.dat";

    private readonly BinaryWriter _writer = new(File.Create(FileName));

    private int _version;

    public void Run(int version)
    {
        Log("Parsing has started, please wait...");

        _version = version;

        var structs = GetStructs(version);

        using (_writer)
        {
            foreach (var subsetOfStructs in structs.GetType().GetProperties())
            {
                if (!Versioning.IsActive(subsetOfStructs, version))
                {
                    continue;
                }

                var value = (object[])subsetOfStructs.GetValue(structs);

                if (value == null)
                {
                    continue;
                }

                ParseEachStruct(value);
            }
        }

        Log($"'{FileName}' was created successfully");
    }

    private Struct GetStructs(int version)
    {
        var json = new Database().LoadData(GetConfig().ConnectionString, version);

        return JsonConvert.DeserializeObject<Struct>(json) ?? throw new InvalidOperationException();
    }

    private dynamic GetValue(PropertyInfo field, object structure)
    {
        return field.PropertyType == typeof(string)
            ? ParseString((string)field.GetValue(structure))
            : field.GetValue(structure);
    }

    private void ParseEachStruct(IReadOnlyCollection<object> subsetOfStructs)
    {
        _writer.Write(subsetOfStructs.Count);

        foreach (var structure in subsetOfStructs)
        {
            foreach (var field in structure.GetType().GetProperties())
            {
                if (!Versioning.IsActive(field, _version))
                {
                    continue;
                }

                _writer.Write(GetValue(field, structure));
            }
        }
    }

    private byte[] ParseString(string field)
    {
        if (string.IsNullOrEmpty(field))
        {
            return BitConverter.GetBytes(0);
        }

        var bytes = Encoding.GetEncoding(GetConfig().Encoding).GetBytes(field);
        var length = BitConverter.GetBytes(bytes.Length);

        return length.Concat(bytes).ToArray();
    }
}