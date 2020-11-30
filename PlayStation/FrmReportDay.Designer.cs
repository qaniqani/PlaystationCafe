namespace PlayStation
{
    partial class FrmReportDay
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
            this.lvCalc = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblCancelAdditionAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCancelAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalUsedTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalAddition = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvCalc
            // 
            this.lvCalc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader13,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader8,
            this.columnHeader12,
            this.columnHeader11,
            this.columnHeader14});
            this.lvCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCalc.FullRowSelect = true;
            this.lvCalc.GridLines = true;
            this.lvCalc.Location = new System.Drawing.Point(10, 10);
            this.lvCalc.Name = "lvCalc";
            this.lvCalc.Size = new System.Drawing.Size(1097, 413);
            this.lvCalc.TabIndex = 0;
            this.lvCalc.UseCompatibleStateImageBehavior = false;
            this.lvCalc.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "İşlem No";
            this.columnHeader1.Width = 53;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Makine Adı";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hesap Türü";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader13
            // 
            this.columnHeader13.DisplayIndex = 4;
            this.columnHeader13.Text = "İşlem Durumu";
            this.columnHeader13.Width = 98;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "Tarife Adı";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Baş. Saati";
            this.columnHeader5.Width = 107;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Bitiş Saati";
            this.columnHeader6.Width = 101;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Kullanılan Süre";
            this.columnHeader7.Width = 82;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Adisyonlar";
            this.columnHeader9.Width = 65;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Adisyon Tutarı";
            this.columnHeader10.Width = 85;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Hesap Tutarı";
            this.columnHeader8.Width = 74;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Toplam";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "İşlem Notu";
            this.columnHeader11.Width = 109;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblCancelAdditionAmount);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.lblCancelAmount);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.lblTotalUsedTime);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.lblTotalAddition);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.lblTotalAmount);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(10, 423);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1097, 77);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Hesap Özeti";
            // 
            // lblCancelAdditionAmount
            // 
            this.lblCancelAdditionAmount.AutoSize = true;
            this.lblCancelAdditionAmount.Location = new System.Drawing.Point(747, 40);
            this.lblCancelAdditionAmount.Name = "lblCancelAdditionAmount";
            this.lblCancelAdditionAmount.Size = new System.Drawing.Size(37, 13);
            this.lblCancelAdditionAmount.TabIndex = 9;
            this.lblCancelAdditionAmount.Text = "0,0 TL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(640, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "İptal Adisyon Tutarı";
            // 
            // lblCancelAmount
            // 
            this.lblCancelAmount.AutoSize = true;
            this.lblCancelAmount.Location = new System.Drawing.Point(528, 40);
            this.lblCancelAmount.Name = "lblCancelAmount";
            this.lblCancelAmount.Size = new System.Drawing.Size(37, 13);
            this.lblCancelAmount.TabIndex = 7;
            this.lblCancelAmount.Text = "0,0 TL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Toplam İptal Tutarları";
            // 
            // lblTotalUsedTime
            // 
            this.lblTotalUsedTime.AutoSize = true;
            this.lblTotalUsedTime.Location = new System.Drawing.Point(979, 40);
            this.lblTotalUsedTime.Name = "lblTotalUsedTime";
            this.lblTotalUsedTime.Size = new System.Drawing.Size(35, 13);
            this.lblTotalUsedTime.TabIndex = 5;
            this.lblTotalUsedTime.Text = "00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(860, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Toplam Kullanılan Süre";
            // 
            // lblTotalAddition
            // 
            this.lblTotalAddition.AutoSize = true;
            this.lblTotalAddition.Location = new System.Drawing.Point(309, 40);
            this.lblTotalAddition.Name = "lblTotalAddition";
            this.lblTotalAddition.Size = new System.Drawing.Size(37, 13);
            this.lblTotalAddition.TabIndex = 3;
            this.lblTotalAddition.Text = "0,0 TL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Toplam Adisyon Tutarı";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(92, 40);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(37, 13);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0,0 TL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toplam Tutar";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "İptal Sebebi";
            this.columnHeader14.Width = 75;
            // 
            // FrmReportDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 510);
            this.Controls.Add(this.lvCalc);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReportDay";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Günlük Rapor";
            this.Load += new System.EventHandler(this.FrmReportDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCalc;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalUsedTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalAddition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label lblCancelAdditionAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCancelAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader columnHeader14;

    }
}