using System.Globalization;
using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json;

namespace InfoDat
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            // resolve before the parser opens Info.dat so a bad db doesn't wipe it
            var version = ResolveVersion();

            new Parser().Run(version);

            if (GetConfig().ReplaceInfoDat)
            {
                ReplaceInfoDatInEtcRfs(GetConfig().EtcFilePath);
            }

            Console.Write(Environment.NewLine + "Press any key to continue...");
            Console.ReadKey();
        }

        private const string InfoDatPassword = "4a3408a275b0343719ae2ab7250a8cab0c03b2178a58f2de";

        private static void ReplaceInfoDatInEtcRfs(string etcRfsPath, string fileName = "Info.dat")
        {
            var etcRfs = new ZipFile(etcRfsPath);

            if (etcRfs.GetEntry(fileName) == null)
            {
                etcRfs.Close();
                throw new FileNotFoundException($"File '{fileName}' not found in '{etcRfsPath}'");
            }

            etcRfs.Password = InfoDatPassword;
            etcRfs.BeginUpdate();
            etcRfs.Delete(fileName);
            etcRfs.Add(fileName, fileName);
            etcRfs.CommitUpdate();
            etcRfs.Close();

            Log($"File '{fileName}' replaced in '{etcRfsPath}'");
        }

        private static int ResolveVersion()
        {
            var config = GetConfig();

            if (config.ClientVersion.HasValue)
            {
                VersionDetector.Validate(config.ConnectionString, config.ClientVersion.Value);
                Log($"Client version {config.ClientVersion.Value} (forced via config)");

                return config.ClientVersion.Value;
            }

            var version = VersionDetector.Detect(config.ConnectionString);
            Log($"Client version {version} (detected from database)");

            return version;
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