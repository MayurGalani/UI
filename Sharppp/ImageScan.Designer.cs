namespace SHARP_ACCOUNTING
{
    partial class ImageScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageScan));
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.pb_scanned_image = new System.Windows.Forms.PictureBox();
            this.bnt_copy_jpg_to_scan = new System.Windows.Forms.Button();
            this.btn_remove_image = new System.Windows.Forms.Button();
            this.lbl_image_filename = new System.Windows.Forms.Label();
            this.lbl_image_title = new System.Windows.Forms.Label();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnMakeSelection = new System.Windows.Forms.Button();
            this.btnCrop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_scanned_image)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Type :";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Documents"});
            this.cbType.Location = new System.Drawing.Point(122, 13);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.Sorted = true;
            this.cbType.TabIndex = 1;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(6, 88);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(131, 41);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 132);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(70, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Image Saved";
            this.lblResult.Visible = false;
            // 
            // lbDevices
            // 
            this.lbDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Location = new System.Drawing.Point(6, 39);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(686, 43);
            this.lbDevices.TabIndex = 4;
            // 
            // pb_scanned_image
            // 
            this.pb_scanned_image.Location = new System.Drawing.Point(12, 171);
            this.pb_scanned_image.Name = "pb_scanned_image";
            this.pb_scanned_image.Size = new System.Drawing.Size(675, 466);
            this.pb_scanned_image.TabIndex = 5;
            this.pb_scanned_image.TabStop = false;
            this.pb_scanned_image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_scanned_image_MouseDown);
            this.pb_scanned_image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_scanned_image_MouseMove);
            this.pb_scanned_image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_scanned_image_MouseUp);
            // 
            // bnt_copy_jpg_to_scan
            // 
            this.bnt_copy_jpg_to_scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_copy_jpg_to_scan.Location = new System.Drawing.Point(252, 88);
            this.bnt_copy_jpg_to_scan.Name = "bnt_copy_jpg_to_scan";
            this.bnt_copy_jpg_to_scan.Size = new System.Drawing.Size(131, 41);
            this.bnt_copy_jpg_to_scan.TabIndex = 6;
            this.bnt_copy_jpg_to_scan.Text = "Link Jpg to Scan";
            this.bnt_copy_jpg_to_scan.UseVisualStyleBackColor = true;
            this.bnt_copy_jpg_to_scan.Click += new System.EventHandler(this.bnt_copy_jpg_to_scan_Click);
            // 
            // btn_remove_image
            // 
            this.btn_remove_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remove_image.Location = new System.Drawing.Point(486, 88);
            this.btn_remove_image.Name = "btn_remove_image";
            this.btn_remove_image.Size = new System.Drawing.Size(131, 41);
            this.btn_remove_image.TabIndex = 7;
            this.btn_remove_image.Text = "Remove Image";
            this.btn_remove_image.UseVisualStyleBackColor = true;
            this.btn_remove_image.Click += new System.EventHandler(this.btn_remove_image_Click);
            // 
            // lbl_image_filename
            // 
            this.lbl_image_filename.AutoSize = true;
            this.lbl_image_filename.Location = new System.Drawing.Point(12, 640);
            this.lbl_image_filename.Name = "lbl_image_filename";
            this.lbl_image_filename.Size = new System.Drawing.Size(35, 13);
            this.lbl_image_filename.TabIndex = 8;
            this.lbl_image_filename.Text = "label2";
            // 
            // lbl_image_title
            // 
            this.lbl_image_title.AutoSize = true;
            this.lbl_image_title.Location = new System.Drawing.Point(249, 17);
            this.lbl_image_title.Name = "lbl_image_title";
            this.lbl_image_title.Size = new System.Drawing.Size(10, 13);
            this.lbl_image_title.TabIndex = 9;
            this.lbl_image_title.Text = " ";
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateLeft.Image")));
            this.btnRotateLeft.Location = new System.Drawing.Point(639, 88);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(48, 48);
            this.btnRotateLeft.TabIndex = 10;
            this.btnRotateLeft.UseVisualStyleBackColor = true;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnMakeSelection
            // 
            this.btnMakeSelection.Location = new System.Drawing.Point(104, 142);
            this.btnMakeSelection.Name = "btnMakeSelection";
            this.btnMakeSelection.Size = new System.Drawing.Size(115, 23);
            this.btnMakeSelection.TabIndex = 11;
            this.btnMakeSelection.Text = "Make Selection";
            this.btnMakeSelection.UseVisualStyleBackColor = true;
            this.btnMakeSelection.Click += new System.EventHandler(this.btnMakeSelection_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Location = new System.Drawing.Point(252, 140);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(75, 26);
            this.btnCrop.TabIndex = 12;
            this.btnCrop.Text = "Crop";
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // ImageScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 662);
            this.Controls.Add(this.btnCrop);
            this.Controls.Add(this.btnMakeSelection);
            this.Controls.Add(this.btnRotateLeft);
            this.Controls.Add(this.lbl_image_title);
            this.Controls.Add(this.lbl_image_filename);
            this.Controls.Add(this.btn_remove_image);
            this.Controls.Add(this.bnt_copy_jpg_to_scan);
            this.Controls.Add(this.pb_scanned_image);
            this.Controls.Add(this.lbDevices);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label1);
            this.Name = "ImageScan";
            this.Text = "ImageScan";
            this.Load += new System.EventHandler(this.ImageScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_scanned_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.PictureBox pb_scanned_image;
        private System.Windows.Forms.Button bnt_copy_jpg_to_scan;
        private System.Windows.Forms.Button btn_remove_image;
        private System.Windows.Forms.Label lbl_image_filename;
        private System.Windows.Forms.Label lbl_image_title;
        private System.Windows.Forms.Button btnRotateLeft;
        internal System.Windows.Forms.Button btnMakeSelection;
        internal System.Windows.Forms.Button btnCrop;
    }
}