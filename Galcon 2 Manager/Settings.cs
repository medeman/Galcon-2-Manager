using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Galcon_2_Manager
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            textBoxSettingDownloadUrl.Text = ConfigurationManager.AppSettings["downloadUrl"];
            textBoxSettingHashLatestUrl.Text = ConfigurationManager.AppSettings["hashLatestUrl"];
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["downloadUrl"].Value = textBoxSettingDownloadUrl.Text;
            config.AppSettings.Settings["hashLatestUrl"].Value = textBoxSettingHashLatestUrl.Text;

            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
