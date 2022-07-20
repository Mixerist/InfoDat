using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace InfoDat;

public class Parser
{
    private const string FileName = "Info.dat";

    private const string Url = "http://r2parser.test:8080";

    private readonly BinaryWriter _writer = new(File.Create(FileName));

    public void Run()
    {
        var structs = GetStructs();

        using (_writer)
        {
            foreach (var subsetOfStructs in structs.GetType().GetProperties())
            {
                ParseEachStruct((object[])subsetOfStructs.GetValue(structs));
            }
        }
    }

    private Struct GetStructs()
    {
        var json = new HttpClient().GetStringAsync(Url).Result;

        return JsonConvert.DeserializeObject<Struct>(json);
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

        var length = BitConverter.GetBytes(Encoding.UTF8.GetBytes(field).Length);
        var array = length.Concat(Encoding.UTF8.GetBytes(field)).ToArray();

        return array;
    }
}