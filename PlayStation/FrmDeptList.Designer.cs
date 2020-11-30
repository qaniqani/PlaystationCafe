namespace PlayStation
{
    partial class FrmDeptList
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
            this.dtDebtDate = new DevExpress.XtraEditors.DateEdit();
            this.txtDebtAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtGsmNr = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvDebtList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDebtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDebtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGsmNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtDebtDate);
            this.groupControl1.Controls.Add(this.txtDebtAmount);
            this.groupControl1.Controls.Add(this.txtGsmNr);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(491, 96);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Borçlu Bilgileri";
            // 
            // dtDebtDate
            // 
            this.dtDebtDate.EditValue = null;
            this.dtDebtDate.Location = new System.Drawing.Point(271, 64);
            this.dtDebtDate.Name = "dtDebtDate";
            this.dtDebtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDebtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDebtDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dtDebtDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dtDebtDate.Size = new System.Drawing.Size(100, 20);
            this.dtDebtDate.TabIndex = 8;
            // 
            // txtDebtAmount
            // 
            this.txtDebtAmount.Location = new System.Drawing.Point(271, 32);
            this.txtDebtAmount.Name = "txtDebtAmount";
            this.txtDebtAmount.Properties.Mask.EditMask = "n";
            this.txtDebtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDebtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtDebtAmount.TabIndex = 7;
            // 
            // txtGsmNr
            // 
            this.txtGsmNr.Location = new System.Drawing.Point(78, 64);
            this.txtGsmNr.Name = "txtGsmNr";
            this.txtGsmNr.Properties.Mask.EditMask = "0(999)000 00 00";
            this.txtGsmNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtGsmNr.Size = new System.Drawing.Size(111, 20);
            this.txtGsmNr.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(111, 20);
            this.txtName.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::PlayStation.Properties.Resources.btn_add;
            this.btnSave.Location = new System.Drawing.Point(393, 29);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ödeme Tarihi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Borç Tutarı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "GSM No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adı Soyadı";
            // 
            // lvDebtList
            // 
            this.lvDebtList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvDebtList.FullRowSelect = true;
            this.lvDebtList.GridLines = true;
            this.lvDebtList.Location = new System.Drawing.Point(12, 114);
            this.lvDebtList.MultiSelect = false;
            this.lvDebtList.Name = "lvDebtList";
            this.lvDebtList.Size = new System.Drawing.Size(491, 318);
            this.lvDebtList.TabIndex = 1;
            this.lvDebtList.UseCompatibleStateImageBehavior = false;
            this.lvDebtList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Adı Soyadı";
            this.columnHeader1.Width = 104;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "GSM No";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tutar";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ödeme Tarihi";
            this.columnHeader4.Width = 111;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Borç Tarihi";
            this.columnHeader5.Width = 89;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::PlayStation.Properties.Resources.check_green;
            this.btnOk.Location = new System.Drawing.Point(428, 438);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Tamam";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::PlayStation.Properties.Resources.btn_cancel;
            this.btnDelete.Location = new System.Drawing.Point(12, 438);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmDeptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 470);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lvDebtList);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeptList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borç Listesi";
            this.Load += new System.EventHandler(this.FrmDeptList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDebtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDebtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGsmNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvDebtList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private DevExpress.XtraEditors.DateEdit dtDebtDate;
        private DevExpress.XtraEditors.TextEdit txtDebtAmount;
        private DevExpress.XtraEditors.TextEdit txtGsmNr;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}