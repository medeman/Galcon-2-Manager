using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Galcon_2_Manager
{
    class Utilities
    {
        public Utilities()
        {
            this.configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Galcon 2\";
        }

        private string configPath;

        // Deletes settings-local.dat and settings-cloud.dat. Returns whether they did exist before the process.
        public bool deleteConfig()
        {
            bool exists = false;

            if (File.Exists(this.configPath + "settings-local.dat"))
            {
                exists = true;
                File.Delete(this.configPath + "settings-local.dat");
            }

            if (File.Exists(this.configPath + "settings-cloud.dat"))
            {
                exists = true;
                File.Delete(this.configPath + "settings-cloud.dat");
            }

            return exists;
        }
    }
}
