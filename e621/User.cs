using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace e621
{
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
        public string password_hash { get; set; }

        public Boolean login(string username, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://e621.net/user/login.json?name=" + username + "&password=" + password);

            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                User json = JsonConvert.DeserializeObject<User>(responseString);

                if (json.password_hash != null)
                {
                    this.password_hash = json.password_hash;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
