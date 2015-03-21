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

            textBoxSettingDownloadUrl.Text = Settings.getConfigKey("downloadUrl");
            textBoxSettingHashLatestUrl.Text = Settings.getConfigKey("hashLatestUrl");
        }

        // Saves the configuration to the configuration file.
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> mapping = new Dictionary<string, string>
            {
                {"downloadUrl", textBoxSettingDownloadUrl.Text},
                {"hashLatestUrl", textBoxSettingHashLatestUrl.Text}
            };

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            foreach (KeyValuePair<string, string> entry in mapping)
            {
                if (config.AppSettings.Settings[entry.Key] != null)
                    config.AppSettings.Settings[entry.Key].Value = entry.Value;
                else
                    config.AppSettings.Settings.Add(entry.Key, entry.Value);
            }

            config.Save(ConfigurationSaveMode.Modified);

            this.Close();
        }

        // Returns AppSetting value for given key (or fallback if the key doesn't exist).
        public static string getConfigKey(string key)
        {
            // Return key from App.config if it exists
            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key];
            }
            
            // Fallback to default settings
            if (Settings.defaults[key] != null)
            {
                return Settings.defaults[key];
            }

            // Key doesn't exist
            MessageBox.Show("Invalid configuration. Application will exit.");
            Environment.Exit(0); // Not using Application.Exit() here because the function returned to could still throw an exception.

            return "";
        }

        // Contains default config values.
        private static Dictionary<string, string> defaults = new Dictionary<string, string>
        {
            {"downloadUrl", "https://www.galcon.com/g2/files/latest/Galcon2.zip"},
            {"hashLatestUrl", "https://f00b4r.org/g2/hash/latest/windows.txt"}
        };
    }
}
