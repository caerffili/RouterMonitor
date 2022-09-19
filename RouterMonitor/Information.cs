using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RouterMonitor
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        /*private void Register_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            rg.RegTo.Text = RegisteredTo;
            rg.RegQty.Text = RegisteredQty.ToString();
            rg.SerialNo.Text = RegisteredSerialNo;
            if (rg.ShowDialog() == DialogResult.OK) {
                RegToLabel.Text = "Registered To : " + rg.RegTo.Text;
                RegQtyLabel.Text = "Licensed Quantity : " + rg.RegQty.Text;
            }
        }*/

        /*private void Information_Shown(object sender, EventArgs e)
        {
            RegToLabel.Text = "Registered To : " + RegisteredTo; 
            
            if (Registered)
            {
                RegQtyLabel.Text = "Licensed Quantity : " + RegisteredQty.ToString();
            }
            else
            {
                RegQtyLabel.Text = "Licensed Quantity : 0";
            }
        }*/
    }
}