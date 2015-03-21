namespace Galcon_2_Manager
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonTopClose = new System.Windows.Forms.Button();
            this.buttonTopMove = new System.Windows.Forms.Button();
            this.buttonTopMinimize = new System.Windows.Forms.Button();
            this.groupBoxInstall = new System.Windows.Forms.GroupBox();
            this.buttonInstallRemove = new System.Windows.Forms.Button();
            this.labelInstallStatus = new System.Windows.Forms.Label();
            this.buttonInstallUpdate = new System.Windows.Forms.Button();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.webBrowserNews = new System.Windows.Forms.WebBrowser();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.groupBoxUtilities = new System.Windows.Forms.GroupBox();
            this.buttonUtilityDeleteConfig = new System.Windows.Forms.Button();
            this.groupBoxInstall.SuspendLayout();
            this.groupBoxUtilities.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTopClose
            // 
            this.buttonTopClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTopClose.BackgroundImage = global::Galcon_2_Manager.Properties.Resources.button_close;
            this.buttonTopClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTopClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTopClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTopClose.Location = new System.Drawing.Point(856, 12);
            this.buttonTopClose.Name = "buttonTopClose";
            this.buttonTopClose.Size = new System.Drawing.Size(32, 32);
            this.buttonTopClose.TabIndex = 0;
            this.buttonTopClose.UseVisualStyleBackColor = false;
            this.buttonTopClose.Click += new System.EventHandler(this.buttonTopClose_Click);
            // 
            // buttonTopMove
            // 
            this.buttonTopMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTopMove.BackgroundImage = global::Galcon_2_Manager.Properties.Resources.button_move;
            this.buttonTopMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTopMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTopMove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTopMove.Location = new System.Drawing.Point(780, 12);
            this.buttonTopMove.Name = "buttonTopMove";
            this.buttonTopMove.Size = new System.Drawing.Size(32, 32);
            this.buttonTopMove.TabIndex = 1;
            this.buttonTopMove.UseVisualStyleBackColor = false;
            this.buttonTopMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonTopMove_MouseDown);
            // 
            // buttonTopMinimize
            // 
            this.buttonTopMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTopMinimize.BackgroundImage = global::Galcon_2_Manager.Properties.Resources.button_minimize;
            this.buttonTopMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTopMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTopMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTopMinimize.Location = new System.Drawing.Point(818, 12);
            this.buttonTopMinimize.Name = "buttonTopMinimize";
            this.buttonTopMinimize.Size = new System.Drawing.Size(32, 32);
            this.buttonTopMinimize.TabIndex = 2;
            this.buttonTopMinimize.UseVisualStyleBackColor = false;
            this.buttonTopMinimize.Click += new System.EventHandler(this.buttonTopMinimize_Click);
            // 
            // groupBoxInstall
            // 
            this.groupBoxInstall.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxInstall.Controls.Add(this.buttonInstallRemove);
            this.groupBoxInstall.Controls.Add(this.labelInstallStatus);
            this.groupBoxInstall.Controls.Add(this.buttonInstallUpdate);
            this.groupBoxInstall.Controls.Add(this.buttonInstall);
            this.groupBoxInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInstall.ForeColor = System.Drawing.Color.White;
            this.groupBoxInstall.Location = new System.Drawing.Point(12, 354);
            this.groupBoxInstall.Name = "groupBoxInstall";
            this.groupBoxInstall.Size = new System.Drawing.Size(200, 134);
            this.groupBoxInstall.TabIndex = 3;
            this.groupBoxInstall.TabStop = false;
            this.groupBoxInstall.Text = "Installation";
            // 
            // buttonInstallRemove
            // 
            this.buttonInstallRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonInstallRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonInstallRemove.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonInstallRemove.Enabled = false;
            this.buttonInstallRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstallRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstallRemove.ForeColor = System.Drawing.Color.White;
            this.buttonInstallRemove.Location = new System.Drawing.Point(9, 99);
            this.buttonInstallRemove.Name = "buttonInstallRemove";
            this.buttonInstallRemove.Size = new System.Drawing.Size(96, 24);
            this.buttonInstallRemove.TabIndex = 6;
            this.buttonInstallRemove.Text = "Remove";
            this.buttonInstallRemove.UseVisualStyleBackColor = false;
            this.buttonInstallRemove.Click += new System.EventHandler(this.buttonInstallRemove_Click);
            // 
            // labelInstallStatus
            // 
            this.labelInstallStatus.AutoSize = true;
            this.labelInstallStatus.Location = new System.Drawing.Point(6, 19);
            this.labelInstallStatus.Name = "labelInstallStatus";
            this.labelInstallStatus.Size = new System.Drawing.Size(52, 17);
            this.labelInstallStatus.TabIndex = 0;
            this.labelInstallStatus.Text = "Status:";
            // 
            // buttonInstallUpdate
            // 
            this.buttonInstallUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonInstallUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonInstallUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonInstallUpdate.Enabled = false;
            this.buttonInstallUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstallUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstallUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonInstallUpdate.Location = new System.Drawing.Point(9, 69);
            this.buttonInstallUpdate.Name = "buttonInstallUpdate";
            this.buttonInstallUpdate.Size = new System.Drawing.Size(96, 24);
            this.buttonInstallUpdate.TabIndex = 5;
            this.buttonInstallUpdate.Text = "Update";
            this.buttonInstallUpdate.UseVisualStyleBackColor = false;
            this.buttonInstallUpdate.Click += new System.EventHandler(this.buttonInstallUpdate_Click);
            // 
            // buttonInstall
            // 
            this.buttonInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonInstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonInstall.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonInstall.Enabled = false;
            this.buttonInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstall.ForeColor = System.Drawing.Color.White;
            this.buttonInstall.Location = new System.Drawing.Point(9, 39);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(96, 24);
            this.buttonInstall.TabIndex = 4;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = false;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // webBrowserNews
            // 
            this.webBrowserNews.Location = new System.Drawing.Point(218, 50);
            this.webBrowserNews.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserNews.Name = "webBrowserNews";
            this.webBrowserNews.Size = new System.Drawing.Size(670, 438);
            this.webBrowserNews.TabIndex = 4;
            this.webBrowserNews.Url = new System.Uri("http://www.galcon.com/news/category/galcon2/", System.UriKind.Absolute);
            this.webBrowserNews.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowserNews_Navigated);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(214, 14);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(173, 24);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Manager 0.2-beta";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Galcon_2_Manager.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 71);
            this.panel1.TabIndex = 5;
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.BackColor = System.Drawing.Color.Transparent;
            this.buttonLaunch.BackgroundImage = global::Galcon_2_Manager.Properties.Resources.button_launch_disabled;
            this.buttonLaunch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonLaunch.Enabled = false;
            this.buttonLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLaunch.ForeColor = System.Drawing.Color.Transparent;
            this.buttonLaunch.Location = new System.Drawing.Point(46, 116);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(128, 128);
            this.buttonLaunch.TabIndex = 9;
            this.buttonLaunch.UseVisualStyleBackColor = false;
            this.buttonLaunch.EnabledChanged += new System.EventHandler(this.buttonLaunch_EnabledChanged);
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // groupBoxUtilities
            // 
            this.groupBoxUtilities.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxUtilities.Controls.Add(this.buttonUtilityDeleteConfig);
            this.groupBoxUtilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxUtilities.ForeColor = System.Drawing.Color.White;
            this.groupBoxUtilities.Location = new System.Drawing.Point(12, 292);
            this.groupBoxUtilities.Name = "groupBoxUtilities";
            this.groupBoxUtilities.Size = new System.Drawing.Size(200, 56);
            this.groupBoxUtilities.TabIndex = 10;
            this.groupBoxUtilities.TabStop = false;
            this.groupBoxUtilities.Text = "Utilities";
            // 
            // buttonUtilityDeleteConfig
            // 
            this.buttonUtilityDeleteConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonUtilityDeleteConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonUtilityDeleteConfig.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonUtilityDeleteConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUtilityDeleteConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUtilityDeleteConfig.ForeColor = System.Drawing.Color.White;
            this.buttonUtilityDeleteConfig.Location = new System.Drawing.Point(9, 22);
            this.buttonUtilityDeleteConfig.Name = "buttonUtilityDeleteConfig";
            this.buttonUtilityDeleteConfig.Size = new System.Drawing.Size(96, 24);
            this.buttonUtilityDeleteConfig.TabIndex = 7;
            this.buttonUtilityDeleteConfig.Text = "Delete config";
            this.buttonUtilityDeleteConfig.UseVisualStyleBackColor = false;
            this.buttonUtilityDeleteConfig.Click += new System.EventHandler(this.buttonUtilityDeleteConfig_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Galcon_2_Manager.Properties.Resources.background_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.groupBoxUtilities);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowserNews);
            this.Controls.Add(this.groupBoxInstall);
            this.Controls.Add(this.buttonTopMinimize);
            this.Controls.Add(this.buttonTopMove);
            this.Controls.Add(this.buttonTopClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Galcon 2 Manager";
            this.groupBoxInstall.ResumeLayout(false);
            this.groupBoxInstall.PerformLayout();
            this.groupBoxUtilities.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTopClose;
        private System.Windows.Forms.Button buttonTopMove;
        private System.Windows.Forms.Button buttonTopMinimize;
        private System.Windows.Forms.GroupBox groupBoxInstall;
        private System.Windows.Forms.Label labelInstallStatus;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonInstallRemove;
        private System.Windows.Forms.Button buttonInstallUpdate;
        private System.Windows.Forms.WebBrowser webBrowserNews;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.GroupBox groupBoxUtilities;
        private System.Windows.Forms.Button buttonUtilityDeleteConfig;
    }
}

