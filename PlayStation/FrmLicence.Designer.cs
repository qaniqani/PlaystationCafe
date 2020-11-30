namespace PlayStation
{
    partial class FrmLicence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLicence));
            this.btnClose = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLicenseKey = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.lblLicenceEndDate = new System.Windows.Forms.Label();
            this.lblLicenceStartDate = new System.Windows.Forms.Label();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLicenceUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNewRegisterUser = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(307, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(92, 346);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(139, 13);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.nvisionsoft.net";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Console Plus :";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 261);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(370, 70);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLicenseKey);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblLicenceEndDate);
            this.groupBox1.Controls.Add(this.lblLicenceStartDate);
            this.groupBox1.Controls.Add(this.lblUserCount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 148);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lisans Kodu ve Detayları";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(124, 112);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(237, 33);
            this.lblMessage.TabIndex = 16;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Lisans Durumunuz: ";
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.Location = new System.Drawing.Point(83, 17);
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.Size = new System.Drawing.Size(278, 20);
            this.txtLicenseKey.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Lisans Bitiş Tarihi: ";
            // 
            // lblLicenceEndDate
            // 
            this.lblLicenceEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLicenceEndDate.Location = new System.Drawing.Point(124, 87);
            this.lblLicenceEndDate.Name = "lblLicenceEndDate";
            this.lblLicenceEndDate.Size = new System.Drawing.Size(237, 21);
            this.lblLicenceEndDate.TabIndex = 10;
            this.lblLicenceEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLicenceStartDate
            // 
            this.lblLicenceStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLicenceStartDate.Location = new System.Drawing.Point(124, 65);
            this.lblLicenceStartDate.Name = "lblLicenceStartDate";
            this.lblLicenceStartDate.Size = new System.Drawing.Size(237, 21);
            this.lblLicenceStartDate.TabIndex = 9;
            this.lblLicenceStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserCount
            // 
            this.lblUserCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUserCount.Location = new System.Drawing.Point(124, 41);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(237, 21);
            this.lblUserCount.TabIndex = 8;
            this.lblUserCount.Text = "0";
            this.lblUserCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Lisans Başlangıç Tarihi: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Kullanıcı Sayısı: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Lisans Kodu: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "NVision Soft Yazılım Geliştirme";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "Lisans bilgileri belirli periyotlarda güncellenmesi gerekmektedir.\r\nBu periyotlar" +
    " NVision Soft Yazılım Geliştirme tarafından belirlenmektedir.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLicenceUpdate
            // 
            this.btnLicenceUpdate.Location = new System.Drawing.Point(214, 232);
            this.btnLicenceUpdate.Name = "btnLicenceUpdate";
            this.btnLicenceUpdate.Size = new System.Drawing.Size(168, 23);
            this.btnLicenceUpdate.TabIndex = 15;
            this.btnLicenceUpdate.Text = "Lisans Bilgilerini Güncelle";
            this.btnLicenceUpdate.UseVisualStyleBackColor = true;
            this.btnLicenceUpdate.Click += new System.EventHandler(this.btnLicenceUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(201, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Lisans Yöneticisi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::PlayStation.Properties.Resources.Consoleplus_logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnNewRegisterUser
            // 
            this.btnNewRegisterUser.Location = new System.Drawing.Point(12, 232);
            this.btnNewRegisterUser.Name = "btnNewRegisterUser";
            this.btnNewRegisterUser.Size = new System.Drawing.Size(149, 23);
            this.btnNewRegisterUser.TabIndex = 26;
            this.btnNewRegisterUser.Text = "Yeni Kullanıcı Kaydı";
            this.btnNewRegisterUser.UseVisualStyleBackColor = true;
            this.btnNewRegisterUser.Visible = false;
            this.btnNewRegisterUser.Click += new System.EventHandler(this.btnNewRegisterUser_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 418);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNewRegisterUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLicenceUpdate);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lisans Güncelleme";
            this.Load += new System.EventHandler(this.FrmLicence_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblLicenceEndDate;
        private System.Windows.Forms.Label lblLicenceStartDate;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLicenceUpdate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtLicenseKey;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNewRegisterUser;
        private System.Windows.Forms.Button button1;
    }
}