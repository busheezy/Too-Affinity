using Microsoft.Win32;

namespace Too_Affinity
{
    public partial class Form1 : Form
    {
        string appName = "Too Affinity";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey? rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rk == null)
            {
                Application.Exit();
                return;
            }

            var existingRegistryValue = rk.GetValue(appName);
            if (existingRegistryValue != null)
            {
                startWithWindowsCb.Checked = true;
            }

            startMinimizedCb.Checked = Properties.Settings.Default.startMinimized;
            disableFirstCoreCb.Checked = Properties.Settings.Default.disableFirstCore;
            disableHtCb.Checked = Properties.Settings.Default.disableHt;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.startMinimized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        private void startWithWindowsCb_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey? rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rk == null)
            {
                Application.Exit();
                return;
            }

            if (startWithWindowsCb.Checked)
            {
                rk.SetValue(appName, Application.ExecutablePath);
            }
            else
            {
                rk.DeleteValue(appName, false);
            }
        }

        private void startMinimizedCb_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startMinimized = startMinimizedCb.Checked;
            Properties.Settings.Default.Save();
        }

        private void disableFirstCoreCb_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.disableFirstCore = disableFirstCoreCb.Checked;
            Properties.Settings.Default.Save();
        }

        private void disableHtCb_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.disableHt = disableHtCb.Checked;
            Properties.Settings.Default.Save();
        }
    }
}