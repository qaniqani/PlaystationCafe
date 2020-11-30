namespace PlayStation
{
    partial class FrmOpenTarrifs
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lvTarrifsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenMachine = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lvTarrifsList);
            this.groupControl2.Location = new System.Drawing.Point(12, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(654, 203);
            this.groupControl2.TabIndex = 2;
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
            this.columnHeader3.Text = "Seçili Tarife";
            this.columnHeader3.Width = 140;
            // 
            // btnOpenMachine
            // 
            this.btnOpenMachine.Image = global::PlayStation.Properties.Resources.check_green;
            this.btnOpenMachine.Location = new System.Drawing.Point(446, 221);
            this.btnOpenMachine.Name = "btnOpenMachine";
            this.btnOpenMachine.Size = new System.Drawing.Size(130, 23);
            this.btnOpenMachine.TabIndex = 3;
            this.btnOpenMachine.Text = "Seçili Tarifeyle Aç";
            this.btnOpenMachine.Click += new System.EventHandler(this.btnOpenMachine_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::PlayStation.Properties.Resources.btn_cancel;
            this.btnCancel.Location = new System.Drawing.Point(591, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmOpenTarrifs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 255);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenMachine);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpenTarrifs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifeli Masa Aç";
            this.Load += new System.EventHandler(this.FrmOpenTarrifs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ListView lvTarrifsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevExpress.XtraEditors.SimpleButton btnOpenMachine;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}