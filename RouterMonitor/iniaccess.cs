using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace RouterMonitor
{
    class iniaccess
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW",
            SetLastError = true,
            CharSet = CharSet.Unicode, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            string lpReturnString,
            int nSize,
            string lpFilename);


        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW",
            SetLastError = true,
            CharSet = CharSet.Unicode, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFilename);

        
        string iniFile;

        public iniaccess(string inifilename)
        {
            iniFile = inifilename;
        }
        
             
        public string GetIniFileString(string category, string key, string defaultValue)
        {
            string returnString = new string(' ', 1024);
            GetPrivateProfileString(category, key, defaultValue, returnString, 1024, iniFile);
            return returnString.Split('\0')[0];
        }

        public void WriteIniFileString(string category, string key, string Value)
        {
            WritePrivateProfileString(category, key, Value, iniFile);
        }

        public bool GetIniFileBool(string category, string key, bool defaultValue)
        {
            string returnString = new string(' ', 1024);
            if (defaultValue)
            {
                GetPrivateProfileString(category, key, "Yes", returnString, 1024, iniFile);
            }
            else
            {
                GetPrivateProfileString(category, key, "No", returnString, 1024, iniFile);
            }
            if (returnString.Split('\0')[0] == "Yes") { return true; } else { return false; }
        }

        public void WriteIniFileBool(string category, string key, bool Value)
        {
            if (Value)
            {
                WritePrivateProfileString(category, key, "Yes", iniFile);
            }
            else
            {
                WritePrivateProfileString(category, key, "No", iniFile);
            }
        }
    }
}
