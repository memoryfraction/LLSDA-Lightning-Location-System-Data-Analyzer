namespace LLSDA.Client.Winform
{
    partial class Form1
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
            this.MonthDistribution = new System.Windows.Forms.Button();
            this.HourDistribution = new System.Windows.Forms.Button();
            this.buttonYearDistribution = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MonthDistribution
            // 
            this.MonthDistribution.Enabled = false;
            this.MonthDistribution.Location = new System.Drawing.Point(100, 80);
            this.MonthDistribution.Name = "MonthDistribution";
            this.MonthDistribution.Size = new System.Drawing.Size(141, 55);
            this.MonthDistribution.TabIndex = 0;
            this.MonthDistribution.Text = "Month Distribution";
            this.MonthDistribution.UseVisualStyleBackColor = true;
            this.MonthDistribution.Click += new System.EventHandler(this.Button1_Click);
            // 
            // HourDistribution
            // 
            this.HourDistribution.Location = new System.Drawing.Point(386, 80);
            this.HourDistribution.Name = "HourDistribution";
            this.HourDistribution.Size = new System.Drawing.Size(140, 55);
            this.HourDistribution.TabIndex = 1;
            this.HourDistribution.Text = "Hour Distribution";
            this.HourDistribution.UseVisualStyleBackColor = true;
            this.HourDistribution.Click += new System.EventHandler(this.HourDistribution_Click);
            // 
            // buttonYearDistribution
            // 
            this.buttonYearDistribution.Location = new System.Drawing.Point(100, 223);
            this.buttonYearDistribution.Name = "buttonYearDistribution";
            this.buttonYearDistribution.Size = new System.Drawing.Size(141, 49);
            this.buttonYearDistribution.TabIndex = 2;
            this.buttonYearDistribution.Text = "YearDistribution";
            this.buttonYearDistribution.UseVisualStyleBackColor = true;
            this.buttonYearDistribution.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 368);
            this.Controls.Add(this.buttonYearDistribution);
            this.Controls.Add(this.HourDistribution);
            this.Controls.Add(this.MonthDistribution);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MonthDistribution;
        private System.Windows.Forms.Button HourDistribution;
        private System.Windows.Forms.Button buttonYearDistribution;
    }
}

