
namespace UI
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
            this.maintab = new System.Windows.Forms.TabControl();
            this.tbdash = new System.Windows.Forms.TabPage();
            this.tbdentry = new System.Windows.Forms.TabPage();
            this.tdMasters = new System.Windows.Forms.TabPage();
            this.tdreport = new System.Windows.Forms.TabPage();
            this.tdsetting = new System.Windows.Forms.TabPage();
            this.tdUtilities = new System.Windows.Forms.TabPage();
            this.tdhelp = new System.Windows.Forms.TabPage();
            this.tdDataMerge = new System.Windows.Forms.TabPage();
            this.maintab.SuspendLayout();
            this.SuspendLayout();
            // 
            // maintab
            // 
            this.maintab.AllowDrop = true;
            this.maintab.Controls.Add(this.tbdash);
            this.maintab.Controls.Add(this.tbdentry);
            this.maintab.Controls.Add(this.tdMasters);
            this.maintab.Controls.Add(this.tdreport);
            this.maintab.Controls.Add(this.tdsetting);
            this.maintab.Controls.Add(this.tdUtilities);
            this.maintab.Controls.Add(this.tdhelp);
            this.maintab.Controls.Add(this.tdDataMerge);
            this.maintab.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintab.HotTrack = true;
            this.maintab.ItemSize = new System.Drawing.Size(100, 30);
            this.maintab.Location = new System.Drawing.Point(0, 81);
            this.maintab.Name = "maintab";
            this.maintab.Padding = new System.Drawing.Point(45, 3);
            this.maintab.SelectedIndex = 0;
            this.maintab.Size = new System.Drawing.Size(2014, 1080);
            this.maintab.TabIndex = 100;
            // 
            // tbdash
            // 
            this.tbdash.BackColor = System.Drawing.Color.Lavender;
            this.tbdash.Location = new System.Drawing.Point(4, 34);
            this.tbdash.Name = "tbdash";
            this.tbdash.Padding = new System.Windows.Forms.Padding(3);
            this.tbdash.Size = new System.Drawing.Size(2006, 1042);
            this.tbdash.TabIndex = 0;
            this.tbdash.Text = "Home (Alt+H)";
            // 
            // tbdentry
            // 
            this.tbdentry.BackColor = System.Drawing.Color.Lavender;
            this.tbdentry.Location = new System.Drawing.Point(4, 34);
            this.tbdentry.Name = "tbdentry";
            this.tbdentry.Size = new System.Drawing.Size(1889, 1042);
            this.tbdentry.TabIndex = 1;
            this.tbdentry.Text = "Data Entry(Alt+D)";
            this.tbdentry.Click += new System.EventHandler(this.tbdentry_Click);
            // 
            // tdMasters
            // 
            this.tdMasters.BackColor = System.Drawing.Color.Lavender;
            this.tdMasters.Location = new System.Drawing.Point(4, 34);
            this.tdMasters.Name = "tdMasters";
            this.tdMasters.Size = new System.Drawing.Size(1889, 1042);
            this.tdMasters.TabIndex = 2;
            this.tdMasters.Text = "Masters(Alt+M)";
            // 
            // tdreport
            // 
            this.tdreport.BackColor = System.Drawing.Color.Lavender;
            this.tdreport.Location = new System.Drawing.Point(4, 34);
            this.tdreport.Name = "tdreport";
            this.tdreport.Size = new System.Drawing.Size(1889, 1042);
            this.tdreport.TabIndex = 3;
            this.tdreport.Text = "Report(Alt+R)";
            // 
            // tdsetting
            // 
            this.tdsetting.BackColor = System.Drawing.Color.Lavender;
            this.tdsetting.Location = new System.Drawing.Point(4, 34);
            this.tdsetting.Name = "tdsetting";
            this.tdsetting.Size = new System.Drawing.Size(1889, 1042);
            this.tdsetting.TabIndex = 4;
            this.tdsetting.Text = "Setting(Alt+E)";
            // 
            // tdUtilities
            // 
            this.tdUtilities.BackColor = System.Drawing.Color.Lavender;
            this.tdUtilities.Location = new System.Drawing.Point(4, 34);
            this.tdUtilities.Margin = new System.Windows.Forms.Padding(6);
            this.tdUtilities.Name = "tdUtilities";
            this.tdUtilities.Padding = new System.Windows.Forms.Padding(6);
            this.tdUtilities.Size = new System.Drawing.Size(1889, 1042);
            this.tdUtilities.TabIndex = 5;
            this.tdUtilities.Text = "Utilities(Alt+U)";
            // 
            // tdhelp
            // 
            this.tdhelp.BackColor = System.Drawing.Color.Lavender;
            this.tdhelp.Location = new System.Drawing.Point(4, 34);
            this.tdhelp.Name = "tdhelp";
            this.tdhelp.Size = new System.Drawing.Size(1889, 1042);
            this.tdhelp.TabIndex = 6;
            this.tdhelp.Text = "Help(Alt+F1)";
            // 
            // tdDataMerge
            // 
            this.tdDataMerge.BackColor = System.Drawing.Color.Lavender;
            this.tdDataMerge.Location = new System.Drawing.Point(4, 34);
            this.tdDataMerge.Name = "tdDataMerge";
            this.tdDataMerge.Size = new System.Drawing.Size(1889, 1042);
            this.tdDataMerge.TabIndex = 7;
            this.tdDataMerge.Text = "DataMerge(Alt+A)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.maintab);
            this.Name = "Form1";
            this.Text = "Form1";
            this.maintab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tbdentry;
        private System.Windows.Forms.TabPage tdMasters;
        private System.Windows.Forms.TabPage tdreport;
        private System.Windows.Forms.TabPage tdsetting;
        private System.Windows.Forms.TabPage tdUtilities;
        private System.Windows.Forms.TabPage tdhelp;
        private System.Windows.Forms.TabPage tdDataMerge;
        internal System.Windows.Forms.TabPage tbdash;
        internal System.Windows.Forms.TabControl maintab;
    }
}

