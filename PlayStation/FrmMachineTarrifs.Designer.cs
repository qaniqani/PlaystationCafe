namespace PlayStation
{
    partial class FrmMachineTarrifs
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
            this.gcMachines = new DevExpress.XtraEditors.GroupControl();
            this.xscPanel = new DevExpress.XtraEditors.XtraScrollableControl();
            this.btnTarrifsSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcMachines)).BeginInit();
            this.gcMachines.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcMachines
            // 
            this.gcMachines.Controls.Add(this.xscPanel);
            this.gcMachines.Location = new System.Drawing.Point(12, 12);
            this.gcMachines.Name = "gcMachines";
            this.gcMachines.Size = new System.Drawing.Size(365, 494);
            this.gcMachines.TabIndex = 1;
            this.gcMachines.Text = "Masalara Özel Tarife Atama";
            // 
            // xscPanel
            // 
            this.xscPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscPanel.Location = new System.Drawing.Point(2, 21);
            this.xscPanel.Name = "xscPanel";
            this.xscPanel.Size = new System.Drawing.Size(361, 471);
            this.xscPanel.TabIndex = 0;
            // 
            // btnTarrifsSave
            // 
            this.btnTarrifsSave.Image = global::PlayStation.Properties.Resources.btn_add;
            this.btnTarrifsSave.Location = new System.Drawing.Point(298, 512);
            this.btnTarrifsSave.Name = "btnTarrifsSave";
            this.btnTarrifsSave.Size = new System.Drawing.Size(79, 23);
            this.btnTarrifsSave.TabIndex = 5;
            this.btnTarrifsSave.Text = "Kaydet";
            this.btnTarrifsSave.Click += new System.EventHandler(this.btnTarrifsSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::PlayStation.Properties.Resources.btn_cancel;
            this.btnClose.Location = new System.Drawing.Point(217, 512);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // FrmMachineTarrifs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 545);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTarrifsSave);
            this.Controls.Add(this.gcMachines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMachineTarrifs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masaya Göre Tarifeler";
            this.Load += new System.EventHandler(this.FrmMachineTarrifs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMachines)).EndInit();
            this.gcMachines.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcMachines;
        private DevExpress.XtraEditors.SimpleButton btnTarrifsSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.XtraScrollableControl xscPanel;
    }
}