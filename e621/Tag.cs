using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace e621
{
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int type { get; set; }
        public bool? type_locked { get; set; }

        public static String Search(String url)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                return wc.DownloadString(Uri.EscapeUriString(url));
            }
        }

        public static String Search(Dictionary<string, object> parameters)
        {
            String url = "https://e621.net/tag/index.json?" + string.Join("&", parameters.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));

            return Tag.Search(url);
        }

    }

    public class Alias
    {
        public int id { get; set; }
        public string name { get; set; }
        public int alias_id { get; set; }
        public bool pending { get; set; }
    }
}
