
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.maintab = new System.Windows.Forms.TabControl();
            this.tbdash = new System.Windows.Forms.TabPage();
            this.tbdentry = new System.Windows.Forms.TabPage();
            this.tdMasters = new System.Windows.Forms.TabPage();
            this.tdreport = new System.Windows.Forms.TabPage();
            this.tdsetting = new System.Windows.Forms.TabPage();
            this.tdUtilities = new System.Windows.Forms.TabPage();
            this.tdhelp = new System.Windows.Forms.TabPage();
            this.tdDataMerge = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.maintab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.maintab.Location = new System.Drawing.Point(0, 132);
            this.maintab.Name = "maintab";
            this.maintab.Padding = new System.Drawing.Point(43, 3);
            this.maintab.SelectedIndex = 0;
            this.maintab.Size = new System.Drawing.Size(2050, 750);
            this.maintab.TabIndex = 100;
            // 
            // tbdash
            // 
            this.tbdash.BackColor = System.Drawing.Color.Lavender;
            this.tbdash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbdash.BackgroundImage")));
            this.tbdash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbdash.Location = new System.Drawing.Point(4, 34);
            this.tbdash.Name = "tbdash";
            this.tbdash.Padding = new System.Windows.Forms.Padding(3);
            this.tbdash.Size = new System.Drawing.Size(2042, 712);
            this.tbdash.TabIndex = 0;
            this.tbdash.Text = "Home (Alt+H)";
            this.tbdash.Click += new System.EventHandler(this.tbdash_Click);
            // 
            // tbdentry
            // 
            this.tbdentry.BackColor = System.Drawing.Color.Lavender;
            this.tbdentry.Location = new System.Drawing.Point(4, 34);
            this.tbdentry.Name = "tbdentry";
            this.tbdentry.Size = new System.Drawing.Size(2042, 712);
            this.tbdentry.TabIndex = 1;
            this.tbdentry.Text = "Data Entry(Alt+D)";
            // 
            // tdMasters
            // 
            this.tdMasters.BackColor = System.Drawing.Color.Lavender;
            this.tdMasters.Location = new System.Drawing.Point(4, 34);
            this.tdMasters.Name = "tdMasters";
            this.tdMasters.Size = new System.Drawing.Size(2042, 712);
            this.tdMasters.TabIndex = 2;
            this.tdMasters.Text = "Masters(Alt+M)";
            // 
            // tdreport
            // 
            this.tdreport.BackColor = System.Drawing.Color.Lavender;
            this.tdreport.Location = new System.Drawing.Point(4, 34);
            this.tdreport.Name = "tdreport";
            this.tdreport.Size = new System.Drawing.Size(2042, 712);
            this.tdreport.TabIndex = 3;
            this.tdreport.Text = "Report(Alt+R)";
            // 
            // tdsetting
            // 
            this.tdsetting.BackColor = System.Drawing.Color.Lavender;
            this.tdsetting.Location = new System.Drawing.Point(4, 34);
            this.tdsetting.Name = "tdsetting";
            this.tdsetting.Size = new System.Drawing.Size(2042, 712);
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
            this.tdUtilities.Size = new System.Drawing.Size(2042, 712);
            this.tdUtilities.TabIndex = 5;
            this.tdUtilities.Text = "Utilities(Alt+U)";
            // 
            // tdhelp
            // 
            this.tdhelp.BackColor = System.Drawing.Color.Lavender;
            this.tdhelp.Location = new System.Drawing.Point(4, 34);
            this.tdhelp.Name = "tdhelp";
            this.tdhelp.Size = new System.Drawing.Size(2042, 712);
            this.tdhelp.TabIndex = 6;
            this.tdhelp.Text = "Help(Alt+F1)";
            // 
            // tdDataMerge
            // 
            this.tdDataMerge.BackColor = System.Drawing.Color.Lavender;
            this.tdDataMerge.Location = new System.Drawing.Point(4, 34);
            this.tdDataMerge.Name = "tdDataMerge";
            this.tdDataMerge.Size = new System.Drawing.Size(2042, 712);
            this.tdDataMerge.TabIndex = 7;
            this.tdDataMerge.Text = "DataMerge(Alt+A)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1772, 888);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 31);
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(1818, 895);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(193, 20);
            this.linkLabel1.TabIndex = 102;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "youremail@gmail.com";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(1772, 925);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 29);
            this.pictureBox2.TabIndex = 103;
            this.pictureBox2.TabStop = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(1829, 928);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(131, 24);
            this.linkLabel2.TabIndex = 104;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "+91987654321";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1623, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 66);
            this.button1.TabIndex = 105;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1683, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 37);
            this.textBox1.TabIndex = 106;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(1901, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 84);
            this.button2.TabIndex = 107;
            this.button2.Text = "Sign Up";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.maintab);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.maintab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}

