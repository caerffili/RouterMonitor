using System;
using System.Xml.XPath;
using System.Xml;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Linq;

namespace RouterMonitor
{
    public class RouterComms
    {
        public RouterStatsClass RouterStats;

        public string RouterConfigPath;
        public string RouterModel;
        public string RouterUsername;
        public string RouterPassword;
        public string ModemType;
        public string RouterAuthChallenge;
        public string ipaddress;
        public bool Debug;


        public int[] tones = new int[512];

        public TelnetEngine.Telnet tn;
        public HTMLEngine hn;

        public RouterComms(int HistoryQty)
        {
            tn = new TelnetEngine.Telnet();
            hn = new HTMLEngine();
            RouterStats = new RouterStatsClass(HistoryQty);
        }


        ~RouterComms()
        {
           
        }


        public bool Connect()
        {
            return tn.OpenConnection(ipaddress);
        }


        public bool Login()
        {
            RouterAuthChallenge = "";
            hn.cookies = null;

            return GetStats(RouterConfigPath + @"\" + RouterModel + @"\login.xml");
        }


        public bool GetPrelimaryInfo()
        {
            // Initialise the router (ie get it into a known state and get prelinary info
            return GetStats(RouterConfigPath + @"\" + RouterModel + @"\initialisation.xml");
        }


        public void Poll()
        {
           // Login();
            GetStats(RouterConfigPath + @"\" + RouterModel + @"\enquire.xml");
        }


        public bool Reboot()
        {
            // Initialise the router (ie get it into a known state and get prelinary info
            return GetStats(RouterConfigPath + @"\" + RouterModel + @"\reboot.xml");
        }


        public void TelnetMode()
        {
            GetStats(RouterConfigPath + @"\" + RouterModel + @"\telnetmode.xml");
        }


        public void Disconnect()
        {
            //GetStats(RouterModel + @"\logout.xml");
            tn.Close();
       
        }


        private bool GetStats(string xmlfile)
        {
            // Open and parse the xml host file
            XmlTextReader reader = new XmlTextReader(xmlfile);
            string CommandType = "telnet";    // html / telnet
            string Command = "";   

            string Wait = "";           // telnet wait for
            string RespComplete = "";   // String to look for when response is complete

            string Method = "";         // http method (get/post)
            string URL = "";            // http url
            string Data = "";           // http data
            AuthenticationMethods AuthenticationMethod = AuthenticationMethods.None;


            string type = "";           // Temp var for identifying xml tags
            bool abort = false;

            int entriesperline = 0;
            //string preamble = "";
            int startpos = 0;
            int fieldspacing = 0;
            int fieldsize = 0;
            int lines = 0;
            string format = "";
            int starttone = 0;
            int startline = 0;

            // y cursor on buffer
            int ycursor = 0;

            while ((abort == false) && (reader.Read()))
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an Element
                        type = reader.Name;
                        break;
                    case XmlNodeType.DocumentType: // The node is a DocumentType
                        break;
                    case XmlNodeType.CDATA:
                        type = type.ToLower();
                        switch (type)
                        {
                            case "htmlparser": // HTML Advanced parser
                                AdvancedParser(hn.response, reader.Value.ToLower());
                                break;
                            case "telnetparser": // HTML Advanced parser
                                AdvancedParser(tn.VirtualScreen.Hardcopy(), reader.Value.ToLower());
                                break;
                            case "url": URL = reader.Value; break;
                            case "data": Data = reader.Value; break;
                        }
                        break;
                    case XmlNodeType.Text:
                        type = type.ToLower();
                        

           //             if (type == "data") { data = reader.Value.ToUpper(); }


                        if (type == "preamble")
                        {
                            bool preamblefound = false;
                            ycursor = 1;
                            do
                            {
                                if (tn.VirtualScreen.GetLine(ycursor).Contains(reader.Value))
                                {
                                    // Preamble found
                                    preamblefound = true;
                                }
                                else
                                {
                                    //                                    string before = tn.VirtualScreen.GetLine(ycursor);
                                    tn.VirtualScreen.CleanScreen(1,ycursor,80,ycursor);
                                    //                                    string after = tn.VirtualScreen.GetLine(ycursor);
                                    ycursor++;
                                }
                            } while ((ycursor < tn.VirtualScreen.Height) && (preamblefound == false));
                            //                           tnview.TelnetViewText.Text = tn.VirtualScreen.Hardcopy().TrimEnd().Replace("\n", "\r\n");

                            //                           tnview.TelnetViewText.Update();
                        }

                        string nv1 = reader.Value.Replace("(", "[(]");
                        string newvalue = nv1.Replace(")", "[)]");

                        // Extract values
                        switch (type)
                        {
                            case "htmlparser": // HTML Advanced parser
                                AdvancedParser(hn.response, reader.Value.ToLower());
                                break;
                            case "telnetparser": // HTML Advanced parser
                                AdvancedParser(tn.VirtualScreen.Hardcopy(), reader.Value.ToLower());
                                break;

                            // Command type and command
                            case "commandtype": CommandType = reader.Value.ToLower(); break;

                            // telnet command stuff
                            case "wait": Wait = reader.Value; break;
                            case "command": Command = reader.Value; break;
                            case "respcomplete": RespComplete = reader.Value; break;

                            // html command stuff
                            case "method": Method = reader.Value; break;
                            case "url": URL = reader.Value; break;
                            case "data": Data = reader.Value; break;
                            case "authentication":
                                if (reader.Value.ToLower() == "basic") { AuthenticationMethod = AuthenticationMethods.Basic; }
                                if (reader.Value.ToLower() == "cookie") { AuthenticationMethod = AuthenticationMethods.Cookie; }
                                break;

                            // telnet tones parser        
                            case "entriesperline": entriesperline = Convert.ToInt32(reader.Value); break;
                            case "startpos": startpos = Convert.ToInt32(reader.Value); break;
                            case "fieldspacing": fieldspacing = Convert.ToInt32(reader.Value); break;
                            case "fieldsize": fieldsize = Convert.ToInt32(reader.Value); break;
                            case "starttone": starttone = Convert.ToInt32(reader.Value); break;
                            case "startline": startline = Convert.ToInt32(reader.Value); break;
                            case "lines": lines = Convert.ToInt32(reader.Value); break;
                            case "format": format = reader.Value.ToUpper(); break;


                            // Basic router details
                            case "model": RouterStats.Model = RegExString(CommandType, newvalue); break;
                            case "hostname": RouterStats.Hostname = RegExString(CommandType, newvalue); break;
                            case "serialno": RouterStats.SerialNo = RegExString(CommandType, newvalue); break;
                            case "sysuptime": RouterStats.SysUpTime = RegExString(CommandType, newvalue); break;
                            case "dsluptime": RouterStats.DSLUpTime = RegExString(CommandType, newvalue); break;

                            // Versions
                            case "firmware": RouterStats.Firmware = RegExString(CommandType, newvalue); break;
                            case "bootloaderver": RouterStats.BootLoaderVer = RegExString(CommandType, newvalue); break;
                            case "wirelessver": RouterStats.WirelessVer = RegExString(CommandType, newvalue); break;
                            case "dslver": RouterStats.DSLVer = RegExString(CommandType, newvalue); break;
                            case "hardwarever": RouterStats.HardwareVer = RegExString(CommandType, newvalue); break;
                            case "dspver": RouterStats.DSPVer = RegExString(CommandType, newvalue); break;

                            // WAN Stuff
                            case "dslmode": RouterStats.dslmode[0] = RegExString(CommandType, newvalue); break;
                            case "dslstatus": RouterStats.dslstatus[0] = RegExString(CommandType, newvalue); break;
                            case "dslfastint": RouterStats.dslfastint[0] = RegExString(CommandType, newvalue); break;
                            //  case "connectionmode": RouterStats.ConnectionMode = RegExString(CommandType, newvalue); break;
                            case "wanconntype": RouterStats.PPPMode = RegExString(CommandType, newvalue); break;
                            case "wanpridns": RouterStats.WanPriDns = RegExString(CommandType, newvalue); break;
                            case "wansecdns": RouterStats.WanSecDns = RegExString(CommandType, newvalue); break;
                            case "wanip": RouterStats.wanip[0] = RegExWANIP(CommandType, newvalue); break;
                            case "txpcktshex": RouterStats.TxPckts[0] = RegExHex(CommandType, newvalue); break;
                            case "rxpcktshex": RouterStats.RxPckts[0] = RegExHex(CommandType, newvalue); break;
                            case "txpckts": RouterStats.TxPckts[0] = RegExInt(CommandType, newvalue); break;
                            case "rxpckts": RouterStats.RxPckts[0] = RegExInt(CommandType, newvalue); break;

                            // MAC Addresses
                            case "wanmac": RouterStats.WanMAC = RegExString(CommandType, newvalue); break;
                            case "lanmac": RouterStats.LanMAC = RegExString(CommandType, newvalue); break;

                            // WiFi Stuff
                            case "wifichannel": RouterStats.WifiChannel = RegExString(CommandType, newvalue); break;
                            case "wifissid": RouterStats.WifiSSID = RegExString(CommandType, newvalue); break;
                            case "wifimac": RouterStats.WifiMAC = RegExString(CommandType, newvalue); break;

                            // Download rates
                            case "download": RouterStats.Download[0] = RegExInt(CommandType, newvalue) / 1000; break;
                            case "downloadk": RouterStats.Download[0] = RegExInt(CommandType, newvalue); break;
                            case "upload": RouterStats.Upload[0] = RegExInt(CommandType, newvalue) / 1000; break;
                            case "uploadk": RouterStats.Upload[0] = RegExInt(CommandType, newvalue); break;
                            case "downloadint": RouterStats.DownloadInt[0] = RegExInt(CommandType, newvalue) / 1000; break;
                            case "downloadintk": RouterStats.DownloadInt[0] = RegExInt(CommandType, newvalue); break;
                            case "uploadint": RouterStats.UploadInt[0] = RegExInt(CommandType, newvalue) / 1000; break;
                            case "uploadintk": RouterStats.UploadInt[0] = RegExInt(CommandType, newvalue); break;
                            case "downloadfast": RouterStats.DownloadFast[0] = RegExInt(CommandType, newvalue) / 1000; break;
                            case "downloadfastk": RouterStats.DownloadFast[0] = RegExInt(CommandType, newvalue); break;
                            case "uploadfast": RouterStats.UploadFast[0] = RegExInt(CommandType, newvalue) / 1000; break;
                            case "uploadfastk": RouterStats.UploadFast[0] = RegExInt(CommandType, newvalue); break;

                            // Signal to noise ratio
                            case "downstreamsnr": RouterStats.downstreamsnr[0] = RegExDecimal(CommandType, newvalue); break;
                            case "upstreamsnr": RouterStats.upstreamsnr[0] = RegExDecimal(CommandType, newvalue); break;

                            // Power
                            case "downstreampower": RouterStats.downstreampower[0] = RegExDecimal(CommandType, newvalue); break;
                            case "upstreampower": RouterStats.upstreampower[0] = RegExDecimal(CommandType, newvalue); break;

                            // Attenuation
                            case "downstreamatt": RouterStats.downstreamatt[0] = RegExDecimal(CommandType, newvalue); break;
                            case "upstreamatt": RouterStats.upstreamatt[0] = RegExDecimal(CommandType, newvalue); break;

                            // Errors
                            case "downfecrrorfast": RouterStats.downFECerrorFast[0] = RegExInt(CommandType, newvalue); break;
                            case "downfecerrorint": RouterStats.downFECerrorInt[0] = RegExInt(CommandType, newvalue); break;
                            case "downcrcerrorfast": RouterStats.downCRCerrorFast[0] = RegExInt(CommandType, newvalue); break;
                            case "downcrcerrorint": RouterStats.downCRCerrorInt[0] = RegExInt(CommandType, newvalue); break;
                            case "downhecerrorfast": RouterStats.downHECerrorFast[0] = RegExInt(CommandType, newvalue); break;
                            case "downhecerrorint": RouterStats.downHECerrorInt[0] = RegExInt(CommandType, newvalue); break;
                            case "upfecerrorfast": RouterStats.upFECerrorFast[0] = RegExInt(CommandType, newvalue); break;
                            case "upfecerrorint": RouterStats.upFECerrorInt[0] = RegExInt(CommandType, newvalue); break;
                            case "upcrcCerrorfast": RouterStats.upCRCerrorFast[0] = RegExInt(CommandType, newvalue); break;
                            case "upcrcerrorint": RouterStats.upCRCerrorInt[0] = RegExInt(CommandType, newvalue); break;
                            case "uphecerrorfast": RouterStats.upHECerrorFast[0] = RegExInt(CommandType, newvalue); break;
                            case "uphecerrorint": RouterStats.upHECerrorInt[0] = RegExInt(CommandType, newvalue); break;
                        }




                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "action")
                        {
                            if (Command != "")
                            {
                                if (CommandType == "telnet")
                                {
                                    if (CommandTelnet(Wait, Command, RespComplete) == false)
                                    {
                                        abort = true;
                                    }
                                }
                            }
                            if (URL != "") {
                                if (CommandType == "html")
                                {
                                    if (CommandHTML(Method, URL, Data, AuthenticationMethod) == false)
                                    {
                                        abort = true;
                                    }
                                }
                            }
                            Wait = "";
                            Command = "";
                            RespComplete = "";
                            Method = "";
                            URL = "";
                            Data = "";

                        }

                        if (reader.Name == "tones")
                        {
                            RouterStats.receivedtones = true;
                            int tone = starttone;

                            for (int i = 0; i < lines; i++)
                            {
                                string line = tn.VirtualScreen.GetLine(ycursor + startline);
                                // Split string
                                for (int n = 0; n < entriesperline; n++)
                                {
                                    // Extract value
                                    if (format == "COMPRESSED")
                                    {
                                        try
                                        {
                                            tones[tone] = int.Parse(line.Substring(startpos + n * fieldspacing, 1), NumberStyles.AllowHexSpecifier);
                                            tone++;
                                        }
                                        catch
                                        {
                                            tones[tone] = 0;
                                            tone++;
                                        }
                                        try
                                        {
                                            tones[tone] = int.Parse(line.Substring(startpos + n * fieldspacing + 1, 1), NumberStyles.AllowHexSpecifier);
                                            tone++;
                                        }
                                        catch
                                        {
                                            tones[tone] = 0;
                                            tone++;
                                        }
                                    }

                                    // Extract value
                                    if (format == "SINGLEHEX")
                                    {
                                        try
                                        {
                                            tones[tone] = int.Parse(line.Substring(startpos + n * fieldspacing, 1), NumberStyles.AllowHexSpecifier);
                                            tone++;
                                        }
                                        catch
                                        {
                                            tones[tone] = 0;
                                            tone++;
                                        }
                                    }

                                    if (format == "UNCOMPRESSED")
                                    {
                                        try
                                        {
                                            tones[tone] = Convert.ToInt32(line.Substring(startpos + n * fieldspacing, 2));
                                            tone++;
                                        }
                                        catch
                                        {
                                            tones[tone] = 0;
                                            tone++;
                                        }
                                    }
 
                                }
                                ycursor++;
                            }

                        }
                        break;
                }
            }
            reader.Close();

            if (abort == true)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        #region RegEx functions
        private string RegExString(string commandtype, string nv)
        {
            string newvalue = nv.Replace("{ignore}", @"?\s*(\S+)");

            if (commandtype == "telnet")
            {
                return tn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>[^\f\n\r\t\v]+)"));
            }
            if (commandtype == "html")
            {
                return hn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>[^\f\n\r\t\v]+)"));
            }
            return "";
        }

        private int RegExInt(string commandtype, string nv)
        {
            string newvalue = nv.Replace("{ignore}", @"?\s*(\S+)");

            if (commandtype == "telnet")
            {
                return Convert.ToInt32(tn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>\d+)")));
            }
            if (commandtype == "html")
            {
                return Convert.ToInt32(hn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>\d+)")));
            }
            return 0;
        }

        private int RegExHex(string commandtype, string nv)
        {
            string newvalue = nv.Replace("{ignore}", @"?\s*(\S+)");

            if (commandtype == "telnet")
            {
                return int.Parse(tn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>[^\f\n\r\t\v]+)")), NumberStyles.AllowHexSpecifier);
            }
            if (commandtype == "html")
            {
                return int.Parse(hn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>[^\f\n\r\t\v]+)")), NumberStyles.AllowHexSpecifier);
            }
            return 0;
        }

        private Decimal RegExDecimal(string commandtype, string nv)
        {
            string newvalue = nv.Replace("{ignore}", @"?\s*(\S+)");
            
            if (commandtype == "telnet")
            {
                return Convert.ToDecimal(tn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>\d+[.]*\d*)")));
            }
            if (commandtype == "html")
            {
                return Convert.ToDecimal(hn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>\d+[.]\d+)")));
            }
            return 0;
        } 
        
        private string RegExWANIP(string commandtype, string newvalue)
        {
            if (commandtype == "telnet")
            {
                return tn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})?\s*"));
            }
            if (commandtype == "html")
            {
                return hn.GetRegExValue(newvalue.Replace("{value}", @"?\s*(?<value>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})?\s*"));
            }
            return "";
        }
        #endregion


        #region Command functions
        private bool CommandTelnet(String wait, String command, String respcomp)
        {
            string nc = command.Replace("{esc}", '\x1b'.ToString());
            string nc2 = nc.Replace("{password}", RouterPassword);
            string newcmd = nc2.Replace("{username}", RouterUsername);

            string f = null;

            if (wait != "")
            {
                f = tn.WaitForString(wait, false, 3);
                if (f == null) return false;
                    //throw new TelnetEngine.TerminalException("Wait string not found.");
            }

            tn.VirtualScreen.CleanScreen();
  
            if (command.Contains("{esc}")) {
                tn.SendResponse(newcmd, false);	// send "24" to get to next screen 
            } else {
                tn.SendResponse(newcmd, true);	// send "24" to get to next screen 
            }

            //tn.WaitForString2(3);

            if (respcomp != "")
            {
                f = tn.WaitForString(respcomp, false, 3);
                if (f == null) return false;
                    //throw new TelnetEngine.TerminalException("Response Complete string not found.");
            }

            return true;
        }

        private byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private String BuildLogonToken(String Password, String LD)
        {
            if ((!String.IsNullOrEmpty(Password)) && (!String.IsNullOrEmpty(LD)))
            {
                SHA256Managed md5 = new SHA256Managed();
                byte[] pwd = md5.ComputeHash(Encoding.ASCII.GetBytes(Password));
                byte[] ld = StringToByteArray(LD);
                byte[] final = pwd.Concat(ld).ToArray();

                Console.WriteLine(ByteArrayToString(final).ToUpper());
                byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(ByteArrayToString(final).ToUpper()));
                return ByteArrayToString(hash).ToUpper();
            }
            else
            {
                return "";
            }
        }

        private bool CommandHTML(String Method, String URL, String Data, AuthenticationMethods AuthenticationMethod)
        {
            string NewURL = URL.Replace("{ipaddress}", ipaddress);
            string nc = Data.Replace("{esc}", '\x1b'.ToString());
            string nc2 = nc.Replace("{password}", RouterPassword);
            string nc3 = nc2.Replace("{sha256auth}", BuildLogonToken(RouterPassword, RouterAuthChallenge));
            string NewData = nc3.Replace("{username}", RouterUsername);


            //     string f = null;

            bool returnval = hn.CommandHTML(Method, NewURL, NewData, AuthenticationMethod, RouterUsername, RouterPassword);

            if ((Debug) && (returnval)) {
                DebugForm dbg = new DebugForm();
                hn.response = hn.response.Replace("&nbsp;", " ");
                hn.response = hn.response.Replace("\r\n", "");
                hn.response = hn.response.Replace("\r", "");
                hn.response = hn.response.Replace("\n", "");
                dbg.DebugTextBox.Text = hn.response;
                dbg.DebugTextBox.SelectionStart = 0;
                dbg.DebugTextBox.SelectionLength = 0;
                dbg.ShowDialog();
            }
            
            return returnval;
        }


 


        #endregion


        private void AdvancedParser(string response, string regexstring)
        {
            // Create token variables
            string[] token = new string[40];

            // Replace html codes
            response = response.Replace("&nbsp;", " ");
            response = response.Replace("\r\n", "");
            response = response.Replace("\r", "");
            response = response.Replace("\n", "");

            // Cleanup the regex string
            regexstring = regexstring.Replace("(", "[(]");
            regexstring = regexstring.Replace(")", "[)]");
            regexstring = regexstring.Replace("[", @"\x5B");
            regexstring = regexstring.Replace("]", @"\x5D");

            // Find tokens in the regex string
            int tokenstart = 0;
            int tokenno = 0;
            for (int i = 0; i < regexstring.Length; i++)
            {
                if (regexstring.Substring(i, 1) == "{") { tokenstart = i; }
                if (regexstring.Substring(i, 1) == "}")
                {
                    token[tokenno] = regexstring.Substring(tokenstart + 1, i - tokenstart - 1);
                    tokenno++;
                }
            }

            // Rebuild the regex string swapping tokens with regex codes
            for (int i = 0; i < tokenno; i++)
            {
                regexstring = regexstring.Replace("{" + token[i] + "}", "(?<" + token[i] + ">[^\\f\\n\\r\\t\\v]*?)");
            }


            // Perform the regex
            Regex r1 = new Regex(regexstring, RegexOptions.IgnoreCase);
            Match m1 = r1.Match(response);


            for (int i = 0; i < tokenno; i++)
            {
                string value = null;

                try
                {
                    value = m1.Result("${" + token[i] + "}");
                }
                catch
                {
                }

                if (!String.IsNullOrEmpty(value))
                {
                    switch (token[i])
                    {
                        case "routerauthchallenge":
                            RouterAuthChallenge = value;
                            break;
                        // Basic router details
                        case "model": RouterStats.Model = value; break;
                        case "hostname": RouterStats.Hostname = value; break;
                        case "serialno": RouterStats.SerialNo = value; break;
                        case "sysuptime": RouterStats.SysUpTime = value; break;

                        // Versions
                        case "firmware": RouterStats.Firmware = value; break;
                        case "bootloaderver": RouterStats.BootLoaderVer = value; break;
                        case "wirelessver": RouterStats.WirelessVer = value; break;
                        case "dslver": RouterStats.DSLVer = value; break;
                        case "hardwarever": RouterStats.HardwareVer = value; break;
                        case "dspver": RouterStats.DSPVer = value; break;

                        // WAN Stuff
                        case "dslmode": RouterStats.dslmode[0] = value; break;
                        case "dslstatus": RouterStats.dslstatus[0] = value; break;
                        case "dslfastint": RouterStats.dslfastint[0] = value; break;
                        case "dsluptime": RouterStats.DSLUpTime = value; break;

                        //  case "connectionmode": RouterStats.ConnectionMode = value; break;
                        case "wanconntype": RouterStats.PPPMode = value; break;
                        case "wanpridns": RouterStats.WanPriDns = value; break;
                        case "wansecdns": RouterStats.WanSecDns = value; break;
                        case "wanip": RouterStats.wanip[0] = value; break;
                        case "txpcktshex": RouterStats.TxPckts[0] = int.Parse(value, NumberStyles.AllowHexSpecifier); break;
                        case "rxpcktshex": RouterStats.RxPckts[0] = int.Parse(value, NumberStyles.AllowHexSpecifier); break;
                        case "txpckts": RouterStats.TxPckts[0] = Convert.ToInt32(value); break;
                        case "rxpckts": RouterStats.RxPckts[0] = Convert.ToInt32(value); break;

                        // MAC Addresses
                        case "wanmac": RouterStats.WanMAC = value; break;
                        case "lanmac": RouterStats.LanMAC = value; break;

                        // WiFi Stuff
                        case "wifichannel": RouterStats.WifiChannel = value; break;
                        case "wifissid": RouterStats.WifiSSID = value; break;
                        case "wifimac": RouterStats.WifiMAC = value; break;

                        // Download rates
                        case "downloadint": RouterStats.DownloadInt[0] = Convert.ToInt32(value) / 1000; break;
                        case "downloadintk": RouterStats.DownloadInt[0] = Convert.ToInt32(value); break;
                        case "uploadint": RouterStats.UploadInt[0] = Convert.ToInt32(value) / 1000; break;
                        case "uploadintk": RouterStats.UploadInt[0] = Convert.ToInt32(value); break;
                        case "downloadfast": RouterStats.DownloadFast[0] = Convert.ToInt32(value) / 1000; break;
                        case "downloadfastk": RouterStats.DownloadFast[0] = Convert.ToInt32(value); break;
                        case "uploadfast": RouterStats.UploadFast[0] = Convert.ToInt32(value) / 1000; break;
                        case "uploadfastk": RouterStats.UploadFast[0] = Convert.ToInt32(value); break;

                        // Signal to noise ratio
                        case "downstreamsnr": RouterStats.downstreamsnr[0] = Convert.ToDecimal(value); break;
                        case "upstreamsnr": RouterStats.upstreamsnr[0] = Convert.ToDecimal(value); break;

                        // Power
                        case "downstreampower": RouterStats.downstreampower[0] = Convert.ToDecimal(value); break;
                        case "upstreampower": RouterStats.upstreampower[0] = Convert.ToDecimal(value); break;

                        // Attenuation
                        case "downstreamatt": RouterStats.downstreamatt[0] = Convert.ToInt32(value); break;
                        case "upstreamatt": RouterStats.upstreamatt[0] = Convert.ToInt32(value); break;

                        // Errors
                        case "downfecrrorfast": RouterStats.downFECerrorFast[0] = Convert.ToInt32(value); break;
                        case "downfecerrorint": RouterStats.downFECerrorInt[0] = Convert.ToInt32(value); break;
                        case "downcrcerrorfast": RouterStats.downCRCerrorFast[0] = Convert.ToInt32(value); break;
                        case "downcrcerrorint": RouterStats.downCRCerrorInt[0] = Convert.ToInt32(value); break;
                        case "downhecerrorfast": RouterStats.downHECerrorFast[0] = Convert.ToInt32(value); break;
                        case "downhecerrorint": RouterStats.downHECerrorInt[0] = Convert.ToInt32(value); break;
                        case "upfecerrorfast": RouterStats.upFECerrorFast[0] = Convert.ToInt32(value); break;
                        case "upfecerrorint": RouterStats.upFECerrorInt[0] = Convert.ToInt32(value); break;
                        case "upcrcerrorfast": RouterStats.upCRCerrorFast[0] = Convert.ToInt32(value); break;
                        case "upcrcerrorint": RouterStats.upCRCerrorInt[0] = Convert.ToInt32(value); break;
                        case "uphecerrorfast": RouterStats.upHECerrorFast[0] = Convert.ToInt32(value); break;
                        case "uphecerrorint": RouterStats.upHECerrorInt[0] = Convert.ToInt32(value); break;

                        case "lte_cellid": RouterStats.mLTE_CellId[0] = Convert.ToInt32(value, 16); break;
                        case "lte_activeband": RouterStats.mLTE_ActiveBand[0] = value; break;
                        //case "lte_primarybandwidth": RouterStats.mLTE_ActiveBandwidth[0] = (int)Convert.ToDecimal(value); break;

                        case "lte_caprimaryband": RouterStats.mLTE_CAPrimaryBand[0] = Convert.ToInt32(value); break;
                        case "lte_caprimarybandwidth": RouterStats.mLTE_CAPrimaryBandwidth[0] = (int)Convert.ToDecimal(value); break;
                        case "lte_ca1band": RouterStats.mLTE_CA1Band[0] = Convert.ToInt32(value); break;
                        case "lte_ca1bandwidth": RouterStats.mLTE_CA1Bandwidth[0] = (int)Convert.ToDecimal(value); break;
                        case "lte_rsrp": RouterStats.mLTE_RSRP[0] = Convert.ToInt32(value); break;
                        case "lte_pci": RouterStats.mLTE_PCI[0] = Convert.ToInt32(value); break;
                        case "lte_sinr": RouterStats.mLTE_SINR[0] = Convert.ToDecimal(value); break;
                        case "lte_networktype": RouterStats.mLTE_NetworkType[0] = value; break;
                        case "nr_band": RouterStats.m5G_Band[0] = value; break;
                        case "nr_nrarfcn": RouterStats.m5G_NRARFCN[0] = Convert.ToInt32(value); break;
                        case "nr_pci": RouterStats.m5G_PCI[0] = Convert.ToInt32(value, 16); break;
                        case "lte_earfcn": RouterStats.mLTE_EARFCN[0] = Convert.ToInt32(value); break;
                        case "nr_rsrp": RouterStats.m5G_RSRP[0] = Convert.ToInt32(value); break;
                        case "nr_sinr": RouterStats.m5G_SINR[0] = Convert.ToDecimal(value); break;
                            //case "downfecrrorfast": RouterStats.downFECerrorFast[0] = Convert.ToInt32(value); break;
                            //case "downfecrrorfast": RouterStats.downFECerrorFast[0] = Convert.ToInt32(value); break;

                    }
                }
            }
        }
    }
}










