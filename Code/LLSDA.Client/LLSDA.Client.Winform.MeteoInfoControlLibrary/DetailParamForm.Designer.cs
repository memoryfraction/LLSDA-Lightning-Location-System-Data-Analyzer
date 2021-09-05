namespace MeteoInfoControlLibrary
{
    partial class DetailParamForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxEachSideBoxNum = new RegexTextBox.RegexTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.panelCirInfo = new System.Windows.Forms.Panel();
            this.TextBoxdRCir = new RegexTextBox.RegexTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBoxSideLength = new RegexTextBox.RegexTextBox();
            this.panelBoxInfo = new System.Windows.Forms.Panel();
            this.label33 = new System.Windows.Forms.Label();
            this.radioButtonCircle = new System.Windows.Forms.RadioButton();
            this.radioButtonSquare = new System.Windows.Forms.RadioButton();
            this.panelCirInfo.SuspendLayout();
            this.panelBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(280, 160);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // textBoxEachSideBoxNum
            // 
            this.textBoxEachSideBoxNum.ForeColor = System.Drawing.Color.Black;
            this.textBoxEachSideBoxNum.Location = new System.Drawing.Point(202, 24);
            this.textBoxEachSideBoxNum.Name = "textBoxEachSideBoxNum";
            this.textBoxEachSideBoxNum.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.textBoxEachSideBoxNum.Size = new System.Drawing.Size(54, 21);
            this.textBoxEachSideBoxNum.TabIndex = 137;
            this.textBoxEachSideBoxNum.Text = "9";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(113, 28);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(71, 12);
            this.label32.TabIndex = 136;
            this.label32.Text = "每边格子数:";
            // 
            // panelCirInfo
            // 
            this.panelCirInfo.Controls.Add(this.TextBoxdRCir);
            this.panelCirInfo.Controls.Add(this.label34);
            this.panelCirInfo.Location = new System.Drawing.Point(110, 95);
            this.panelCirInfo.Name = "panelCirInfo";
            this.panelCirInfo.Size = new System.Drawing.Size(158, 28);
            this.panelCirInfo.TabIndex = 135;
            // 
            // TextBoxdRCir
            // 
            this.TextBoxdRCir.ForeColor = System.Drawing.Color.Black;
            this.TextBoxdRCir.Location = new System.Drawing.Point(92, 4);
            this.TextBoxdRCir.Name = "TextBoxdRCir";
            this.TextBoxdRCir.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.TextBoxdRCir.Size = new System.Drawing.Size(54, 21);
            this.TextBoxdRCir.TabIndex = 92;
            this.TextBoxdRCir.Text = "5";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(3, 7);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(59, 12);
            this.label34.TabIndex = 91;
            this.label34.Text = "半径[km]:";
            // 
            // textBoxSideLength
            // 
            this.textBoxSideLength.ForeColor = System.Drawing.Color.Black;
            this.textBoxSideLength.Location = new System.Drawing.Point(202, 56);
            this.textBoxSideLength.Name = "textBoxSideLength";
            this.textBoxSideLength.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.textBoxSideLength.Size = new System.Drawing.Size(54, 21);
            this.textBoxSideLength.TabIndex = 133;
            this.textBoxSideLength.Text = "5";
            // 
            // panelBoxInfo
            // 
            this.panelBoxInfo.Controls.Add(this.label33);
            this.panelBoxInfo.Location = new System.Drawing.Point(110, 51);
            this.panelBoxInfo.Name = "panelBoxInfo";
            this.panelBoxInfo.Size = new System.Drawing.Size(158, 31);
            this.panelBoxInfo.TabIndex = 134;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(3, 8);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(83, 12);
            this.label33.TabIndex = 63;
            this.label33.Text = "格子边长[km]:";
            // 
            // radioButtonCircle
            // 
            this.radioButtonCircle.AutoSize = true;
            this.radioButtonCircle.Location = new System.Drawing.Point(23, 100);
            this.radioButtonCircle.Name = "radioButtonCircle";
            this.radioButtonCircle.Size = new System.Drawing.Size(47, 16);
            this.radioButtonCircle.TabIndex = 132;
            this.radioButtonCircle.TabStop = true;
            this.radioButtonCircle.Text = "圆型";
            this.radioButtonCircle.UseVisualStyleBackColor = true;
            // 
            // radioButtonSquare
            // 
            this.radioButtonSquare.AutoSize = true;
            this.radioButtonSquare.Checked = true;
            this.radioButtonSquare.Location = new System.Drawing.Point(21, 56);
            this.radioButtonSquare.Name = "radioButtonSquare";
            this.radioButtonSquare.Size = new System.Drawing.Size(59, 16);
            this.radioButtonSquare.TabIndex = 131;
            this.radioButtonSquare.TabStop = true;
            this.radioButtonSquare.Text = "方格型";
            this.radioButtonSquare.UseVisualStyleBackColor = true;
            // 
            // DetailParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 195);
            this.Controls.Add(this.textBoxEachSideBoxNum);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.panelCirInfo);
            this.Controls.Add(this.textBoxSideLength);
            this.Controls.Add(this.panelBoxInfo);
            this.Controls.Add(this.radioButtonCircle);
            this.Controls.Add(this.radioButtonSquare);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DetailParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详细参数设置";
            this.panelCirInfo.ResumeLayout(false);
            this.panelCirInfo.PerformLayout();
            this.panelBoxInfo.ResumeLayout(false);
            this.panelBoxInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private RegexTextBox.RegexTextBox textBoxEachSideBoxNum;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panelCirInfo;
        private RegexTextBox.RegexTextBox TextBoxdRCir;
        private System.Windows.Forms.Label label34;
        private RegexTextBox.RegexTextBox textBoxSideLength;
        private System.Windows.Forms.Panel panelBoxInfo;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.RadioButton radioButtonCircle;
        private System.Windows.Forms.RadioButton radioButtonSquare;
    }
}