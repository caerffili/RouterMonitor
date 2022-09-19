using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace RouterMonitor.Encryption
{
    class KeyCheck
    {
        public static bool SerialNoCheck(string key1, string email, string product, int qty)
        {
            string key = key1.Replace("-", "");
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;
            sSourceData = email + product + qty.ToString();
            //Create a byte array from source data
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);

            //Compute hash based on source data
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            Console.WriteLine(ByteArrayToString(tmpHash));

            if (ByteArrayToString(tmpHash).Substring(0,16) == key) return true;

            return false;


        }

        public static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
