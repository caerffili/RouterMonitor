using System;
using System.Collections.Generic;
using System.Text;
using RouterMonitor;
using System.Windows.Forms;

namespace Reboot
{
    class reboot
    {

        static string ConfigFile = null;
        static string IPAddress = null;
        static string UserName = null;
        static string Password = null;
        static string RouterModel = null;
        static bool Telnet = false;

        static RouterMonitor.RouterComms rc;


        static void Main(string[] args)
        {
            Console.Write("Router Rebooter.");

            bool ValidParams = false;

            if (args.Length == 1)
            {
                ConfigFile = args[0];
                ValidParams = true;
            }

            if (args.Length == 5)
            {
                IPAddress = args[0];
                UserName = args[1];
                Password = args[2];
                RouterModel = args[3];
                if (args[4].ToLower() == "telnet") { Telnet = true;}

                ValidParams = true;
            }

            if (!ValidParams)
            {
                Console.WriteLine("Usage : reboot [<configfile>] [<IP Address> <loginname> <password> <routermodel> <Mode Telnet|html]");
                Console.WriteLine("Where <configfile> is the name of the ini file which corresponds to the router.");
                Console.WriteLine("Examples-");
                Console.WriteLine("reboot zyzxel.ini");
                Console.WriteLine("reboot 192.168.1.1 root p455w0rd 'Zyxel Prestige 660R' Telnet");
                
            }

            rc = new RouterComms();

            ConnectRouter();

            DisconnectRouter();
            
        }


        static bool ConnectRouter()
        {
            rc.RouterConfigPath = Application.StartupPath + @"\RouterConfigs";
            rc.RouterModel = RouterModel;
            rc.RouterUsername = UserName;
            rc.RouterPassword = Password;
            rc.ipaddress = IPAddress;
            rc.Debug = false;
            rc.RouterStats.Clear();

            if (Telnet)
            {
                // Connect to telnet interface
                if (!rc.Connect())
                {
                    Console.Write("Cannot connect to router. Check IP Address");
                    return false;
                }
            }

            // Login
            if (!rc.Login())
            {
                Console.Write("Cannot logon to router. Check password!");
                return false;
            }


            // Get the preliminary info and get to the main router ui
            if (!rc.GetPrelimaryInfo())
            {
                return false;
            }

            // Reboot
            if (!rc.Reboot())
            {
                return false;
            }
            return true;
        }

        static void DisconnectRouter()
        {
            rc.Disconnect();
        }
    }
}
