namespace TelnetEngine
{
    partial class Telnet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TelnetWindow = new System.Windows.Forms.TextBox();
            this.x = new System.Windows.Forms.TextBox();
            this.y = new System.Windows.Forms.TextBox();
            this.visibleY0B = new System.Windows.Forms.TextBox();
            this.visibleY0T = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TelnetWindow
            // 
            this.TelnetWindow.BackColor = System.Drawing.Color.Black;
            this.TelnetWindow.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelnetWindow.ForeColor = System.Drawing.Color.White;
            this.TelnetWindow.Location = new System.Drawing.Point(12, 12);
            this.TelnetWindow.Multiline = true;
            this.TelnetWindow.Name = "TelnetWindow";
            this.TelnetWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TelnetWindow.Size = new System.Drawing.Size(606, 666);
            this.TelnetWindow.TabIndex = 0;
            this.TelnetWindow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Telnet_KeyPress);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(91, 695);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(100, 20);
            this.x.TabIndex = 1;
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(197, 695);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(100, 20);
            this.y.TabIndex = 2;
            // 
            // visibleY0B
            // 
            this.visibleY0B.Location = new System.Drawing.Point(347, 695);
            this.visibleY0B.Name = "visibleY0B";
            this.visibleY0B.Size = new System.Drawing.Size(100, 20);
            this.visibleY0B.TabIndex = 3;
            // 
            // visibleY0T
            // 
            this.visibleY0T.Location = new System.Drawing.Point(453, 695);
            this.visibleY0T.Name = "visibleY0T";
            this.visibleY0T.Size = new System.Drawing.Size(100, 20);
            this.visibleY0T.TabIndex = 4;
            // 
            // Telnet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(631, 727);
            this.Controls.Add(this.visibleY0T);
            this.Controls.Add(this.visibleY0B);
            this.Controls.Add(this.y);
            this.Controls.Add(this.x);
            this.Controls.Add(this.TelnetWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Telnet";
            this.Text = "Telnet";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Telnet_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox x;
        private System.Windows.Forms.TextBox y;
        private System.Windows.Forms.TextBox visibleY0B;
        private System.Windows.Forms.TextBox visibleY0T;
        private System.Windows.Forms.TextBox TelnetWindow;
    }
}

