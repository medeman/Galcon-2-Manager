using System;
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
        // Code for moving the window without the title bar.
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

            buttonLaunch.FlatAppearance.BorderSize = 0;

            im.StatusUpdated += (object sender, StatusUpdatedEventArgs e) =>
            {
                switch (e.installStatus)
                {
                    case InstallStatus.Checking:
                        labelInstallStatus.Text = "Status: Checking...";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = false;
                        break;
                    case InstallStatus.UpToDate:
                        labelInstallStatus.Text = "Status: Up to date!";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = true;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = true;
                        break;
                    case InstallStatus.NotChecked:
                        labelInstallStatus.Text = "Status: Not checked.";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = false;
                        break;
                    case InstallStatus.NotInstalled:
                        labelInstallStatus.Text = "Status: Not installed.";
                        buttonInstall.Enabled = true;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = false;
                        break;
                    case InstallStatus.Outdated:
                        labelInstallStatus.Text = "Status: Outdated!";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = true;
                        buttonInstallUpdate.Enabled = true;
                        buttonLaunch.Enabled = true;
                        break;
                    case InstallStatus.OfflineInstalled:
                        labelInstallStatus.Text = "Status: Offline (installed)";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = true;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = true;
                        break;
                    case InstallStatus.OfflineNotInstalled:
                        labelInstallStatus.Text = "Status: Offline (not installed)";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = false;
                        break;
                    case InstallStatus.Downloading:
                        labelInstallStatus.Text = "Status: Downloading (" + e.progress + " %)";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = false;
                        break;
                    case InstallStatus.Verifying:
                        labelInstallStatus.Text = "Status: Verifying...";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = false;
                        break;
                    case InstallStatus.ChecksumMismatch:
                        labelInstallStatus.Text = "Status: Checksum mismatch.";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = false;
                        break;
                    case InstallStatus.Installing:
                        labelInstallStatus.Text = "Status: Installing...";
                        buttonInstall.Enabled = false;
                        buttonInstallRemove.Enabled = false;
                        buttonInstallUpdate.Enabled = false;
                        buttonLaunch.Enabled = false;
                        break;
                }
            };

            im.init();
            im.getVersionInfo();
        }

        // Handle window movement.
        private void buttonTopMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Minimizes the window.
        private void buttonTopMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Closes the application.
        private void buttonTopClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Injects CSS (and JS) to format the news page properly.
        private void webBrowserNews_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            webBrowserNews.Document.CreateElement("style");

            HtmlElement head = webBrowserNews.Document.GetElementsByTagName("head")[0];
            HtmlElement linkElement = webBrowserNews.Document.CreateElement("link");

            linkElement.SetAttribute("rel", "stylesheet");
            linkElement.SetAttribute("href", "https://f00b4r.org/g2/manager/news.css");

            head.AppendChild(linkElement);
        }

        // Installs the game using InstallManager.
        private void buttonInstall_Click(object sender, EventArgs e)
        {
            im.install();
        }

        // Updates the game using InstallManager.
        private void buttonInstallUpdate_Click(object sender, EventArgs e)
        {
            im.update();
        }

        // Uninstalls the game using InstallManager.
        private void buttonInstallRemove_Click(object sender, EventArgs e)
        {
            DialogResult remove = MessageBox.Show("Do you want to uninstall Galcon 2?", "Confirm", MessageBoxButtons.YesNo);

            if (remove == DialogResult.Yes)
                im.uninstall();
        }

        // Launches the game using InstallManager.
        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            im.launch();
        }

        // Change button picture for launch button for enabled and disabled states.
        private void buttonLaunch_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonLaunch.Enabled)
                buttonLaunch.BackgroundImage = Galcon_2_Manager.Properties.Resources.button_launch;
            else
                buttonLaunch.BackgroundImage = Galcon_2_Manager.Properties.Resources.button_launch_disabled;
        }
    }
}
