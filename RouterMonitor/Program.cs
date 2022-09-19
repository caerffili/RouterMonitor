using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RouterMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*Form1 f1 = new Form1(args);
            f1.Initialise();
            Application.Run(f1);*/

            Application.Run(new Form1(args));
        }
    }
}