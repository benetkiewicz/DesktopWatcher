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

        public Form1()
        {
            InitializeComponent();
            this.desktopPath = string.Format("{0}\\", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
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

        private void FormUnloadHandler(object sender, FormClosingEventArgs e)
        {
            if (this.desktopWatcher != null)
            {
                desktopWatcher.EnableRaisingEvents = false;
                desktopWatcher.Dispose();
            }
        }

        private void FileOnDesktopCreated(object sender, FileSystemEventArgs e)
        {
            fileName = e.Name;
            TrayIcon.BalloonTipText = string.Format("File {0} appeared on desktop!", e.Name);
            TrayIcon.ShowBalloonTip(7 * 1000);
        }

        private void TrayIconBalloonTipClicked(object sender, EventArgs e)
        {
            string args = string.Format("/Select,{0}{1}", this.desktopPath, fileName);
            var processStartInfo = new ProcessStartInfo("Explorer.exe", args);
            Process.Start(processStartInfo);
        }

        private void TrayExitMenuItemClicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
