namespace DesktopWatcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if (desktopWatcher != null)
                {
                    desktopWatcher.EnableRaisingEvents = false;
                    desktopWatcher.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDuration = new System.Windows.Forms.Label();
            this.upDownBaloonDuration = new System.Windows.Forms.NumericUpDown();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.TrayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBaloonDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipText = "There is a new file on desktop";
            this.TrayIcon.BalloonTipTitle = "New file on desktop";
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Desktop Watcher";
            this.TrayIcon.Visible = true;
            this.TrayIcon.BalloonTipClicked += new System.EventHandler(this.TrayIconBalloonTipClicked);
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIconMouseDoubleClicked);
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.TrayExitMenuItemClicked);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 26);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(95, 13);
            this.lblDuration.TabIndex = 1;
            this.lblDuration.Text = "Baloon tip duration";
            // 
            // upDownBaloonDuration
            // 
            this.upDownBaloonDuration.Location = new System.Drawing.Point(206, 24);
            this.upDownBaloonDuration.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.upDownBaloonDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownBaloonDuration.Name = "upDownBaloonDuration";
            this.upDownBaloonDuration.Size = new System.Drawing.Size(66, 20);
            this.upDownBaloonDuration.TabIndex = 2;
            this.upDownBaloonDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(197, 158);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 3;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.SaveSettingsClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 212);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.upDownBaloonDuration);
            this.Controls.Add(this.btnSaveSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingHandler);
            this.Load += new System.EventHandler(this.FormLoadHandler);
            this.TrayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.upDownBaloonDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown upDownBaloonDuration;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}

