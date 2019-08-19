using System.Collections.Generic;
using System.Net;

namespace remotexe
{
    class Web
    {
        public static void Download(string url, string save)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, save);
            }
        }

        public static string GetPb(string id)
        {
            var contents = (new WebClient()).DownloadString("https://pastebin.com/raw/"+id);
            return contents;
        }

        public static List<string> GetList(string id)
        {
            var DownloadList = new List<string>();
            foreach (string item in Web.GetPb(id).Split('\n')) {
                DownloadList.Add(item.Replace("\r",""));
            }
            return DownloadList;
        }
    }
}
