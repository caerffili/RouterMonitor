namespace RouterMonitor
{
    partial class PerfGraph
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ShowDownSNR = new System.Windows.Forms.CheckBox();
            this.ShowDownRate = new System.Windows.Forms.CheckBox();
            this.ShowUpRate = new System.Windows.Forms.CheckBox();
            this.ShowUpSNR = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(842, 482);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // ShowDownSNR
            // 
            this.ShowDownSNR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowDownSNR.AutoSize = true;
            this.ShowDownSNR.Checked = true;
            this.ShowDownSNR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowDownSNR.Location = new System.Drawing.Point(42, 509);
            this.ShowDownSNR.Name = "ShowDownSNR";
            this.ShowDownSNR.Size = new System.Drawing.Size(110, 17);
            this.ShowDownSNR.TabIndex = 1;
            this.ShowDownSNR.Text = "Show Down SNR";
            this.ShowDownSNR.UseVisualStyleBackColor = true;
            this.ShowDownSNR.CheckedChanged += new System.EventHandler(this.ShowDownSnr_CheckedChanged);
            // 
            // ShowDownRate
            // 
            this.ShowDownRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowDownRate.AutoSize = true;
            this.ShowDownRate.Checked = true;
            this.ShowDownRate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowDownRate.Location = new System.Drawing.Point(181, 509);
            this.ShowDownRate.Name = "ShowDownRate";
            this.ShowDownRate.Size = new System.Drawing.Size(110, 17);
            this.ShowDownRate.TabIndex = 2;
            this.ShowDownRate.Text = "Show Down Rate";
            this.ShowDownRate.UseVisualStyleBackColor = true;
            this.ShowDownRate.CheckedChanged += new System.EventHandler(this.ShowDownRate_CheckedChanged);
            // 
            // ShowUpRate
            // 
            this.ShowUpRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowUpRate.AutoSize = true;
            this.ShowUpRate.Checked = true;
            this.ShowUpRate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowUpRate.Location = new System.Drawing.Point(489, 509);
            this.ShowUpRate.Name = "ShowUpRate";
            this.ShowUpRate.Size = new System.Drawing.Size(96, 17);
            this.ShowUpRate.TabIndex = 4;
            this.ShowUpRate.Text = "Show Up Rate";
            this.ShowUpRate.UseVisualStyleBackColor = true;
            this.ShowUpRate.CheckedChanged += new System.EventHandler(this.ShowUpRate_CheckedChanged);
            // 
            // ShowUpSNR
            // 
            this.ShowUpSNR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowUpSNR.AutoSize = true;
            this.ShowUpSNR.Checked = true;
            this.ShowUpSNR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowUpSNR.Location = new System.Drawing.Point(350, 509);
            this.ShowUpSNR.Name = "ShowUpSNR";
            this.ShowUpSNR.Size = new System.Drawing.Size(96, 17);
            this.ShowUpSNR.TabIndex = 3;
            this.ShowUpSNR.Text = "Show Up SNR";
            this.ShowUpSNR.UseVisualStyleBackColor = true;
            this.ShowUpSNR.CheckedChanged += new System.EventHandler(this.ShowUpSNR_CheckedChanged);
            // 
            // PerfGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 538);
            this.Controls.Add(this.ShowUpRate);
            this.Controls.Add(this.ShowUpSNR);
            this.Controls.Add(this.ShowDownRate);
            this.Controls.Add(this.ShowDownSNR);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "PerfGraph";
            this.Text = "Performance Statistics";
            this.Load += new System.EventHandler(this.PerfGraph_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.CheckBox ShowDownSNR;
        private System.Windows.Forms.CheckBox ShowDownRate;
        private System.Windows.Forms.CheckBox ShowUpRate;
        private System.Windows.Forms.CheckBox ShowUpSNR;
    }
}