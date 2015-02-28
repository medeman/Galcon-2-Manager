using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Galcon_2_Manager.IM
{
    // Contains all possible states the installation can be in.
    public enum InstallStatus {
        Checking,
        NotChecked,
        NotInstalled,
        Outdated,
        UpToDate,
        OfflineInstalled,
        OfflineNotInstalled,
        Downloading,
        Verifying,
        Installing,
        ChecksumMismatch
    };

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
            this.sendStatusUpdatedEvent();
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

        // Downloads the checksum of the latest version and stores it in this.hashLatest
        public void getVersionInfo()
        {
            WebClient wc = new WebClient();

            wc.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) =>
            {
                if (e.Error != null)
                {
                    // Error downloading the checksum, server unreachable or we're offline. Set status accordingly.

                    installStatus = InstallStatus.OfflineNotInstalled;
                }
                else
                {
                    // Download successful, convert byte[] to UTF8 string and save the hash to this.hashLatest.

                    byte[] raw = e.Result;

                    installStatus = InstallStatus.NotInstalled;

                    this.hashLatest = System.Text.Encoding.UTF8.GetString(raw).Trim();
                }

                this.sendStatusUpdatedEvent();
            };

            wc.DownloadDataAsync(new Uri("http://f00b4r.org/g2/hash/latest/windows.txt"));
        }

        public void install()
        {
            if (File.Exists(@"cache\Galcon2.zip"))
            {
                this.calculateCacheHash();
                this.extract();
            }
            else
            {
                WebClient wc = new WebClient();

                installStatus = InstallStatus.Downloading;
                this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus, 0));

                wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                {
                    this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus, e.ProgressPercentage));
                };

                wc.DownloadFileCompleted += (object sender, System.ComponentModel.AsyncCompletedEventArgs e) =>
                {
                    this.installStatus = InstallStatus.Verifying;
                    this.sendStatusUpdatedEvent();
                    this.calculateCacheHash();
                    this.extract();
                };

                wc.DownloadFileAsync(new Uri("https://www.galcon.com/g2/files/latest/Galcon2.zip"), @"cache\Galcon2.zip");
            }
        }

        private void extract(bool skipVerify = false)
        {
            if (skipVerify || compareHashs(this.hashCache, this.hashLatest))
            {
                // The downloaded file's checksum is equal to the remote checksum.

                if (Directory.Exists(@"cache\Galcon2"))
                    Directory.Delete(@"cache\Galcon2", true);

                installStatus = InstallStatus.Installing;
                this.sendStatusUpdatedEvent();

                System.IO.Compression.ZipFile.ExtractToDirectory(@"cache\Galcon2.zip", "cache");
                Directory.Move(@"cache\Galcon2", "game");

                installStatus = InstallStatus.UpToDate;
                this.sendStatusUpdatedEvent();
            }
            else
            {
                // Checksums do not match, indicating a corrupted download.

                installStatus = InstallStatus.ChecksumMismatch;
            }
        }

        public void update()
        {
            // Will probably be removed because installing and updating is a very similar process.
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

            fs.Close();
        }

        private bool compareHashs(string hashA, string hashB)
        {
            return hashA == hashB;
        }

        private void sendStatusUpdatedEvent()
        {
            this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus));
        }

        public void launch()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\game";
            startInfo.FileName = Directory.GetCurrentDirectory() + @"\game\galcon2.exe";

            Process.Start(startInfo);
        }
    }
}
