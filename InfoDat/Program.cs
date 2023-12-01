using System.Globalization;

namespace InfoDat
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            new Parser().Run();
        }
    }
}