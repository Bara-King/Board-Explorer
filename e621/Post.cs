using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace e621
{
    public class CreatedAt
    {
        public string json_class { get; set; }
        public int s { get; set; }
        public int n { get; set; }
    }

    public class Post
    {
        public event EventHandler onDownloadCompleted;

        public int id { get; set; }

        public string tags { get; set; }

        public object locked_tags { get; set; }
        public string description { get; set; }
        public CreatedAt created_at { get; set; }
        public int creator_id { get; set; }
        public string author { get; set; }
        public int change { get; set; }
        public string source { get; set; }
        public int score { get; set; }
        public int fav_count { get; set; }
        public string md5 { get; set; }
        public int file_size { get; set; }
        public string file_url { get; set; }
        public string file_ext { get; set; }
        public string preview_url { get; set; }
        public int preview_width { get; set; }
        public int preview_height { get; set; }
        public string sample_url { get; set; }
        public int sample_width { get; set; }
        public int sample_height { get; set; }
        public string rating { get; set; }
        public string status { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool has_comments { get; set; }
        public bool has_notes { get; set; }
        public bool has_children { get; set; }
        public string children { get; set; }
        public int? parent_id { get; set; }
        public List<string> artist { get; set; }
        public List<string> sources { get; set; }

        public string Username { get; set; }
        public string Apikey { get; set; }

        public enum FileType {
            Thumb,
            File
        };

        public static String Search(String url)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                return wc.DownloadString(Uri.EscapeUriString(url));
            }
        }

        public static String Search(String tags, Dictionary<string,object> parameters)
        {
            parameters.Add("tags", tags);

            String url = "https://e621.net/post/index.json?" + string.Join("&", parameters.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));

            return Post.Search(url);
        }

        public void Download(String SaveDir = "originals", FileType fileType = FileType.File)
        {
            String url = this.file_url;
            if(fileType == FileType.Thumb)
            {
                url = this.preview_url;
            }

            using (WebClient wc = new WebClient())
            {
                //wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += OnDownloadCompleted;
                wc.DownloadFileAsync(new System.Uri(url), Path.Combine(SaveDir, this.md5 + "." + this.file_ext));
            }
        }

        private void OnDownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            onDownloadCompleted?.Invoke(this, e);
        }

        public Boolean Favorite(Post post)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://e621.net/favorite/create.json");

            var postData = "id=" + post.id;
            postData += "&login=" + Username;
            postData += "&password_hash=" + Apikey;
            var data = Encoding.ASCII.GetBytes(postData);

            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Response json = JsonConvert.DeserializeObject<Response>(responseString);

                return json.success;
            }
            catch (Exception e)
            {
                return false;
            }
                        
        }
        
    }

    internal class Response
    {
        public Boolean success;
    }
}
