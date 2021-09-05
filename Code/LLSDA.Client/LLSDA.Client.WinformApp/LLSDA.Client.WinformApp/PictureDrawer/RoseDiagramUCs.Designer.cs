namespace LLSDA.Client.Winform
{
    partial class RoseDiagramUCs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartRose = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartRose)).BeginInit();
            this.SuspendLayout();
            // 
            // chartRose
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRose.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRose.Legends.Add(legend1);
            this.chartRose.Location = new System.Drawing.Point(21, 53);
            this.chartRose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartRose.Name = "chartRose";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar;
            series1.Color = System.Drawing.Color.Red;
            series1.CustomProperties = "RadarDrawingStyle=Line, CircularLabelsStyle=Circular, AreaDrawingStyle=Polygon";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Lightning Direction";
            this.chartRose.Series.Add(series1);
            this.chartRose.Size = new System.Drawing.Size(564, 380);
            this.chartRose.TabIndex = 0;
            this.chartRose.Text = "RoseDiagram";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSave.Location = new System.Drawing.Point(612, 317);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(108, 39);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCopy.Location = new System.Drawing.Point(612, 395);
            this.buttonCopy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(108, 39);
            this.buttonCopy.TabIndex = 2;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // RoseDiagramUCs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.chartRose);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RoseDiagramUCs";
            this.Size = new System.Drawing.Size(744, 545);
            ((System.ComponentModel.ISupportInitialize)(this.chartRose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartRose;

    }
}
