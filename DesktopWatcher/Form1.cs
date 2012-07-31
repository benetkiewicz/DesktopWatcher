namespace DesktopWatcher
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
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
            desktopPath = string.Format(CultureInfo.InvariantCulture, "{0}\\", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            baloonDisplayTime = 5;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalHotkey.HotkeyMessageId)
            {
                ShowBaloon(fileName);
            }

            base.WndProc(ref m);
        }

        private void RegisterHotKey()
        {
            var hotKey = new GlobalHotkey(0x0008, Keys.Z, this); // win + Z
            if (!hotKey.Register())
            {
                MessageBox.Show("Hotkey failed to register!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        private void UnregisterHotkey()
        {
            var hotKey = new GlobalHotkey(0x0008, Keys.Z, this); // win + Z
            if (!hotKey.Unregister())
            {
                MessageBox.Show("Hotkey failed to unregister!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        private void StartFileSystemWatcher()
        {
            desktopWatcher = new FileSystemWatcher();
            desktopWatcher.Path = this.desktopPath;
            desktopWatcher.Filter = "*.*";
            desktopWatcher.NotifyFilter = NotifyFilters.FileName;
            desktopWatcher.Created += FileOnDesktopCreated;
            desktopWatcher.EnableRaisingEvents = true;
        }

        private void StopFileSystemWatcher()
        {
            if (desktopWatcher != null)
            {
                desktopWatcher.EnableRaisingEvents = false;
                desktopWatcher.Dispose();
                desktopWatcher = null;
            }
        }

        private void FormLoadHandler(object sender, EventArgs eventArgs)
        {
            StartFileSystemWatcher();
            RegisterHotKey();
        }

        private void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
            {
                return;
            }

            if (!allowClose)
            {
                this.WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            } 
            else
            {
                UnregisterHotkey();
                StopFileSystemWatcher();
            }
        }

        private void FormResizeHandler(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void FileOnDesktopCreated(object sender, FileSystemEventArgs e)
        {
            fileName = e.Name;
            ShowBaloon(fileName);
        }

        private void ShowBaloon(string name)
        {
            trayIcon.BalloonTipText = string.Format(CultureInfo.InvariantCulture, "File {0} appeared on desktop!", name);
            trayIcon.ShowBalloonTip((int)baloonDisplayTime * 1000);
        }

        private void TrayIconBalloonTipClicked(object sender, EventArgs e)
        {
            string args = string.Format(CultureInfo.InvariantCulture, "/Select,{0}{1}", this.desktopPath, fileName);
            var processStartInfo = new ProcessStartInfo("Explorer.exe", args);
            Process.Start(processStartInfo);
        }

        private void TrayExitMenuItemClicked(object sender, EventArgs e)
        {
            allowClose = true;
            this.Close();
        }

        private void SaveSettingsClicked(object sender, EventArgs e)
        {
            SaveSettings();
            WindowState = FormWindowState.Minimized;
        }

        private void TrayIconMouseDoubleClicked(object sender, MouseEventArgs e)
        {
            LoadSettings();
            this.Show();
            WindowState = FormWindowState.Normal; 
        }

        private void SaveSettings()
        {
            baloonDisplayTime = this.downUpBaloonDuration.Value;
        }

        private void LoadSettings()
        {
            this.downUpBaloonDuration.Value = baloonDisplayTime;
        }
    }
}
