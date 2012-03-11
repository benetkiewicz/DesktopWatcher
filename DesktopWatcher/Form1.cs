namespace DesktopWatcher
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private FileSystemWatcher desktopWatcher;
        private string fileName;
        const string DesktopPath = @"c:\Users\piotr\Desktop\";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void FormLoadHandler(object sender, EventArgs eventArgs)
        {
            desktopWatcher = new FileSystemWatcher();
            desktopWatcher.Path = DesktopPath;
            desktopWatcher.Filter = "*.*";
            desktopWatcher.NotifyFilter = NotifyFilters.FileName;
            desktopWatcher.Created += FileOnDesktopCreated;
            desktopWatcher.EnableRaisingEvents = true;
        }

        public void FormUnloadHandler(object sender, FormClosingEventArgs e)
        {
            if (this.desktopWatcher != null)
            {
                desktopWatcher.EnableRaisingEvents = false;
                desktopWatcher.Dispose();
            }
        }

        void FileOnDesktopCreated(object sender, FileSystemEventArgs e)
        {
            fileName = e.Name;
            TrayIcon.BalloonTipText = string.Format("File {0} appeared on desktop!", e.Name);
            TrayIcon.ShowBalloonTip(7*1000);
        }

        private void TrayIconBalloonTipClicked(object sender, EventArgs e)
        {
            string args = string.Format("/Select, {0}{1}", DesktopPath, fileName);
            var processStartInfo = new ProcessStartInfo("Explorer.exe", args);
            Process.Start(processStartInfo);
        }
    }
}
