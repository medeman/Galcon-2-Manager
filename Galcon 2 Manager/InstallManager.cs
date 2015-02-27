﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Galcon_2_Manager.IM
{
    public enum InstallStatus { Checking, NotChecked, NotInstalled, Outdated, UpToDate, OfflineInstalled, OfflineNotInstalled, Updating };

    public delegate void StatusUpdatedEventHandler(object sender, StatusUpdatedEventArgs e);

    public class StatusUpdatedEventArgs : EventArgs
    {
        public StatusUpdatedEventArgs(InstallStatus installStatus, int progress = 0)
        {
            this.installStatus = installStatus;
            if (progress != null)
                this.progress = progress;
        }

        public InstallStatus installStatus;
        public int progress;
    }

    class InstallManager
    {
        string hashLatest;
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

            wc.DownloadDataAsync(new Uri("http://localhost/g2hash.php"));
        }

        public void install()
        {
            WebClient wc = new WebClient();

            installStatus = InstallStatus.Updating;
            this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus, 0));

            wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
            {
                this.StatusUpdated(this, new StatusUpdatedEventArgs(installStatus, e.ProgressPercentage));
            };

            wc.DownloadFileAsync(new Uri("https://www.galcon.com/g2/files/latest/Galcon2.zip"), @"cache\Galcon2.zip");
        }

        public void update()
        {

        }

        public void uninstall()
        {

        }
    }
}
