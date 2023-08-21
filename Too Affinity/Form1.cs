using Microsoft.Win32;
using System.Diagnostics;
using System.Collections;

namespace Too_Affinity;

public partial class Form1 : Form
{
    private static string appName = "Too Affinity";
    private static System.Windows.Forms.Timer processCheckTimer = new System.Windows.Forms.Timer();
    private static bool attached = false;
    private static string[] exeNames = { "csgo", "cs2" };
    private Process? foundProcess = null;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        toolStripStatusLabel1.Text = "Waiting for game.";

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
        foreach (String exeName in exeNames)
        {
            Process[] gameProcceses = Process.GetProcessesByName(exeName);

            if (gameProcceses.Length > 0)
            {
                this.foundProcess = gameProcceses[0];
                break;
            }
            else
            {
                this.foundProcess = null;
            }
        }


        if (this.foundProcess == null && attached)
        {
            disableFirstCoreCb.Enabled = true;
            disableHtCb.Enabled = true;
            attached = false;

            toolStripStatusLabel1.Text = "Waiting for game.";
        }
        else if (this.foundProcess != null && !attached)
        {
            disableFirstCoreCb.Enabled = false;
            disableHtCb.Enabled = false;
            attached = true;

            enable(this.foundProcess);
        }
    }

    private long GetIntFromBitArray(BitArray bitArray)
    {
        var array = new byte[8];
        bitArray.CopyTo(array, 0);
        return BitConverter.ToInt64(array, 0);
    }

    private void enable(Process process)
    {
        int processorCount = Environment.ProcessorCount;
        BitArray affBits = new BitArray(processorCount, true);

        int offset = 0;

        if (disableFirstCoreCb.Checked)
        {
            offset += 1;
            affBits.Set(0, false);

            if (disableHtCb.Checked)
            {
                offset += 1;
                affBits.Set(1, false);
            }
        }

        if (disableHtCb.Checked)
        {
            for (int i = offset; i <= processorCount; i++)
            {
                if (i % 2 != 0)
                {
                    affBits.Set(i, false);
                }
            }
        }

        var affInt64Result = GetIntFromBitArray(affBits);
        process.ProcessorAffinity = new IntPtr(affInt64Result);

        var affSzResult = Convert.ToString(affInt64Result, 2);
        toolStripStatusLabel1.Text = $"Attached: {ReverseSz(affSzResult)}";
    }

    public static string ReverseSz(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
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