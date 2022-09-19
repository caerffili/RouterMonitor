using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace RouterMonitor
{
    public partial class PerfGraph : Form
    {
                        
        StreamReader sw;

        public String LogFilename;


        char[] delimiter;

        DateTime dt;
        int UpRate;
        int DownRate;
        Decimal DownSnr;
        Decimal UpSnr;

        public PerfGraph()
        {
            InitializeComponent();

            // Define delimeters
            string delimStr = ",";
            delimiter = delimStr.ToCharArray();
        }




        private bool OpenFile()
        {
            try
            {
                if (!File.Exists(LogFilename)) return false;

                sw = File.OpenText(LogFilename);
            }
            catch
            {
                MessageBox.Show("ERROR");
                return false;
            }

            return GetLine(true);
        }

        private bool GetLine(bool HeaderLine)
        {
            string line = sw.ReadLine();

            if (line == null) return false;
            if (HeaderLine) return true;

            string [] elements = null;

            elements = line.Split(delimiter, 5);
            dt = Convert.ToDateTime(elements[0]);
            DownRate = Convert.ToInt32(elements[1]);
            DownSnr = Convert.ToDecimal(elements[2]); 
            UpRate = Convert.ToInt32(elements[3]);
            UpSnr = Convert.ToDecimal(elements[4]);

            return true;
        }


        private bool CloseFile()
        {
            sw.Close();
            return false;
        }


 
        private void CreateGraph()
        {
            if (!OpenFile()) return;


            // get a reference to the GraphPane
            GraphPane myPane = zedGraphControl1.GraphPane;

            // Set the Titles
            myPane.Title.Text = "DSL Performance Data";
            myPane.Title.FontSpec.Size = 20;

            myPane.XAxis.Title.Text = "Date / Time";
            myPane.XAxis.Type = AxisType.Date;


            myPane.YAxis.Title.Text = "Units";

            myPane.Legend.FontSpec.Size = 12;
            myPane.Legend.Position = ZedGraph.LegendPos.BottomCenter;


            // Enable the X and Y axis grids
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;


  //          myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            myPane.Chart.Fill = new Fill(Color.LightGray, Color.DarkGray, 45.0f);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);


            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();


            while (GetLine(false)) 
            {
                list1.Add((double)new XDate(dt), (double)DownSnr);
                list2.Add((double)new XDate(dt), (double)DownRate / 1000);
                list3.Add((double)new XDate(dt), (double)UpSnr);
                list4.Add((double) new XDate(dt), (double)UpRate / 1000);
            }


            LineItem L1 = myPane.AddCurve("Down SNR", list1, Color.Red, SymbolType.None);
            LineItem L2 = myPane.AddCurve("Down Rate (x1000)", list2, Color.Blue, SymbolType.None);
            LineItem L3 = myPane.AddCurve("Up SNR", list3, Color.Green, SymbolType.None);
            LineItem L4 = myPane.AddCurve("Up Rate (x1000)", list4, Color.Yellow, SymbolType.None);


            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zedGraphControl1.AxisChange();

            CloseFile();
        }

        private void PerfGraph_Load(object sender, EventArgs e)
        {
            // Setup the graph
            CreateGraph();
        }


        private void ShowDownSnr_CheckedChanged(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList[0].IsVisible = ShowDownSNR.Checked;
            zedGraphControl1.Invalidate();
        }

        private void ShowDownRate_CheckedChanged(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList[1].IsVisible = ShowDownRate.Checked;
            zedGraphControl1.Invalidate();
        }

        private void ShowUpSNR_CheckedChanged(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList[2].IsVisible = ShowUpSNR.Checked;
            zedGraphControl1.Invalidate();
        }

        private void ShowUpRate_CheckedChanged(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList[3].IsVisible = ShowUpRate.Checked;
            zedGraphControl1.Invalidate();
        }
    }
}