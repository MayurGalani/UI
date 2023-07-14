namespace AutoScan
{
    partial class frmAutoScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoScan));
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.btnStopScan = new System.Windows.Forms.Button();
            this.picScan = new System.Windows.Forms.PictureBox();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bgwScan = new System.ComponentModel.BackgroundWorker();
            this.pbWaiting = new System.Windows.Forms.ProgressBar();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            this.nudRes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHeightInch = new System.Windows.Forms.NumericUpDown();
            this.nudWidthInch = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxCustomPixel = new System.Windows.Forms.CheckBox();
            this.cmbColorMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightInch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthInch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(198, 10);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(72, 29);
            this.btnSelectPath.TabIndex = 0;
            this.btnSelectPath.Text = "Select Path";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(18, 15);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(174, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnStartScan
            // 
            this.btnStartScan.Location = new System.Drawing.Point(107, 58);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(75, 23);
            this.btnStartScan.TabIndex = 2;
            this.btnStartScan.Text = "Start";
            this.btnStartScan.UseVisualStyleBackColor = true;
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // btnStopScan
            // 
            this.btnStopScan.Enabled = false;
            this.btnStopScan.Location = new System.Drawing.Point(195, 58);
            this.btnStopScan.Name = "btnStopScan";
            this.btnStopScan.Size = new System.Drawing.Size(75, 23);
            this.btnStopScan.TabIndex = 3;
            this.btnStopScan.Text = "Stop";
            this.btnStopScan.UseVisualStyleBackColor = true;
            this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
            // 
            // picScan
            // 
            this.picScan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picScan.Location = new System.Drawing.Point(375, 134);
            this.picScan.Name = "picScan";
            this.picScan.Size = new System.Drawing.Size(362, 425);
            this.picScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picScan.TabIndex = 4;
            this.picScan.TabStop = false;
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(597, 72);
            this.nudWidth.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.ReadOnly = true;
            this.nudWidth.Size = new System.Drawing.Size(65, 20);
            this.nudWidth.TabIndex = 10;
            this.nudWidth.Value = new decimal(new int[] {
            1250,
            0,
            0,
            0});
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(668, 72);
            this.nudHeight.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.ReadOnly = true;
            this.nudHeight.Size = new System.Drawing.Size(65, 20);
            this.nudHeight.TabIndex = 11;
            this.nudHeight.Value = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(528, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(605, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Height";
            // 
            // bgwScan
            // 
            this.bgwScan.WorkerReportsProgress = true;
            this.bgwScan.WorkerSupportsCancellation = true;
            this.bgwScan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwScan_DoWork);
            this.bgwScan.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwScan_ProgressChanged);
            this.bgwScan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwScan_RunWorkerCompleted);
            // 
            // pbWaiting
            // 
            this.pbWaiting.Location = new System.Drawing.Point(24, 300);
            this.pbWaiting.Name = "pbWaiting";
            this.pbWaiting.Size = new System.Drawing.Size(262, 25);
            this.pbWaiting.TabIndex = 15;
            // 
            // nudTime
            // 
            this.nudTime.Location = new System.Drawing.Point(297, 302);
            this.nudTime.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            this.nudTime.Size = new System.Drawing.Size(49, 20);
            this.nudTime.TabIndex = 16;
            this.nudTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudRes
            // 
            this.nudRes.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudRes.Location = new System.Drawing.Point(672, 12);
            this.nudRes.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.nudRes.Minimum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.nudRes.Name = "nudRes";
            this.nudRes.Size = new System.Drawing.Size(65, 20);
            this.nudRes.TabIndex = 17;
            this.nudRes.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudRes.ValueChanged += new System.EventHandler(this.nudRes_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(676, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Resolution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Waiting Sec.";
            // 
            // nudHeightInch
            // 
            this.nudHeightInch.Location = new System.Drawing.Point(597, 12);
            this.nudHeightInch.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudHeightInch.Name = "nudHeightInch";
            this.nudHeightInch.Size = new System.Drawing.Size(65, 20);
            this.nudHeightInch.TabIndex = 21;
            this.nudHeightInch.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nudHeightInch.ValueChanged += new System.EventHandler(this.nudHeightInch_ValueChanged);
            // 
            // nudWidthInch
            // 
            this.nudWidthInch.Location = new System.Drawing.Point(520, 12);
            this.nudWidthInch.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudWidthInch.Name = "nudWidthInch";
            this.nudWidthInch.Size = new System.Drawing.Size(65, 20);
            this.nudWidthInch.TabIndex = 20;
            this.nudWidthInch.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudWidthInch.ValueChanged += new System.EventHandler(this.nudWidthInch_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Pixel Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(669, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Pixel Height";
            // 
            // cbxCustomPixel
            // 
            this.cbxCustomPixel.AutoSize = true;
            this.cbxCustomPixel.Location = new System.Drawing.Point(472, 75);
            this.cbxCustomPixel.Name = "cbxCustomPixel";
            this.cbxCustomPixel.Size = new System.Drawing.Size(113, 17);
            this.cbxCustomPixel.TabIndex = 24;
            this.cbxCustomPixel.Text = "Custom Pixel Units";
            this.cbxCustomPixel.UseVisualStyleBackColor = true;
            this.cbxCustomPixel.CheckedChanged += new System.EventHandler(this.cbxCustomPixel_CheckedChanged);
            // 
            // cmbColorMode
            // 
            this.cmbColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorMode.FormattingEnabled = true;
            this.cmbColorMode.Items.AddRange(new object[] {
            "Black and White",
            "Color",
            "Gray Scale"});
            this.cmbColorMode.Location = new System.Drawing.Point(375, 10);
            this.cmbColorMode.Name = "cmbColorMode";
            this.cmbColorMode.Size = new System.Drawing.Size(133, 21);
            this.cmbColorMode.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(409, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Color Mode";
            // 
            // txtWT
            // 
            this.txtWT.BackColor = System.Drawing.Color.Black;
            this.txtWT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWT.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWT.ForeColor = System.Drawing.Color.Chartreuse;
            this.txtWT.Location = new System.Drawing.Point(26, 338);
            this.txtWT.Name = "txtWT";
            this.txtWT.Size = new System.Drawing.Size(260, 29);
            this.txtWT.TabIndex = 27;
            this.txtWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmAutoScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 571);
            this.Controls.Add(this.txtWT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbColorMode);
            this.Controls.Add(this.cbxCustomPixel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudHeightInch);
            this.Controls.Add(this.nudWidthInch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudRes);
            this.Controls.Add(this.nudTime);
            this.Controls.Add(this.pbWaiting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.picScan);
            this.Controls.Add(this.btnStopScan);
            this.Controls.Add(this.btnStartScan);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnSelectPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAutoScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic Scanner  - tiff format File";
            this.Load += new System.EventHandler(this.frmAutoScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightInch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthInch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.Button btnStopScan;
        private System.Windows.Forms.PictureBox picScan;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bgwScan;
        private System.Windows.Forms.ProgressBar pbWaiting;
        private System.Windows.Forms.NumericUpDown nudTime;
        private System.Windows.Forms.NumericUpDown nudRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudHeightInch;
        private System.Windows.Forms.NumericUpDown nudWidthInch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxCustomPixel;
        private System.Windows.Forms.ComboBox cmbColorMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWT;
    }
}

