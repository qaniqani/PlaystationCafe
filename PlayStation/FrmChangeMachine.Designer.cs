namespace PlayStation
{
    partial class FrmChangeMachine
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
            this.cmbMachineList = new System.Windows.Forms.ComboBox();
            this.btnChange = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblMachineName
            // 
            this.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMachineName.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblMachineName.Location = new System.Drawing.Point(12, 9);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(203, 51);
            this.lblMachineName.TabIndex = 0;
            this.lblMachineName.Text = "Masa 16";
            this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMachineList
            // 
            this.cmbMachineList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachineList.FormattingEnabled = true;
            this.cmbMachineList.Location = new System.Drawing.Point(12, 72);
            this.cmbMachineList.Name = "cmbMachineList";
            this.cmbMachineList.Size = new System.Drawing.Size(203, 21);
            this.cmbMachineList.TabIndex = 1;
            // 
            // btnChange
            // 
            this.btnChange.Image = global::PlayStation.Properties.Resources.check_green;
            this.btnChange.Location = new System.Drawing.Point(12, 105);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(97, 37);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "&Değiştir";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::PlayStation.Properties.Resources.check_red;
            this.btnCancel.Location = new System.Drawing.Point(118, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 37);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Vazgeç";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmChangeMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 153);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.cmbMachineList);
            this.Controls.Add(this.lblMachineName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangeMachine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masa Değiştir";
            this.Load += new System.EventHandler(this.FrmChangeMachine_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.ComboBox cmbMachineList;
        private DevExpress.XtraEditors.SimpleButton btnChange;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}