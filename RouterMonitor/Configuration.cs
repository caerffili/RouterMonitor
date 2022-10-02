using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RouterMonitor.Encryption;



namespace RouterMonitor
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {

            // Get the router models
            
            // Make a reference to a directory.
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\RouterConfigs");

            // Get a reference to each directory in that directory.
            DirectoryInfo[] diArr = di.GetDirectories();

            // Display the names of the directories.
            foreach (DirectoryInfo dri in diArr) 
            {
                RouterModel.Items.Add(dri.Name);
            }


            string inifile = Application.StartupPath + @"\config.ini";
            iniaccess ini = new iniaccess(inifile);

            RouterModel.Text = ini.GetIniFileString("Router", "RouterModel", "");
            RouterRaiseTelnet.Checked = ini.GetIniFileBool("Router", "RaiseTelnet", true);
            RouterTelnetAllowed.Checked = ini.GetIniFileBool("Router", "TelnetAllowed", true);
            RouterIP.Text = ini.GetIniFileString("Router", "IP", "192.168.1.1");
            RouterUsername.Text = ini.GetIniFileString("Router", "RouterUsername", "");
            RouterPassword.Text = Decrypt(ini.GetIniFileString("Router", "Password", ""));

            PolingInt.Text = ini.GetIniFileString("Router", "PollInterval", "60");

            EmailEnabled.Checked = ini.GetIniFileBool("Email", "Enabled", false);
            EmailSMTPServer.Text = ini.GetIniFileString("Email", "SMTPServer", "");
            EmailFromAddress.Text = ini.GetIniFileString("Email", "From", "");
            EmailToAddress.Text = ini.GetIniFileString("Email", "To", "");
            EmailOnSyncChange.Checked = ini.GetIniFileBool("Email", "EmailOnSyncChange", false);
            EmailOnUpwards.Checked = ini.GetIniFileBool("Email", "EmailOnUpwards", false);
            EmailOnDownwards.Checked = ini.GetIniFileBool("Email", "EmailOnDownwards", false);
            EmailOnIncreasing.Checked = ini.GetIniFileBool("Email", "EmailOnIncreasing", false);;
            EmailOnIncreasingPollCount.Text = ini.GetIniFileString("Email", "EmailOnIncreasingPollCount", "10");
            EmailOnVarLine.Checked = ini.GetIniFileBool("Email", "EmailOnVarLine", false); ;
            EmailOnVarLinePollCount.Text = ini.GetIniFileString("Email", "EmailOnVarLinePollCount", "15");

            checkBoxMQTTEnable.Checked = ini.GetIniFileBool("MQTT", "Enabled", false);
            textBoxMQTTHost.Text = ini.GetIniFileString("MQTT", "Host", "");
            textBoxMQTTBaseTopic.Text = ini.GetIniFileString("MQTT", "BaseTopic", "");
            checkBoxMQTTHomeAssistantEnabled.Checked = ini.GetIniFileBool("MQTT", "HomeAssistantEnabled", false);
            textBoxMQTTHomeAssistantDeviceName.Text = ini.GetIniFileString("MQTT", "HomeAssistantDeviceName", "");
            textBoxMQTTHomeAssistantDiscoveryBaseTopic.Text = ini.GetIniFileString("MQTT", "HomeAssistantDiscoveryBaseTopic", "");
            textBoxMQTTHomeAssistantUniqueID.Text = ini.GetIniFileString("MQTT", "HomeAssistantUniqueID", "");

            LogEnabled.Checked = ini.GetIniFileBool("Logging", "Enabled", false);
            LogChangesOnly.Checked = ini.GetIniFileBool("Logging", "LogChangesOnly", true);
            LogFilename.Text = ini.GetIniFileString("Logging", "Filename", Application.StartupPath + @"\log.csv");

            StartAutoConnect.Checked = ini.GetIniFileBool("Startup", "AutoConnect", false);
            StartShowTelnet.Checked = ini.GetIniFileBool("Startup", "ShowTelnet", false);
            SpeedTestURL.Text = ini.GetIniFileString("SpeedTest", "URL", "");

            PingHost1.Text = ini.GetIniFileString("Pings", "PingHost1", "");
            PingHost2.Text = ini.GetIniFileString("Pings", "PingHost2", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inifile = Application.StartupPath + @"\config.ini";
            iniaccess ini = new iniaccess(inifile);

            ini.WriteIniFileBool("Router", "RaiseTelnet", RouterRaiseTelnet.Checked);
            ini.WriteIniFileBool("Router", "TelnetAllowed", RouterTelnetAllowed.Checked);
            ini.WriteIniFileString("Router", "ModemType", ModemType.Text);
            ini.WriteIniFileBool("Router", "PersistentLogin", PersistentLogin.Checked);

            ini.WriteIniFileString("Router", "RouterModel", RouterModel.Text);
            ini.WriteIniFileString("Router", "IP", RouterIP.Text);
            ini.WriteIniFileString("Router", "RouterUsername", RouterUsername.Text);
            ini.WriteIniFileString("Router", "Password", Encrypt(RouterPassword.Text));
            ini.WriteIniFileString("Router", "PollInterval", PolingInt.Text);



            ini.WriteIniFileBool("Email", "Enabled", EmailEnabled.Checked);
            ini.WriteIniFileString("Email", "SMTPServer", EmailSMTPServer.Text);
            ini.WriteIniFileString("Email", "From", EmailFromAddress.Text);
            ini.WriteIniFileString("Email", "To", EmailToAddress.Text);
            ini.WriteIniFileBool("Email", "EmailOnSyncChange", EmailOnSyncChange.Checked);
            ini.WriteIniFileBool("Email", "EmailOnUpwards", EmailOnUpwards.Checked);
            ini.WriteIniFileBool("Email", "EmailOnDownwards", EmailOnDownwards.Checked);
            ini.WriteIniFileBool("Email", "EmailOnIncreasing", EmailOnIncreasing.Checked);
            ini.WriteIniFileString("Email", "EmailOnIncreasingPollCount", EmailOnIncreasingPollCount.Text);
            ini.WriteIniFileBool("Email", "EmailOnVarLine", EmailOnVarLine.Checked);
            ini.WriteIniFileString("Email", "EmailOnVarLinePollCount", EmailOnVarLinePollCount.Text);

            ini.WriteIniFileBool("MQTT", "Enabled", checkBoxMQTTEnable.Checked);
            ini.WriteIniFileString("MQTT", "Host", textBoxMQTTHost.Text);
            ini.WriteIniFileString("MQTT", "BaseTopic", textBoxMQTTBaseTopic.Text);
            ini.WriteIniFileBool("MQTT", "HomeAssistantEnabled", checkBoxMQTTHomeAssistantEnabled.Checked);
            ini.WriteIniFileString("MQTT", "HomeAssistantDeviceName", textBoxMQTTHomeAssistantDeviceName.Text);
            ini.WriteIniFileString("MQTT", "HomeAssistantDiscoveryBaseTopic", textBoxMQTTHomeAssistantDiscoveryBaseTopic.Text);
            ini.WriteIniFileString("MQTT", "HomeAssistantUniqueID", textBoxMQTTHomeAssistantUniqueID.Text);

            ini.WriteIniFileBool("Logging", "Enabled", LogEnabled.Checked);
            ini.WriteIniFileBool("Logging", "LogChangesOnly", LogChangesOnly.Checked);
            ini.WriteIniFileString("Logging", "Filename", LogFilename.Text);

            ini.WriteIniFileBool("Startup", "AutoConnect", StartAutoConnect.Checked);
            ini.WriteIniFileBool("Startup", "ShowTelnet", StartShowTelnet.Checked);
            ini.WriteIniFileString("SpeedTest", "URL", SpeedTestURL.Text);

            ini.WriteIniFileString("Pings", "PingHost1", PingHost1.Text);
            ini.WriteIniFileString("Pings", "PingHost2", PingHost2.Text);
        }

        private void PolingInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Keys)e.KeyChar != Keys.Back) && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void EmailVarLineNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Keys)e.KeyChar != Keys.Back) && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void EmailVarLineNo_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(EmailOnVarLinePollCount.Text) < 2 || Convert.ToInt32(EmailOnVarLinePollCount.Text) > 50) 
            {// Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                EmailOnVarLinePollCount.Select(0, EmailOnVarLinePollCount.Text.Length);

            }

        }

        private void RouterInfo_Click(object sender, EventArgs e)
        {
            StreamReader sr;
            
            string infofilename = Application.StartupPath + @"\RouterConfigs\" + RouterModel.Text + @"\routerinfo.txt";
       
            try
            {
                if (!File.Exists(infofilename)) return;
                sr = File.OpenText(infofilename);
            }
            catch
            {
                MessageBox.Show("ERROR");
                return;
            }

                        
            string line;

            RouterInfo ri = new RouterInfo();
 
            do {
                line = sr.ReadLine();
                ri.RouterInfoTB.Text += line + "\r\n";

            } while (line != null);

            ri.RouterInfoTB.SelectionStart = 0;
            ri.RouterInfoTB.SelectionLength = 0;
            sr.Close();

            ri.ShowDialog();
        }

        private void Filepicker_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = LogFilename.Text;
            sfd.OverwritePrompt = false;
            sfd.ShowDialog();
            LogFilename.Text = sfd.FileName;
        }

        private void RouterModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string inifile = Application.StartupPath + @"\RouterConfigs\" + RouterModel.Text + @"\router.ini";
            iniaccess ini = new iniaccess(inifile);

            RouterRaiseTelnet.Checked = ini.GetIniFileBool("Router", "RaiseTelnet", true);
            RouterTelnetAllowed.Checked = ini.GetIniFileBool("Router", "TelnetAllowed", true);
            ModemType.Text = ini.GetIniFileString("Router", "ModemType", "ADSL");
            PersistentLogin.Checked = ini.GetIniFileBool("Router", "PersistentLogin", true);
        }

        public string Decrypt(string enctext)
        {
            // Set the required algorithm
            EncryptionAlgorithm algorithm = EncryptionAlgorithm.Des;

            // Init variables.
            byte[] IV = null;
            byte[] key = null;

            try
            { 
                //Try to decrypt.  Create the encryptor.
                Decryptor dec = new Decryptor(algorithm);

                if ((EncryptionAlgorithm.TripleDes == algorithm) ||
                    (EncryptionAlgorithm.Rijndael == algorithm))
                { //3Des only work with a 16 or 24 byte key.
                    key = Encoding.ASCII.GetBytes("password12345678");
                    if (EncryptionAlgorithm.Rijndael == algorithm)
                    { // Must be 16 bytes for Rijndael.
                        IV = Encoding.ASCII.GetBytes("init vec is big.");
                    }
                    else
                    {
                        IV = Encoding.ASCII.GetBytes("init vec");
                    }
                }
                else
                { //Des only works with an 8 byte key. The others uses variable length keys.
                    //Set the key to null to have a new one generated.
                    key = Encoding.ASCII.GetBytes("password");
                    IV = Encoding.ASCII.GetBytes("init vec");
                }

                dec.IV = IV;

                // Perform the decryption.
                byte[] cipherText = Convert.FromBase64String(enctext);
                byte[] plainText = dec.Decrypt(cipherText, key);
                return Encoding.ASCII.GetString(plainText);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string Encrypt(string cleartext)
        {
            // Set the required algorithm
            EncryptionAlgorithm algorithm = EncryptionAlgorithm.Des;

            // Init variables.
            byte[] IV = null;
            byte[] cipherText = null;
            byte[] key = null;

            try
            { //Try to encrypt.
                //Create the encryptor.
                Encryptor enc = new Encryptor(EncryptionAlgorithm.Des);

                if ((EncryptionAlgorithm.TripleDes == algorithm) ||
                    (EncryptionAlgorithm.Rijndael == algorithm))
                { //3Des only work with a 16 or 24 byte key.
                    key = Encoding.ASCII.GetBytes("password12345678");
                    if (EncryptionAlgorithm.Rijndael == algorithm)
                    { // Must be 16 bytes for Rijndael.
                        IV = Encoding.ASCII.GetBytes("init vec is big.");
                    }
                    else
                    {
                        IV = Encoding.ASCII.GetBytes("init vec");
                    }
                }
                else
                { //Des only works with an 8 byte key. The others uses variable length keys.
                    //Set the key to null to have a new one generated.
                    key = Encoding.ASCII.GetBytes("password");
                    IV = Encoding.ASCII.GetBytes("init vec");
                }
                // Uncomment the next lines to have the key or IV generated for you.
                // key = null;
                // IV = null;

                enc.IV = IV;

                // Perform the encryption.
                byte[] plainText = Encoding.ASCII.GetBytes(cleartext);
                cipherText = enc.Encrypt(plainText, key);
                return Convert.ToBase64String(cipherText);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}