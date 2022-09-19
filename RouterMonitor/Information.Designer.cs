namespace RouterMonitor
{
    partial class About
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RegToLabel = new System.Windows.Forms.Label();
            this.RegQtyLabel = new System.Windows.Forms.Label();
            this.Register = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Michael Morgan (2007)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DSL Monitor - Version 0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pre Release";
            // 
            // RegToLabel
            // 
            this.RegToLabel.AutoSize = true;
            this.RegToLabel.Location = new System.Drawing.Point(25, 128);
            this.RegToLabel.Name = "RegToLabel";
            this.RegToLabel.Size = new System.Drawing.Size(80, 13);
            this.RegToLabel.TabIndex = 4;
            this.RegToLabel.Text = "Registered To :";
            // 
            // RegQtyLabel
            // 
            this.RegQtyLabel.AutoSize = true;
            this.RegQtyLabel.Location = new System.Drawing.Point(25, 152);
            this.RegQtyLabel.Name = "RegQtyLabel";
            this.RegQtyLabel.Size = new System.Drawing.Size(98, 13);
            this.RegQtyLabel.TabIndex = 5;
            this.RegQtyLabel.Text = "Licensed Quantity :";
            // 
            // Register
            // 
            this.Register.Location = new System.Drawing.Point(162, 181);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 6;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(66, 181);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 7;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "http://www.dsl-monitor.co.uk/";
            // 
            // About
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 216);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.RegQtyLabel);
            this.Controls.Add(this.RegToLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RegToLabel;
        private System.Windows.Forms.Label RegQtyLabel;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label4;

    }
}