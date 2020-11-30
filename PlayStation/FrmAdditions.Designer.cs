namespace PlayStation
{
    partial class FrmAdditions
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lvMachineAddition = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvStock = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.dgAdditionTotal = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.dgTotal = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.dblcTotal = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAdditionTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dblcTotal)).BeginInit();
            this.cmsRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.groupControl4);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Controls.Add(this.lvMachineAddition);
            this.groupControl1.Controls.Add(this.lvStock);
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(10, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(597, 444);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Adisyon İşlemleri";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::PlayStation.Properties.Resources.btn_cancel;
            this.btnCancel.Location = new System.Drawing.Point(390, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.simpleButton2_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::PlayStation.Properties.Resources.btn_add;
            this.btnSave.Location = new System.Drawing.Point(498, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.txtNote);
            this.groupControl4.Location = new System.Drawing.Point(339, 303);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(244, 100);
            this.groupControl4.TabIndex = 4;
            this.groupControl4.Text = "Adisyon Hakkında Not";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(5, 24);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(234, 71);
            this.txtNote.TabIndex = 0;
            this.txtNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::PlayStation.Properties.Resources.btn_cancel;
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(262, 219);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "< ÇIKAR";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::PlayStation.Properties.Resources.btn_add;
            this.btnAdd.Location = new System.Drawing.Point(262, 179);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "EKLE >";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            // 
            // lvMachineAddition
            // 
            this.lvMachineAddition.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvMachineAddition.FullRowSelect = true;
            this.lvMachineAddition.GridLines = true;
            this.lvMachineAddition.Location = new System.Drawing.Point(339, 107);
            this.lvMachineAddition.MultiSelect = false;
            this.lvMachineAddition.Name = "lvMachineAddition";
            this.lvMachineAddition.Size = new System.Drawing.Size(244, 186);
            this.lvMachineAddition.TabIndex = 3;
            this.lvMachineAddition.UseCompatibleStateImageBehavior = false;
            this.lvMachineAddition.View = System.Windows.Forms.View.Details;
            this.lvMachineAddition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            this.lvMachineAddition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvMachineAddition_MouseDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "";
            this.columnHeader4.Text = "Ürün Adı";
            this.columnHeader4.Width = 91;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Fiyat";
            this.columnHeader6.Width = 52;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Adet";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tarih";
            this.columnHeader7.Width = 68;
            // 
            // lvStock
            // 
            this.lvStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvStock.FullRowSelect = true;
            this.lvStock.GridLines = true;
            this.lvStock.Location = new System.Drawing.Point(12, 107);
            this.lvStock.MultiSelect = false;
            this.lvStock.Name = "lvStock";
            this.lvStock.Size = new System.Drawing.Size(244, 296);
            this.lvStock.TabIndex = 0;
            this.lvStock.UseCompatibleStateImageBehavior = false;
            this.lvStock.View = System.Windows.Forms.View.Details;
            this.lvStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ürün Adı";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 2;
            this.columnHeader2.Text = "Stok";
            this.columnHeader2.Width = 44;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 1;
            this.columnHeader3.Text = "Birim Fiyatı";
            this.columnHeader3.Width = 67;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gaugeControl1);
            this.groupControl3.Location = new System.Drawing.Point(339, 31);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(244, 70);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Tutar";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.dgAdditionTotal});
            this.gaugeControl1.Location = new System.Drawing.Point(5, 24);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(234, 41);
            this.gaugeControl1.TabIndex = 0;
            this.gaugeControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            // 
            // dgAdditionTotal
            // 
            this.dgAdditionTotal.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#34000000");
            this.dgAdditionTotal.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#7F93C6");
            this.dgAdditionTotal.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent1});
            this.dgAdditionTotal.Bounds = new System.Drawing.Rectangle(6, 6, 222, 29);
            this.dgAdditionTotal.DigitCount = 8;
            this.dgAdditionTotal.Name = "dgAdditionTotal";
            this.dgAdditionTotal.Padding = new DevExpress.XtraGauges.Core.Base.TextSpacing(26, 20, 26, 20);
            this.dgAdditionTotal.Text = "00,000";
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(409.7F, 99.9625F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent1";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style25;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(26F, 0F);
            this.digitalBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lblMachineName);
            this.groupControl2.Location = new System.Drawing.Point(12, 31);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(244, 70);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Masa";
            // 
            // lblMachineName
            // 
            this.lblMachineName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMachineName.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblMachineName.Location = new System.Drawing.Point(5, 24);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(234, 41);
            this.lblMachineName.TabIndex = 0;
            this.lblMachineName.Text = "Masa Adı";
            this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgTotal
            // 
            this.dgTotal.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#34000000");
            this.dgTotal.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#7F93C6");
            this.dgTotal.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.dblcTotal});
            this.dgTotal.Bounds = new System.Drawing.Rectangle(6, 6, 184, 59);
            this.dgTotal.DigitCount = 9;
            this.dgTotal.DisplayMode = DevExpress.XtraGauges.Core.Model.DigitalGaugeDisplayMode.Matrix8x14;
            this.dgTotal.Name = "dgTotal";
            this.dgTotal.Padding = new DevExpress.XtraGauges.Core.Base.TextSpacing(26, 26, 26, 20);
            this.dgTotal.Text = "999,99";
            // 
            // dblcTotal
            // 
            this.dblcTotal.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(458F, 130F);
            this.dblcTotal.Name = "digitalBackgroundLayerComponent1";
            this.dblcTotal.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style25;
            this.dblcTotal.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(26F, 0F);
            this.dblcTotal.ZOrder = 1000;
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem});
            this.cmsRightClick.Name = "cmsRightClick";
            this.cmsRightClick.Size = new System.Drawing.Size(102, 26);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.düzenleToolStripMenuItem.Text = "&Çıkar";
            // 
            // FrmAdditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 464);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdditions";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adisyonlar";
            this.Load += new System.EventHandler(this.FrmAdditions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvStock_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAdditionTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dblcTotal)).EndInit();
            this.cmsRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ListView lvMachineAddition;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvStock;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge dgAdditionTotal;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge dgTotal;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent dblcTotal;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.TextBox txtNote;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}