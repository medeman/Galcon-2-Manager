using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Configuration;

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

        // Initializes the InstallManager class.
        public void init()
        {
            this.sendStatusUpdatedEvent();
            this.prepare();
        }

        public event StatusUpdatedEventHandler StatusUpdated;

        // Prepares the directory structure Galcon 2 Manager uses if it doesn't exist yet.
        private void prepare()
        {
            if (!Directory.Exists("cache"))
                Directory.CreateDirectory("cache");
        }

        // Downloads the checksum of the latest version and stores it in this.hashLatest.
        public void getVersionInfo()
        {
            WebClient wc = new WebClient();

            wc.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) =>
            {
                if (e.Error != null)
                {
                    // Error downloading the checksum, server unreachable or we're offline. Set status accordingly.

                    if (File.Exists(@"game\Galcon2.exe"))
                        installStatus = InstallStatus.OfflineInstalled;
                    else
                        installStatus = InstallStatus.OfflineNotInstalled;
                }
                else
                {
                    // Download successful, convert byte[] to UTF8 string and save the hash to this.hashLatest.

                    byte[] raw = e.Result;
                    this.hashLatest = System.Text.Encoding.UTF8.GetString(raw).Trim();

                    // Calculate the hash of the Galcon2.zip in cache to compare it with the hash returned from the server.
                    this.calculateCacheHash();

                    if (this.compareHashs(this.hashLatest, this.hashCache) && File.Exists(@"game\Galcon2.exe"))
                        installStatus = InstallStatus.UpToDate;
                    else if (File.Exists(@"game\Galcon2.exe"))
                        // Hashs do not match, but the game is installed - it's likely outdated.
                        installStatus = InstallStatus.Outdated;
                    else
                        installStatus = InstallStatus.NotInstalled;
                }

                this.sendStatusUpdatedEvent();
            };

            wc.DownloadDataAsync(new Uri(Settings.getConfigKey("hashLatestUrl")));
        }

        // Installs the game (and downloads it if Galcon2.zip is not in the cache folder).
        public void install()
        {
            // Check if there is a Galcon2.zip in the cache folder and calculate its checksum.
            if (File.Exists(@"cache\Galcon2.zip"))
                this.calculateCacheHash();

            // If checksums match, extract the existing version of Galcon2.zip, else download it.
            if (this.compareHashs(this.hashCache, this.hashLatest))
            {
                this.extract();
            }
            else
            {
                WebClient wc = new WebClient();

                installStatus = InstallStatus.Downloading;
                this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus, 0));

                // Send StatusUpdated event with download progress percentage.
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

                wc.DownloadFileAsync(new Uri(Settings.getConfigKey("downloadUrl")), @"cache\Galcon2.zip");
            }
        }

        // Extract Galcon2.zip from cache to the game folder.
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
                this.uninstall(false);
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

        // Updates an existing installation (by deleting Galcon2.zip in the cache folder and starting the install process).
        public void update()
        {
            if (File.Exists(@"cache\Galcon2.zip"))
                File.Delete(@"cache\Galcon2.zip");
            this.install();
        }

        // Uninstalls the game. Set changeStatus to false to prevent a status update.
        public void uninstall(bool changeStatus = true)
        {
            // Delete the game folder (we should probably clear the cache folder as well?).

            if (Directory.Exists("game"))
                Directory.Delete("game", true);

            if (changeStatus)
            {
                installStatus = InstallStatus.NotInstalled;
                this.sendStatusUpdatedEvent();
            }
        }

        // Calculates the hash of Galcon2.zip in the cache folder and saves it to this.hashCache.
        private void calculateCacheHash()
        {
            if (File.Exists(@"cache\Galcon2.zip"))
            {
                SHA256 shaChecksum = SHA256.Create();

                FileStream fs = new FileStream(@"cache\Galcon2.zip", FileMode.Open);
                fs.Position = 0;

                this.hashCache = BitConverter.ToString(shaChecksum.ComputeHash(fs)).Replace("-", string.Empty).ToLower();

                fs.Close();
            }
            else
                this.hashCache = "0";
        }

        // Compares two SHA256 hashes.
        private bool compareHashs(string hashA, string hashB)
        {
            return hashA == hashB;
        }

        // Triggers the StatusUpdated event with installStatus.
        private void sendStatusUpdatedEvent()
        {
            this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus));
        }

        // Launches the game.
        public void launch()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\game";
            startInfo.FileName = Directory.GetCurrentDirectory() + @"\game\galcon2.exe";

            Process.Start(startInfo);
        }
    }
}
