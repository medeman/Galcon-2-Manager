using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Galcon_2_Manager.IM
{
    public enum InstallStatus { Checking, NotChecked, NotInstalled, Outdated, UpToDate, OfflineInstalled, OfflineNotInstalled, Updating };

    public delegate void StatusUpdatedEventHandler(object sender, StatusUpdatedEventArgs e);

    public class StatusUpdatedEventArgs : EventArgs
    {
        public StatusUpdatedEventArgs(InstallStatus installStatus, int progress = 0)
        {
            this.installStatus = installStatus;
            this.progress = progress;
        }

        public InstallStatus installStatus;
        public int progress;
    }

    class InstallManager
    {
        string hashLatest, hashCache;
        private InstallStatus installStatus = InstallStatus.Checking;

        public InstallManager()
        {
            
        }

        public void init()
        {
            this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus));
            this.prepare();
        }

        public event StatusUpdatedEventHandler StatusUpdated;

        private void prepare()
        {
            if (!Directory.Exists("game"))
                Directory.CreateDirectory("game");
            if (!Directory.Exists("cache"))
                Directory.CreateDirectory("cache");
        }

        public void getVersionInfo()
        {
            WebClient wc = new WebClient();

            wc.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) =>
            {
                if (e.Error != null)
                {
                    installStatus = InstallStatus.OfflineNotInstalled;
                }
                else
                {
                    byte[] raw = e.Result;

                    installStatus = InstallStatus.NotInstalled;

                    this.hashLatest = System.Text.Encoding.UTF8.GetString(raw);
                }

                this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus));
            };

            wc.DownloadDataAsync(new Uri("http://f00b4r.org/g2/hash/latest/windows.txt"));
        }

        public void install()
        {
            if (File.Exists(@"cache\Galcon2.zip"))
            {
                this.calculateCacheHash();
            }
            else
            {
                WebClient wc = new WebClient();

                installStatus = InstallStatus.Updating;
                this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus, 0));

                wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                {
                    this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus, e.ProgressPercentage));
                };

                wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
                {
                    this.calculateCacheHash();
                };

                wc.DownloadFileAsync(new Uri("https://www.galcon.com/g2/files/latest/Galcon2.zip"), @"cache\Galcon2.zip");
            }
        }

        public void update()
        {

        }

        public void uninstall()
        {

        }

        private void calculateCacheHash()
        {
            SHA256 shaChecksum = SHA256.Create();

            FileStream fs = new FileStream(@"cache\Galcon2.zip", FileMode.Open);
            fs.Position = 0;

            this.hashCache = BitConverter.ToString(shaChecksum.ComputeHash(fs)).Replace("-", string.Empty).ToLower();
        }
    }
}
