namespace PlayStation
{
    partial class FrmConnection
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDBClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtDBPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtDBUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtDBName = new DevExpress.XtraEditors.TextEdit();
            this.txtDBServerName = new DevExpress.XtraEditors.TextEdit();
            this.btnDBSave = new DevExpress.XtraEditors.SimpleButton();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBServerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btnDBClose);
            this.groupControl1.Controls.Add(this.txtDBPassword);
            this.groupControl1.Controls.Add(this.txtDBUserName);
            this.groupControl1.Controls.Add(this.txtDBName);
            this.groupControl1.Controls.Add(this.txtDBServerName);
            this.groupControl1.Controls.Add(this.btnDBSave);
            this.groupControl1.Controls.Add(this.label18);
            this.groupControl1.Controls.Add(this.label17);
            this.groupControl1.Controls.Add(this.label16);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(292, 232);
            this.groupControl1.TabIndex = 16;
            this.groupControl1.Text = "Bağlantı Bilgileri";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 35);
            this.label1.TabIndex = 26;
            this.label1.Text = "Sistemin çalışması için lütfen bağlantı bilgilerini eksiksiz ve doğru giriniz.";
            // 
            // btnDBClose
            // 
            this.btnDBClose.Image = global::PlayStation.Properties.Resources.btn_cancel;
            this.btnDBClose.Location = new System.Drawing.Point(199, 147);
            this.btnDBClose.Name = "btnDBClose";
            this.btnDBClose.Size = new System.Drawing.Size(75, 23);
            this.btnDBClose.TabIndex = 25;
            this.btnDBClose.Text = "İptal";
            this.btnDBClose.Click += new System.EventHandler(this.btnDBClose_Click);
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(118, 112);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.Properties.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(156, 20);
            this.txtDBPassword.TabIndex = 22;
            // 
            // txtDBUserName
            // 
            this.txtDBUserName.Location = new System.Drawing.Point(118, 86);
            this.txtDBUserName.Name = "txtDBUserName";
            this.txtDBUserName.Properties.PasswordChar = '*';
            this.txtDBUserName.Size = new System.Drawing.Size(156, 20);
            this.txtDBUserName.TabIndex = 20;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(118, 60);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(156, 20);
            this.txtDBName.TabIndex = 18;
            // 
            // txtDBServerName
            // 
            this.txtDBServerName.Location = new System.Drawing.Point(118, 34);
            this.txtDBServerName.Name = "txtDBServerName";
            this.txtDBServerName.Size = new System.Drawing.Size(156, 20);
            this.txtDBServerName.TabIndex = 16;
            // 
            // btnDBSave
            // 
            this.btnDBSave.Image = global::PlayStation.Properties.Resources.btn_add;
            this.btnDBSave.Location = new System.Drawing.Point(118, 147);
            this.btnDBSave.Name = "btnDBSave";
            this.btnDBSave.Size = new System.Drawing.Size(75, 23);
            this.btnDBSave.TabIndex = 24;
            this.btnDBSave.Text = "Kaydet";
            this.btnDBSave.Click += new System.EventHandler(this.btnDBSave_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 115);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "Parola";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "Kullanıcı Adı";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Database Adı";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Sunucu";
            // 
            // FrmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 258);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veritabanı Ayarları";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBServerName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnDBClose;
        private DevExpress.XtraEditors.TextEdit txtDBPassword;
        private DevExpress.XtraEditors.TextEdit txtDBUserName;
        private DevExpress.XtraEditors.TextEdit txtDBName;
        private DevExpress.XtraEditors.TextEdit txtDBServerName;
        private DevExpress.XtraEditors.SimpleButton btnDBSave;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
    }
}