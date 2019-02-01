using System;
using System.IO;
using System.Windows.Forms;
using e621;

namespace Board_Explorer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Board_Explorer.Properties.Settings.Default.Username;
            txtSaveDir.Text = Board_Explorer.Properties.Settings.Default.SaveDir;

            string Apikey = Board_Explorer.Properties.Settings.Default.Apikey;
            if (Apikey != String.Empty)
            {
                btnLogin.Text = "Logout";
            }

            long appSize = Utilities.GetDirectorySize(Path.Combine(txtSaveDir.Text, "originals")) + Utilities.GetDirectorySize(Path.Combine(txtSaveDir.Text, "thumbs"));

            lblSpace.Text = "Used space: " + Utilities.FileSize(appSize);


            numResults.Value = Board_Explorer.Properties.Settings.Default.MaxResults;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Apikey = Board_Explorer.Properties.Settings.Default.Apikey;
            if (Apikey == String.Empty)
            {
                User user = new User();
                Boolean success = user.login(txtUsername.Text, txtPassword.Text);
                if (success)
                {
                    Board_Explorer.Properties.Settings.Default.Username = txtUsername.Text;
                    Board_Explorer.Properties.Settings.Default.Apikey = user.password_hash;
                    Board_Explorer.Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("There was an error loggin in your account.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                Board_Explorer.Properties.Settings.Default.Username = "";
                Board_Explorer.Properties.Settings.Default.Apikey = "";
                Board_Explorer.Properties.Settings.Default.Save();
                btnLogin.Text = "Login";
            }
        }

        private void btnBrowseSaveDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                String path = folderBrowserDialog.SelectedPath;
                txtSaveDir.Text = path;

                Board_Explorer.Properties.Settings.Default.SaveDir = path;
                Board_Explorer.Properties.Settings.Default.Save();
            }
        }

        private void numResults_ValueChanged(object sender, EventArgs e)
        {
            Board_Explorer.Properties.Settings.Default.MaxResults = (int)numResults.Value;
            Board_Explorer.Properties.Settings.Default.Save();
        }
    }
}
