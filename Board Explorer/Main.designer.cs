namespace Board_Explorer
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.imgPosts = new System.Windows.Forms.ImageList(this.components);
            this.lstView = new System.Windows.Forms.ListView();
            this.ctxPost = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxItemOne621 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxItemFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxItemVoteUp = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxItemVoteDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxItemDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShare = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTelegram = new System.Windows.Forms.ToolStripMenuItem();
            this.staStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.offlineModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.strProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPosts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindByMd5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDownloadAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSyncTags = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenDownloads = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportError = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.lblFilesize = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblMd5 = new System.Windows.Forms.Label();
            this.lnkSource = new System.Windows.Forms.LinkLabel();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblFavorites = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.ntfMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuSyncFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPost.SuspendLayout();
            this.staStrip.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(291, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTags
            // 
            this.txtTags.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTags.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTags.Location = new System.Drawing.Point(12, 29);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(273, 20);
            this.txtTags.TabIndex = 1;
            // 
            // imgPosts
            // 
            this.imgPosts.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgPosts.ImageSize = new System.Drawing.Size(16, 16);
            this.imgPosts.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.Location = new System.Drawing.Point(12, 56);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(666, 400);
            this.lstView.TabIndex = 2;
            this.lstView.UseCompatibleStateImageBehavior = false;
            // 
            // ctxPost
            // 
            this.ctxPost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxItemOne621,
            this.toolStripSeparator3,
            this.ctxItemFavorite,
            this.toolStripSeparator4,
            this.ctxItemVoteUp,
            this.ctxItemVoteDown,
            this.toolStripSeparator5,
            this.ctxItemDownload,
            this.mnuShare});
            this.ctxPost.Name = "ctxPost";
            this.ctxPost.Size = new System.Drawing.Size(148, 154);
            // 
            // ctxItemOne621
            // 
            this.ctxItemOne621.Name = "ctxItemOne621";
            this.ctxItemOne621.Size = new System.Drawing.Size(147, 22);
            this.ctxItemOne621.Text = "Open on e621";
            this.ctxItemOne621.Click += new System.EventHandler(this.ctxItemOne621_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(144, 6);
            // 
            // ctxItemFavorite
            // 
            this.ctxItemFavorite.Image = global::Board_Explorer.Properties.Resources.heart_add;
            this.ctxItemFavorite.Name = "ctxItemFavorite";
            this.ctxItemFavorite.Size = new System.Drawing.Size(147, 22);
            this.ctxItemFavorite.Text = "Favorite";
            this.ctxItemFavorite.Click += new System.EventHandler(this.ctxItemFavorite_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(144, 6);
            // 
            // ctxItemVoteUp
            // 
            this.ctxItemVoteUp.Image = global::Board_Explorer.Properties.Resources.arrow_up;
            this.ctxItemVoteUp.Name = "ctxItemVoteUp";
            this.ctxItemVoteUp.Size = new System.Drawing.Size(147, 22);
            this.ctxItemVoteUp.Text = "Vote Up";
            this.ctxItemVoteUp.Click += new System.EventHandler(this.ctxItemVoteUp_Click);
            // 
            // ctxItemVoteDown
            // 
            this.ctxItemVoteDown.Image = global::Board_Explorer.Properties.Resources.arrow_down;
            this.ctxItemVoteDown.Name = "ctxItemVoteDown";
            this.ctxItemVoteDown.Size = new System.Drawing.Size(147, 22);
            this.ctxItemVoteDown.Text = "Vote Down";
            this.ctxItemVoteDown.Click += new System.EventHandler(this.ctxItemVoteDown_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(144, 6);
            // 
            // ctxItemDownload
            // 
            this.ctxItemDownload.Image = global::Board_Explorer.Properties.Resources.download_cloud;
            this.ctxItemDownload.Name = "ctxItemDownload";
            this.ctxItemDownload.Size = new System.Drawing.Size(147, 22);
            this.ctxItemDownload.Text = "Download";
            this.ctxItemDownload.Click += new System.EventHandler(this.ctxItemDownload_Click);
            // 
            // mnuShare
            // 
            this.mnuShare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTelegram});
            this.mnuShare.Name = "mnuShare";
            this.mnuShare.Size = new System.Drawing.Size(147, 22);
            this.mnuShare.Text = "Share";
            // 
            // mnuTelegram
            // 
            this.mnuTelegram.Name = "mnuTelegram";
            this.mnuTelegram.Size = new System.Drawing.Size(123, 22);
            this.mnuTelegram.Text = "Telegram";
            this.mnuTelegram.Click += new System.EventHandler(this.mnuTelegram_Click);
            // 
            // staStrip
            // 
            this.staStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.staStatusLabel,
            this.toolStripStatusLabel1,
            this.strProgress});
            this.staStrip.Location = new System.Drawing.Point(0, 467);
            this.staStrip.Name = "staStrip";
            this.staStrip.Size = new System.Drawing.Size(934, 22);
            this.staStrip.TabIndex = 5;
            this.staStrip.Text = "stsStrip";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offlineModeToolStripMenuItem,
            this.onlineModeToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "Online";
            // 
            // offlineModeToolStripMenuItem
            // 
            this.offlineModeToolStripMenuItem.Image = global::Board_Explorer.Properties.Resources.bullet_red;
            this.offlineModeToolStripMenuItem.Name = "offlineModeToolStripMenuItem";
            this.offlineModeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.offlineModeToolStripMenuItem.Text = "Offline Mode";
            this.offlineModeToolStripMenuItem.Click += new System.EventHandler(this.offlineModeToolStripMenuItem_Click);
            // 
            // onlineModeToolStripMenuItem
            // 
            this.onlineModeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("onlineModeToolStripMenuItem.Image")));
            this.onlineModeToolStripMenuItem.Name = "onlineModeToolStripMenuItem";
            this.onlineModeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.onlineModeToolStripMenuItem.Text = "Online Mode";
            this.onlineModeToolStripMenuItem.Click += new System.EventHandler(this.onlineModeToolStripMenuItem_Click);
            // 
            // staStatusLabel
            // 
            this.staStatusLabel.Name = "staStatusLabel";
            this.staStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.staStatusLabel.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(656, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = " ";
            // 
            // strProgress
            // 
            this.strProgress.Name = "strProgress";
            this.strProgress.Size = new System.Drawing.Size(190, 16);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuPosts,
            this.mnuTools,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(934, 24);
            this.mnuMain.TabIndex = 7;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mnuPosts
            // 
            this.mnuPosts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFavorites,
            this.mnuFindByMd5,
            this.toolStripSeparator6,
            this.mnuDownloadAll});
            this.mnuPosts.Name = "mnuPosts";
            this.mnuPosts.Size = new System.Drawing.Size(47, 20);
            this.mnuPosts.Text = "Posts";
            // 
            // mnuFavorites
            // 
            this.mnuFavorites.Name = "mnuFavorites";
            this.mnuFavorites.Size = new System.Drawing.Size(182, 22);
            this.mnuFavorites.Text = "Load Favorites";
            this.mnuFavorites.Click += new System.EventHandler(this.mnuFavorites_Click);
            // 
            // mnuFindByMd5
            // 
            this.mnuFindByMd5.Name = "mnuFindByMd5";
            this.mnuFindByMd5.Size = new System.Drawing.Size(182, 22);
            this.mnuFindByMd5.Text = "Find By Image";
            this.mnuFindByMd5.Click += new System.EventHandler(this.mnuFindByMd5_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuDownloadAll
            // 
            this.mnuDownloadAll.Name = "mnuDownloadAll";
            this.mnuDownloadAll.Size = new System.Drawing.Size(182, 22);
            this.mnuDownloadAll.Text = "Download Displayed";
            this.mnuDownloadAll.Click += new System.EventHandler(this.mnuDownloadAll_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.toolStripSeparator1,
            this.mnuSyncFavorites,
            this.mnuSyncTags,
            this.toolStripSeparator7,
            this.mnuOpenDownloads});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(47, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(196, 22);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuSyncTags
            // 
            this.mnuSyncTags.Name = "mnuSyncTags";
            this.mnuSyncTags.Size = new System.Drawing.Size(196, 22);
            this.mnuSyncTags.Text = "Sync Tags";
            this.mnuSyncTags.Click += new System.EventHandler(this.mnuSyncTags_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuOpenDownloads
            // 
            this.mnuOpenDownloads.Name = "mnuOpenDownloads";
            this.mnuOpenDownloads.Size = new System.Drawing.Size(196, 22);
            this.mnuOpenDownloads.Text = "Open Download Folder";
            this.mnuOpenDownloads.Click += new System.EventHandler(this.mnuOpenDownloads_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRelease,
            this.mnuReportError,
            this.toolStripSeparator2,
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuRelease
            // 
            this.mnuRelease.Name = "mnuRelease";
            this.mnuRelease.Size = new System.Drawing.Size(166, 22);
            this.mnuRelease.Text = "Check for Update";
            this.mnuRelease.Click += new System.EventHandler(this.mnuRelease_Click);
            // 
            // mnuReportError
            // 
            this.mnuReportError.Name = "mnuReportError";
            this.mnuReportError.Size = new System.Drawing.Size(166, 22);
            this.mnuReportError.Text = "Report Error";
            this.mnuReportError.Click += new System.EventHandler(this.mnuReportError_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(166, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblDimensions);
            this.groupBox1.Controls.Add(this.lblFilesize);
            this.groupBox1.Controls.Add(this.lblArtist);
            this.groupBox1.Controls.Add(this.lblMd5);
            this.groupBox1.Controls.Add(this.lnkSource);
            this.groupBox1.Controls.Add(this.lblSource);
            this.groupBox1.Controls.Add(this.lblFavorites);
            this.groupBox1.Controls.Add(this.lblScore);
            this.groupBox1.Controls.Add(this.lblRating);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.lblTags);
            this.groupBox1.Controls.Add(this.lstTags);
            this.groupBox1.Location = new System.Drawing.Point(684, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 400);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // lblDimensions
            // 
            this.lblDimensions.AutoSize = true;
            this.lblDimensions.Location = new System.Drawing.Point(6, 190);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(64, 13);
            this.lblDimensions.TabIndex = 12;
            this.lblDimensions.Text = "Dimensions:";
            // 
            // lblFilesize
            // 
            this.lblFilesize.AutoSize = true;
            this.lblFilesize.Location = new System.Drawing.Point(6, 170);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Size = new System.Drawing.Size(44, 13);
            this.lblFilesize.TabIndex = 11;
            this.lblFilesize.Text = "Filesize:";
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(6, 130);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(33, 13);
            this.lblArtist.TabIndex = 10;
            this.lblArtist.Text = "Artist:";
            // 
            // lblMd5
            // 
            this.lblMd5.AutoSize = true;
            this.lblMd5.Location = new System.Drawing.Point(6, 50);
            this.lblMd5.Name = "lblMd5";
            this.lblMd5.Size = new System.Drawing.Size(33, 13);
            this.lblMd5.TabIndex = 8;
            this.lblMd5.Text = "MD5:";
            // 
            // lnkSource
            // 
            this.lnkSource.AutoSize = true;
            this.lnkSource.Location = new System.Drawing.Point(56, 150);
            this.lnkSource.Name = "lnkSource";
            this.lnkSource.Size = new System.Drawing.Size(27, 13);
            this.lnkSource.TabIndex = 7;
            this.lnkSource.TabStop = true;
            this.lnkSource.Text = "Link";
            this.lnkSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSource_LinkClicked);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(6, 150);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(44, 13);
            this.lblSource.TabIndex = 6;
            this.lblSource.Text = "Source:";
            // 
            // lblFavorites
            // 
            this.lblFavorites.AutoSize = true;
            this.lblFavorites.Location = new System.Drawing.Point(6, 110);
            this.lblFavorites.Name = "lblFavorites";
            this.lblFavorites.Size = new System.Drawing.Size(56, 13);
            this.lblFavorites.TabIndex = 5;
            this.lblFavorites.Text = "Favorites: ";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(6, 90);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(38, 13);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "Score:";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(6, 70);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(41, 13);
            this.lblRating.TabIndex = 3;
            this.lblRating.Text = "Rating:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(6, 30);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID:";
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(6, 210);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(34, 13);
            this.lblTags.TabIndex = 1;
            this.lblTags.Text = "Tags:";
            // 
            // lstTags
            // 
            this.lstTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(6, 234);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(228, 160);
            this.lstTags.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(372, 27);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ntfMain
            // 
            this.ntfMain.Text = "ntfMain";
            this.ntfMain.Visible = true;
            // 
            // mnuSyncFavorites
            // 
            this.mnuSyncFavorites.Name = "mnuSyncFavorites";
            this.mnuSyncFavorites.Size = new System.Drawing.Size(196, 22);
            this.mnuSyncFavorites.Text = "Sync Favorites";
            this.mnuSyncFavorites.Click += new System.EventHandler(this.mnuSyncFavorites_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 489);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.staStrip);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.lstView);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Board Explorer";
            this.ctxPost.ResumeLayout(false);
            this.staStrip.ResumeLayout(false);
            this.staStrip.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.ImageList imgPosts;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.ContextMenuStrip ctxPost;
        private System.Windows.Forms.ToolStripMenuItem ctxItemFavorite;
        private System.Windows.Forms.StatusStrip staStrip;
        private System.Windows.Forms.ToolStripStatusLabel staStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem ctxItemDownload;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem offlineModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineModeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPosts;
        private System.Windows.Forms.ToolStripMenuItem mnuFavorites;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenDownloads;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuDownloadAll;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar strProgress;
        private System.Windows.Forms.ToolStripMenuItem mnuReportError;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ctxItemOne621;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ToolStripMenuItem mnuRelease;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblFavorites;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.NotifyIcon ntfMain;
        private System.Windows.Forms.ToolStripMenuItem ctxItemVoteUp;
        private System.Windows.Forms.ToolStripMenuItem ctxItemVoteDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.LinkLabel lnkSource;
        private System.Windows.Forms.Label lblMd5;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.ToolStripMenuItem mnuFindByMd5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuShare;
        private System.Windows.Forms.ToolStripMenuItem mnuTelegram;
        private System.Windows.Forms.Label lblFilesize;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.ToolStripMenuItem mnuSyncTags;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mnuSyncFavorites;
    }
}

