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
            this.buttonRoseDiagram = new System.Windows.Forms.Button();
            this.buttonCurrent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MonthDistribution
            // 
            this.MonthDistribution.Enabled = false;
            this.MonthDistribution.Location = new System.Drawing.Point(100, 100);
            this.MonthDistribution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MonthDistribution.Name = "MonthDistribution";
            this.MonthDistribution.Size = new System.Drawing.Size(141, 69);
            this.MonthDistribution.TabIndex = 0;
            this.MonthDistribution.Text = "Month Distribution";
            this.MonthDistribution.UseVisualStyleBackColor = true;
            this.MonthDistribution.Click += new System.EventHandler(this.Button1_Click);
            // 
            // HourDistribution
            // 
            this.HourDistribution.Location = new System.Drawing.Point(386, 100);
            this.HourDistribution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HourDistribution.Name = "HourDistribution";
            this.HourDistribution.Size = new System.Drawing.Size(140, 69);
            this.HourDistribution.TabIndex = 1;
            this.HourDistribution.Text = "Hour Distribution";
            this.HourDistribution.UseVisualStyleBackColor = true;
            this.HourDistribution.Click += new System.EventHandler(this.HourDistribution_Click);
            // 
            // buttonYearDistribution
            // 
            this.buttonYearDistribution.Location = new System.Drawing.Point(100, 279);
            this.buttonYearDistribution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonYearDistribution.Name = "buttonYearDistribution";
            this.buttonYearDistribution.Size = new System.Drawing.Size(141, 61);
            this.buttonYearDistribution.TabIndex = 2;
            this.buttonYearDistribution.Text = "YearDistribution";
            this.buttonYearDistribution.UseVisualStyleBackColor = true;
            this.buttonYearDistribution.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // buttonRoseDiagram
            // 
            this.buttonRoseDiagram.Location = new System.Drawing.Point(386, 279);
            this.buttonRoseDiagram.Name = "buttonRoseDiagram";
            this.buttonRoseDiagram.Size = new System.Drawing.Size(141, 61);
            this.buttonRoseDiagram.TabIndex = 3;
            this.buttonRoseDiagram.Text = "buttonRoseDiagram";
            this.buttonRoseDiagram.UseVisualStyleBackColor = true;
            this.buttonRoseDiagram.Click += new System.EventHandler(this.buttonRoseDiagram_Click);
            // 
            // buttonCurrent
            // 
            this.buttonCurrent.Location = new System.Drawing.Point(100, 479);
            this.buttonCurrent.Name = "buttonCurrent";
            this.buttonCurrent.Size = new System.Drawing.Size(141, 61);
            this.buttonCurrent.TabIndex = 4;
            this.buttonCurrent.Text = "LightningCurrent";
            this.buttonCurrent.UseVisualStyleBackColor = true;
            this.buttonCurrent.Click += new System.EventHandler(this.buttonCurrent_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 553);
            this.Controls.Add(this.buttonCurrent);
            this.Controls.Add(this.buttonRoseDiagram);
            this.Controls.Add(this.buttonYearDistribution);
            this.Controls.Add(this.HourDistribution);
            this.Controls.Add(this.MonthDistribution);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MonthDistribution;
        private System.Windows.Forms.Button HourDistribution;
        private System.Windows.Forms.Button buttonYearDistribution;
        private System.Windows.Forms.Button buttonRoseDiagram;
        private System.Windows.Forms.Button buttonCurrent;
    }
}

