using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouterMonitor
{
    public class RouterStatsClass
    {
        public string Model;
        public string Hostname;
        public string Firmware;
        public string BootLoaderVer;
        public string KernelVer;
        public string WirelessVer;
        public string DSLVer;
        public string HardwareVer;
        public string DSPVer;
        public string SerialNo;
        public string TargetPlatform;
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

        public int[] TxPckts;
        public int[] RxPckts;
        public string[] dslmode; // G.dmt etc
        public string[] dslstatus; // Up, down, showtime etc.
        public string[] dslfastint; // Fast or interleaved
        public string[] wanip;


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


        public string[] mLTE_NetworkType;
        public int[] mLTE_CellId;

        public String[] LTE_Bands;
        public String[] mLTE_ActiveBand;
        public int[] mLTE_ActiveBandwidth;
        public int[] mLTE_CAPrimaryBand;
        public int[] mLTE_CAPrimaryBandwidth;

        public int[] mLTE_CA1_Band;
        public int[] mLTE_CA1_Bandwidth;
        public int[] mLTE_CA1_PCI;
        public int[] mLTE_CA1_EARFCN;

        public int[] mLTE_CA2_Band;
        public int[] mLTE_CA2_Bandwidth;
        public int[] mLTE_CA2_PCI;
        public int[] mLTE_CA2_EARFCN;

        public int[] mLTE_CA3_Band;
        public int[] mLTE_CA3_Bandwidth;
        public int[] mLTE_CA3_PCI;
        public int[] mLTE_CA3_EARFCN;

        public int[] mLTE_CA4_Band;
        public int[] mLTE_CA4_Bandwidth;
        public int[] mLTE_CA4_PCI;
        public int[] mLTE_CA4_EARFCN;

        public decimal[] mLTE_RSRP;
        public decimal[] mLTE_SINR;
        public decimal[] mLTE_RSRQ;
        public decimal[] mLTE_RSSI;

        public decimal[] mLTE_SignalStrength;
        public String[] mLTE_Operator_Name;
        public int[] mLTE_Operator_MCC;
        public int[] mLTE_Operator_NNC;

        public int[] mLTE_PCI;
        public int[] mLTE_EARFCN;
        public string[] m5G_Band;
        public int[] m5G_NRARFCN;
        public int[] m5G_PCI;
        public int[] m5G_RSRP;
        public decimal[] m5G_SINR;




        //public string[] Ping;

        public bool receivedtones;

        public int HistoryQty;
        public RouterStatsClass(int historyQty)
        {
            HistoryQty = historyQty;

            // Declare array for SNR and Attenuation storage
            TimeRecorded = new DateTime[HistoryQty];

            TxPckts = new int[HistoryQty];
            RxPckts = new int[HistoryQty];
            dslmode = new string[HistoryQty];
            dslstatus = new string[HistoryQty];
            dslfastint = new string[HistoryQty];
            wanip = new string[HistoryQty];

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

            mLTE_NetworkType = new string[HistoryQty];
            mLTE_CellId = new int[HistoryQty];
            LTE_Bands = new String[HistoryQty];
            mLTE_ActiveBand = new String[HistoryQty];
            mLTE_ActiveBandwidth = new int[HistoryQty];
            mLTE_CAPrimaryBand = new int[HistoryQty];
            mLTE_CAPrimaryBandwidth = new int[HistoryQty];

            mLTE_CA1_Band = new int[HistoryQty];
            mLTE_CA1_Bandwidth = new int[HistoryQty];
            mLTE_CA1_PCI = new int[HistoryQty];
            mLTE_CA1_EARFCN = new int[HistoryQty];

            mLTE_CA2_Band = new int[HistoryQty];
            mLTE_CA2_Bandwidth = new int[HistoryQty];
            mLTE_CA2_PCI = new int[HistoryQty];
            mLTE_CA2_EARFCN = new int[HistoryQty];

            mLTE_CA3_Band = new int[HistoryQty];
            mLTE_CA3_Bandwidth = new int[HistoryQty];
            mLTE_CA3_PCI = new int[HistoryQty];
            mLTE_CA3_EARFCN = new int[HistoryQty];

            mLTE_CA4_Band = new int[HistoryQty];
            mLTE_CA4_Bandwidth = new int[HistoryQty];
            mLTE_CA4_PCI = new int[HistoryQty];
            mLTE_CA4_EARFCN = new int[HistoryQty];



            mLTE_RSRP = new decimal[HistoryQty];
            mLTE_SINR = new decimal[HistoryQty];
            mLTE_RSRQ = new decimal[HistoryQty];
            mLTE_RSSI = new decimal[HistoryQty];

            mLTE_SignalStrength = new decimal[HistoryQty];
            mLTE_Operator_Name = new string[HistoryQty];
            mLTE_Operator_MCC = new int[HistoryQty];
            mLTE_Operator_NNC = new int[HistoryQty];

            mLTE_PCI = new int[HistoryQty];
            mLTE_EARFCN = new int[HistoryQty];

            m5G_Band = new string[HistoryQty];
            m5G_RSRP = new int[HistoryQty];
            m5G_SINR = new decimal[HistoryQty];
            m5G_NRARFCN = new int[HistoryQty];
            m5G_PCI = new int[HistoryQty];
        }

        public void RollHistory()
        {
            // Move the stats history
            for (int i = HistoryQty - 2; i >= 0; i--)
            {
                TxPckts[i + 1] = TxPckts[i];
                RxPckts[i + 1] = RxPckts[i];
                dslmode[i + 1] = dslmode[i];
                dslstatus[i + 1] = dslstatus[i];
                dslfastint[i + 1] = dslfastint[i];
                wanip[i + 1] = wanip[i];

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

                mLTE_NetworkType[i + 1] = mLTE_NetworkType[i];
                mLTE_CellId[i + 1] = mLTE_CellId[i];
                LTE_Bands[i + 1] = LTE_Bands[i];
                mLTE_ActiveBand[i + 1] = mLTE_ActiveBand[i];
                mLTE_ActiveBandwidth[i + 1] = mLTE_ActiveBandwidth[i];
                mLTE_CAPrimaryBand[i + 1] = mLTE_CAPrimaryBand[i];
                mLTE_CAPrimaryBandwidth[i + 1] = mLTE_CAPrimaryBandwidth[i];

                mLTE_CA1_Band[i + 1] = mLTE_CA1_Band[i];
                mLTE_CA1_Bandwidth[i + 1] = mLTE_CA1_Bandwidth[i];
                mLTE_CA1_PCI[i + 1] = mLTE_CA1_PCI[i];
                mLTE_CA1_EARFCN[i + 1] = mLTE_CA1_EARFCN[i];

                mLTE_CA2_Band[i + 1] = mLTE_CA2_Band[i];
                mLTE_CA2_Bandwidth[i + 1] = mLTE_CA2_Bandwidth[i];
                mLTE_CA2_PCI[i + 1] = mLTE_CA2_PCI[i];
                mLTE_CA2_EARFCN[i + 1] = mLTE_CA2_EARFCN[i];

                mLTE_CA3_Band[i + 1] = mLTE_CA3_Band[i];
                mLTE_CA3_Bandwidth[i + 1] = mLTE_CA3_Bandwidth[i];
                mLTE_CA3_PCI[i + 1] = mLTE_CA3_PCI[i];
                mLTE_CA3_EARFCN[i + 1] = mLTE_CA3_EARFCN[i];

                mLTE_CA4_Band[i + 1] = mLTE_CA4_Band[i];
                mLTE_CA4_Bandwidth[i + 1] = mLTE_CA4_Bandwidth[i];
                mLTE_CA4_PCI[i + 1] = mLTE_CA4_PCI[i];
                mLTE_CA4_EARFCN[i + 1] = mLTE_CA4_EARFCN[i];

                mLTE_RSRP[i + 1] = mLTE_RSRP[i];
                mLTE_SINR[i + 1] = mLTE_SINR[i];
                mLTE_RSRQ[i + 1] = mLTE_RSRQ[i];
                mLTE_RSSI[i + 1] = mLTE_RSSI[i];

                mLTE_SignalStrength[i + 1] = mLTE_SignalStrength[i];
                mLTE_Operator_Name[i + 1] = mLTE_Operator_Name[i];
                mLTE_Operator_MCC[i + 1] = mLTE_Operator_MCC[i];
                mLTE_Operator_NNC[i + 1] = mLTE_Operator_NNC[i];

                mLTE_PCI[i + 1] = mLTE_PCI[i];
                mLTE_EARFCN[i + 1] = mLTE_EARFCN[i];
                m5G_Band[i + 1] = m5G_Band[i];
                m5G_RSRP[i + 1] = m5G_RSRP[i];
                m5G_SINR[i + 1] = m5G_SINR[i];
                m5G_NRARFCN[i + 1] = m5G_NRARFCN[i];
                m5G_PCI[i + 1] = m5G_PCI[i];


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


            StringBuilder sb = new StringBuilder();
            if (mLTE_CAPrimaryBand[0] > 1)
            {
                sb.Append("B" + mLTE_CAPrimaryBand[0].ToString() + " (" + mLTE_CAPrimaryBandwidth[0].ToString() + "MHz)");
                if (mLTE_CA1_Band[0] > 1)
                {
                    sb.Append(" + B" + mLTE_CA1_Band[0].ToString() + " (" + mLTE_CA1_Bandwidth[0].ToString() + "MHz)");
                }
                if (mLTE_CA2_Band[0] > 1)
                {
                    sb.Append(" + B" + mLTE_CA2_Band[0].ToString() + " (" + mLTE_CA2_Bandwidth[0].ToString() + "MHz)");
                }
                if (mLTE_CA3_Band[0] > 1)
                {
                    sb.Append(" + B" + mLTE_CA3_Band[0].ToString() + " (" + mLTE_CA3_Bandwidth[0].ToString() + "MHz)");
                }
                if (mLTE_CA4_Band[0] > 1)
                {
                    sb.Append(" + B" + mLTE_CA4_Band[0].ToString() + " (" + mLTE_CA4_Bandwidth[0].ToString() + "MHz)");
                }
                LTE_Bands[0] = sb.ToString();
            }
            else
            {
                LTE_Bands[0] = mLTE_ActiveBand[0];
            }
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
            dslmode[0] = "";
            dslstatus[0] = "";
            dslfastint[0] = "";
            //  RouterStats.ConnectionMode = "";
            PPPMode = "";
            WanPriDns = "";
            WanSecDns = "";
            wanip[0] = "";
            TxPckts[0] = 0;
            RxPckts[0] = 0;

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

                mLTE_NetworkType[i] = "";
                mLTE_CellId[i] = 0;
                LTE_Bands[i] = "";
                mLTE_ActiveBand[i] = "";
                mLTE_ActiveBandwidth[i] = 0;
                mLTE_CAPrimaryBand[i] = 0;
                mLTE_CAPrimaryBandwidth[i] = 0;

                mLTE_CA1_Band[i] = 0;
                mLTE_CA1_Bandwidth[i] = 0;
                mLTE_CA1_PCI[i] = 0;
                mLTE_CA1_EARFCN[i] = 0;

                mLTE_CA2_Band[i] = 0;
                mLTE_CA2_Bandwidth[i] = 0;
                mLTE_CA2_PCI[i] = 0;
                mLTE_CA2_EARFCN[i] = 0;

                mLTE_CA3_Band[i] = 0;
                mLTE_CA3_Bandwidth[i] = 0;
                mLTE_CA3_PCI[i] = 0;
                mLTE_CA3_EARFCN[i] = 0;

                mLTE_CA4_Band[i] = 0;
                mLTE_CA4_Bandwidth[i] = 0;
                mLTE_CA4_PCI[i] = 0;
                mLTE_CA4_EARFCN[i] = 0;

                mLTE_RSRP[i] = 0;
                mLTE_SINR[i] = 0;
                mLTE_RSRQ[i] = 0;
                mLTE_RSSI[i] = 0;

                mLTE_SignalStrength[i] = 0; ;
                mLTE_Operator_Name[i] = "";
                mLTE_Operator_MCC[i] = 0;
                mLTE_Operator_NNC[i] = 0;

                mLTE_PCI[i] = 0;
                mLTE_EARFCN[i] = 0;

                m5G_Band[i] = "";
                m5G_RSRP[i] = 0;
                m5G_SINR[i] = 0;
                m5G_NRARFCN[i] = 0;
                m5G_PCI[i] = 0;
            }

            receivedtones = false;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (!String.IsNullOrEmpty(Model)) sb.Append(String.Format("Model: {0}, ", Model));
            if (!String.IsNullOrEmpty(Hostname)) sb.Append(String.Format("Hostname: {0}, ", Hostname));
            if (!String.IsNullOrEmpty(Firmware)) sb.Append(String.Format("Firmware: {0}, ", Firmware));
            if (!String.IsNullOrEmpty(BootLoaderVer)) sb.Append(String.Format("BootLoaderVer: {0}, ", BootLoaderVer));
            if (!String.IsNullOrEmpty(DSLVer)) sb.Append(String.Format("DSLVer: {0}, ", DSLVer));
            if (!String.IsNullOrEmpty(KernelVer)) sb.Append(String.Format("KernelVer: {0}, ", KernelVer));
            if (!String.IsNullOrEmpty(WirelessVer)) sb.Append(String.Format("WirelessVer: {0}, ", WirelessVer));
            if (!String.IsNullOrEmpty(HardwareVer)) sb.Append(String.Format("HardwareVer: {0}, ", HardwareVer));
            if (!String.IsNullOrEmpty(SerialNo)) sb.Append(String.Format("SerialNo: {0}, ", SerialNo));
            if (!String.IsNullOrEmpty(TargetPlatform)) sb.Append(String.Format("TargetPlatform: {0}, ", TargetPlatform));
            if (!String.IsNullOrEmpty(PPPMode)) sb.Append(String.Format("PPPMode: {0}, ", PPPMode));
            if (!String.IsNullOrEmpty(WanPriDns)) sb.Append(String.Format("WanPriDns: {0}, ", WanPriDns));
            if (!String.IsNullOrEmpty(WanSecDns)) sb.Append(String.Format("WanSecDns: {0}, ", WanSecDns));
            if (!String.IsNullOrEmpty(WanMAC)) sb.Append(String.Format("WanMAC: {0}, ", WanMAC));
            if (!String.IsNullOrEmpty(LanMAC)) sb.Append(String.Format("LanMAC: {0}, ", LanMAC));
            if (!String.IsNullOrEmpty(SysUpTime)) sb.Append(String.Format("SysUpTime: {0}, ", SysUpTime));
            if (!String.IsNullOrEmpty(DSLUpTime)) sb.Append(String.Format("DSLUpTime: {0}, ", DSLUpTime));

            if (!String.IsNullOrEmpty(WifiChannel)) sb.Append(String.Format("WifiChannel: {0}, ", WifiChannel));
            if (!String.IsNullOrEmpty(WifiSSID)) sb.Append(String.Format("WifiSSID: {0}, ", WifiSSID));
            if (!String.IsNullOrEmpty(WifiMAC)) sb.Append(String.Format("DSLVer: {0}, ", WifiMAC));

            sb.Append(String.Format("TxPckts: {0}, ", TxPckts[0]));
            sb.Append(String.Format("RxPckts: {0}, ", RxPckts[0]));

            if (!String.IsNullOrEmpty(dslmode[0])) sb.Append(String.Format("dslmode: {0}, ", dslmode[0]));
            if (!String.IsNullOrEmpty(dslstatus[0])) sb.Append(String.Format("dslstatus: {0}, ", dslstatus[0]));
            if (!String.IsNullOrEmpty(dslfastint[0])) sb.Append(String.Format("dslfastint: {0}, ", dslfastint[0]));
            if (!String.IsNullOrEmpty(wanip[0])) sb.Append(String.Format("wanip: {0}, ", wanip[0]));

            if ((Download[0] > 0)) sb.Append(String.Format("Download: {0}, ", Download[0]));
            if ((DownloadFast[0] > 0)) sb.Append(String.Format("DownloadFast: {0}, ", DownloadFast[0]));
            if ((DownloadInt[0] > 0)) sb.Append(String.Format("DownloadInt: {0}, ", DownloadInt[0]));

            if ((downstreamsnr[0] > 0)) sb.Append(String.Format("downstreamsnr: {0}, ", downstreamsnr[0]));
            if ((downstreamatt[0] > 0)) sb.Append(String.Format("downstreamatt: {0}, ", downstreamatt[0]));
            if ((downstreampower[0] > 0)) sb.Append(String.Format("downstreampower: {0}, ", downstreampower[0]));

            if ((downCRCerrors[0] > 0)) sb.Append(String.Format("downCRCerrors: {0}, ", downCRCerrors[0]));
            if ((downCRCerrorFast[0] > 0)) sb.Append(String.Format("downCRCerrorFast: {0}, ", downCRCerrorFast[0]));
            if ((downCRCerrorInt[0] > 0)) sb.Append(String.Format("downCRCerrorInt: {0}, ", downCRCerrorInt[0]));

            if ((downHECerrors[0] > 0)) sb.Append(String.Format("downHECerrors: {0}, ", downHECerrors[0]));
            if ((downHECerrorFast[0] > 0)) sb.Append(String.Format("downHECerrorFast: {0}, ", downHECerrorFast[0]));
            if ((downHECerrorInt[0] > 0)) sb.Append(String.Format("downHECerrorInt: {0}, ", downHECerrorInt[0]));

            if ((downFECerrors[0] > 0)) sb.Append(String.Format("downFECerrors: {0}, ", downFECerrors[0]));
            if ((downFECerrorFast[0] > 0)) sb.Append(String.Format("downFECerrorFast: {0}, ", downFECerrorFast[0]));
            if ((downFECerrorInt[0] > 0)) sb.Append(String.Format("downFECerrorInt: {0}, ", downFECerrorInt[0]));

            if ((Upload[0] > 0)) sb.Append(String.Format("Upload: {0}, ", Upload[0]));
            if ((UploadFast[0] > 0)) sb.Append(String.Format("UploadFast: {0}, ", UploadFast[0]));
            if ((UploadInt[0] > 0)) sb.Append(String.Format("UploadInt: {0}, ", UploadInt[0]));

            if ((upstreamsnr[0] > 0)) sb.Append(String.Format("upstreamsnr: {0}, ", upstreamsnr[0]));
            if ((upstreamatt[0] > 0)) sb.Append(String.Format("upstreamatt: {0}, ", upstreamatt[0]));
            if ((upstreampower[0] > 0)) sb.Append(String.Format("upstreampower: {0}, ", upstreampower[0]));

            if ((upCRCerrors[0] > 0)) sb.Append(String.Format("upCRCerrors: {0}, ", upCRCerrors[0]));
            if ((upCRCerrorFast[0] > 0)) sb.Append(String.Format("upCRCerrorFast: {0}, ", upCRCerrorFast[0]));
            if ((upCRCerrorInt[0] > 0)) sb.Append(String.Format("upCRCerrorInt: {0}, ", upCRCerrorInt[0]));

            if ((upHECerrors[0] > 0)) sb.Append(String.Format("upHECerrors: {0}, ", upHECerrors[0]));
            if ((upHECerrorFast[0] > 0)) sb.Append(String.Format("upHECerrorFast: {0}, ", upHECerrorFast[0]));
            if ((upHECerrorInt[0] > 0)) sb.Append(String.Format("DoupHECerrorIntwnload: {0}, ", upHECerrorInt[0]));

            if ((upFECerrors[0] > 0)) sb.Append(String.Format("Download: {0}, ", Download[0]));
            if ((upFECerrorFast[0] > 0)) sb.Append(String.Format("upFECerrorFast: {0}, ", upFECerrorFast[0]));
            if ((upFECerrorInt[0] > 0)) sb.Append(String.Format("upFECerrorInt: {0}, ", upFECerrorInt[0]));

            /*     if ((Download[0] > 0)) sb.Append(String.Format("Download: {0}, ", Download[0]));
                 if ((Download[0] > 0)) sb.Append(String.Format("Download: {0}, ", Download[0]));


             public DateTime[] TimeRecorded;



             public string[] mLTE_NetworkType;
             public int[] mLTE_CellId;

             public String[] LTE_Bands;
             public String[] mLTE_ActiveBand;
             public int[] mLTE_ActiveBandwidth;
             public int[] mLTE_CAPrimaryBand;
             public int[] mLTE_CAPrimaryBandwidth;

             public int[] mLTE_CA1_Band;
             public int[] mLTE_CA1_Bandwidth;
             public int[] mLTE_CA1_PCI;
             public int[] mLTE_CA1_EARFCN;

             public int[] mLTE_CA2_Band;
             public int[] mLTE_CA2_Bandwidth;
             public int[] mLTE_CA2_PCI;
             public int[] mLTE_CA2_EARFCN;

             public int[] mLTE_CA3_Band;
             public int[] mLTE_CA3_Bandwidth;
             public int[] mLTE_CA3_PCI;
             public int[] mLTE_CA3_EARFCN;

             public int[] mLTE_CA4_Band;
             public int[] mLTE_CA4_Bandwidth;
             public int[] mLTE_CA4_PCI;
             public int[] mLTE_CA4_EARFCN;

             public decimal[] mLTE_RSRP;
             public decimal[] mLTE_SINR;
             public decimal[] mLTE_RSRQ;
             public decimal[] mLTE_RSSI;

             public decimal[] mLTE_SignalStrength;
             public String[] mLTE_Operator_Name;
             public int[] mLTE_Operator_MCC;
             public int[] mLTE_Operator_NNC;

             public int[] mLTE_PCI;
             public int[] mLTE_EARFCN;
             public string[] m5G_Band;
             public int[] m5G_NRARFCN;
             public int[] m5G_PCI;
             public int[] m5G_RSRP;
             public decimal[] m5G_SINR;**/


            return sb.ToString();
        }
    }
}
