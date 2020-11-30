namespace PlayStation
{
    partial class FrmChangeTime
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTime = new DevExpress.XtraEditors.TimeEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç Saati";
            // 
            // txtTime
            // 
            this.txtTime.EditValue = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.txtTime.Location = new System.Drawing.Point(96, 22);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTime.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.txtTime.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.txtTime.Size = new System.Drawing.Size(80, 20);
            this.txtTime.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::PlayStation.Properties.Resources.check_green;
            this.btnOk.Location = new System.Drawing.Point(182, 21);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(91, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Tamam";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmChangeTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 67);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangeTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Başlangıç Saatini Değiştir";
            this.Load += new System.EventHandler(this.FrmChangeTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TimeEdit txtTime;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}