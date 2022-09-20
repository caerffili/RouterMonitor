using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouterMonitor
{
    public class RouterStatsClass
    {
        public string BootLoaderVer;
        public string WirelessVer;
        public string DSLVer;
        public string HardwareVer;
        public string DSPVer;
        public string SerialNo;
        public string PPPMode;
        public string WanPriDns;
        public string WanSecDns;
        public string WanMAC;
        public string LanMAC;
        // public string ConnectionMode;
        public string SysUpTime;
        public string DSLUpTime;

        public string WifiChannel;
        public string WifiSSID;
        public string WifiMAC;

        public int TxPckts;
        public int RxPckts;

        public string Model;
        public string Hostname;
        public string Firmware;

        public string dslmode; // G.dmt etc
        public string dslstatus; // Up, down, showtime etc.
        public string dslfastint; // Fast or interleaved
        public string wanip;


        public DateTime[] TimeRecorded;

        public int[] Download;
        public int[] DownloadFast;
        public int[] DownloadInt;

        public decimal[] downstreamsnr;
        public decimal[] downstreamatt;
        public decimal[] downstreampower;

        public int[] downCRCerrors;
        public int[] downCRCerrorFast;
        public int[] downCRCerrorInt;

        public int[] downHECerrors;
        public int[] downHECerrorFast;
        public int[] downHECerrorInt;

        public int[] downFECerrors;
        public int[] downFECerrorFast;
        public int[] downFECerrorInt;


        public int[] Upload;
        public int[] UploadFast;
        public int[] UploadInt;

        public decimal[] upstreamsnr;
        public decimal[] upstreamatt;
        public decimal[] upstreampower;

        public int[] upCRCerrors;
        public int[] upCRCerrorFast;
        public int[] upCRCerrorInt;

        public int[] upHECerrors;
        public int[] upHECerrorFast;
        public int[] upHECerrorInt;

        public int[] upFECerrors;
        public int[] upFECerrorFast;
        public int[] upFECerrorInt;

        //public string[] Ping;

        public bool receivedtones;

        public int HistoryQty;
        public RouterStatsClass(int historyQty)
        {
            HistoryQty = historyQty;

            // Declare array for SNR and Attenuation storage
            TimeRecorded = new DateTime[HistoryQty];

            Download = new int[HistoryQty];
            DownloadFast = new int[HistoryQty];
            DownloadInt = new int[HistoryQty];

            downstreamsnr = new decimal[HistoryQty];
            downstreamatt = new decimal[HistoryQty];
            downstreampower = new decimal[HistoryQty];

            downCRCerrors = new int[HistoryQty];
            downCRCerrorFast = new int[HistoryQty];
            downCRCerrorInt = new int[HistoryQty];

            downHECerrors = new int[HistoryQty];
            downHECerrorFast = new int[HistoryQty];
            downHECerrorInt = new int[HistoryQty];

            downFECerrors = new int[HistoryQty];
            downFECerrorFast = new int[HistoryQty];
            downFECerrorInt = new int[HistoryQty];


            Upload = new int[HistoryQty];
            UploadFast = new int[HistoryQty];
            UploadInt = new int[HistoryQty];

            upstreamsnr = new decimal[HistoryQty];
            upstreamatt = new decimal[HistoryQty];
            upstreampower = new decimal[HistoryQty];

            upCRCerrors = new int[HistoryQty];
            upCRCerrorFast = new int[HistoryQty];
            upCRCerrorInt = new int[HistoryQty];

            upHECerrors = new int[HistoryQty];
            upHECerrorFast = new int[HistoryQty];
            upHECerrorInt = new int[HistoryQty];

            upFECerrors = new int[HistoryQty];
            upFECerrorFast = new int[HistoryQty];
            upFECerrorInt = new int[HistoryQty];
        }

        public void RollHistory()
        {
            // Move the stats history
            for (int i = HistoryQty - 2; i >= 0; i--)
            {
                Download[i + 1] = Download[i];
                DownloadFast[i + 1] = DownloadFast[i];
                DownloadInt[i + 1] = DownloadInt[i];

                downstreamsnr[i + 1] = downstreamsnr[i];
                downstreamatt[i + 1] = downstreamatt[i];
                downstreampower[i + 1] = downstreampower[i];

                downCRCerrors[i + 1] = downCRCerrors[i];
                downCRCerrorFast[i + 1] = downCRCerrorFast[i];
                downCRCerrorInt[i + 1] = downCRCerrorInt[i];

                downHECerrors[i + 1] = downHECerrors[i];
                downHECerrorFast[i + 1] = downHECerrorFast[i];
                downHECerrorInt[i + 1] = downHECerrorInt[i];

                downFECerrors[i + 1] = downFECerrors[i];
                downFECerrorFast[i + 1] = downFECerrorFast[i];
                downFECerrorInt[i + 1] = downFECerrorInt[i];


                Upload[i + 1] = Upload[i];
                UploadFast[i + 1] = UploadFast[i];
                UploadInt[i + 1] = UploadInt[i];

                upstreamsnr[i + 1] = upstreamsnr[i];
                upstreamatt[i + 1] = upstreamatt[i];
                upstreampower[i + 1] = upstreampower[i];

                upCRCerrors[i + 1] = upCRCerrors[i];
                upCRCerrorFast[i + 1] = upCRCerrorFast[i];
                upCRCerrorInt[i + 1] = upCRCerrorInt[i];

                upHECerrors[i + 1] = upHECerrors[i];
                upHECerrorFast[i + 1] = upHECerrorFast[i];
                upHECerrorInt[i + 1] = upHECerrorInt[i];

                upFECerrors[i + 1] = upFECerrors[i];
                upFECerrorFast[i + 1] = upFECerrorFast[i];
                upFECerrorInt[i + 1] = upFECerrorInt[i];

                TimeRecorded[i + 1] = TimeRecorded[i];
            }

            TimeRecorded[0] = DateTime.Now;
        }

        public void Summarise()
        {
            Download[0] = Math.Max(Math.Max(DownloadInt[0], DownloadFast[0]), Download[0]);
            downCRCerrors[0] = Math.Max(Math.Max(downCRCerrorInt[0], downCRCerrorFast[0]), downCRCerrors[0]);
            downHECerrors[0] = Math.Max(Math.Max(downHECerrorInt[0], downHECerrorFast[0]), downHECerrors[0]);
            downFECerrors[0] = Math.Max(Math.Max(downFECerrorInt[0], downFECerrorFast[0]), downFECerrors[0]);

            Upload[0] = Math.Max(Math.Max(UploadInt[0], UploadFast[0]), Upload[0]);
            upCRCerrors[0] = Math.Max(Math.Max(upCRCerrorInt[0], upCRCerrorFast[0]), upCRCerrors[0]);
            upHECerrors[0] = Math.Max(Math.Max(upHECerrorInt[0], upHECerrorFast[0]), upHECerrors[0]);
            upFECerrors[0] = Math.Max(Math.Max(upFECerrorInt[0], upFECerrorFast[0]), upFECerrors[0]);
        }

        public void Clear()
        {
            // Basic router details
            Model = "";
            Hostname = "";
            SerialNo = "";
            SysUpTime = "";
            DSLUpTime = "";

            // Versions
            Firmware = "";
            BootLoaderVer = "";
            WirelessVer = "";
            DSLVer = "";
            HardwareVer = "";
            DSPVer = "";

            // WAN Stuff
            dslmode = "";
            dslstatus = "";
            dslfastint = "";
            //  RouterStats.ConnectionMode = "";
            PPPMode = "";
            WanPriDns = "";
            WanSecDns = "";
            wanip = "";
            TxPckts = 0;
            RxPckts = 0;

            // MAC Addresses
            WanMAC = "";
            LanMAC = "";

            // WiFi Stuff
            WifiChannel = "";
            WifiSSID = "";
            WifiMAC = "";


            for (int i = 0; i < HistoryQty; i++)
            {
                Download[i] = 0;
                DownloadFast[i] = 0;
                DownloadInt[i] = 0;

                downstreamsnr[i] = 0;
                downstreamatt[i] = 0;
                downstreampower[i] = 0;

                downCRCerrors[i] = 0;
                downCRCerrorFast[i] = 0;
                downCRCerrorInt[i] = 0;

                downHECerrors[i] = 0;
                downHECerrorFast[i] = 0;
                downHECerrorInt[i] = 0;

                downFECerrors[i] = 0;
                downFECerrorFast[i] = 0;
                downFECerrorInt[i] = 0;


                Upload[i] = 0;
                UploadFast[i] = 0;
                UploadInt[i] = 0;
 
                upstreamsnr[i] = 0;
                upstreamatt[i] = 0;
                upstreampower[i] = 0;

                upCRCerrors[i] = 0;
                upCRCerrorFast[i] = 0;
                upCRCerrorInt[i] = 0;

                upHECerrors[i] = 0;
                upHECerrorFast[i] = 0;
                upHECerrorInt[i] = 0;

                upFECerrors[i] = 0;
                upFECerrorFast[i] = 0;
                upFECerrorInt[i] = 0;
            }

            receivedtones = false;
        }
    }
}
