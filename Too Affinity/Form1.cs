using Microsoft.Win32;
using System.Diagnostics;

namespace Too_Affinity;

public partial class Form1 : Form
{
    private static string appName = "Too Affinity";
    private static System.Windows.Forms.Timer processCheckTimer = new System.Windows.Forms.Timer();
    private static bool attached = false;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        initCbState();
        startTimer();
    }

    private void initCbState()
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

    private void startTimer()
    {
        processCheckTimer.Interval = 5000;
        processCheckTimer.Tick += onProcessCheck;
        processCheckTimer.Enabled = true;
        processCheckTimer.Start();
    }

    private void onProcessCheck(Object? source, EventArgs e)
    {
        Process[] csgoProcesses = Process.GetProcessesByName("csgo");

        if (csgoProcesses.Length == 0 && attached)
        {
            // disable

            disableFirstCoreCb.Enabled = true;
            disableHtCb.Enabled = true;

            toolStripStatusLabel1.Text = "Waiting for csgo.";
            attached = false;
        }
        else if (csgoProcesses.Length > 0 && !attached)
        {
            //enable

            disableFirstCoreCb.Enabled = false;
            disableHtCb.Enabled = false;

            enable(csgoProcesses[0]);
            attached = true;
        }
    }

    private int getCurrentAffInt(Process process)
    {
        var aff = process.ProcessorAffinity;
        var affInt = aff.ToInt32();
        return affInt;
    }

    public static string ReverseSz(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static int modifyBit(int num, int position, int newBit)
    {
        int mask = 1 << position;
        return (num & ~mask) | ((newBit << position) & mask);
    }

    private void setLabelBinary(int affInt, int length)
    {
        var affSz = Convert.ToString(affInt, 2).PadLeft(20, '0');
        toolStripStatusLabel1.Text = $"Attached: {ReverseSz(affSz)}";
    }

    private void enable(Process process)
    {
        var affInt = getCurrentAffInt(process);
        var affSz = Convert.ToString(affInt, 2);

        int offset = 0;

        if (disableFirstCoreCb.Checked)
        {
            affInt = modifyBit(affInt, 0, 0);
            offset += 1;

            if (disableHtCb.Checked)
            {
                offset += 1;
                affInt = modifyBit(affInt, 1, 0);
            }
        }

        if (disableHtCb.Checked)
        {
            for (int i = offset; i <= affSz.Length; i++)
            {
                if (i % 2 != 0)
                {
                    affInt = modifyBit(affInt, i, 0);
                }
            }
        }

        setLabelBinary(affInt, affSz.Length);

        process.ProcessorAffinity = new IntPtr(affInt);
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