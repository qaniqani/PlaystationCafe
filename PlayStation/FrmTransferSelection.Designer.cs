namespace PlayStation
{
    partial class FrmTransferSelection
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
            this.btnChangeTable = new DevExpress.XtraEditors.SimpleButton();
            this.btnCalculateTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnChangeTable
            // 
            this.btnChangeTable.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnChangeTable.Appearance.Options.UseFont = true;
            this.btnChangeTable.Image = global::PlayStation.Properties.Resources.change_table1;
            this.btnChangeTable.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnChangeTable.Location = new System.Drawing.Point(214, 12);
            this.btnChangeTable.Name = "btnChangeTable";
            this.btnChangeTable.Size = new System.Drawing.Size(153, 89);
            this.btnChangeTable.TabIndex = 1;
            this.btnChangeTable.Text = "Masayı Yer Değiştir";
            this.btnChangeTable.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnCalculateTransfer
            // 
            this.btnCalculateTransfer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCalculateTransfer.Appearance.Options.UseFont = true;
            this.btnCalculateTransfer.Image = global::PlayStation.Properties.Resources.calculate_transfer1;
            this.btnCalculateTransfer.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCalculateTransfer.Location = new System.Drawing.Point(12, 12);
            this.btnCalculateTransfer.Name = "btnCalculateTransfer";
            this.btnCalculateTransfer.Size = new System.Drawing.Size(153, 89);
            this.btnCalculateTransfer.TabIndex = 0;
            this.btnCalculateTransfer.Text = "Hesabı Aktar";
            this.btnCalculateTransfer.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmTransferSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 113);
            this.Controls.Add(this.btnChangeTable);
            this.Controls.Add(this.btnCalculateTransfer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransferSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İşlem Türü";
            this.Load += new System.EventHandler(this.FrmTransferSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCalculateTransfer;
        private DevExpress.XtraEditors.SimpleButton btnChangeTable;
    }
}