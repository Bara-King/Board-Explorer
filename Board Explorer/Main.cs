﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using LiteDB;
using Newtonsoft.Json;
using Octokit;
using e621;

namespace Board_Explorer
{

    public partial class Main : Form
    {
        List<Post> posts;
        Post post = new Post();

        String nextBatch = "";

        int post_id;

        String saveDirectory = AppDomain.CurrentDomain.BaseDirectory;
        String thumbsDirectory = String.Empty;
        String originalsDirectory = String.Empty;

        LiteDatabase local_db = new LiteDatabase(@"local.db");

        public bool online = true;

        public int limit = Board_Explorer.Properties.Settings.Default.MaxResults;
        public int page = 1;

        public Main()
        {
            InitializeComponent();

            ntfMain.Icon = this.Icon;
            ntfMain.Text = this.Text;

            saveDirectory = Board_Explorer.Properties.Settings.Default.SaveDir;

            thumbsDirectory = Path.Combine(saveDirectory, "thumbs");
            originalsDirectory = Path.Combine(saveDirectory, "originals");

            Directory.CreateDirectory(thumbsDirectory);
            Directory.CreateDirectory(originalsDirectory);

            post.Username = Board_Explorer.Properties.Settings.Default.Username;
            post.Apikey = Board_Explorer.Properties.Settings.Default.Apikey;

            lnkSource.Visible = false;

            imgPosts.Images.Clear();
            lstView.Clear();

            btnNext.Hide();

            imgPosts.ImageSize = new Size(150, 150);
            imgPosts.ColorDepth = ColorDepth.Depth32Bit;

            lstView.LargeImageList = imgPosts;

            lstView.MouseClick += lstView_MouseClick;
            lstView.DoubleClick += lstView_DoubleClick;

            txtTags.KeyDown += new KeyEventHandler(txtTags_KeyDown);

            lstTags.DoubleClick += lstTags_DoubleClick;

            checkUpdatesAsync();

            //var colTags = local_db.GetCollection<Tag>("tag");
            //string[] output = (from o in colTags.FindAll().ToList() select o.name).ToArray();

            //AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            //auto.AddRange(output);
            //txtTags.AutoCompleteCustomSource = auto;
        }

        public async void checkUpdatesAsync()
        {
            var client = new GitHubClient(new ProductHeaderValue("Board-Explorer"));
            var releases = await client.Repository.Release.GetAll("goatmew", "Board-Explorer");

            if (releases.Count() > 0)
            {
                var latest = releases[0];
                String fileUrl = latest.Assets[0].BrowserDownloadUrl;

                int releaseVersion = int.Parse(latest.TagName.TrimStart('v').Replace(".", ""));
                int appVersion = int.Parse(this.ProductVersion.TrimEnd('0').Replace(".", ""));

                if (releaseVersion > appVersion)
                {
                    DialogResult response = MessageBox.Show("There is a new version avaiable for download. Would you like to update?", "New Version avaiable", MessageBoxButtons.YesNo);
                    if (response == DialogResult.Yes)
                    {
                        Utilities.Download(fileUrl, "Update.zip");
                        Utilities.onDownloadCompleted += OpenUpdate();
                    }
                }
            }
        }

        private EventHandler OpenUpdate()
        {
            System.Diagnostics.Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
            return null;
        }

        private void txtTags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        public void search()
        {
            page = 1;
            if (online) {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("limit", limit);
                posts = JsonConvert.DeserializeObject<List<Post>>(Post.Search(txtTags.Text, parameters));
            }
            else {
                var localPosts = local_db.GetCollection<Post>("post");
                posts = localPosts.Find(x => x.tags.Contains(txtTags.Text)).ToList();
            }

            if(posts.Count == 0)
            {
                MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK);
            }

            LoadPosts(posts);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("page", page);
            parameters.Add("limit", limit);
            posts = JsonConvert.DeserializeObject<List<Post>>(Post.Search(txtTags.Text, parameters));
            LoadPosts(posts);
        }

        private void LoadPosts(List<Post> posts)
        {
            ClearUI();
            strProgress.Minimum = 0;
            strProgress.Maximum = posts.Count();
            strProgress.Value = 0;

            if(posts.Count == limit)
            {
                btnNext.Show();
            }
            else
            {
                btnNext.Hide();
            }

            foreach (Post post in posts)
            {
                Thread thread = new Thread(() => AsyncAddItem(post));
                thread.Start();

                try
                {
                    var dbPosts = local_db.GetCollection<Post>("post");

                    // Insert new customer document (Id will be auto-incremented)
                    dbPosts.Insert(post);

                    
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void AsyncAddItem(Post post)
        {
            Image bmp;
            if (ThumbExists(post))
            {
                bmp = LoadImage(post);
            }
            else
            {
                bmp = DownloadThumb(post);
            }

            try
            {
                imgPosts.Images.Add(post.id.ToString(), Utilities.FitThumb(bmp, 150, 150));
            }
            catch (Exception ex)
            {

            }

            if (lstView.InvokeRequired)
            {
                lstView.Invoke(new MethodInvoker(delegate
                {
                    lstView.Items.Add(post.id.ToString(), imgPosts.Images.IndexOfKey(post.id.ToString()));
                }));
            }
            else
            {
                lstView.Items.Add(post.id.ToString(), imgPosts.Images.IndexOfKey(post.id.ToString()));
            }

            BeginInvoke((Action)(() => strProgress.PerformStep()));
        }

        private Image DownloadThumb(Post post, String SaveDir = "thumbs")
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(post.preview_url);

            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();

            Bitmap bmp = new Bitmap(responseStream);

            ImageCodecInfo encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Png.Guid);

            switch (post.file_ext)
            {
                case "png":
                    encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Png.Guid);
                    break;
                case "jpg":
                    encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                    break;
                case "gif":
                    encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Gif.Guid);
                    break;
            }

            var encParams = new EncoderParameters() { Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L) } };

            bmp.Save(Path.Combine(saveDirectory, SaveDir + "/" + post.md5 + "." + post.file_ext), encoder, encParams);

            responseStream.Dispose();

            return bmp;
        }

        private Image LoadImage(Post post)
        {
            Bitmap bmp = new Bitmap(Path.Combine(thumbsDirectory, post.md5 + "." + post.file_ext));
            return bmp;
        }

        private Boolean ThumbExists(Post post)
        {
            return File.Exists(Path.Combine(thumbsDirectory, post.md5 + "." + post.file_ext));
        }

        private Boolean OriginalExists(Post post)
        {
            return File.Exists(Path.Combine(originalsDirectory, post.md5 + "." + post.file_ext));
        }

        public void ClearUI()
        {
            lstView.Items.Clear();
            imgPosts.Images.Clear();

            lblID.Text = "ID:";
            lblMd5.Text = "MD5: ";
            lblRating.Text = "Rating:";
            lblScore.Text = "Score:";
            lblFavorites.Text = "Favorites:";
            lblArtist.Text = "Artist:";
            lnkSource.Links.Clear();
            lnkSource.Visible = false;
            lblFilesize.Text = "Filesize:";
            lblDimensions.Text = "Dimensions:";
            lstTags.Items.Clear();
        }

        public void lstView_MouseClick(object sender, MouseEventArgs e)
        { 
            ListViewItem item = lstView.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                post_id = Int32.Parse(item.Text);
            }

            var posts = local_db.GetCollection<Post>("post");
            Post post = posts.FindOne(postitem => postitem.id == post_id);

            Dictionary<string, string> rating = new Dictionary<string, string> {
                {"s","Safe"}, {"q","Questionable"}, {"e","Explicit"} 
            };

            lblID.Text = "ID: #" + post.id.ToString();
            lblMd5.Text = "MD5: " + post.md5;
            lblRating.Text = "Rating: " + rating[post.rating];
            lblScore.Text = "Score: " + post.score.ToString();
            lblFavorites.Text = "Favorites: " + post.fav_count;
            if (post.artist.Count > 0) {
                lblArtist.Text = "Artist: " + post.artist[0];
            }
            else
            {
                lblArtist.Text = "Artist:";
            }
             
            lnkSource.Links.Clear();

            lnkSource.Links.Add(0, 4, post.source);
            lnkSource.Visible = true;

            lblFilesize.Text = "Filesize: " + Utilities.FileSize(post.file_size);
            lblDimensions.Text = "Dimensions: " + post.width + " x " + post.height;

            lstTags.Items.Clear();
            foreach(string tag in post.tags.Split(null))
            {
                lstTags.Items.Add(tag);
            }

            if (e.Button == MouseButtons.Right)
            {                
                if (item != null)
                {
                    
                    item.Selected = true;

                    var favorites = local_db.GetCollection<Favorite>("favorite");
                    var favorite = favorites.FindOne(x => x.id == post_id);

                    if (favorite != null)
                    {
                        ctxItemFavorite.Image = Properties.Resources.heart_delete;
                        ctxItemFavorite.Text = "Remove Favorite";
                    }
                    else
                    {
                        ctxItemFavorite.Image = Properties.Resources.heart_add;
                        ctxItemFavorite.Text = "Add Favorite";
                    }

                    var count = favorites.Count(Query.EQ("id", post_id));

                    ctxPost.Show(lstView, e.Location);
                }
            }
        }

        private void lstView_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lstView.SelectedIndices;
            if (indices.Count > 0)
            {
                int index = lstView.SelectedIndices[0];

                var posts = local_db.GetCollection<Post>("post");
                Post post = posts.FindOne(item => item.id == post_id);

                string selectedFile = post.md5 + "." + post.file_ext;
                // the file exists open the file.
                if (File.Exists(Path.Combine(originalsDirectory, selectedFile)))
                {
                    //
                    try
                    {

                        System.Diagnostics.Process.Start(Path.Combine(originalsDirectory, selectedFile));


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }
                }
                else
                {
                    try
                    {
                        staStatusLabel.Text = "Downloading post #" + post_id + ".";
                        post.Download(originalsDirectory);
                        post.onDownloadCompleted += FileDownloadedOpen;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }
                }
            }
        }

        private void lstTags_DoubleClick(object sender, EventArgs e)
        {
            int index = lstTags.SelectedIndex;
            String tag = lstTags.Items[index].ToString();
            txtTags.Text = tag;
            search();
        }

        private void FileDownloadedOpen(object sender, EventArgs e)
        {
            Post post = (Post)sender;
            string selectedFile = post.md5 + "." + post.file_ext;
            System.Diagnostics.Process.Start(Path.Combine(originalsDirectory, selectedFile));
        }

        private void ctxItemFavorite_Click(object sender, EventArgs e)
        {
            var favorites = local_db.GetCollection<Favorite>("favorite");
            var favorite = favorites.FindOne(x => x.id == post_id);

            if (favorite != null)
            {
                Boolean online = post.UnFavorite(post_id);

                if (online)
                {
                    staStatusLabel.Text = "Post #" + post_id + " removed online and locally from favorites.";
                }
                else
                {
                    staStatusLabel.Text = "Post #" + post_id + " removed from local favorites. Online connection failed.";
                }
                
                try
                {
                    favorites.Delete(post_id);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Boolean online = post.Favorite(post_id);

                if (online)
                {
                    staStatusLabel.Text = "Post #" + post_id + " added online and locally to favorites.";
                }
                else
                {
                    staStatusLabel.Text = "Post #" + post_id + " added locally to favorites. Online connection failed.";
                }

                try
                {
                    // Create your new customer instance
                    favorite = new Favorite
                    {
                        id = post_id
                    };

                    // Insert new customer document (Id will be auto-incremented)
                    favorites.Insert(favorite);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void ctxItemDownload_Click(object sender, EventArgs e)
        {
            var posts = local_db.GetCollection<Post>("post");
            Post post = posts.FindOne(item => item.id == post_id);
            post.Download(originalsDirectory);
        }

        private void onlineModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton1.Image = Properties.Resources.bullet_green;
            toolStripSplitButton1.Name = "Online";
            online = true;
        }

        private void offlineModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton1.Image = Properties.Resources.bullet_red;
            toolStripSplitButton1.Name = "Offline";
            online = false;
        }

        private void mnuOpenDownloads_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(originalsDirectory);
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            Form frmSettings = new Settings();
            frmSettings.Show();
        }

        private void mnuDownloadAll_Click(object sender, EventArgs e)
        {
            if (posts.Count > 0)
            {
                strProgress.Minimum = 0;
                strProgress.Maximum = posts.Count;
                strProgress.Value = 0;

                foreach (Post post in posts)
                {
                    if (!OriginalExists(post)){
                        post.Download();

                        post.onDownloadCompleted += FileDownloaded;
                    }
                    else
                    {
                        strProgress.Value += 1;
                    }
                }
            }
        }

        private void FileDownloaded(object sender, EventArgs e)
        {
            if (strProgress.Maximum > strProgress.Value)
            {
                strProgress.Value += 1;
            }
        }

        private void mnuFavorites_Click(object sender, EventArgs e)
        {
            var colFavorites = local_db.GetCollection<Favorite>("favorite");
            var favorites = colFavorites.FindAll();

            BsonArray ids = new BsonArray();
            //List<int> ids = new List<int>();

            foreach (Favorite favorite in favorites)
            {
                ids.Add(favorite.id);
            }

            var colPosts = local_db.GetCollection<Post>("post");
            posts = colPosts.Find(Query.In("_id", ids.ToArray())).ToList();

            LoadPosts(posts);
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            Form frmAbout = new About();
            frmAbout.Show();
        }

        private void mnuReportError_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/goatmew/Board-Explorer/issues");
        }

        private void ctxItemOne621_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://e621.net/post/show/"+ post_id); 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuRelease_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/goatmew/Board-Explorer/releases");
        }

        private void ctxItemVoteUp_Click(object sender, EventArgs e)
        {
            Boolean online = post.Vote(post_id, 1);

            if (online)
            {
                staStatusLabel.Text = "Post #" + post_id + " added voted up.";
            }
            else
            {
                staStatusLabel.Text = "Online connection failed.";
            }
        }

        private void ctxItemVoteDown_Click(object sender, EventArgs e)
        {
            Boolean online = post.Vote(post_id, -1);

            if (online)
            {
                staStatusLabel.Text = "Post #" + post_id + " added voted down.";
            }
            else
            {
                staStatusLabel.Text = "Online connection failed.";
            }
        }

        private void lnkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel = (LinkLabel)sender;
            System.Diagnostics.Process.Start(linkLabel.Links[0].LinkData.ToString());
        }

        private void mnuFindByMd5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            
            if (DialogResult.OK == fileDialog.ShowDialog())
            {
                String file = fileDialog.FileName;

                String md5 = Utilities.CalculateMD5(file);

                txtTags.Text = "MD5:" + md5;
                search();
            }
        }

        private void mnuTelegram_Click(object sender, EventArgs e)
        {
            var posts = local_db.GetCollection<Post>("post");
            Post post = posts.FindOne(item => item.id == post_id);
            String url = Uri.EscapeUriString(post.file_url);
            System.Diagnostics.Process.Start("https://telegram.me/share/url?url=" + url + "&text=Shared with Board Explorer");
        }

        private void mnuSyncTags_Click(object sender, EventArgs e)
        {
            

            Thread thread = new Thread(() => AsyncAddTags(1));
            thread.Start();
        }

        private void AsyncAddTags(int page)
        {
            var dbTags = local_db.GetCollection<Tag>("tag");
            dbTags.EnsureIndex("name", true);

            int limit = 500;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("limit", limit);
            parameters.Add("page", page);
            List<Tag> tags = JsonConvert.DeserializeObject<List<Tag>>(e621.Tag.Search(parameters));

            foreach (Tag tag in tags)
            {
                try
                {
                    dbTags.Insert(tag);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ex. Saving Tag: " + tag.name + " - " + ex.ToString());
                }
            }

            if (tags.Count == limit)
            {
                page++;
                Thread.Sleep(500);
                Thread thread = new Thread(() => AsyncAddTags(page));
                thread.Start();
            }
        }

        private void mnuSyncFavorites_Click(object sender, EventArgs e)
        {
            syncFavorites(1);
        }

        private void syncFavorites(int page)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("page", page);
            parameters.Add("limit", limit);
            posts = JsonConvert.DeserializeObject<List<Post>>(Post.Search("fav:" + Properties.Settings.Default.Username, parameters));

            var dbPosts = local_db.GetCollection<Post>("post");
            var dbFavorites = local_db.GetCollection<Favorite>("favorite");

            foreach (Post post in posts)
            {
                try
                {
                    dbPosts.Insert(post);
                }
                catch (Exception ex)
                {

                }

                try
                {
                    Favorite favorite = new Favorite
                    {
                        id = post.id
                    };

                    dbFavorites.Insert(favorite);
                }
                catch (Exception ex)
                {

                }
            }

            if(posts.Count == limit)
            {
                page++;
                syncFavorites(page);
            }
        }
    }
}
