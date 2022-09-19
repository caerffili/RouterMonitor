namespace RouterMonitor
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
            this.Connect = new System.Windows.Forms.Button();
            this.Downstream = new System.Windows.Forms.GroupBox();
            this.RxPckts = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DownstreamFECs = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DownstreamHeaderErrors = new System.Windows.Forms.Label();
            this.DownstreamCRCErrors = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DownstreamAttenuation = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DownstreamRate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DownstreamPower = new System.Windows.Forms.Label();
            this.DownstreamSNR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Upstream = new System.Windows.Forms.GroupBox();
            this.TxPckts = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.UpstreamFECs = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.UpstreamHeaderErrors = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.UpstreamCRCErrors = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.UpstreamAttenuation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UpstreamPower = new System.Windows.Forms.Label();
            this.UpstreamRate = new System.Windows.Forms.Label();
            this.UpstreamSNR = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.Disconnect = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Tones = new System.Windows.Forms.Button();
            this.Telnet = new System.Windows.Forms.Button();
            this.Config = new System.Windows.Forms.Button();
            this.Graph = new System.Windows.Forms.Button();
            this.Information = new System.Windows.Forms.Button();
            this.SpeedTest = new System.Windows.Forms.Button();
            this.Showtelnetdisplay = new System.Windows.Forms.CheckBox();
            this.DSLMode = new System.Windows.Forms.Label();
            this.DSLStatus = new System.Windows.Forms.Label();
            this.WanIP = new System.Windows.Forms.Label();
            this.DSLUpTime = new System.Windows.Forms.Label();
            this.DSLFastInt = new System.Windows.Forms.Label();
            this.Hostname = new System.Windows.Forms.Label();
            this.Firmware = new System.Windows.Forms.Label();
            this.HeaderBar = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DSPVer = new System.Windows.Forms.Label();
            this.WifiMAC = new System.Windows.Forms.Label();
            this.WifiSSID = new System.Windows.Forms.Label();
            this.WifiChannel = new System.Windows.Forms.Label();
            this.LANMac = new System.Windows.Forms.Label();
            this.WanMAC = new System.Windows.Forms.Label();
            this.WanSecDNS = new System.Windows.Forms.Label();
            this.WanPriDNS = new System.Windows.Forms.Label();
            this.WanConnType = new System.Windows.Forms.Label();
            this.SerialNo = new System.Windows.Forms.Label();
            this.ADSLVer = new System.Windows.Forms.Label();
            this.HardwareVer = new System.Windows.Forms.Label();
            this.WireLessVer = new System.Windows.Forms.Label();
            this.BootLoaderVer = new System.Windows.Forms.Label();
            this.AdditionalInfoButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ping2 = new System.Windows.Forms.Label();
            this.Ping1 = new System.Windows.Forms.Label();
            this.Downstream.SuspendLayout();
            this.Upstream.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.SystemColors.Control;
            this.Connect.Image = ((System.Drawing.Image)(resources.GetObject("Connect.Image")));
            this.Connect.Location = new System.Drawing.Point(5, 5);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(46, 46);
            this.Connect.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Connect, "Connect");
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Downstream
            // 
            this.Downstream.Controls.Add(this.RxPckts);
            this.Downstream.Controls.Add(this.label12);
            this.Downstream.Controls.Add(this.DownstreamFECs);
            this.Downstream.Controls.Add(this.label10);
            this.Downstream.Controls.Add(this.DownstreamHeaderErrors);
            this.Downstream.Controls.Add(this.DownstreamCRCErrors);
            this.Downstream.Controls.Add(this.label);
            this.Downstream.Controls.Add(this.label9);
            this.Downstream.Controls.Add(this.DownstreamAttenuation);
            this.Downstream.Controls.Add(this.label7);
            this.Downstream.Controls.Add(this.DownstreamRate);
            this.Downstream.Controls.Add(this.label3);
            this.Downstream.Controls.Add(this.label2);
            this.Downstream.Controls.Add(this.DownstreamPower);
            this.Downstream.Controls.Add(this.DownstreamSNR);
            this.Downstream.Controls.Add(this.label1);
            this.Downstream.Location = new System.Drawing.Point(12, 164);
            this.Downstream.Name = "Downstream";
            this.Downstream.Size = new System.Drawing.Size(190, 204);
            this.Downstream.TabIndex = 2;
            this.Downstream.TabStop = false;
            this.Downstream.Text = "Downstream";
            // 
            // RxPckts
            // 
            this.RxPckts.Location = new System.Drawing.Point(99, 180);
            this.RxPckts.Name = "RxPckts";
            this.RxPckts.Size = new System.Drawing.Size(85, 13);
            this.RxPckts.TabIndex = 24;
            this.RxPckts.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Rx Packets";
            // 
            // DownstreamFECs
            // 
            this.DownstreamFECs.Location = new System.Drawing.Point(99, 158);
            this.DownstreamFECs.Name = "DownstreamFECs";
            this.DownstreamFECs.Size = new System.Drawing.Size(85, 13);
            this.DownstreamFECs.TabIndex = 22;
            this.DownstreamFECs.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "FE Corrections";
            // 
            // DownstreamHeaderErrors
            // 
            this.DownstreamHeaderErrors.Location = new System.Drawing.Point(99, 136);
            this.DownstreamHeaderErrors.Name = "DownstreamHeaderErrors";
            this.DownstreamHeaderErrors.Size = new System.Drawing.Size(85, 13);
            this.DownstreamHeaderErrors.TabIndex = 20;
            this.DownstreamHeaderErrors.Text = "0";
            // 
            // DownstreamCRCErrors
            // 
            this.DownstreamCRCErrors.Location = new System.Drawing.Point(99, 114);
            this.DownstreamCRCErrors.Name = "DownstreamCRCErrors";
            this.DownstreamCRCErrors.Size = new System.Drawing.Size(85, 13);
            this.DownstreamCRCErrors.TabIndex = 19;
            this.DownstreamCRCErrors.Text = "0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(16, 114);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(59, 13);
            this.label.TabIndex = 18;
            this.label.Text = "CRC Errors";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Header Errors";
            // 
            // DownstreamAttenuation
            // 
            this.DownstreamAttenuation.Location = new System.Drawing.Point(99, 92);
            this.DownstreamAttenuation.Name = "DownstreamAttenuation";
            this.DownstreamAttenuation.Size = new System.Drawing.Size(85, 13);
            this.DownstreamAttenuation.TabIndex = 16;
            this.DownstreamAttenuation.Text = "0 db";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Attenuation";
            // 
            // DownstreamRate
            // 
            this.DownstreamRate.Location = new System.Drawing.Point(99, 26);
            this.DownstreamRate.Name = "DownstreamRate";
            this.DownstreamRate.Size = new System.Drawing.Size(85, 13);
            this.DownstreamRate.TabIndex = 14;
            this.DownstreamRate.Text = "0 kbps";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Power";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SNR";
            // 
            // DownstreamPower
            // 
            this.DownstreamPower.Location = new System.Drawing.Point(99, 70);
            this.DownstreamPower.Name = "DownstreamPower";
            this.DownstreamPower.Size = new System.Drawing.Size(85, 13);
            this.DownstreamPower.TabIndex = 10;
            this.DownstreamPower.Text = "0 db";
            // 
            // DownstreamSNR
            // 
            this.DownstreamSNR.Location = new System.Drawing.Point(99, 48);
            this.DownstreamSNR.Name = "DownstreamSNR";
            this.DownstreamSNR.Size = new System.Drawing.Size(85, 13);
            this.DownstreamSNR.TabIndex = 9;
            this.DownstreamSNR.Text = "0 db";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sync Rate";
            // 
            // Upstream
            // 
            this.Upstream.Controls.Add(this.TxPckts);
            this.Upstream.Controls.Add(this.label14);
            this.Upstream.Controls.Add(this.UpstreamFECs);
            this.Upstream.Controls.Add(this.label13);
            this.Upstream.Controls.Add(this.UpstreamHeaderErrors);
            this.Upstream.Controls.Add(this.label15);
            this.Upstream.Controls.Add(this.UpstreamCRCErrors);
            this.Upstream.Controls.Add(this.label11);
            this.Upstream.Controls.Add(this.UpstreamAttenuation);
            this.Upstream.Controls.Add(this.label8);
            this.Upstream.Controls.Add(this.UpstreamPower);
            this.Upstream.Controls.Add(this.UpstreamRate);
            this.Upstream.Controls.Add(this.UpstreamSNR);
            this.Upstream.Controls.Add(this.label4);
            this.Upstream.Controls.Add(this.label5);
            this.Upstream.Controls.Add(this.label6);
            this.Upstream.Location = new System.Drawing.Point(216, 165);
            this.Upstream.Name = "Upstream";
            this.Upstream.Size = new System.Drawing.Size(189, 204);
            this.Upstream.TabIndex = 7;
            this.Upstream.TabStop = false;
            this.Upstream.Text = "Upstream";
            // 
            // TxPckts
            // 
            this.TxPckts.Location = new System.Drawing.Point(98, 180);
            this.TxPckts.Name = "TxPckts";
            this.TxPckts.Size = new System.Drawing.Size(85, 13);
            this.TxPckts.TabIndex = 25;
            this.TxPckts.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Tx Packets";
            // 
            // UpstreamFECs
            // 
            this.UpstreamFECs.Location = new System.Drawing.Point(98, 158);
            this.UpstreamFECs.Name = "UpstreamFECs";
            this.UpstreamFECs.Size = new System.Drawing.Size(85, 13);
            this.UpstreamFECs.TabIndex = 24;
            this.UpstreamFECs.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "FE Corrections";
            // 
            // UpstreamHeaderErrors
            // 
            this.UpstreamHeaderErrors.Location = new System.Drawing.Point(98, 136);
            this.UpstreamHeaderErrors.Name = "UpstreamHeaderErrors";
            this.UpstreamHeaderErrors.Size = new System.Drawing.Size(85, 13);
            this.UpstreamHeaderErrors.TabIndex = 21;
            this.UpstreamHeaderErrors.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Header Errors";
            // 
            // UpstreamCRCErrors
            // 
            this.UpstreamCRCErrors.Location = new System.Drawing.Point(98, 114);
            this.UpstreamCRCErrors.Name = "UpstreamCRCErrors";
            this.UpstreamCRCErrors.Size = new System.Drawing.Size(85, 13);
            this.UpstreamCRCErrors.TabIndex = 19;
            this.UpstreamCRCErrors.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "CRC Errors";
            // 
            // UpstreamAttenuation
            // 
            this.UpstreamAttenuation.Location = new System.Drawing.Point(98, 92);
            this.UpstreamAttenuation.Name = "UpstreamAttenuation";
            this.UpstreamAttenuation.Size = new System.Drawing.Size(85, 13);
            this.UpstreamAttenuation.TabIndex = 17;
            this.UpstreamAttenuation.Text = "0 db";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Attenuation";
            // 
            // UpstreamPower
            // 
            this.UpstreamPower.Location = new System.Drawing.Point(98, 70);
            this.UpstreamPower.Name = "UpstreamPower";
            this.UpstreamPower.Size = new System.Drawing.Size(85, 13);
            this.UpstreamPower.TabIndex = 12;
            this.UpstreamPower.Text = "0 db";
            // 
            // UpstreamRate
            // 
            this.UpstreamRate.Location = new System.Drawing.Point(98, 26);
            this.UpstreamRate.Name = "UpstreamRate";
            this.UpstreamRate.Size = new System.Drawing.Size(85, 13);
            this.UpstreamRate.TabIndex = 13;
            this.UpstreamRate.Text = "0 kbps";
            // 
            // UpstreamSNR
            // 
            this.UpstreamSNR.Location = new System.Drawing.Point(98, 48);
            this.UpstreamSNR.Name = "UpstreamSNR";
            this.UpstreamSNR.Size = new System.Drawing.Size(85, 13);
            this.UpstreamSNR.TabIndex = 11;
            this.UpstreamSNR.Text = "0 db";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Power";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "SNR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sync Rate";
            // 
            // Status
            // 
            this.Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Status.Location = new System.Drawing.Point(2, 492);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(2);
            this.Status.Size = new System.Drawing.Size(418, 20);
            this.Status.TabIndex = 8;
            this.Status.Text = "label7";
            // 
            // Disconnect
            // 
            this.Disconnect.BackColor = System.Drawing.SystemColors.Control;
            this.Disconnect.Image = ((System.Drawing.Image)(resources.GetObject("Disconnect.Image")));
            this.Disconnect.Location = new System.Drawing.Point(57, 5);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(46, 46);
            this.Disconnect.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Disconnect, "Disconnect");
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // Pause
            // 
            this.Pause.BackColor = System.Drawing.SystemColors.Control;
            this.Pause.Image = ((System.Drawing.Image)(resources.GetObject("Pause.Image")));
            this.Pause.Location = new System.Drawing.Point(5, 5);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(46, 46);
            this.Pause.TabIndex = 2;
            this.toolTip1.SetToolTip(this.Pause, "Pause");
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Tones
            // 
            this.Tones.BackColor = System.Drawing.SystemColors.Control;
            this.Tones.Image = ((System.Drawing.Image)(resources.GetObject("Tones.Image")));
            this.Tones.Location = new System.Drawing.Point(109, 5);
            this.Tones.Name = "Tones";
            this.Tones.Size = new System.Drawing.Size(46, 46);
            this.Tones.TabIndex = 3;
            this.toolTip1.SetToolTip(this.Tones, "View Tones");
            this.Tones.UseVisualStyleBackColor = true;
            this.Tones.Click += new System.EventHandler(this.Tones_Click);
            // 
            // Telnet
            // 
            this.Telnet.BackColor = System.Drawing.SystemColors.Control;
            this.Telnet.Image = ((System.Drawing.Image)(resources.GetObject("Telnet.Image")));
            this.Telnet.Location = new System.Drawing.Point(161, 5);
            this.Telnet.Name = "Telnet";
            this.Telnet.Size = new System.Drawing.Size(46, 46);
            this.Telnet.TabIndex = 4;
            this.toolTip1.SetToolTip(this.Telnet, "Telnet");
            this.Telnet.UseVisualStyleBackColor = true;
            this.Telnet.Click += new System.EventHandler(this.Telnet_Click);
            // 
            // Config
            // 
            this.Config.BackColor = System.Drawing.SystemColors.Control;
            this.Config.Image = ((System.Drawing.Image)(resources.GetObject("Config.Image")));
            this.Config.Location = new System.Drawing.Point(265, 5);
            this.Config.Name = "Config";
            this.Config.Size = new System.Drawing.Size(46, 46);
            this.Config.TabIndex = 6;
            this.toolTip1.SetToolTip(this.Config, "Configuration");
            this.Config.UseVisualStyleBackColor = true;
            this.Config.Click += new System.EventHandler(this.Config_Click);
            // 
            // Graph
            // 
            this.Graph.BackColor = System.Drawing.SystemColors.Control;
            this.Graph.Image = ((System.Drawing.Image)(resources.GetObject("Graph.Image")));
            this.Graph.Location = new System.Drawing.Point(213, 5);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(46, 46);
            this.Graph.TabIndex = 5;
            this.toolTip1.SetToolTip(this.Graph, "Performance Statistics Graph");
            this.Graph.UseVisualStyleBackColor = true;
            this.Graph.Click += new System.EventHandler(this.Graph_Click);
            // 
            // Information
            // 
            this.Information.Image = ((System.Drawing.Image)(resources.GetObject("Information.Image")));
            this.Information.Location = new System.Drawing.Point(369, 5);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(46, 46);
            this.Information.TabIndex = 7;
            this.toolTip1.SetToolTip(this.Information, "About");
            this.Information.UseVisualStyleBackColor = true;
            this.Information.Click += new System.EventHandler(this.Information_Click);
            // 
            // SpeedTest
            // 
            this.SpeedTest.Image = ((System.Drawing.Image)(resources.GetObject("SpeedTest.Image")));
            this.SpeedTest.Location = new System.Drawing.Point(317, 5);
            this.SpeedTest.Name = "SpeedTest";
            this.SpeedTest.Size = new System.Drawing.Size(46, 46);
            this.SpeedTest.TabIndex = 24;
            this.toolTip1.SetToolTip(this.SpeedTest, "Speed Test");
            this.SpeedTest.UseVisualStyleBackColor = true;
            this.SpeedTest.Click += new System.EventHandler(this.SpeedTest_Click);
            // 
            // Showtelnetdisplay
            // 
            this.Showtelnetdisplay.AutoSize = true;
            this.Showtelnetdisplay.Location = new System.Drawing.Point(12, 461);
            this.Showtelnetdisplay.Name = "Showtelnetdisplay";
            this.Showtelnetdisplay.Size = new System.Drawing.Size(159, 17);
            this.Showtelnetdisplay.TabIndex = 8;
            this.Showtelnetdisplay.Text = "Show telnet/html debugging";
            this.Showtelnetdisplay.UseVisualStyleBackColor = true;
            this.Showtelnetdisplay.CheckedChanged += new System.EventHandler(this.Showtelnetdisplay_CheckedChanged);
            // 
            // DSLMode
            // 
            this.DSLMode.AutoSize = true;
            this.DSLMode.Location = new System.Drawing.Point(220, 24);
            this.DSLMode.Name = "DSLMode";
            this.DSLMode.Size = new System.Drawing.Size(113, 13);
            this.DSLMode.TabIndex = 14;
            this.DSLMode.Text = "DSL Mode : Unknown";
            // 
            // DSLStatus
            // 
            this.DSLStatus.Location = new System.Drawing.Point(17, 24);
            this.DSLStatus.Name = "DSLStatus";
            this.DSLStatus.Size = new System.Drawing.Size(197, 14);
            this.DSLStatus.TabIndex = 15;
            this.DSLStatus.Text = "DSL Status : Unknown";
            // 
            // WanIP
            // 
            this.WanIP.Location = new System.Drawing.Point(17, 46);
            this.WanIP.Name = "WanIP";
            this.WanIP.Size = new System.Drawing.Size(197, 13);
            this.WanIP.TabIndex = 16;
            this.WanIP.Text = "WanIP : 0.0.0.0";
            // 
            // DSLUpTime
            // 
            this.DSLUpTime.AutoSize = true;
            this.DSLUpTime.Location = new System.Drawing.Point(220, 68);
            this.DSLUpTime.Name = "DSLUpTime";
            this.DSLUpTime.Size = new System.Drawing.Size(122, 13);
            this.DSLUpTime.TabIndex = 22;
            this.DSLUpTime.Text = "DSL Up time : Unknown";
            // 
            // DSLFastInt
            // 
            this.DSLFastInt.AutoSize = true;
            this.DSLFastInt.Location = new System.Drawing.Point(220, 46);
            this.DSLFastInt.Name = "DSLFastInt";
            this.DSLFastInt.Size = new System.Drawing.Size(114, 13);
            this.DSLFastInt.TabIndex = 21;
            this.DSLFastInt.Text = "DSL Conn  : Unknown";
            // 
            // Hostname
            // 
            this.Hostname.AutoSize = true;
            this.Hostname.Location = new System.Drawing.Point(8, 354);
            this.Hostname.Name = "Hostname";
            this.Hostname.Size = new System.Drawing.Size(110, 13);
            this.Hostname.TabIndex = 19;
            this.Hostname.Text = "Hostname : Unknown";
            // 
            // Firmware
            // 
            this.Firmware.AutoSize = true;
            this.Firmware.Location = new System.Drawing.Point(8, 24);
            this.Firmware.Name = "Firmware";
            this.Firmware.Size = new System.Drawing.Size(104, 13);
            this.Firmware.TabIndex = 18;
            this.Firmware.Text = "Firmware : Unknown";
            // 
            // HeaderBar
            // 
            this.HeaderBar.AutoSize = true;
            this.HeaderBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderBar.ForeColor = System.Drawing.Color.Black;
            this.HeaderBar.Location = new System.Drawing.Point(5, 18);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(316, 33);
            this.HeaderBar.TabIndex = 22;
            this.HeaderBar.Text = "DSL Router test results";
            this.HeaderBar.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DSPVer);
            this.groupBox2.Controls.Add(this.Firmware);
            this.groupBox2.Controls.Add(this.Hostname);
            this.groupBox2.Controls.Add(this.WifiMAC);
            this.groupBox2.Controls.Add(this.WifiSSID);
            this.groupBox2.Controls.Add(this.WifiChannel);
            this.groupBox2.Controls.Add(this.LANMac);
            this.groupBox2.Controls.Add(this.WanMAC);
            this.groupBox2.Controls.Add(this.WanSecDNS);
            this.groupBox2.Controls.Add(this.WanPriDNS);
            this.groupBox2.Controls.Add(this.WanConnType);
            this.groupBox2.Controls.Add(this.SerialNo);
            this.groupBox2.Controls.Add(this.ADSLVer);
            this.groupBox2.Controls.Add(this.HardwareVer);
            this.groupBox2.Controls.Add(this.WireLessVer);
            this.groupBox2.Controls.Add(this.BootLoaderVer);
            this.groupBox2.Location = new System.Drawing.Point(434, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 381);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional Info";
            // 
            // DSPVer
            // 
            this.DSPVer.AutoSize = true;
            this.DSPVer.Location = new System.Drawing.Point(8, 134);
            this.DSPVer.Name = "DSPVer";
            this.DSPVer.Size = new System.Drawing.Size(54, 13);
            this.DSPVer.TabIndex = 13;
            this.DSPVer.Text = "DSP Ver :";
            // 
            // WifiMAC
            // 
            this.WifiMAC.AutoSize = true;
            this.WifiMAC.Location = new System.Drawing.Point(8, 332);
            this.WifiMAC.Name = "WifiMAC";
            this.WifiMAC.Size = new System.Drawing.Size(60, 13);
            this.WifiMAC.TabIndex = 12;
            this.WifiMAC.Text = "WiFi MAC :";
            // 
            // WifiSSID
            // 
            this.WifiSSID.AutoSize = true;
            this.WifiSSID.Location = new System.Drawing.Point(8, 310);
            this.WifiSSID.Name = "WifiSSID";
            this.WifiSSID.Size = new System.Drawing.Size(56, 13);
            this.WifiSSID.TabIndex = 11;
            this.WifiSSID.Text = "WiFi SSID";
            // 
            // WifiChannel
            // 
            this.WifiChannel.AutoSize = true;
            this.WifiChannel.Location = new System.Drawing.Point(8, 288);
            this.WifiChannel.Name = "WifiChannel";
            this.WifiChannel.Size = new System.Drawing.Size(70, 13);
            this.WifiChannel.TabIndex = 10;
            this.WifiChannel.Text = "WiFi Channel";
            // 
            // LANMac
            // 
            this.LANMac.AutoSize = true;
            this.LANMac.Location = new System.Drawing.Point(8, 266);
            this.LANMac.Name = "LANMac";
            this.LANMac.Size = new System.Drawing.Size(60, 13);
            this.LANMac.TabIndex = 9;
            this.LANMac.Text = "LAN MAC :";
            // 
            // WanMAC
            // 
            this.WanMAC.AutoSize = true;
            this.WanMAC.Location = new System.Drawing.Point(8, 244);
            this.WanMAC.Name = "WanMAC";
            this.WanMAC.Size = new System.Drawing.Size(68, 13);
            this.WanMAC.TabIndex = 8;
            this.WanMAC.Text = "WAN MAC : ";
            // 
            // WanSecDNS
            // 
            this.WanSecDNS.AutoSize = true;
            this.WanSecDNS.Location = new System.Drawing.Point(8, 222);
            this.WanSecDNS.Name = "WanSecDNS";
            this.WanSecDNS.Size = new System.Drawing.Size(87, 13);
            this.WanSecDNS.TabIndex = 7;
            this.WanSecDNS.Text = "Seconday DNS :";
            // 
            // WanPriDNS
            // 
            this.WanPriDNS.AutoSize = true;
            this.WanPriDNS.Location = new System.Drawing.Point(8, 200);
            this.WanPriDNS.Name = "WanPriDNS";
            this.WanPriDNS.Size = new System.Drawing.Size(73, 13);
            this.WanPriDNS.TabIndex = 6;
            this.WanPriDNS.Text = "Primary DNS :";
            // 
            // WanConnType
            // 
            this.WanConnType.AutoSize = true;
            this.WanConnType.Location = new System.Drawing.Point(8, 178);
            this.WanConnType.Name = "WanConnType";
            this.WanConnType.Size = new System.Drawing.Size(67, 13);
            this.WanConnType.TabIndex = 5;
            this.WanConnType.Text = "PPP Mode : ";
            // 
            // SerialNo
            // 
            this.SerialNo.AutoSize = true;
            this.SerialNo.Location = new System.Drawing.Point(8, 156);
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Size = new System.Drawing.Size(59, 13);
            this.SerialNo.TabIndex = 4;
            this.SerialNo.Text = "Serial No. :";
            // 
            // ADSLVer
            // 
            this.ADSLVer.AutoSize = true;
            this.ADSLVer.Location = new System.Drawing.Point(8, 90);
            this.ADSLVer.Name = "ADSLVer";
            this.ADSLVer.Size = new System.Drawing.Size(60, 13);
            this.ADSLVer.TabIndex = 3;
            this.ADSLVer.Text = "ADSL Ver :";
            // 
            // HardwareVer
            // 
            this.HardwareVer.AutoSize = true;
            this.HardwareVer.Location = new System.Drawing.Point(8, 112);
            this.HardwareVer.Name = "HardwareVer";
            this.HardwareVer.Size = new System.Drawing.Size(78, 13);
            this.HardwareVer.TabIndex = 2;
            this.HardwareVer.Text = "Hardware Ver :";
            // 
            // WireLessVer
            // 
            this.WireLessVer.AutoSize = true;
            this.WireLessVer.Location = new System.Drawing.Point(8, 68);
            this.WireLessVer.Name = "WireLessVer";
            this.WireLessVer.Size = new System.Drawing.Size(72, 13);
            this.WireLessVer.TabIndex = 1;
            this.WireLessVer.Text = "Wireless Ver :";
            // 
            // BootLoaderVer
            // 
            this.BootLoaderVer.AutoSize = true;
            this.BootLoaderVer.Location = new System.Drawing.Point(8, 46);
            this.BootLoaderVer.Name = "BootLoaderVer";
            this.BootLoaderVer.Size = new System.Drawing.Size(83, 13);
            this.BootLoaderVer.TabIndex = 0;
            this.BootLoaderVer.Text = "Bootloader Ver :";
            // 
            // AdditionalInfoButton
            // 
            this.AdditionalInfoButton.Location = new System.Drawing.Point(274, 460);
            this.AdditionalInfoButton.Name = "AdditionalInfoButton";
            this.AdditionalInfoButton.Size = new System.Drawing.Size(125, 23);
            this.AdditionalInfoButton.TabIndex = 25;
            this.AdditionalInfoButton.Text = "Additional Info";
            this.AdditionalInfoButton.UseVisualStyleBackColor = true;
            this.AdditionalInfoButton.Click += new System.EventHandler(this.AdditionalInfo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DSLFastInt);
            this.groupBox3.Controls.Add(this.DSLStatus);
            this.groupBox3.Controls.Add(this.DSLUpTime);
            this.groupBox3.Controls.Add(this.DSLMode);
            this.groupBox3.Controls.Add(this.WanIP);
            this.groupBox3.Location = new System.Drawing.Point(12, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 91);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DSL Info";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Ping2);
            this.groupBox1.Controls.Add(this.Ping1);
            this.groupBox1.Location = new System.Drawing.Point(12, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 67);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ping Check";
            // 
            // Ping2
            // 
            this.Ping2.AutoSize = true;
            this.Ping2.Location = new System.Drawing.Point(17, 45);
            this.Ping2.Name = "Ping2";
            this.Ping2.Size = new System.Drawing.Size(34, 13);
            this.Ping2.TabIndex = 1;
            this.Ping2.Text = "Ping2";
            // 
            // Ping1
            // 
            this.Ping1.AutoSize = true;
            this.Ping1.Location = new System.Drawing.Point(17, 23);
            this.Ping1.Name = "Ping1";
            this.Ping1.Size = new System.Drawing.Size(34, 13);
            this.Ping1.TabIndex = 0;
            this.Ping1.Text = "Ping1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.AdditionalInfoButton);
            this.Controls.Add(this.SpeedTest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.HeaderBar);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.Config);
            this.Controls.Add(this.Telnet);
            this.Controls.Add(this.Tones);
            this.Controls.Add(this.Showtelnetdisplay);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Upstream);
            this.Controls.Add(this.Downstream);
            this.Controls.Add(this.Connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "DSL Monitor";
            this.Downstream.ResumeLayout(false);
            this.Downstream.PerformLayout();
            this.Upstream.ResumeLayout(false);
            this.Upstream.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        //private System.Windows.Forms.Timer PollingTimer;
        private System.Windows.Forms.GroupBox Downstream;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Upstream;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label DownstreamRate;
        private System.Windows.Forms.Label DownstreamSNR;
        private System.Windows.Forms.Label DownstreamPower;
        private System.Windows.Forms.Label UpstreamSNR;
        private System.Windows.Forms.Label UpstreamPower;
        private System.Windows.Forms.Label UpstreamRate;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox Showtelnetdisplay;
        private System.Windows.Forms.Button Tones;
        private System.Windows.Forms.Label DSLMode;
        private System.Windows.Forms.Label DSLStatus;
        private System.Windows.Forms.Label DownstreamAttenuation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label UpstreamAttenuation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label DownstreamHeaderErrors;
        private System.Windows.Forms.Label DownstreamCRCErrors;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label UpstreamHeaderErrors;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label UpstreamCRCErrors;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label DownstreamFECs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label UpstreamFECs;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label WanIP;
        private System.Windows.Forms.Button Telnet;
        private System.Windows.Forms.Button Config;
        private System.Windows.Forms.Button Graph;
        private System.Windows.Forms.Button Information;
        private System.Windows.Forms.Label HeaderBar;
        private System.Windows.Forms.Label Hostname;
        private System.Windows.Forms.Label Firmware;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label WanSecDNS;
        private System.Windows.Forms.Label WanPriDNS;
        private System.Windows.Forms.Label WanConnType;
        private System.Windows.Forms.Label SerialNo;
        private System.Windows.Forms.Label ADSLVer;
        private System.Windows.Forms.Label HardwareVer;
        private System.Windows.Forms.Label WireLessVer;
        private System.Windows.Forms.Label BootLoaderVer;
        private System.Windows.Forms.Label WifiMAC;
        private System.Windows.Forms.Label WifiSSID;
        private System.Windows.Forms.Label WifiChannel;
        private System.Windows.Forms.Label LANMac;
        private System.Windows.Forms.Label WanMAC;
        private System.Windows.Forms.Button SpeedTest;
        private System.Windows.Forms.Button AdditionalInfoButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label RxPckts;
        private System.Windows.Forms.Label TxPckts;
        private System.Windows.Forms.Label DSLFastInt;
        private System.Windows.Forms.Label DSPVer;
        private System.Windows.Forms.Label DSLUpTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Ping2;
        private System.Windows.Forms.Label Ping1;
    }
}

