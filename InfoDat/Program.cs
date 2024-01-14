using System.Globalization;
using System.IO.Compression;
using Newtonsoft.Json;

namespace InfoDat
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            new Parser().Run();

            if (GetConfig().ReplaceInfoDat)
            {
                ReplaceFileInZip(GetConfig().EtcFilePath, GetConfig().FileName);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void ReplaceFileInZip(string zipFilePath, string fileName)
        {
            using var archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Update);
            var existingEntry = archive.GetEntry(fileName);

            if (existingEntry != null)
            {
                existingEntry.Delete();

                archive.CreateEntryFromFile(fileName, fileName);
                Console.WriteLine($"File '{fileName}' replaced in '{zipFilePath}'");
            }
            else
            {
                throw new FileNotFoundException($"File '{fileName}' not found in '{zipFilePath}'");
            }
        }

        public static Config? GetConfig()
        {
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
        }
    }
}