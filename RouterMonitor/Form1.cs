using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Timers;

namespace RouterMonitor
{
    struct iniparamsstruct
    {
        public string RouterIPAddress;       // IPAddress of the router
        public bool RouterRaiseTelnet;
        public bool RouterTelnetAllowed;
        public string ModemType;
        public string RouterModel;
        public string RouterUsername;
        public string RouterPassword;

        public bool EmailEnabled;
        public string EmailSMTPServer;
        public string EmailToAddress;
        public string EmailFromAddress;
        public bool EmailOnSyncChange;
        public bool EmailOnUpwards;
        public bool EmailOnDownwards;
        public bool EmailOnIncreasing;
        public int EmailOnIncreasingPollCount;
        public bool EmailOnVarLine;
        public int EmailOnVarLinePollCount;

        public int PollInterval;

        public bool LogEnabled;
        public bool LogChangesOnly;
        public string LogFilename;

        public bool AutoStart;         // Set to auto start the polling
        public bool ShowTNDonStartup;  // Show the telnet debugging window at startup
        public string SpeedTestURL;

        public string PingHost1;
        public string PingHost2;
    }


    public partial class Form1 : Form
    {

        delegate void StringParameterDelegate(string value);
        public delegate void InvokeDelegate();

        private iniparamsstruct IniParams = new iniparamsstruct();

        System.Timers.Timer PollingTimer;
        RouterComms rc;
        private Object PollingLock = new Object();


        #region Variables
        bool TelnetMode;
        int MessageCount;

        bool knobbledUI;        // Flag to control UI options
        bool AutoSinglePoll;    // Flag to auto poll on startup
        bool Paused;            // System is paused

        bool PollingEnabled;

        bool AdditionalInfo;

        int HistoryQty;         // Qty of stat History
        int HistoryQtyDispRate;         // Qty of stat History
        int PollTickCounter;
        bool PollInProgress;

        MQTT mqtt;

        // Ping stuff
        public enum PingStatusEnum { NoIP, FindingIP, FoundIP };
        public class PingStatusClass
        {
            public PingStatusEnum Status;
            public IPAddress IPAddress;
            public string Host;
            public string Results;
            public int Delay;

            public PingStatusClass()
            {
                PingStatusEnum Status = new PingStatusEnum();
                IPAddress IPAddress = new IPAddress(0);
                Delay = 0;
            }
        }
        public PingStatusClass[] PingStatus;
        #endregion


        #region LastEmailedValues
        // Last values emailed
        int LastXmitvalDownstreamRate;
        decimal LastXmitvalDownstreamSNR;
        decimal LastXmitvalDownstreamAttenuation;
        decimal LastXmitvalDownstreamPower;
        int LastXmitdownCRCerrors;
        int LastXmitdownHECerrors;
        int LastXmitdownFECerrors;

        int LastXmitvalUpstreamRate;
        decimal LastXmitvalUpstreamSNR;
        decimal LastXmitvalUpstreamAttenuation;
        decimal LastXmitvalUpstreamPower;
        int LastXmitupCRCerrors;
        int LastXmitupHECerrors;
        int LastXmitupFECerrors;
        #endregion


        #region LastLoggedValues
        DateTime LastLoggedTimeRecorded;
        int LastLoggedvalDownstreamRate;
        decimal LastLoggedvalDownstreamSNR;
        int LastLoggedvalUpstreamRate;
        decimal LastLoggedvalUpstreamSNR;
        #endregion


        #region Constructor
        public Form1(string[] args)
        {
            InitializeComponent();

            // Setup ping stuff
            PingStatus = new PingStatusClass[2];
            PingStatus[0] = new PingStatusClass();
            PingStatus[1] = new PingStatusClass();

            // Get the config from the config file
            ReadIniParameters();

            // Process the command line arguments and set the operating mode
            if (args.Length > 0)
            {
                if (args[0] == "quicktest")
                {
                    knobbledUI = true;
                    AutoSinglePoll = true;
                    Paused = true;          // Set to true to disable the timer
                    TelnetMode = false;
                    IniParams.AutoStart = false;
                    IniParams.ShowTNDonStartup = false;
                    IniParams.EmailEnabled = false;
                    IniParams.LogEnabled = false;
                }
            }
            else
            {
                knobbledUI = false;
                AutoSinglePoll = false;
                Paused = false;
                TelnetMode = false;
                PollTickCounter = IniParams.PollInterval;
                PollInProgress = false;
            }

            HistoryQtyDispRate = 20;
            HistoryQty = 100;


            // If UI knobbled then hide various controls
            if (knobbledUI)
            {
                Connect.Visible = false;
                Disconnect.Visible = false;
                Pause.Visible = false;
                Telnet.Visible = false;
                Graph.Visible = false;
                Config.Visible = false;
                Tones.Location = new Point(317, 5);
                HeaderBar.Visible = true;
                Showtelnetdisplay.Visible = false;
            }


            // Create and setup the routercomms object
            rc = new RouterComms(HistoryQty);
            rc.tn.ControlBox = false;       // Disable the control box icons
            rc.tn.disablekeypress = true;   // Disable key presses

            // Set buttons status
            Connect.Enabled = true;
            Disconnect.Enabled = false;
            Pause.Visible = false;
            Telnet.Enabled = false;
            Tones.Enabled = false;
            AdditionalInfo = false;

            UpdateStatus("Not Connected");

            // Create Timer and hook up the Elapsed event for the timer.
            PollingTimer = new System.Timers.Timer(1000);
            PollingTimer.Elapsed += new ElapsedEventHandler(PollingTimer_Tick);

            PollingEnabled = false;
            PollingTimer.Enabled = true;

            mqtt = new MQTT("routermonitor/5g", "10.20.0.40");
        }
        #endregion


        #region StartupControl
        // Bodge below to allow the program to run stuff after the form is displayed.
        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);
            Application.Idle += new EventHandler(OnLoaded);
        }

        // The code below run once the form is initialised and displayed
        // This will perform any startup procedures
        private void OnLoaded(object sender, EventArgs args)
        {
            Application.Idle -= new EventHandler(OnLoaded);

            // Show the telnet display if required
            Showtelnetdisplay.Checked = IniParams.ShowTNDonStartup;


            if (AutoSinglePoll == true)
            {
                if (ConnectRouter())
                {
                    Poll();                         // In this mode the program is paused so manual poll
                    Disconnect_Click(null, null);
                }
            }

            if (IniParams.AutoStart) Connect_Click(null, null);
        }
        #endregion


        #region ReadIniParameters
        void ReadIniParameters()
        {
            // Openup the ini file
            string inifile = Application.StartupPath + @"\config.ini";
            iniaccess ini = new iniaccess(inifile);

            IniParams.RouterModel = ini.GetIniFileString("Router", "RouterModel", "");
            IniParams.RouterRaiseTelnet = ini.GetIniFileBool("Router", "RaiseTelnet", true);
            IniParams.RouterTelnetAllowed = ini.GetIniFileBool("Router", "TelnetAllowed", true);
            IniParams.ModemType = ini.GetIniFileString("Router", "ModemType", "ADSL");
            IniParams.RouterIPAddress = ini.GetIniFileString("Router", "IP", "192.168.1.1");
            IniParams.RouterUsername = ini.GetIniFileString("Router", "RouterUsername", "");

            Configuration cnf = new Configuration();
            IniParams.RouterPassword = cnf.Decrypt(ini.GetIniFileString("Router", "Password", ""));
            IniParams.PollInterval = Convert.ToInt32(ini.GetIniFileString("Router", "PollInterval", "60"));
            PollTickCounter = IniParams.PollInterval;

            IniParams.EmailEnabled = ini.GetIniFileBool("Email", "Enabled", false);
            IniParams.EmailSMTPServer = ini.GetIniFileString("Email", "SMTPServer", "");
            IniParams.EmailFromAddress = ini.GetIniFileString("Email", "From", "");
            IniParams.EmailToAddress = ini.GetIniFileString("Email", "To", "");
            IniParams.EmailOnSyncChange = ini.GetIniFileBool("Email", "EmailOnSyncChange", false);
            IniParams.EmailOnUpwards = ini.GetIniFileBool("Email", "EmailOnUpwards", false);
            IniParams.EmailOnDownwards = ini.GetIniFileBool("Email", "EmailOnDownwards", false);
            IniParams.EmailOnIncreasing = ini.GetIniFileBool("Email", "EmailOnIncreasing", false); ;
            IniParams.EmailOnIncreasingPollCount = Convert.ToInt32(ini.GetIniFileString("Email", "EmailOnIncreasingPollCount", "10"));
            IniParams.EmailOnVarLine = ini.GetIniFileBool("Email", "EmailOnVarLine", false); ;
            IniParams.EmailOnVarLinePollCount = Convert.ToInt32(ini.GetIniFileString("Email", "EmailOnVarLinePollCount", "15"));

            IniParams.LogEnabled = ini.GetIniFileBool("Logging", "Enabled", false);
            IniParams.LogChangesOnly = ini.GetIniFileBool("Logging", "LogChangesOnly", true);
            IniParams.LogFilename = ini.GetIniFileString("Logging", "Filename", Application.StartupPath + @"\log.csv");

            IniParams.AutoStart = ini.GetIniFileBool("Startup", "AutoConnect", false);
            IniParams.ShowTNDonStartup = ini.GetIniFileBool("Startup", "ShowTelnet", false);
            IniParams.SpeedTestURL = ini.GetIniFileString("SpeedTest", "URL", "");


            PingStatus[0].Host = ini.GetIniFileString("Pings", "PingHost1", "");
            PingStatus[1].Host = ini.GetIniFileString("Pings", "PingHost2", "");
            PingStatus[0].Status = PingStatusEnum.NoIP;
            PingStatus[1].Status = PingStatusEnum.NoIP;

            UpdateControls();
        }
        #endregion


        #region UpdateScreenControls
        void UpdateControls()
        {
            if (IniParams.ModemType == "ADSL")
            {
                label2_1.Text = "Sync Rate";
                label2_2.Text = "SNR";
                label2_3.Text = "Power";
                label2_4.Text = "Attenuation";
                label2_5.Text = "CRC Errors";
                label2_6.Text = "Header Errors";
                label2_7.Text = "FE Corrections";
                label2_8.Text = "Rx Packets";
                label3_1.Text = "Sync Rate";
                label3_2.Text = "SNR";
                label3_3.Text = "Power";
                label3_4.Text = "Attenuation";
                label3_5.Text = "CRC Errors";
                label3_6.Text = "Header Errors";
                label3_7.Text = "FE Corrections";
                label3_8.Text = "Tx Packets";
            }

            if (IniParams.ModemType == "5G")
            {
                label2_1.Text = "Cell ID";
                label2_2.Text = "Band";
                label2_3.Text = "RSRP";
                label2_4.Text = "SINR";
                label2_5.Text = "PCI";
                label2_6.Text = "EARFN";
                label2_7.Text = "";
                label2_8.Text = "";
                label3_1.Text = "Band";
                label3_2.Text = "RSRP";
                label3_3.Text = "SINR";
                label3_4.Text = "PCI";
                label3_5.Text = "NRARFCN";
                label3_6.Text = "";
                label3_7.Text = "";
                label3_8.Text = "";
            }
        }

        void UpdateStatus(string value)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UpdateStatus), new object[] { value });
                return;
            }
            // Must be on the UI thread if we've got this far
            Status.Text = value;
            Status.Update();
        }

        void UpdateRouterStatus()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new InvokeDelegate(UpdateRouterStatus));
                return;
            }

            //Create CultureInfo and TextInfo classes to use ToTitleCase method
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            if (IniParams.ModemType == "ADSL")
            {
                // Display the results on screen
                // -----------------------------
                text2_1.Text = rc.RouterStats.Download[0].ToString() + " kbps";
                text3_1.Text = rc.RouterStats.Upload[0].ToString() + " kbps";

                text2_2.Text = rc.RouterStats.downstreamsnr[0].ToString() + " db";
                text3_2.Text = rc.RouterStats.upstreamsnr[0].ToString() + " db";

                text2_3.Text = rc.RouterStats.downstreampower[0].ToString() + " db";
                text3_3.Text = rc.RouterStats.upstreampower[0].ToString() + " db";

                text2_4.Text = rc.RouterStats.downstreamatt[0].ToString() + " db";
                text3_4.Text = rc.RouterStats.upstreamatt[0].ToString() + " db";

                text2_5.Text = rc.RouterStats.downCRCerrors[0].ToString();
                text2_6.Text = rc.RouterStats.downHECerrors[0].ToString();
                text2_7.Text = rc.RouterStats.downFECerrors[0].ToString();

                text3_5.Text = rc.RouterStats.upCRCerrors[0].ToString();
                text3_6.Text = rc.RouterStats.upHECerrors[0].ToString();
                text3_7.Text = rc.RouterStats.upFECerrors[0].ToString();

                text2_8.Text = rc.RouterStats.RxPckts.ToString();
                text3_8.Text = rc.RouterStats.TxPckts.ToString();
            }

            if (IniParams.ModemType == "5G")
            {
                text2_1.Text = rc.RouterStats.mLTE_CellId[0].ToString();

                StringBuilder sb = new StringBuilder();
                if (rc.RouterStats.mLTE_CAPrimaryBand[0] > 1)
                {
                    sb.Append("B" + rc.RouterStats.mLTE_CAPrimaryBand[0].ToString() + " (" + rc.RouterStats.mLTE_CAPrimaryBandwidth[0].ToString() + "MHz)");
                    if (rc.RouterStats.mLTE_CA1Band[0] > 1)
                    {
                        sb.Append(" + B" + rc.RouterStats.mLTE_CA1Band[0].ToString() + " (" + rc.RouterStats.mLTE_CA1Bandwidth[0].ToString() + "MHz)");
                    }
                    text2_2.Text = sb.ToString();
                }
                else
                {
                    text2_2.Text = rc.RouterStats.mLTE_ActiveBand[0];
                }

                text2_3.Text = rc.RouterStats.mLTE_RSRP[0].ToString() + " dBm";
                text2_4.Text = rc.RouterStats.mLTE_SINR[0].ToString() + " dB";
                text2_5.Text = rc.RouterStats.mLTE_PCI[0].ToString();
                text2_6.Text = rc.RouterStats.mLTE_EARFCN[0].ToString();
                text2_7.Text = "";
                text2_8.Text = "";

                text3_1.Text = rc.RouterStats.m5G_Band[0].ToString();
                text3_2.Text = rc.RouterStats.m5G_RSRP[0].ToString() + " dBm";
                text3_3.Text = rc.RouterStats.m5G_SINR[0].ToString() + " dB";
                text3_4.Text = rc.RouterStats.m5G_PCI[0].ToString();
                text3_5.Text = rc.RouterStats.m5G_NRARFCN[0].ToString();
                text3_6.Text = "";
                text3_7.Text = "";
                text3_8.Text = "";
            }

            DSLMode.Text = "DSL Mode : " + rc.RouterStats.dslmode[0];
            if (rc.RouterStats.dslstatus != null) DSLStatus.Text = "DSL Status : " + textInfo.ToTitleCase(rc.RouterStats.dslstatus[0]);
            WanIP.Text = "WAN IP : " + rc.RouterStats.wanip[0];

            Firmware.Text = "Firmware : " + rc.RouterStats.Firmware;
            Hostname.Text = "Hostname : " + rc.RouterStats.Hostname;

            WanSecDNS.Text = "Seconday DNS : " + rc.RouterStats.WanSecDns;
            WanPriDNS.Text = "Primary DNS : " + rc.RouterStats.WanPriDns;
            WanConnType.Text = "PPP Mode : " + rc.RouterStats.PPPMode;
            SerialNo.Text = "Serial No. : " + rc.RouterStats.SerialNo;
            ADSLVer.Text = "ADSL Ver : " + rc.RouterStats.DSLVer;
            HardwareVer.Text = "Hardware Ver : " + rc.RouterStats.HardwareVer;
            DSPVer.Text = "DSP Ver : " + rc.RouterStats.DSPVer;
            WireLessVer.Text = "Wireless ver : " + rc.RouterStats.WirelessVer;
            BootLoaderVer.Text = "Bootloader Ver : " + rc.RouterStats.BootLoaderVer;
            WifiMAC.Text = "WiFi MAC : " + rc.RouterStats.WifiMAC;
            WifiSSID.Text = "WifI SSID : " + rc.RouterStats.WifiSSID;
            WifiChannel.Text = "WiFi Channel : " + rc.RouterStats.WifiChannel;
            LANMac.Text = "LAN MAC : " + rc.RouterStats.LanMAC;
            WanMAC.Text = "WAN MAC : " + rc.RouterStats.WanMAC;

            DSLUpTime.Text = "DSL Up time : " + rc.RouterStats.DSLUpTime;


            Ping1.Text = PingStatus[0].Results;
            Ping2.Text = PingStatus[1].Results;

            this.Text = "DSL Monitor - " + rc.RouterStats.Model + " [Up time : " + rc.RouterStats.SysUpTime + "]";

            if (rc.RouterStats.dslfastint[0] != "")
            {
                DSLFastInt.Text = "DSL Conn : " + rc.RouterStats.dslfastint;
            }
            else
            {
                if (rc.RouterStats.DownloadInt[0] > rc.RouterStats.DownloadFast[0])
                {
                    DSLFastInt.Text = "DSL Conn : Interleaved";
                }
                else
                {
                    if (rc.RouterStats.DownloadInt[0] < rc.RouterStats.DownloadFast[0])
                    {
                        DSLFastInt.Text = "DSL Conn : Fast";
                    }
                    else
                    {
                        DSLFastInt.Text = "DSL Conn :";
                    }
                }
            }
        }

        void UpdatePingStatus()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new InvokeDelegate(UpdatePingStatus));
                return;
            }

            //Create CultureInfo and TextInfo classes to use ToTitleCase method
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;


            Ping1.Text = PingStatus[0].Results;
            Ping2.Text = PingStatus[1].Results;
        }
        #endregion


        #region ClearDownStorage
        void ClearDownStorage()
        {
            rc.RouterStats.Clear();

            // Initialise last emailed values          
            LastXmitvalDownstreamRate = -1;
            LastXmitvalDownstreamSNR = -1;
            LastXmitvalDownstreamAttenuation = -1;
            LastXmitvalDownstreamPower = -1;
            LastXmitdownCRCerrors = -1;
            LastXmitdownHECerrors = -1;
            LastXmitdownFECerrors = -1;

            LastXmitvalUpstreamRate = -1;
            LastXmitvalUpstreamSNR = -1;
            LastXmitvalUpstreamAttenuation = -1;
            LastXmitvalUpstreamPower = -1;
            LastXmitupCRCerrors = -1;
            LastXmitupHECerrors = -1;
            LastXmitupFECerrors = -1;

            LastLoggedvalDownstreamRate = -1;
            LastLoggedvalDownstreamSNR = -1;
            LastLoggedvalUpstreamRate = -1;
            LastLoggedvalUpstreamSNR = -1;
        }
        #endregion


        #region Connect & Disconnect
        private bool ConnectRouter()
        {
            // Clear down the storage
            ClearDownStorage();
            UpdateStatus("Connecting...");

            rc.RouterConfigPath = Application.StartupPath + @"\RouterConfigs";
            rc.RouterModel = IniParams.RouterModel;
            rc.RouterUsername = IniParams.RouterUsername;
            rc.RouterPassword = IniParams.RouterPassword;
            rc.ModemType = IniParams.ModemType;
            rc.ipaddress = IniParams.RouterIPAddress;
            rc.Debug = Showtelnetdisplay.Checked;

            Connect.Enabled = false;

            if (IniParams.RouterRaiseTelnet)
            {
                // Connect to telnet interface
                if (!rc.Connect())
                {
                    Disconnect_Click(null, null);
                    MessageBox.Show("Cannot connect to router. Check password!", "Error");
                    return false;
                }
            }

            // Login
            if (!rc.Login())
            {
                Disconnect_Click(null, null);
                MessageBox.Show("Cannot logon to router. Check password!", "Error");
                return false;
            }

            Disconnect.Enabled = true;
            Telnet.Enabled = IniParams.RouterTelnetAllowed;
            Pause.Visible = true;
            Connect.Visible = false;

            // Get the preliminary info
            if (!rc.GetPrelimaryInfo())
            {
                Disconnect_Click(null, null);
                return false;
            }

            UpdateRouterStatus();

            // Set buttons
            UpdateStatus("Connected");
            PollTickCounter = 0;
            PollingEnabled = true;

            return true;
        }

        private void DisconnectRouter()
        {
            PollingEnabled = false;

            // Wait to get the lock on the pollprogress variable
            lock (PollingLock)
            {
                // Wait until the current poll completed
                while (PollInProgress)
                {
                    Thread.Sleep(100);
                }
            }

            // Additional delay to ensure poll has cleaned up
            Thread.Sleep(50);

            rc.Disconnect();
            Connect.Enabled = true;
            Disconnect.Enabled = false;
            Connect.Visible = true;
            Pause.Visible = false;
            Telnet.Enabled = false;

            UpdateStatus("Not Connected");
        }
        #endregion


        #region Button Handlers
        private void Connect_Click(object sender, EventArgs e)
        {
            ConnectRouter();
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            DisconnectRouter();
        }
        
        private void Tones_Click(object sender, EventArgs e)
        {
            Tones tonewindow = new Tones();
            tonewindow.tones = rc.tones;
            tonewindow.ShowDialog();
        }

        private void Config_Click(object sender, EventArgs e)
        {
            Configuration cfg = new Configuration();
            cfg.LoadConfig();
            if (cfg.ShowDialog() == DialogResult.OK)
                ReadIniParameters();
        }

        private void Graph_Click(object sender, EventArgs e)
        {
            PerfGraph pg = new PerfGraph();
            pg.LogFilename = IniParams.LogFilename;
            pg.ShowDialog();
        }

        private void Information_Click(object sender, EventArgs e)
        {
            About inf = new About();
            inf.ShowDialog();
            ReadIniParameters();
        }

        private void Telnet_Click(object sender, EventArgs e)
        {
            if (Connect.Enabled == false)
            {
                // Wait to get the lock on the pollprogress variable
                bool polling = true;
                while (polling)
                {
                    // Wait until we have the lock
                    lock (PollingLock)
                    {
                        polling = PollInProgress;
                    }
                    Thread.Sleep(100);
                }

                if (TelnetMode == false)
                {
                    Showtelnetdisplay.Enabled = false;
                    PollingTimer.Enabled = false;
                    rc.tn.disablekeypress = false;
                    TelnetMode = true;
                    Pause.Enabled = false;
                    Disconnect.Enabled = false;
                    // Clear virtual screen
                    rc.tn.VirtualScreen.CleanScreen();
                    //rc.tn.TelnetWindow.Text = rc.tn.VirtualScreen.Hardcopy().Replace("\n", "\r\n");
                    // Set router into normal config mode
                    rc.TelnetMode();

                    if (!rc.tn.Visible)
                    {
                        rc.tn.Show();
                    }
                }
                else
                {
                    TelnetMode = false;

                    rc.Disconnect();
                    if (!Showtelnetdisplay.Checked)
                    {
                        rc.tn.Hide();
                    }
                    Thread.Sleep(1000);
                    rc.tn.disablekeypress = true;
                    Showtelnetdisplay.Enabled = true;
                    Pause.Enabled = true;
                    Disconnect.Enabled = true;
                    Connect_Click(null, null);
                }
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (Connect.Enabled == false)
            {
                if (!Paused)
                {
                    // Wait to get the lock on the pollprogress variable
                    bool polling = true;
                    while (polling) {
                        // Wait until we have the lock
                        lock (PollingLock)
                        {
                            polling = PollInProgress;
                        }
                        Thread.Sleep(100);
                    }

                    // Additional delay to ensure poll has cleaned up
                    Thread.Sleep(50);

                    Paused = true;
                    UpdateStatus("Paused...");
                }
                else
                {
                    Paused = false;
                    PollingTimer_Tick(null, null);
                    UpdateStatus("Connected");
                }
            }
        }

        private void SpeedTest_Click(object sender, EventArgs e)
        {
            if (IniParams.SpeedTestURL != "")
            {
                SpeedTest sp = new SpeedTest();
                sp.Browser.Url = new Uri(IniParams.SpeedTestURL);
                sp.ShowDialog();
            }

        }

        private void AdditionalInfo_Click(object sender, EventArgs e)
        {
            if (!AdditionalInfo)
            {
                this.Size = new System.Drawing.Size(645, 546);
                AdditionalInfo = true;
                return;
            }
            else
            {
                this.Size = new System.Drawing.Size(428, 546);
                AdditionalInfo = false;
                return;
            }
        }

        private void Showtelnetdisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (IniParams.RouterRaiseTelnet)
            {
                if (Showtelnetdisplay.Checked)
                {
                    rc.tn.Show();
                }
                else
                {
                    rc.tn.Hide();
                }
            }

        }
        #endregion


        #region Timer Tick
        private void PollingTimer_Tick(object sender, EventArgs e)
        {
            if ((PollingEnabled) && (!Paused)) {
                PollTickCounter--;
                lock (PollingLock)
                {
                    if (!PollInProgress)
                    {
                        if (PollTickCounter <= 0)
                        {
                            PollTickCounter = IniParams.PollInterval;
                            Poll();
                        }
                        else
                        {
                            UpdateStatus("Polling in " + PollTickCounter.ToString() + " seconds.");
                        }
                    }
                }
            }

            PingHost(1);
            PingHost(2);
        }
        #endregion


        #region MinMax functions
        private int Max(int a, int b)
        {
            if (a > b) { return a; } else { return b; }
        }

        private int Min(int a, int b)
        {
            if (a < b) { return a; } else { return b; }
        }

        private decimal Max(decimal a, decimal b)
        {
            if (a > b) { return a; } else { return b; }
        }

        private decimal Min(decimal a, decimal b)
        {
            if (a < b) { return a; } else { return b; }
        }
        #endregion


        private void Poll()
        {
            // Wait for lock and update on the PollingInProgress variable
            lock (PollingLock) {
                PollInProgress = true;
            }

            UpdateStatus("Polling...");

            rc.RouterStats.RollHistory();

            MessageCount++;

            // Get information from the router
            rc.Poll();

            rc.RouterStats.Summarise();

            UpdateRouterStatus();

            MQTTPublish();

            // Write the stats to a file
            if (IniParams.LogEnabled) LogEntry();


            // Email the entry
            if (IniParams.EmailEnabled) EmailEntry();


            // Enable the Tone button
            Tones.Enabled = rc.RouterStats.receivedtones;


            // Wait for lock and update on the PollingInProgress variable
            lock (PollingLock)
            {
                PollInProgress = false;
            }
        }

        private void MQTTPublish()
        {
            if (rc.RouterStats.wanip[0] != rc.RouterStats.wanip[1]) mqtt.Publish_Application_Message("wanip", rc.RouterStats.wanip[0]);
            if (rc.RouterStats.mLTE_NetworkType[0] != rc.RouterStats.mLTE_NetworkType[1]) mqtt.Publish_Application_Message("LTE_NetworkType", rc.RouterStats.mLTE_NetworkType[0]);
            if (rc.RouterStats.mLTE_CellId[0] != rc.RouterStats.mLTE_CellId[1]) mqtt.Publish_Application_Message("LTE_CellId", rc.RouterStats.mLTE_CellId[0]);
            if (rc.RouterStats.mLTE_CAPrimaryBand[0] != rc.RouterStats.mLTE_CAPrimaryBand[1]) mqtt.Publish_Application_Message("LTE_CAPrimaryBand", rc.RouterStats.mLTE_CAPrimaryBand[0]);
            if (rc.RouterStats.mLTE_CAPrimaryBandwidth[0] != rc.RouterStats.mLTE_CAPrimaryBandwidth[1]) mqtt.Publish_Application_Message("LTE_CAPrimaryBandwidth", rc.RouterStats.mLTE_CAPrimaryBandwidth[0]);
            if (rc.RouterStats.mLTE_CA1Band[0] != rc.RouterStats.mLTE_CA1Band[1]) mqtt.Publish_Application_Message("LTE_CA1Band", rc.RouterStats.mLTE_CA1Band[0]);
            if (rc.RouterStats.mLTE_CA1Bandwidth[0] != rc.RouterStats.mLTE_CA1Bandwidth[1]) mqtt.Publish_Application_Message("LTE_CA1Bandwidth", rc.RouterStats.mLTE_CA1Bandwidth[0]);
            if (rc.RouterStats.mLTE_RSRP[0] != rc.RouterStats.mLTE_RSRP[1]) mqtt.Publish_Application_Message("LTE_RSRP", rc.RouterStats.mLTE_RSRP[0]);
            if (rc.RouterStats.mLTE_SINR[0] != rc.RouterStats.mLTE_SINR[1]) mqtt.Publish_Application_Message("LTE_SINR", rc.RouterStats.mLTE_SINR[0]);
            if (rc.RouterStats.mLTE_PCI[0] != rc.RouterStats.mLTE_PCI[1]) mqtt.Publish_Application_Message("LTE_PCI", rc.RouterStats.mLTE_PCI[0]);
            if (rc.RouterStats.mLTE_EARFCN[0] != rc.RouterStats.mLTE_EARFCN[1]) mqtt.Publish_Application_Message("LTE_EARFCN", rc.RouterStats.mLTE_EARFCN[0]);
            if (rc.RouterStats.m5G_Band[0] != rc.RouterStats.m5G_Band[1]) mqtt.Publish_Application_Message("5G_Band", rc.RouterStats.m5G_Band[0]);
            if (rc.RouterStats.m5G_NRARFCN[0] != rc.RouterStats.m5G_NRARFCN[1]) mqtt.Publish_Application_Message("5G_NRARFCN", rc.RouterStats.m5G_NRARFCN[0]);
            if (rc.RouterStats.m5G_PCI[0] != rc.RouterStats.m5G_PCI[1]) mqtt.Publish_Application_Message("5G_PCI", rc.RouterStats.m5G_PCI[0]);
            if (rc.RouterStats.m5G_RSRP[0] != rc.RouterStats.m5G_RSRP[1]) mqtt.Publish_Application_Message("5G_RSRP", rc.RouterStats.m5G_RSRP[0]);
            if (rc.RouterStats.m5G_SINR[0] != rc.RouterStats.m5G_SINR[1]) mqtt.Publish_Application_Message("5G_SINR", rc.RouterStats.m5G_SINR[0]);
        }


        #region Logging and Emailing
        private void LogEntry()
        {
            bool Log = false;
            bool Changed = false;

            // If we are logging every thing then set log to true
            if (!IniParams.LogChangesOnly) { Log = true; }

            // This only relevant if we are logging changes only.
            // If we last logged ten minutes go then set log to true
            if (DateTime.Now > LastLoggedTimeRecorded + TimeSpan.FromMinutes(10)) { Log = true; }

            // This only relevant if we are logging changes only.
            // If there has been a change then set log to true and set changed to true
            if (LastLoggedvalDownstreamRate == -1) {
                // First time around. Log initial values
                Log = true;
            } else {
                if ((rc.RouterStats.Download[0] != LastLoggedvalDownstreamRate) ||
                    (rc.RouterStats.downstreamsnr[0] != LastLoggedvalDownstreamSNR) ||
                    (rc.RouterStats.Upload[0] != LastLoggedvalUpstreamRate) ||
                    (rc.RouterStats.upstreamsnr[0] != LastLoggedvalUpstreamSNR)) {
                    // The current stats are different from the last logged values.
                    Log = true;
                    // There is attribute chance the last set have allready been logged
                    if (rc.RouterStats.TimeRecorded[1] != LastLoggedTimeRecorded)
                    {

                        Changed = true;
                    }
                }
            }



            if (Log)
            {
                // At this point we are either logging all polls or there has been a change
                try
                {
                    StreamWriter sw = null;

                    if (!File.Exists(IniParams.LogFilename))
                    {
                        sw = File.CreateText(IniParams.LogFilename);
                        sw.WriteLine("Date and Time,Down Rate,Down SNR,Up Rate,Up SNR");
                    }
                    else
                    {
                        sw = File.AppendText(IniParams.LogFilename);
                    }


                    // If we are only logging changes and the
                    // vlaues have changes then log the last value
                    if ((IniParams.LogChangesOnly) && (Changed))
                    {
                        sw.WriteLine(/*"A" + test.ToString() + " " + */rc.RouterStats.TimeRecorded[1].ToString() + "," +
                            rc.RouterStats.Download[1].ToString() + "," +
                            rc.RouterStats.downstreamsnr[1].ToString() + "," +
                            rc.RouterStats.Upload[1].ToString() + "," +
                            rc.RouterStats.upstreamsnr[1].ToString());
                    }

                    // Write the current details               
                    sw.WriteLine(/*"C" +test.ToString() + " " + */rc.RouterStats.TimeRecorded[0].ToString() + "," +
                        rc.RouterStats.Download[0].ToString() + "," +
                        rc.RouterStats.downstreamsnr[0].ToString() + "," +
                        rc.RouterStats.Upload[0].ToString() + "," +
                        rc.RouterStats.upstreamsnr[0].ToString());

                    sw.Close();


                }
                catch
                {
                    MessageBox.Show("ERROR");
                }

                // Log this entry
                LastLoggedTimeRecorded = rc.RouterStats.TimeRecorded[0];
                LastLoggedvalDownstreamRate = rc.RouterStats.Download[0];
                LastLoggedvalDownstreamSNR = rc.RouterStats.downstreamsnr[0];
                LastLoggedvalUpstreamRate = rc.RouterStats.Upload[0];
                LastLoggedvalUpstreamSNR = rc.RouterStats.upstreamsnr[0];
                //test++;
            }
        }


        private void EmailEntry()
        {
            // First check for any changes in stats
            // ------------------------------------

            // Assume no changes
            bool changed = false;


            // Check for sync rate changes
            if (IniParams.EmailOnSyncChange)
            {
                if (rc.RouterStats.Download[0] != rc.RouterStats.Download[1]) changed = true;
                if (rc.RouterStats.Upload[0] != rc.RouterStats.Upload[1]) changed = true;
            }


            // Check for downwards SNR changes
            if (IniParams.EmailOnDownwards)
            {
                if (rc.RouterStats.downstreamsnr[0] < LastXmitvalDownstreamSNR) changed = true;
                if (rc.RouterStats.upstreamsnr[0] < LastXmitvalUpstreamSNR) changed = true;
            }


            // Check for upwards SNR changes
            if (IniParams.EmailOnUpwards)
            {
                if (rc.RouterStats.downstreamsnr[0] > LastXmitvalDownstreamSNR) changed = true;
                if (rc.RouterStats.upstreamsnr[0] > LastXmitvalUpstreamSNR) changed = true;
            }


            // Check for gradually increasing snr
            if (IniParams.EmailOnIncreasing)
            {
                decimal Mindwnsnr = 99;
                decimal Minupsnr = 99;

                for (int c = 0; c < IniParams.EmailOnIncreasingPollCount; c++)
                {
                    if (rc.RouterStats.downstreamsnr[c] > 0) Mindwnsnr = Min(Mindwnsnr, rc.RouterStats.downstreamsnr[c]);
                    if (rc.RouterStats.upstreamsnr[c] > 0) Minupsnr = Min(Minupsnr, rc.RouterStats.upstreamsnr[c]);
                }

                if (Mindwnsnr > LastXmitvalDownstreamSNR) changed = true;
                if (Minupsnr > LastXmitvalUpstreamSNR) changed = true;
            }
 


            // Check for upward/noisy SNR changes
            if (IniParams.EmailOnVarLine)
            {
                decimal Maxdwnsnr = 0;
                decimal Maxupsnr = 0;
                decimal Mindwnsnr = 99;
                decimal Minupsnr = 99;

                // Find the minimum and maximum out of the last 'n' readings
                for (int c = 0; c < IniParams.EmailOnVarLinePollCount; c++)
                {
                    Maxdwnsnr = Max(Maxdwnsnr, rc.RouterStats.downstreamsnr[c]);
                    Maxupsnr = Max(Maxupsnr, rc.RouterStats.upstreamsnr[c]);
                    if (rc.RouterStats.downstreamsnr[c] > 0) Mindwnsnr = Min(Mindwnsnr, rc.RouterStats.downstreamsnr[c]);
                    if (rc.RouterStats.upstreamsnr[c] > 0) Minupsnr = Min(Minupsnr, rc.RouterStats.upstreamsnr[c]);
                }

                // Check if the last 'n' readings for noise
                if ((Maxdwnsnr - Mindwnsnr > 1) || (Maxupsnr - Minupsnr > 1))
                {
                    if (MessageCount > IniParams.EmailOnVarLinePollCount) changed = true;
                }
            }


            // If values change then send the email
            // ------------------------------------
            if (changed) {
                // Build the email notification
                StringBuilder sb = new StringBuilder();

                sb.Insert(0, "Changed properties marked with *\r\n\r\n");

                if (rc.RouterStats.Download[0] != LastXmitvalDownstreamRate) sb.Append("*"); 
                sb.Append("Downstream Rate " + rc.RouterStats.Download[0].ToString() + " kbps.\r\n");

                if (rc.RouterStats.downstreamsnr[0] != LastXmitvalDownstreamSNR) sb.Append("*");
                sb.Append("Downstream SNR " + rc.RouterStats.downstreamsnr[0].ToString() + " db.\r\n");

                if (rc.RouterStats.Upload[0] != LastXmitvalUpstreamRate) sb.Append("*");
                sb.Append("Upstream Rate " + rc.RouterStats.Upload[0].ToString() + " kbps.\r\n");

                if (rc.RouterStats.upstreamsnr[0] != LastXmitvalUpstreamSNR) sb.Append("*");
                sb.Append("Uptream SNR " + rc.RouterStats.upstreamsnr[0].ToString() + " db.\r\n");


                // Display the stats history
                sb.Append("\r\nDownstream Rate History - ");
                for (int i = 0; i < HistoryQtyDispRate; i++)
                {
                    sb.Append(rc.RouterStats.Download[i].ToString());
                    if (i < HistoryQtyDispRate - 1) { sb.Append(", "); } else { sb.Append(".\r\n\r\n"); }
                } 

                sb.Append("Downstream SNR History - ");
                for (int i = 0; i < HistoryQty; i++)
                {
                    sb.Append(rc.RouterStats.downstreamsnr[i].ToString());
                    if (i < HistoryQty - 1) { sb.Append(", "); } else { sb.Append(".\r\n\r\n"); }
                }

                sb.Append("Upload Rate History - ");
                for (int i = 0; i < HistoryQtyDispRate; i++)
                {
                    sb.Append(rc.RouterStats.Upload[i].ToString());
                    if (i < HistoryQtyDispRate - 1) { sb.Append(", "); } else { sb.Append(".\r\n\r\n"); }
                } 

                sb.Append("Upload SNR History - ");
                for (int i = 0; i < HistoryQty; i++)
                {
                    sb.Append(rc.RouterStats.upstreamsnr[i].ToString());
                    if (i < HistoryQty - 1) { sb.Append(", "); } else { sb.Append(".\r\n\r\n"); }
                }

                SendMail(sb);

                // Set last transmitted values
                LastXmitvalDownstreamRate = rc.RouterStats.Download[0];
                LastXmitvalDownstreamSNR = rc.RouterStats.downstreamsnr[0];
                LastXmitvalDownstreamAttenuation = rc.RouterStats.downstreamatt[0];
                LastXmitvalDownstreamPower = rc.RouterStats.downstreampower[0];
                LastXmitdownCRCerrors = rc.RouterStats.downCRCerrors[0];
                LastXmitdownHECerrors = rc.RouterStats.downHECerrors[0];
                LastXmitdownFECerrors = rc.RouterStats.downFECerrors[0];

                LastXmitvalUpstreamRate = rc.RouterStats.Upload[0];
                LastXmitvalUpstreamSNR = rc.RouterStats.upstreamsnr[0];
                LastXmitvalUpstreamAttenuation = rc.RouterStats.upstreamatt[0];
                LastXmitvalUpstreamPower = rc.RouterStats.upstreampower[0];
                LastXmitupCRCerrors = rc.RouterStats.upCRCerrors[0];
                LastXmitupHECerrors = rc.RouterStats.upHECerrors[0];
                LastXmitupFECerrors = rc.RouterStats.upFECerrors[0];

                MessageCount = 0;
            }
        }


        private void SendMail(StringBuilder messtr)
        {
    
            MailMessage message = new MailMessage(
                IniParams.EmailFromAddress,
                IniParams.EmailToAddress,
                "Router Report",
                messtr.ToString());

            SmtpClient client = new SmtpClient(IniParams.EmailSMTPServer);
            // Add credentials if the SMTP server requires them.
            //client.Credentials = CredentialCache.DefaultNetworkCredentials;
            try
            {
                client.Send(message);
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, "Mail send error.");
            }
        }
        #endregion


        #region PingTests
        private void PingHost(int pingno)
        {
            pingno--;
            
            // This gets called every second, process any delay
            PingStatus[pingno].Delay--;
            if (PingStatus[pingno].Delay > 0) return;        

            if (PingStatus[pingno].Status == PingStatusEnum.NoIP)
            {
                if (PingStatus[pingno].Host != "")
                {
                    // We do not know the IP for this host. Try to find it.
                    PingStatus[pingno].Status = PingStatusEnum.FindingIP;
                    IAsyncResult asyncResult = Dns.BeginGetHostEntry(PingStatus[pingno].Host, new AsyncCallback(RespCallback), PingStatus[pingno]);
                    PingStatus[pingno].Results = PingStatus[pingno].Host + "  - Finding IP address";
                }
                else
                {
                    PingStatus[pingno].Results = "No Host Specified!";
                }
                UpdatePingStatus();
            }

            if (PingStatus[pingno].Status == PingStatusEnum.FindingIP)
            {
                if (PingStatus[pingno].Results.Length > 50)
                {
                    PingStatus[pingno].Results = PingStatus[pingno].Host + "  - Finding IP address";
                }
                else
                {
                    PingStatus[pingno].Results = PingStatus[pingno].Results + ".";
                }
                UpdatePingStatus();
            }

            if (PingStatus[pingno].Status == PingStatusEnum.FoundIP)
            {
                PerformPing(PingStatus[pingno]);
            }


        }

        public void PerformPing(PingStatusClass PS)
        {
            if (PS.Status == PingStatusEnum.FoundIP)
            {
                PS.Delay = 1;
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                options.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 500;
                try
                {
                    PingReply reply = pingSender.Send(PS.IPAddress, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                        PS.Results = PS.Host + "  (" + reply.Address + ") : Success - " + reply.RoundtripTime + "ms";
                    }
                    else
                    {
                        PS.Results = PS.Host + "  (" + reply.Address + ") : Failure";
                    }
                }
                catch
                {
                    PS.Results = PS.Host + "  () : Failure";
                }
                UpdatePingStatus();
                return;
            }
        }

        private void RespCallback(IAsyncResult ar)
        {
            PingStatusClass PS = null;

            try
            {
                // Convert the IAsyncResult object to a RequestState object.
                //RequestState tempRequestState = (RequestState)ar.AsyncState;
                PS = (PingStatusClass)ar.AsyncState;

                // End the asynchronous request.
                IPHostEntry iph = Dns.EndGetHostEntry(ar);

                PS.IPAddress = iph.AddressList[0];
                PS.Status = PingStatusEnum.FoundIP;
                PerformPing(PS);
            }
            catch (ArgumentNullException e)
            {
                if (PS != null)
                {
                    PS.Status = PingStatusEnum.NoIP;
                    PS.Results = PS.Host + "  - Unable to resolve address";
                    PS.Delay = 10;
                    UpdatePingStatus();
                }
            }
            catch (Exception e)
            {
                if (PS != null)
                {
                    PS.Status = PingStatusEnum.NoIP;
                    PS.Results = PS.Host + "  - Unable to resolve address";
                    PS.Delay = 10;
                    UpdatePingStatus();
                }
            }
        }

        #endregion

        private void Upstream_Enter(object sender, EventArgs e)
        {

        }
    }
}