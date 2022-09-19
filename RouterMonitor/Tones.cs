using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;


namespace RouterMonitor
{
    public partial class Tones : Form
    {

        public int[] tones;

        public Tones()
        {
            InitializeComponent();
        }

        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);
        }



        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "DMT Histogram";
            myPane.Title.FontSpec.Size = 20;
            myPane.XAxis.Title.Text = "DMT Tone";
            myPane.YAxis.Title.Text = "Bits";

            myPane.Chart.Fill = new Fill(Color.LightGray, Color.DarkGray, 45.0f);
            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);

            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;


            PointPairList list1 = new PointPairList();

            int maxx = 0;   
            for (int i = 0; i < 512; i++)
            {
                list1.Add(i, tones[i]);
                if (tones[i] > 0) maxx = i;
            }

            maxx += 20;

            if (maxx < 255) { maxx = 255;}
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = maxx;

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            //LineItem myCurve = myPane.AddCurve("Porsche",
            //      list1, Color.Red, SymbolType.None);

            BarItem fds = myPane.AddBar("", list1, Color.Red);
            

            myPane.BarSettings.MinBarGap = 0;
            myPane.BarSettings.MinClusterGap = 0;

            fds.Bar.Border = new Border(false, Color.Red, 0);
            fds.Bar.Fill = new Fill(Color.Red);
           // myPane.BarSettings.Type =

            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
            //LineItem myCurve2 = myPane.AddCurve("Piper",
            //      list2, Color.Blue, SymbolType.Circle);

            //myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }

        private void Tones_Load(object sender, EventArgs e)
        {
            // Setup the graph
            CreateGraph(zedGraphControl1);
            // Size the control to fill the form with a margin
            SetSize();
        }

        private void Tones_Resize(object sender, EventArgs e)
        {
            SetSize();
        }
    }
}