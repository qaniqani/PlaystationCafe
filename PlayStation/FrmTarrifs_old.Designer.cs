namespace PlayStation
{
    partial class FrmTarrifs_old
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
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbActive = new DevExpress.XtraEditors.CheckEdit();
            this.cbSelected = new DevExpress.XtraEditors.CheckEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTarrifsName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lvTarrifsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSelected.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarrifsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.cmsRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbActive);
            this.groupControl1.Controls.Add(this.cbSelected);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtTotal);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtTarrifsName);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(654, 69);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Tarife Ayarları";
            // 
            // cbActive
            // 
            this.cbActive.Location = new System.Drawing.Point(478, 35);
            this.cbActive.Name = "cbActive";
            this.cbActive.Properties.Caption = "Aktif/ Pasif";
            this.cbActive.Size = new System.Drawing.Size(75, 19);
            this.cbActive.TabIndex = 5;
            // 
            // cbSelected
            // 
            this.cbSelected.Location = new System.Drawing.Point(397, 35);
            this.cbSelected.Name = "cbSelected";
            this.cbSelected.Properties.Caption = "Seçili Değer";
            this.cbSelected.Size = new System.Drawing.Size(75, 19);
            this.cbSelected.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::PlayStation.Properties.Resources.btn_add;
            this.btnSave.Location = new System.Drawing.Point(570, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "TL";
            // 
            // txtTotal
            // 
            this.txtTotal.EditValue = "0";
            this.txtTotal.Location = new System.Drawing.Point(272, 35);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(95, 20);
            this.txtTotal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Saat Ücreti";
            // 
            // txtTarrifsName
            // 
            this.txtTarrifsName.Location = new System.Drawing.Point(73, 35);
            this.txtTarrifsName.Name = "txtTarrifsName";
            this.txtTarrifsName.Size = new System.Drawing.Size(127, 20);
            this.txtTarrifsName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarife Adı";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lvTarrifsList);
            this.groupControl2.Location = new System.Drawing.Point(12, 87);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(654, 203);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Tarifeler";
            // 
            // lvTarrifsList
            // 
            this.lvTarrifsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvTarrifsList.FullRowSelect = true;
            this.lvTarrifsList.GridLines = true;
            this.lvTarrifsList.Location = new System.Drawing.Point(5, 24);
            this.lvTarrifsList.MultiSelect = false;
            this.lvTarrifsList.Name = "lvTarrifsList";
            this.lvTarrifsList.Size = new System.Drawing.Size(644, 174);
            this.lvTarrifsList.TabIndex = 5;
            this.lvTarrifsList.UseCompatibleStateImageBehavior = false;
            this.lvTarrifsList.View = System.Windows.Forms.View.Details;
            this.lvTarrifsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvTarrifsList_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tarife Adı";
            this.columnHeader1.Width = 269;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Saat Ücreti";
            this.columnHeader2.Width = 188;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Seçili Değer";
            this.columnHeader3.Width = 140;
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEdit,
            this.silToolStripMenuItem});
            this.cmsRightClick.Name = "contextMenuStrip1";
            this.cmsRightClick.Size = new System.Drawing.Size(153, 70);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(152, 22);
            this.tsmEdit.Text = "&Düzenle";
            this.tsmEdit.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.silToolStripMenuItem.Text = "&Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::PlayStation.Properties.Resources.check_green;
            this.btnOk.Location = new System.Drawing.Point(587, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Tamam";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmTarrifs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 328);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmTarrifs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifeler";
            this.Load += new System.EventHandler(this.FrmTarrifs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSelected.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarrifsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.cmsRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtTarrifsName;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit cbSelected;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ListView lvTarrifsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private DevExpress.XtraEditors.CheckEdit cbActive;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}