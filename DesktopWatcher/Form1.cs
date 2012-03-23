namespace DesktopWatcher
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private readonly string desktopPath;

        private FileSystemWatcher desktopWatcher;

        private string fileName;

        private decimal baloonDisplayTime;

        private bool allowClose;

        public Form1()
        {
            InitializeComponent();
            desktopPath = string.Format("{0}\\", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            baloonDisplayTime = 5;
        }

        private void FormLoadHandler(object sender, EventArgs eventArgs)
        {
            desktopWatcher = new FileSystemWatcher();
            desktopWatcher.Path = this.desktopPath;
            desktopWatcher.Filter = "*.*";
            desktopWatcher.NotifyFilter = NotifyFilters.FileName;
            desktopWatcher.Created += FileOnDesktopCreated;
            desktopWatcher.EnableRaisingEvents = true;
        }

        private void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!allowClose)
                {
                    WindowState = FormWindowState.Minimized;
                    e.Cancel = true;
                }
            }
        }

        private void FileOnDesktopCreated(object sender, FileSystemEventArgs e)
        {
            fileName = e.Name;
            TrayIcon.BalloonTipText = string.Format("File {0} appeared on desktop!", e.Name);
            TrayIcon.ShowBalloonTip((int)baloonDisplayTime * 1000);
        }

        private void TrayIconBalloonTipClicked(object sender, EventArgs e)
        {
            string args = string.Format("/Select,{0}{1}", this.desktopPath, fileName);
            var processStartInfo = new ProcessStartInfo("Explorer.exe", args);
            Process.Start(processStartInfo);
        }

        private void TrayExitMenuItemClicked(object sender, EventArgs e)
        {
            allowClose = true;
            Close();
        }

        private void SaveSettingsClicked(object sender, EventArgs e)
        {
            SaveSettings();
            WindowState = FormWindowState.Minimized;
        }

        private void TrayIconMouseDoubleClicked(object sender, MouseEventArgs e)
        {
            LoadSettings();
            WindowState = FormWindowState.Normal; 
        }

        private void SaveSettings()
        {
            this.baloonDisplayTime = this.upDownBaloonDuration.Value;
        }

        private void LoadSettings()
        {
            upDownBaloonDuration.Value = baloonDisplayTime;
        }
    }
}
