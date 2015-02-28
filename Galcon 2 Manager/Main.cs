﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Galcon_2_Manager.IM;

namespace Galcon_2_Manager
{
    public partial class Main : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        InstallManager im = new InstallManager();

        public Main()
        {
            InitializeComponent();

            im.StatusUpdated += (object sender, StatusUpdatedEventArgs e) =>
            {
                switch (e.installStatus)
                {
                    case InstallStatus.Checking:
                        labelInstallStatus.Text = "Status: Checking...";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        break;
                    case InstallStatus.UpToDate:
                        labelInstallStatus.Text = "Status: Up to date!";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = true;
                        buttonInstallUpdate.Enabled = false;
                        break;
                    case InstallStatus.NotChecked:
                        labelInstallStatus.Text = "Status: Not checked.";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        break;
                    case InstallStatus.NotInstalled:
                        labelInstallStatus.Text = "Status: Not installed.";
                        buttonInstall.Enabled = true;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        break;
                    case InstallStatus.Outdated:
                        labelInstallStatus.Text = "Status: Outdated!";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = true;
                        buttonInstallUpdate.Enabled = true;
                        break;
                    case InstallStatus.OfflineInstalled:
                        labelInstallStatus.Text = "Status: Offline (installed)";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = true;
                        buttonInstallUpdate.Enabled = false;
                        break;
                    case InstallStatus.OfflineNotInstalled:
                        labelInstallStatus.Text = "Status: Offline (not installed)";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        break;
                    case InstallStatus.Updating:
                        labelInstallStatus.Text = "Status: Installing (" + e.progress + " %)";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        break;
                }
            };

            im.init();
            im.getVersionInfo();
        }

        private void buttonTopMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void buttonTopMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonTopClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void webBrowserNews_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            webBrowserNews.Document.CreateElement("style");

            HtmlElement head = webBrowserNews.Document.GetElementsByTagName("head")[0];
            HtmlElement linkElement = webBrowserNews.Document.CreateElement("link");

            linkElement.SetAttribute("rel", "stylesheet");
            linkElement.SetAttribute("href", "http://localhost/g2manager-news.css");

            head.AppendChild(linkElement);
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            im.install();
        }

        private void buttonInstallUpdate_Click(object sender, EventArgs e)
        {
            im.update();
        }

        private void buttonInstallRemove_Click(object sender, EventArgs e)
        {
            im.uninstall();
        }
    }
}