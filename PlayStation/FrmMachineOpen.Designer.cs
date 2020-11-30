namespace PlayStation
{
    partial class FrmMachineOpen
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
            this.lblMachineName = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtTime = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btn180Min = new DevExpress.XtraEditors.SimpleButton();
            this.btn150Min = new DevExpress.XtraEditors.SimpleButton();
            this.btn120Min = new DevExpress.XtraEditors.SimpleButton();
            this.btn90Min = new DevExpress.XtraEditors.SimpleButton();
            this.btn75Min = new DevExpress.XtraEditors.SimpleButton();
            this.btn60Min = new DevExpress.XtraEditors.SimpleButton();
            this.btn45Min = new DevExpress.XtraEditors.SimpleButton();
            this.btn30Min = new DevExpress.XtraEditors.SimpleButton();
            this.btn15Min = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOkey = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFreeTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMachineName
            // 
            this.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMachineName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMachineName.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblMachineName.Location = new System.Drawing.Point(10, 10);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(425, 66);
            this.lblMachineName.TabIndex = 0;
            this.lblMachineName.Text = "Masa 16";
            this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtTime);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtTotal);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Location = new System.Drawing.Point(10, 88);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(425, 78);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Süre veya Ücret Sınırı";
            // 
            // txtTime
            // 
            this.txtTime.EditValue = "0";
            this.txtTime.Location = new System.Drawing.Point(72, 37);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.Mask.EditMask = "d";
            this.txtTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTime.Size = new System.Drawing.Size(82, 20);
            this.txtTime.TabIndex = 1;
            this.txtTime.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            this.txtTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTime_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "DK";
            // 
            // txtTotal
            // 
            this.txtTotal.EditValue = "0";
            this.txtTotal.Location = new System.Drawing.Point(237, 37);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 2;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            this.txtTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTime_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "TL tutarında.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "veya";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Süre sınırı";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btn180Min);
            this.groupControl2.Controls.Add(this.btn150Min);
            this.groupControl2.Controls.Add(this.btn120Min);
            this.groupControl2.Controls.Add(this.btn90Min);
            this.groupControl2.Controls.Add(this.btn75Min);
            this.groupControl2.Controls.Add(this.btn60Min);
            this.groupControl2.Controls.Add(this.btn45Min);
            this.groupControl2.Controls.Add(this.btn30Min);
            this.groupControl2.Controls.Add(this.btn15Min);
            this.groupControl2.Location = new System.Drawing.Point(10, 180);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(422, 207);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Süre Tanımlama";
            // 
            // btn180Min
            // 
            this.btn180Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn180Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn180Min.Location = new System.Drawing.Point(305, 148);
            this.btn180Min.Name = "btn180Min";
            this.btn180Min.Size = new System.Drawing.Size(112, 40);
            this.btn180Min.TabIndex = 14;
            this.btn180Min.Tag = "180";
            this.btn180Min.Text = "180 DK";
            this.btn180Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btn150Min
            // 
            this.btn150Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn150Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn150Min.Location = new System.Drawing.Point(155, 148);
            this.btn150Min.Name = "btn150Min";
            this.btn150Min.Size = new System.Drawing.Size(112, 40);
            this.btn150Min.TabIndex = 13;
            this.btn150Min.Tag = "150";
            this.btn150Min.Text = "150 DK";
            this.btn150Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btn120Min
            // 
            this.btn120Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn120Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn120Min.Location = new System.Drawing.Point(6, 148);
            this.btn120Min.Name = "btn120Min";
            this.btn120Min.Size = new System.Drawing.Size(112, 40);
            this.btn120Min.TabIndex = 12;
            this.btn120Min.Tag = "120";
            this.btn120Min.Text = "120 DK";
            this.btn120Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btn90Min
            // 
            this.btn90Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn90Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn90Min.Location = new System.Drawing.Point(305, 91);
            this.btn90Min.Name = "btn90Min";
            this.btn90Min.Size = new System.Drawing.Size(112, 40);
            this.btn90Min.TabIndex = 11;
            this.btn90Min.Tag = "90";
            this.btn90Min.Text = "90 DK";
            this.btn90Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btn75Min
            // 
            this.btn75Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn75Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn75Min.Location = new System.Drawing.Point(155, 91);
            this.btn75Min.Name = "btn75Min";
            this.btn75Min.Size = new System.Drawing.Size(112, 40);
            this.btn75Min.TabIndex = 10;
            this.btn75Min.Tag = "75";
            this.btn75Min.Text = "75 DK";
            this.btn75Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btn60Min
            // 
            this.btn60Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn60Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn60Min.Location = new System.Drawing.Point(6, 91);
            this.btn60Min.Name = "btn60Min";
            this.btn60Min.Size = new System.Drawing.Size(112, 40);
            this.btn60Min.TabIndex = 9;
            this.btn60Min.Tag = "60";
            this.btn60Min.Text = "60 DK";
            this.btn60Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btn45Min
            // 
            this.btn45Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn45Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn45Min.Location = new System.Drawing.Point(305, 35);
            this.btn45Min.Name = "btn45Min";
            this.btn45Min.Size = new System.Drawing.Size(112, 40);
            this.btn45Min.TabIndex = 8;
            this.btn45Min.Tag = "45";
            this.btn45Min.Text = "45 DK";
            this.btn45Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btn30Min
            // 
            this.btn30Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn30Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn30Min.Location = new System.Drawing.Point(155, 35);
            this.btn30Min.Name = "btn30Min";
            this.btn30Min.Size = new System.Drawing.Size(112, 40);
            this.btn30Min.TabIndex = 7;
            this.btn30Min.Tag = "30";
            this.btn30Min.Text = "30 DK";
            this.btn30Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btn15Min
            // 
            this.btn15Min.Image = global::PlayStation.Properties.Resources.timer;
            this.btn15Min.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn15Min.Location = new System.Drawing.Point(6, 35);
            this.btn15Min.Name = "btn15Min";
            this.btn15Min.Size = new System.Drawing.Size(112, 40);
            this.btn15Min.TabIndex = 6;
            this.btn15Min.Tag = "15";
            this.btn15Min.Text = "15 DK";
            this.btn15Min.Click += new System.EventHandler(this.btn15Min_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::PlayStation.Properties.Resources.btn_cancel;
            this.btnCancel.Location = new System.Drawing.Point(315, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Vazgeç";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkey
            // 
            this.btnOkey.Image = global::PlayStation.Properties.Resources.check_green;
            this.btnOkey.Location = new System.Drawing.Point(160, 403);
            this.btnOkey.Name = "btnOkey";
            this.btnOkey.Size = new System.Drawing.Size(117, 36);
            this.btnOkey.TabIndex = 4;
            this.btnOkey.Text = "&Tamam";
            this.btnOkey.Click += new System.EventHandler(this.btnOkey_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFreeTime);
            this.groupBox1.Location = new System.Drawing.Point(10, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 40);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Süresiz";
            // 
            // cbFreeTime
            // 
            this.cbFreeTime.AutoSize = true;
            this.cbFreeTime.Location = new System.Drawing.Point(12, 17);
            this.cbFreeTime.Name = "cbFreeTime";
            this.cbFreeTime.Size = new System.Drawing.Size(75, 17);
            this.cbFreeTime.TabIndex = 3;
            this.cbFreeTime.Text = "&Süresiz Aç";
            this.cbFreeTime.UseVisualStyleBackColor = true;
            // 
            // FrmMachineOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 455);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkey);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.lblMachineName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMachineOpen";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masa İşlemleri";
            this.Load += new System.EventHandler(this.FrmMachineOpen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMachineName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btn180Min;
        private DevExpress.XtraEditors.SimpleButton btn150Min;
        private DevExpress.XtraEditors.SimpleButton btn120Min;
        private DevExpress.XtraEditors.SimpleButton btn90Min;
        private DevExpress.XtraEditors.SimpleButton btn75Min;
        private DevExpress.XtraEditors.SimpleButton btn60Min;
        private DevExpress.XtraEditors.SimpleButton btn45Min;
        private DevExpress.XtraEditors.SimpleButton btn30Min;
        private DevExpress.XtraEditors.SimpleButton btn15Min;
        private DevExpress.XtraEditors.SimpleButton btnOkey;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbFreeTime;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtTime;
    }
}