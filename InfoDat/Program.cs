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
                ReplaceInfoDatInEtcRfs(GetConfig().EtcFilePath);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ReplaceInfoDatInEtcRfs(string etcRfsPath, string fileName = "Info.dat")
        {
            using var etcRfs = ZipFile.Open(etcRfsPath, ZipArchiveMode.Update);
            var infoDat = etcRfs.GetEntry(fileName);

            if (infoDat != null)
            {
                infoDat.Delete();
                etcRfs.CreateEntryFromFile(fileName, fileName);

                Log($"File '{fileName}' replaced in '{etcRfsPath}'");
            }
            else
            {
                throw new FileNotFoundException($"File '{fileName}' not found in '{etcRfsPath}'");
            }
        }

        public static Config GetConfig()
        {
            var config = File.ReadAllText("Config.json");

            return JsonConvert.DeserializeObject<Config>(config) ?? throw new InvalidOperationException();
        }

        public static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] " + message);
        }
    }
}