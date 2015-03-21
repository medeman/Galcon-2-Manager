namespace Galcon_2_Manager
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSettingHashLatestUrl = new System.Windows.Forms.Label();
            this.labelSettingDownloadUrl = new System.Windows.Forms.Label();
            this.textBoxSettingHashLatestUrl = new System.Windows.Forms.TextBox();
            this.textBoxSettingDownloadUrl = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelRestartHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSettingHashLatestUrl
            // 
            this.labelSettingHashLatestUrl.AutoSize = true;
            this.labelSettingHashLatestUrl.Location = new System.Drawing.Point(12, 41);
            this.labelSettingHashLatestUrl.Name = "labelSettingHashLatestUrl";
            this.labelSettingHashLatestUrl.Size = new System.Drawing.Size(162, 13);
            this.labelSettingHashLatestUrl.TabIndex = 0;
            this.labelSettingHashLatestUrl.Text = "URL of hash of the latest version";
            // 
            // labelSettingDownloadUrl
            // 
            this.labelSettingDownloadUrl.AutoSize = true;
            this.labelSettingDownloadUrl.Location = new System.Drawing.Point(12, 15);
            this.labelSettingDownloadUrl.Name = "labelSettingDownloadUrl";
            this.labelSettingDownloadUrl.Size = new System.Drawing.Size(124, 13);
            this.labelSettingDownloadUrl.TabIndex = 1;
            this.labelSettingDownloadUrl.Text = "URL to the latest version";
            // 
            // textBoxSettingHashLatestUrl
            // 
            this.textBoxSettingHashLatestUrl.Location = new System.Drawing.Point(180, 38);
            this.textBoxSettingHashLatestUrl.Name = "textBoxSettingHashLatestUrl";
            this.textBoxSettingHashLatestUrl.Size = new System.Drawing.Size(330, 20);
            this.textBoxSettingHashLatestUrl.TabIndex = 2;
            // 
            // textBoxSettingDownloadUrl
            // 
            this.textBoxSettingDownloadUrl.Location = new System.Drawing.Point(180, 12);
            this.textBoxSettingDownloadUrl.Name = "textBoxSettingDownloadUrl";
            this.textBoxSettingDownloadUrl.Size = new System.Drawing.Size(330, 20);
            this.textBoxSettingDownloadUrl.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(435, 166);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelRestartHint
            // 
            this.labelRestartHint.AutoSize = true;
            this.labelRestartHint.Location = new System.Drawing.Point(12, 171);
            this.labelRestartHint.Name = "labelRestartHint";
            this.labelRestartHint.Size = new System.Drawing.Size(342, 13);
            this.labelRestartHint.TabIndex = 5;
            this.labelRestartHint.Text = "You may need to restart the application for some settings to take effect.";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 201);
            this.Controls.Add(this.labelRestartHint);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSettingDownloadUrl);
            this.Controls.Add(this.textBoxSettingHashLatestUrl);
            this.Controls.Add(this.labelSettingDownloadUrl);
            this.Controls.Add(this.labelSettingHashLatestUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSettingHashLatestUrl;
        private System.Windows.Forms.Label labelSettingDownloadUrl;
        private System.Windows.Forms.TextBox textBoxSettingHashLatestUrl;
        private System.Windows.Forms.TextBox textBoxSettingDownloadUrl;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelRestartHint;
    }
}