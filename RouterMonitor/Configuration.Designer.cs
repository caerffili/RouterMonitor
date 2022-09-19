namespace RouterMonitor
{
    partial class Configuration
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
            this.EmailEnabled = new System.Windows.Forms.CheckBox();
            this.EmailSMTPServer = new System.Windows.Forms.TextBox();
            this.EmailFromAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmailToAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Router = new System.Windows.Forms.TabPage();
            this.RouterTelnetAllowed = new System.Windows.Forms.CheckBox();
            this.RouterRaiseTelnet = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.RouterUsername = new System.Windows.Forms.TextBox();
            this.RouterInfo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.RouterModel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PolingInt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RouterIP = new System.Windows.Forms.TextBox();
            this.RouterPassword = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.EmailOnVarLine = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.EmailOnIncreasingPollCount = new System.Windows.Forms.TextBox();
            this.EmailOnIncreasing = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EmailOnSyncChange = new System.Windows.Forms.CheckBox();
            this.EmailOnDownwards = new System.Windows.Forms.CheckBox();
            this.EmailOnVarLinePollCount = new System.Windows.Forms.TextBox();
            this.EmailOnUpwards = new System.Windows.Forms.CheckBox();
            this.LogFile = new System.Windows.Forms.TabPage();
            this.Filepicker = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.LogChangesOnly = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LogFilename = new System.Windows.Forms.TextBox();
            this.LogEnabled = new System.Windows.Forms.CheckBox();
            this.ProgramConfig = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.SpeedTestURL = new System.Windows.Forms.TextBox();
            this.StartShowTelnet = new System.Windows.Forms.CheckBox();
            this.StartAutoConnect = new System.Windows.Forms.CheckBox();
            this.Ping = new System.Windows.Forms.TabPage();
            this.PingHost2 = new System.Windows.Forms.TextBox();
            this.PingHost1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Router.SuspendLayout();
            this.Email.SuspendLayout();
            this.LogFile.SuspendLayout();
            this.ProgramConfig.SuspendLayout();
            this.Ping.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmailEnabled
            // 
            this.EmailEnabled.AutoSize = true;
            this.EmailEnabled.Location = new System.Drawing.Point(12, 18);
            this.EmailEnabled.Name = "EmailEnabled";
            this.EmailEnabled.Size = new System.Drawing.Size(125, 17);
            this.EmailEnabled.TabIndex = 0;
            this.EmailEnabled.Text = "Enable email (SMTP)";
            this.EmailEnabled.UseVisualStyleBackColor = true;
            // 
            // EmailSMTPServer
            // 
            this.EmailSMTPServer.Location = new System.Drawing.Point(86, 43);
            this.EmailSMTPServer.Name = "EmailSMTPServer";
            this.EmailSMTPServer.Size = new System.Drawing.Size(161, 20);
            this.EmailSMTPServer.TabIndex = 1;
            // 
            // EmailFromAddress
            // 
            this.EmailFromAddress.Location = new System.Drawing.Point(86, 69);
            this.EmailFromAddress.Name = "EmailFromAddress";
            this.EmailFromAddress.Size = new System.Drawing.Size(161, 20);
            this.EmailFromAddress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SMTP Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From address";
            // 
            // EmailToAddress
            // 
            this.EmailToAddress.Location = new System.Drawing.Point(86, 95);
            this.EmailToAddress.Name = "EmailToAddress";
            this.EmailToAddress.Size = new System.Drawing.Size(161, 20);
            this.EmailToAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "To address";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Router);
            this.tabControl1.Controls.Add(this.Email);
            this.tabControl1.Controls.Add(this.LogFile);
            this.tabControl1.Controls.Add(this.ProgramConfig);
            this.tabControl1.Controls.Add(this.Ping);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(472, 338);
            this.tabControl1.TabIndex = 1;
            // 
            // Router
            // 
            this.Router.Controls.Add(this.RouterTelnetAllowed);
            this.Router.Controls.Add(this.RouterRaiseTelnet);
            this.Router.Controls.Add(this.label14);
            this.Router.Controls.Add(this.RouterUsername);
            this.Router.Controls.Add(this.RouterInfo);
            this.Router.Controls.Add(this.label9);
            this.Router.Controls.Add(this.RouterModel);
            this.Router.Controls.Add(this.label6);
            this.Router.Controls.Add(this.PolingInt);
            this.Router.Controls.Add(this.label5);
            this.Router.Controls.Add(this.label4);
            this.Router.Controls.Add(this.RouterIP);
            this.Router.Controls.Add(this.RouterPassword);
            this.Router.Location = new System.Drawing.Point(4, 22);
            this.Router.Name = "Router";
            this.Router.Padding = new System.Windows.Forms.Padding(3);
            this.Router.Size = new System.Drawing.Size(464, 312);
            this.Router.TabIndex = 0;
            this.Router.Text = "Router";
            this.Router.UseVisualStyleBackColor = true;
            // 
            // RouterTelnetAllowed
            // 
            this.RouterTelnetAllowed.AutoSize = true;
            this.RouterTelnetAllowed.Enabled = false;
            this.RouterTelnetAllowed.Location = new System.Drawing.Point(239, 67);
            this.RouterTelnetAllowed.Name = "RouterTelnetAllowed";
            this.RouterTelnetAllowed.Size = new System.Drawing.Size(95, 17);
            this.RouterTelnetAllowed.TabIndex = 13;
            this.RouterTelnetAllowed.Text = "Telnet allowed";
            this.RouterTelnetAllowed.UseVisualStyleBackColor = true;
            // 
            // RouterRaiseTelnet
            // 
            this.RouterRaiseTelnet.AutoSize = true;
            this.RouterRaiseTelnet.Enabled = false;
            this.RouterRaiseTelnet.Location = new System.Drawing.Point(239, 44);
            this.RouterRaiseTelnet.Name = "RouterRaiseTelnet";
            this.RouterRaiseTelnet.Size = new System.Drawing.Size(143, 17);
            this.RouterRaiseTelnet.TabIndex = 12;
            this.RouterRaiseTelnet.Text = "Raise Telnet Connection";
            this.RouterRaiseTelnet.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(61, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Username";
            // 
            // RouterUsername
            // 
            this.RouterUsername.Location = new System.Drawing.Point(119, 134);
            this.RouterUsername.Name = "RouterUsername";
            this.RouterUsername.Size = new System.Drawing.Size(161, 20);
            this.RouterUsername.TabIndex = 2;
            // 
            // RouterInfo
            // 
            this.RouterInfo.Location = new System.Drawing.Point(296, 15);
            this.RouterInfo.Name = "RouterInfo";
            this.RouterInfo.Size = new System.Drawing.Size(75, 23);
            this.RouterInfo.TabIndex = 4;
            this.RouterInfo.Text = "Router Info";
            this.RouterInfo.UseVisualStyleBackColor = true;
            this.RouterInfo.Click += new System.EventHandler(this.RouterInfo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(74, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Router";
            // 
            // RouterModel
            // 
            this.RouterModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RouterModel.FormattingEnabled = true;
            this.RouterModel.Location = new System.Drawing.Point(119, 15);
            this.RouterModel.Name = "RouterModel";
            this.RouterModel.Size = new System.Drawing.Size(161, 21);
            this.RouterModel.Sorted = true;
            this.RouterModel.TabIndex = 0;
            this.RouterModel.SelectedIndexChanged += new System.EventHandler(this.RouterModel_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Polling Interval (sec)";
            // 
            // PolingInt
            // 
            this.PolingInt.Location = new System.Drawing.Point(119, 186);
            this.PolingInt.Name = "PolingInt";
            this.PolingInt.Size = new System.Drawing.Size(161, 20);
            this.PolingInt.TabIndex = 4;
            this.PolingInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PolingInt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Router IP";
            // 
            // RouterIP
            // 
            this.RouterIP.Location = new System.Drawing.Point(119, 108);
            this.RouterIP.Name = "RouterIP";
            this.RouterIP.Size = new System.Drawing.Size(161, 20);
            this.RouterIP.TabIndex = 1;
            // 
            // RouterPassword
            // 
            this.RouterPassword.Location = new System.Drawing.Point(119, 160);
            this.RouterPassword.Name = "RouterPassword";
            this.RouterPassword.PasswordChar = '*';
            this.RouterPassword.Size = new System.Drawing.Size(161, 20);
            this.RouterPassword.TabIndex = 3;
            // 
            // Email
            // 
            this.Email.Controls.Add(this.label13);
            this.Email.Controls.Add(this.EmailOnVarLine);
            this.Email.Controls.Add(this.label12);
            this.Email.Controls.Add(this.label11);
            this.Email.Controls.Add(this.EmailOnIncreasingPollCount);
            this.Email.Controls.Add(this.EmailOnIncreasing);
            this.Email.Controls.Add(this.label8);
            this.Email.Controls.Add(this.EmailOnSyncChange);
            this.Email.Controls.Add(this.EmailOnDownwards);
            this.Email.Controls.Add(this.EmailOnVarLinePollCount);
            this.Email.Controls.Add(this.EmailOnUpwards);
            this.Email.Controls.Add(this.label3);
            this.Email.Controls.Add(this.EmailToAddress);
            this.Email.Controls.Add(this.EmailEnabled);
            this.Email.Controls.Add(this.EmailFromAddress);
            this.Email.Controls.Add(this.label1);
            this.Email.Controls.Add(this.label2);
            this.Email.Controls.Add(this.EmailSMTPServer);
            this.Email.Location = new System.Drawing.Point(4, 22);
            this.Email.Name = "Email";
            this.Email.Padding = new System.Windows.Forms.Padding(3);
            this.Email.Size = new System.Drawing.Size(464, 312);
            this.Email.TabIndex = 1;
            this.Email.Text = "Email";
            this.Email.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(51, 279);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "After";
            // 
            // EmailOnVarLine
            // 
            this.EmailOnVarLine.AutoSize = true;
            this.EmailOnVarLine.Location = new System.Drawing.Point(12, 253);
            this.EmailOnVarLine.Name = "EmailOnVarLine";
            this.EmailOnVarLine.Size = new System.Drawing.Size(199, 17);
            this.EmailOnVarLine.TabIndex = 9;
            this.EmailOnVarLine.Text = "Email update on variable quality lines";
            this.EmailOnVarLine.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(143, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "polls";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "After";
            // 
            // EmailOnIncreasingPollCount
            // 
            this.EmailOnIncreasingPollCount.Location = new System.Drawing.Point(86, 227);
            this.EmailOnIncreasingPollCount.Name = "EmailOnIncreasingPollCount";
            this.EmailOnIncreasingPollCount.Size = new System.Drawing.Size(51, 20);
            this.EmailOnIncreasingPollCount.TabIndex = 8;
            // 
            // EmailOnIncreasing
            // 
            this.EmailOnIncreasing.AutoSize = true;
            this.EmailOnIncreasing.Location = new System.Drawing.Point(12, 204);
            this.EmailOnIncreasing.Name = "EmailOnIncreasing";
            this.EmailOnIncreasing.Size = new System.Drawing.Size(143, 17);
            this.EmailOnIncreasing.TabIndex = 7;
            this.EmailOnIncreasing.Text = "Email on increasing SNR";
            this.EmailOnIncreasing.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(143, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "polls (2-50).";
            // 
            // EmailOnSyncChange
            // 
            this.EmailOnSyncChange.AutoSize = true;
            this.EmailOnSyncChange.Location = new System.Drawing.Point(12, 135);
            this.EmailOnSyncChange.Name = "EmailOnSyncChange";
            this.EmailOnSyncChange.Size = new System.Drawing.Size(151, 17);
            this.EmailOnSyncChange.TabIndex = 4;
            this.EmailOnSyncChange.Text = "Email on sync rate change";
            this.EmailOnSyncChange.UseVisualStyleBackColor = true;
            // 
            // EmailOnDownwards
            // 
            this.EmailOnDownwards.AutoSize = true;
            this.EmailOnDownwards.Location = new System.Drawing.Point(12, 181);
            this.EmailOnDownwards.Name = "EmailOnDownwards";
            this.EmailOnDownwards.Size = new System.Drawing.Size(217, 17);
            this.EmailOnDownwards.TabIndex = 6;
            this.EmailOnDownwards.Text = "Email on every downwards SNR change";
            this.EmailOnDownwards.UseVisualStyleBackColor = true;
            // 
            // EmailOnVarLinePollCount
            // 
            this.EmailOnVarLinePollCount.Location = new System.Drawing.Point(86, 276);
            this.EmailOnVarLinePollCount.Name = "EmailOnVarLinePollCount";
            this.EmailOnVarLinePollCount.Size = new System.Drawing.Size(49, 20);
            this.EmailOnVarLinePollCount.TabIndex = 10;
            this.EmailOnVarLinePollCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EmailVarLineNo_KeyPress);
            this.EmailOnVarLinePollCount.Validating += new System.ComponentModel.CancelEventHandler(this.EmailVarLineNo_Validating);
            // 
            // EmailOnUpwards
            // 
            this.EmailOnUpwards.AutoSize = true;
            this.EmailOnUpwards.Location = new System.Drawing.Point(12, 158);
            this.EmailOnUpwards.Name = "EmailOnUpwards";
            this.EmailOnUpwards.Size = new System.Drawing.Size(203, 17);
            this.EmailOnUpwards.TabIndex = 5;
            this.EmailOnUpwards.Text = "Email on every upwards SNR change";
            this.EmailOnUpwards.UseVisualStyleBackColor = true;
            // 
            // LogFile
            // 
            this.LogFile.Controls.Add(this.Filepicker);
            this.LogFile.Controls.Add(this.label7);
            this.LogFile.Controls.Add(this.LogChangesOnly);
            this.LogFile.Controls.Add(this.label10);
            this.LogFile.Controls.Add(this.LogFilename);
            this.LogFile.Controls.Add(this.LogEnabled);
            this.LogFile.Location = new System.Drawing.Point(4, 22);
            this.LogFile.Name = "LogFile";
            this.LogFile.Padding = new System.Windows.Forms.Padding(3);
            this.LogFile.Size = new System.Drawing.Size(464, 312);
            this.LogFile.TabIndex = 4;
            this.LogFile.Text = "Logging";
            this.LogFile.UseVisualStyleBackColor = true;
            // 
            // Filepicker
            // 
            this.Filepicker.Location = new System.Drawing.Point(195, 122);
            this.Filepicker.Name = "Filepicker";
            this.Filepicker.Size = new System.Drawing.Size(75, 23);
            this.Filepicker.TabIndex = 3;
            this.Filepicker.Text = "Choose";
            this.Filepicker.UseVisualStyleBackColor = true;
            this.Filepicker.Click += new System.EventHandler(this.Filepicker_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Logging must be enabled for the stats graph to function.";
            // 
            // LogChangesOnly
            // 
            this.LogChangesOnly.AutoSize = true;
            this.LogChangesOnly.Location = new System.Drawing.Point(12, 41);
            this.LogChangesOnly.Name = "LogChangesOnly";
            this.LogChangesOnly.Size = new System.Drawing.Size(110, 17);
            this.LogChangesOnly.TabIndex = 1;
            this.LogChangesOnly.Text = "Log changes only";
            this.LogChangesOnly.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "FileName";
            // 
            // LogFilename
            // 
            this.LogFilename.Location = new System.Drawing.Point(76, 96);
            this.LogFilename.Name = "LogFilename";
            this.LogFilename.Size = new System.Drawing.Size(347, 20);
            this.LogFilename.TabIndex = 2;
            // 
            // LogEnabled
            // 
            this.LogEnabled.AutoSize = true;
            this.LogEnabled.Location = new System.Drawing.Point(12, 18);
            this.LogEnabled.Name = "LogEnabled";
            this.LogEnabled.Size = new System.Drawing.Size(75, 17);
            this.LogEnabled.TabIndex = 0;
            this.LogEnabled.Text = "Log to File";
            this.LogEnabled.UseVisualStyleBackColor = true;
            // 
            // ProgramConfig
            // 
            this.ProgramConfig.Controls.Add(this.label15);
            this.ProgramConfig.Controls.Add(this.SpeedTestURL);
            this.ProgramConfig.Controls.Add(this.StartShowTelnet);
            this.ProgramConfig.Controls.Add(this.StartAutoConnect);
            this.ProgramConfig.Location = new System.Drawing.Point(4, 22);
            this.ProgramConfig.Name = "ProgramConfig";
            this.ProgramConfig.Padding = new System.Windows.Forms.Padding(3);
            this.ProgramConfig.Size = new System.Drawing.Size(464, 312);
            this.ProgramConfig.TabIndex = 3;
            this.ProgramConfig.Text = "Program configuration";
            this.ProgramConfig.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Speed Test URL";
            // 
            // SpeedTestURL
            // 
            this.SpeedTestURL.Location = new System.Drawing.Point(102, 78);
            this.SpeedTestURL.Name = "SpeedTestURL";
            this.SpeedTestURL.Size = new System.Drawing.Size(344, 20);
            this.SpeedTestURL.TabIndex = 5;
            // 
            // StartShowTelnet
            // 
            this.StartShowTelnet.AutoSize = true;
            this.StartShowTelnet.Location = new System.Drawing.Point(12, 41);
            this.StartShowTelnet.Name = "StartShowTelnet";
            this.StartShowTelnet.Size = new System.Drawing.Size(238, 17);
            this.StartShowTelnet.TabIndex = 1;
            this.StartShowTelnet.Text = "Show telnet screen (debug) on program start.";
            this.StartShowTelnet.UseVisualStyleBackColor = true;
            // 
            // StartAutoConnect
            // 
            this.StartAutoConnect.AutoSize = true;
            this.StartAutoConnect.Location = new System.Drawing.Point(12, 18);
            this.StartAutoConnect.Name = "StartAutoConnect";
            this.StartAutoConnect.Size = new System.Drawing.Size(172, 17);
            this.StartAutoConnect.TabIndex = 0;
            this.StartAutoConnect.Text = "Auto connect on program start.";
            this.StartAutoConnect.UseVisualStyleBackColor = true;
            // 
            // Ping
            // 
            this.Ping.Controls.Add(this.PingHost2);
            this.Ping.Controls.Add(this.PingHost1);
            this.Ping.Controls.Add(this.label17);
            this.Ping.Controls.Add(this.label16);
            this.Ping.Location = new System.Drawing.Point(4, 22);
            this.Ping.Name = "Ping";
            this.Ping.Padding = new System.Windows.Forms.Padding(3);
            this.Ping.Size = new System.Drawing.Size(464, 312);
            this.Ping.TabIndex = 5;
            this.Ping.Text = "Ping";
            this.Ping.UseVisualStyleBackColor = true;
            // 
            // PingHost2
            // 
            this.PingHost2.Location = new System.Drawing.Point(105, 64);
            this.PingHost2.Name = "PingHost2";
            this.PingHost2.Size = new System.Drawing.Size(100, 20);
            this.PingHost2.TabIndex = 3;
            // 
            // PingHost1
            // 
            this.PingHost1.Location = new System.Drawing.Point(105, 38);
            this.PingHost1.Name = "PingHost1";
            this.PingHost1.Size = new System.Drawing.Size(100, 20);
            this.PingHost1.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(61, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Host 2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(61, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Host 1";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(165, 356);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 9;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(255, 356);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(499, 387);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.tabControl1.ResumeLayout(false);
            this.Router.ResumeLayout(false);
            this.Router.PerformLayout();
            this.Email.ResumeLayout(false);
            this.Email.PerformLayout();
            this.LogFile.ResumeLayout(false);
            this.LogFile.PerformLayout();
            this.ProgramConfig.ResumeLayout(false);
            this.ProgramConfig.PerformLayout();
            this.Ping.ResumeLayout(false);
            this.Ping.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox EmailEnabled;
        private System.Windows.Forms.TextBox EmailSMTPServer;
        private System.Windows.Forms.TextBox EmailFromAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmailToAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Router;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RouterIP;
        private System.Windows.Forms.TextBox RouterPassword;
        private System.Windows.Forms.TabPage Email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PolingInt;
        private System.Windows.Forms.TextBox EmailOnVarLinePollCount;
        private System.Windows.Forms.CheckBox EmailOnUpwards;
        private System.Windows.Forms.CheckBox EmailOnSyncChange;
        private System.Windows.Forms.CheckBox EmailOnDownwards;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage ProgramConfig;
        private System.Windows.Forms.CheckBox StartAutoConnect;
        private System.Windows.Forms.CheckBox StartShowTelnet;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox RouterModel;
        private System.Windows.Forms.Button RouterInfo;
        private System.Windows.Forms.TabPage LogFile;
        private System.Windows.Forms.CheckBox LogChangesOnly;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox LogFilename;
        private System.Windows.Forms.CheckBox LogEnabled;
        private System.Windows.Forms.CheckBox EmailOnIncreasing;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox EmailOnIncreasingPollCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox EmailOnVarLine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Filepicker;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox RouterUsername;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox SpeedTestURL;
        private System.Windows.Forms.CheckBox RouterRaiseTelnet;
        private System.Windows.Forms.CheckBox RouterTelnetAllowed;
        private System.Windows.Forms.TabPage Ping;
        private System.Windows.Forms.TextBox PingHost2;
        private System.Windows.Forms.TextBox PingHost1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
    }
}