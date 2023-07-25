using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace InfoDat;

public class Parser
{
    private const string FileName = "Info.dat";

    private const string ConnectionString = "Data Source=127.0.0.1,1433;Initial Catalog=FNLParm;User ID=sa;Password=password;";

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

        Console.WriteLine("Completed!");
    }

    private Struct GetStructs()
    {
        var json = new Database().LoadData(ConnectionString);

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

        var bytes = Encoding.UTF8.GetBytes(field);
        var length = BitConverter.GetBytes(bytes.Length);

        return length.Concat(bytes).ToArray();
    }
}