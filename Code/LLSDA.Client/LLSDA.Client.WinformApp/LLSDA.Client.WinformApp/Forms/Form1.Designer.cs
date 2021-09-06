
namespace LLSDA.Client.WinformApp
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
            this.buttonCurrent = new System.Windows.Forms.Button();
            this.buttonRoseDiagram = new System.Windows.Forms.Button();
            this.buttonYearDistribution = new System.Windows.Forms.Button();
            this.HourDistribution = new System.Windows.Forms.Button();
            this.MonthDistribution = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCurrent
            // 
            this.buttonCurrent.Location = new System.Drawing.Point(135, 470);
            this.buttonCurrent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCurrent.Name = "buttonCurrent";
            this.buttonCurrent.Size = new System.Drawing.Size(141, 49);
            this.buttonCurrent.TabIndex = 9;
            this.buttonCurrent.Text = "LightningCurrent";
            this.buttonCurrent.UseVisualStyleBackColor = true;
            this.buttonCurrent.Click += new System.EventHandler(this.buttonCurrent_Click);
            // 
            // buttonRoseDiagram
            // 
            this.buttonRoseDiagram.Location = new System.Drawing.Point(492, 270);
            this.buttonRoseDiagram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRoseDiagram.Name = "buttonRoseDiagram";
            this.buttonRoseDiagram.Size = new System.Drawing.Size(141, 49);
            this.buttonRoseDiagram.TabIndex = 8;
            this.buttonRoseDiagram.Text = "buttonRoseDiagram";
            this.buttonRoseDiagram.UseVisualStyleBackColor = true;
            this.buttonRoseDiagram.Click += new System.EventHandler(this.buttonRoseDiagram_Click);
            // 
            // buttonYearDistribution
            // 
            this.buttonYearDistribution.Location = new System.Drawing.Point(135, 270);
            this.buttonYearDistribution.Name = "buttonYearDistribution";
            this.buttonYearDistribution.Size = new System.Drawing.Size(141, 49);
            this.buttonYearDistribution.TabIndex = 7;
            this.buttonYearDistribution.Text = "YearDistribution";
            this.buttonYearDistribution.UseVisualStyleBackColor = true;
            this.buttonYearDistribution.Click += new System.EventHandler(this.buttonYearDistribution_Click);
            // 
            // HourDistribution
            // 
            this.HourDistribution.Location = new System.Drawing.Point(492, 91);
            this.HourDistribution.Name = "HourDistribution";
            this.HourDistribution.Size = new System.Drawing.Size(140, 55);
            this.HourDistribution.TabIndex = 6;
            this.HourDistribution.Text = "Hour Distribution";
            this.HourDistribution.UseVisualStyleBackColor = true;
            this.HourDistribution.Click += new System.EventHandler(this.HourDistribution_Click);
            // 
            // MonthDistribution
            // 
            this.MonthDistribution.Enabled = false;
            this.MonthDistribution.Location = new System.Drawing.Point(135, 91);
            this.MonthDistribution.Name = "MonthDistribution";
            this.MonthDistribution.Size = new System.Drawing.Size(141, 55);
            this.MonthDistribution.TabIndex = 5;
            this.MonthDistribution.Text = "Month Distribution";
            this.MonthDistribution.UseVisualStyleBackColor = true;
            this.MonthDistribution.Click += new System.EventHandler(this.MonthDistribution_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 625);
            this.Controls.Add(this.buttonCurrent);
            this.Controls.Add(this.buttonRoseDiagram);
            this.Controls.Add(this.buttonYearDistribution);
            this.Controls.Add(this.HourDistribution);
            this.Controls.Add(this.MonthDistribution);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCurrent;
        private System.Windows.Forms.Button buttonRoseDiagram;
        private System.Windows.Forms.Button buttonYearDistribution;
        private System.Windows.Forms.Button HourDistribution;
        private System.Windows.Forms.Button MonthDistribution;
    }
}