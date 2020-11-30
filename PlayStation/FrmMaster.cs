using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using PlayStation.Data;
using PlayStation.Functions;
using PlayStation.Model.Base;
using PlayStation.Properties;
using Calculates = PlayStation.Data.Calculates;
using Machine = PlayStation.Model.Machine;
using Settings = PlayStation.Data.Settings;
using Tarrifs = PlayStation.Data.Tarrifs;
using Users = PlayStation.Data.Users;

namespace PlayStation
{
    public partial class FrmMaster : XtraForm
    {
        private ImageList _imgList;
        private readonly Process _pro = new Process();

        private Machine _selectedMachine;
        private int _selectedIndex;

        private readonly Logs _l = new Logs();
        private readonly Data.Machine _mac = new Data.Machine();
        private readonly Settings _s = new Settings();
        private readonly Tarrifs _t = new Tarrifs();

        private readonly Device _dev = new Device();

        private readonly Licence _licence = new Licence();

        #region //Machine Picture
        private readonly Bitmap _bClose = Resources.ps_close;
        private readonly Bitmap _bFreeOpen = Resources.ps_freeopen;
        private readonly Bitmap _bLimitedOpen = Resources.ps_limitedopen;
        private readonly Bitmap _bSpecialOpen = Resources.ps_specialopen;
        private readonly Bitmap _bStoped = Resources.ps_stoped;
        private readonly Bitmap _bLast5Minute = Resources.ps_last_5minute;
        #endregion

        public FrmMaster()
        {
            InitializeComponent();
        }

        private void FrmMaster_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            GridLocalizer.Active = new DevexpressLocalizers.GridLocalizer();
            Localizer.Active = new DevexpressLocalizers.EditorLocalizer();
            BarLocalizer.Active = new DevexpressLocalizers.BarManagertLocalizer();

            btnSettings.Visibility = Global.CurrentUser.TYPE == 1 ? BarItemVisibility.Always : BarItemVisibility.Never;

            #region //Create Image List

            _imgList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(90, 90)
            };

            _imgList.Images.Add(_bClose.GetThumbnailImage(96, 96, null, new IntPtr()));
            _imgList.Images.Add(_bFreeOpen.GetThumbnailImage(96, 96, null, new IntPtr()));
            _imgList.Images.Add(_bLimitedOpen.GetThumbnailImage(96, 96, null, new IntPtr()));
            _imgList.Images.Add(_bSpecialOpen.GetThumbnailImage(96, 96, null, new IntPtr()));
            _imgList.Images.Add(_bStoped.GetThumbnailImage(96, 96, null, new IntPtr()));
            _imgList.Images.Add(_bLast5Minute.GetThumbnailImage(96, 96, null, new IntPtr()));
            #endregion

            Current();
            GetMachineList();
            //SetTime();

            sslLoginName.Text = Global.CurrentUser.NAME + " " + Global.CurrentUser.SURNAME;

            lblSelectedMachineName.Text = "";
            dgTotal.Text = "0,0 TL";

            try
            {
                lvMachine.Items[_selectedIndex].Selected = true;
                SelectMachine();
            }
            catch
            {
                // ignored
            }

            LicenceControl();

            var url = new Uri("http://www.nvisionsoft.net/reklam.aspx");
            wBrows.Url = url;

            timer.Start();
            timerNow.Start();

            Process.LogInsert("Program açıldı.", TransactionType.Ekle);
        }

        private void LicenceControl()
        {
            if (_licence.DbRowCount() > 0)
            {
                var licence = _licence.DbLicenceRow();

                if (licence.Active)
                {
                    Global.LicenseDetail = licence;
                    return;
                }

                if (!licence.Demo)
                {
                    MessageBox.Show("Demo hesabınızın süresi dolmuştur. Lisans satın almak için lütfen firmamızla irtibata geçiniz. Adres: http://www.nvisionsoft.net", "HATIRLATMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LockProgram();
                    return;
                }

                if (licence.LicenceEndDate < DateTime.Now)
                {
                    MessageBox.Show("Demo hesabınızın süresi dolmuştur. Lisans satın almak için lütfen firmamızla irtibata geçiniz. Adres: http://www.nvisionsoft.net", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var newLicence = _licence.LicenceClear();
                    Global.LicenseDetail = newLicence;
                    LockProgram();
                    return;
                }

                var ts = licence.LicenceEndDate - DateTime.Today;
                if (ts.Days < 6)
                    MessageBox.Show(string.Format("Lisansınızın bitimine {0} gün kaldı.", ts.Days), "HATIRLATMA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Global.LicenseDetail = licence;
            }
            else
            {
                Global.LicenseDetail = _licence.ActiveDemoLicence();
                if (Global.LicenseDetail.Demo)
                    MessageBox.Show("1 Aylık demo hesabınız aktif olmuştur.", "HATIRLATMA", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Daha önce demo hesabınızı kullandınız. Lütfen lisans satın alınız.", "HATIRLATMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LockProgram();
                }
            }
        }

        private void LicenceException()
        {
            ribbonPage2.Ribbon.Enabled = false;

            ribbonPageGroup1.Enabled = false;
            ribbonPageGroup2.Enabled = false;
            ribbonPageGroup3.Enabled = false;
            ribbonPageGroup6.Enabled = false;

            lvMachine.Enabled = false;

            MessageBox.Show("Lütfen lisans durumunuzu kontrol ediniz.", "HATIRLATMA", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var frmLicence = new FrmLicence();
            frmLicence.ShowDialog();

            var key = Function.DecryptIt(Global.LicenseDetail.LicenceKey);
            if (key.Contains("CONSOLE"))
            {
                Function.WriteRegistry("CheckIsComputer", "1r8qxESGlmeFhVvw/47b2A==");
                Function.WriteRegistry("LicenceKey", Global.LicenseDetail.LicenceKey);
            }

            MessageBox.Show("Lisanslama işleminin tamamlanması için program kapatılacaktır.", "HATIRLATMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var cancel = new CancelEventArgs { Cancel = true };
            Application.Exit(cancel);
        }

        private void LockProgram()
        {
            LicenceException();
            var frmLicence = new FrmLicence();
            frmLicence.ShowDialog();
        }

        private void btnSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result;

            using (var fs = new FrmSettings())
                result = fs.ShowDialog();
            if (result == DialogResult.Yes)
                GetMachineList();
        }

        private void lvMachine_Click(object sender, EventArgs e)
        {
            SelectMachine();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fap = new FrmAddProducts();
            fap.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            AdditionAdding();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmTarrifsOld = new FrmTarrifs_old();
            frmTarrifsOld.Show();
        }

        private void lvMachine_DoubleClick(object sender, EventArgs e)
        {
            DoubleClick1();
        }

        private void lvMachine_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvMachine.SelectedItems[0] == null || lvMachine.SelectedItems.Count <= 0) return;

                if (e.Button == MouseButtons.Right)
                    cmsRightClick.Show(lvMachine, e.X, e.Y);
            }
            catch { }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            EmptyChangeMachine();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineClose();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            if (_selectedMachine != null)
            {
                var ct = new FrmChangeTime(_selectedMachine);
                ct.ShowDialog();
            }
            else
                MessageBox.Show("Lütfen önce düzenleme yapılacak makineyi seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void lvMachine_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void lvMachine_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void lvMachine_DragDrop(object sender, DragEventArgs e)
        {
            var pos = lvMachine.PointToClient(new Point(e.X, e.Y));
            var hit = lvMachine.HitTest(pos);
            if (hit.Item == null) return;

            var dragMachine = (e.Data.GetData(typeof(ListViewItem)) as ListViewItem).Tag as Machine;
            var dropMachine = hit.Item.Tag as Machine;

            if (dropMachine == null || (dragMachine == null || dragMachine.NR == dropMachine.NR)) return;

            if (dragMachine.MACHINESTATUS == (int)MachineType.Kapali) return;

            if (dragMachine.MACHINESTATUS != (int)MachineType.Kapali &&
                dropMachine.MACHINESTATUS != (int)MachineType.Kapali)
            {
                var ts = new FrmTransferSelection(dragMachine, dropMachine);
                var dr = ts.ShowDialog();
                if (dr == DialogResult.Yes)
                    GetMachineList();
            }
            else if (dragMachine.MACHINESTATUS != (int)MachineType.Kapali &&
                    dropMachine.MACHINESTATUS != (int)MachineType.SuresizAcik &&
                    dropMachine.MACHINESTATUS != (int)MachineType.OzelAcik &&
                    dropMachine.MACHINESTATUS != (int)MachineType.Durduruldu &&
                    dropMachine.MACHINESTATUS != (int)MachineType.SureliAcik)
            {
                #region //Masayi tasi
                var dr = MessageBox.Show(Global.CurrentSettings.MACHINETAGNAME + " " + dragMachine.NR + " --> " + Global.CurrentSettings.MACHINETAGNAME + " " + dropMachine.NR + " hesap aktarımı yapılacak. Devam etmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr != DialogResult.Yes) return;

                _mac.EmptyChangeMachine(dragMachine, dropMachine);
                Process.LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + dragMachine.NR + " --> " + Global.CurrentSettings.MACHINETAGNAME + " " + dropMachine.NR + " taşındı.", TransactionType.Duzenle);
                GetMachineList();
                #endregion
            }
        }

        private void tumunuTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvLogs.Items.Clear();
            lvLogs.Refresh();
        }

        private void lvLogs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmsLogRightClick.Show(lvLogs, e.X, e.Y);
        }

        private void btnRMachineClose_Click(object sender, EventArgs e)
        {
            MachineClose();
        }

        private void FrmMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Process.LogInsert("Program kapatıldı.", TransactionType.Ekle);
                _dev.AllMachineClose();
                _dev.ClosePort();
            }
            catch { }
        }

        private void btnFreeOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFreeTimeMachine();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenLimitedTimeMachine();
        }

        private void btnLimitedOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineOpenTarrifs();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _pro.ExpiredMachine();
            GetMachineList();
        }

        private void lvMachine_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue <= 40 && e.KeyValue >= 37)
                SelectMachine();
            else if (e.KeyValue == 123)
            {
                OpenLimitedTimeMachine();
            }
        }

        private void btnRFreeTime_Click(object sender, EventArgs e)
        {
            OpenFreeTimeMachine();
            GetMachineList();
        }

        private void btnRLimitedTime_Click(object sender, EventArgs e)
        {
            OpenLimitedTimeMachine();
        }

        private void btnRAddAddition_Click(object sender, EventArgs e)
        {
            AdditionAdding();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            HoldMachine();
        }

        private void hesabiDurdurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoldMachine();
        }

        private void btnRSpecialTime_Click(object sender, EventArgs e)
        {
            MachineOpenTarrifs();
        }

        private void btnRChangeMachine_Click(object sender, EventArgs e)
        {
            EmptyChangeMachine();
        }

        private void lvMachine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            switch (_selectedMachine.MACHINESTATUS)
            {
                case (int)MachineType.Kapali:
                    {
                        var dr = MessageBox.Show(Global.CurrentSettings.MACHINETAGNAME + " " + _selectedMachine.NR + " açılacak. Açmak istediğinize emin misiniz?", "MASA AÇ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            DoubleClick1();
                            GetMachineList();
                        }
                    }
                    break;
                case (int)MachineType.SureliAcik:
                case (int)MachineType.SuresizAcik:
                case (int)MachineType.OzelAcik:
                    MachineClose();
                    break;
                case (int)MachineType.Durduruldu:
                    {
                        var dr = MessageBox.Show(Global.CurrentSettings.MACHINETAGNAME + " " + _selectedMachine.NR + " adlı hesap tekrar devam ettirilecek. Devam etmek istediğinize emin misiniz?", "MASA AÇ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            HoldMachine();
                        }
                    }
                    break;
            }
        }

        private void btnRBackToCalc_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Hesabı geri almak istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr != DialogResult.Yes) return;

            string result;
            _pro.BackToCalculate(_selectedMachine, out result);
            if (string.IsNullOrEmpty(result))
                GetMachineList();
            else
                MessageBox.Show(result, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnStartTimeChange_Click(object sender, EventArgs e)
        {
            var ct = new FrmChangeTime(_selectedMachine);
            ct.ShowDialog();
        }

        private void btnReportDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rd = new FrmReportDay();
            rd.ShowDialog();
        }

        private void btnReportBetween_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rb = new FrmReportBetween();
            rb.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fl = new FrmLoging();
            fl.ShowDialog();
        }

        private void btnDebtList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dl = new FrmDeptList();
            dl.ShowDialog();
        }

        private void btnNoteBook_ItemClick(object sender, ItemClickEventArgs e)
        {
            var note = new FrmNotes();
            note.ShowDialog();
        }

        private void btnREditTime_Click(object sender, EventArgs e)
        {
            OpenLimitedTimeMachine();
        }

        private void btnRMachineConvertTime_Click(object sender, EventArgs e)
        {
            MachineConvertTime();
        }

        private void timerNow_Tick(object sender, EventArgs e)
        {
            SetTime();
        }

        private void SetTime()
        {
            tssTime.Text = string.Format("{0:dd MMMM yyyy - HH:mm:ss}", DateTime.Now);
        }

        private void SelectLogs()
        {
            var log = _l.SelectEndRow();
            log = log.OrderBy(a => a.LREF).ToList();
            foreach (var item2 in log)
            {
                if (lvLogs.Items.Count > 0)
                {
                    var asd = false;
                    foreach (ListViewItem item in lvLogs.Items)
                    {
                        if (item.Text == item2.LREF.ToString())
                            asd = true;
                    }

                    if (asd) continue;

                    var lvi = new ListViewItem
                    {
                        Tag = item2,
                        Text = item2.LREF.ToString()
                    };
                    lvi.SubItems.Add(item2.TRANSACTIONTYPE.ToString());
                    lvi.SubItems.Add(item2.TRANSACTIONNAME);
                    lvi.SubItems.Add(item2.TRANSACTIONDETAIL);
                    lvi.SubItems.Add(string.Format("{0:dd.MM.yyyy - HH:mm:ss}", item2.DATETIME));
                    lvi.SubItems.Add(item2.USERNAME);
                    lvLogs.Items.Insert(0, lvi);

                    var count = lvLogs.Items.Count;
                    if (count > 50)
                        lvLogs.Items.RemoveAt(50);
                }
                else
                {
                    var lvi = new ListViewItem
                    {
                        Tag = item2,
                        Text = item2.LREF.ToString()
                    };
                    lvi.SubItems.Add(item2.TRANSACTIONTYPE.ToString());
                    lvi.SubItems.Add(item2.TRANSACTIONNAME);
                    lvi.SubItems.Add(item2.TRANSACTIONDETAIL);
                    lvi.SubItems.Add(string.Format("{0:dd.MM.yyyy - HH:mm:ss}", item2.DATETIME));
                    lvi.SubItems.Add(item2.USERNAME);
                    lvLogs.Items.Insert(0, lvi);

                    var count = lvLogs.Items.Count;
                    if (count > 50)
                        lvLogs.Items.RemoveAt(50);
                }
            }
        }

        private void MachineOpenTarrifs()
        {
            try
            {
                if (lvMachine.SelectedItems[0] != null && lvMachine.SelectedItems.Count > 0)
                {
                    _selectedMachine = (lvMachine.SelectedItems[0].Tag as Machine);

                    if (_selectedMachine == null || _selectedMachine.MACHINESTATUS != (int)MachineType.Kapali) return;

                    DialogResult result;

                    using (var ot = new FrmOpenTarrifs(_selectedMachine))
                        result = ot.ShowDialog();

                    if (result != DialogResult.Yes) return;

                    Process.LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + _selectedMachine.NR + " tarifeli hesap açıldı.", TransactionType.Ekle);
                    GetMachineList();
                }
                else
                    MessageBox.Show("Lütfen açılacak masayı seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Lütfen açılacak masayı seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void GetMachineList()
        {
            var li = _mac.Select();
            lvMachine.Items.Clear();
            lvMachine.LargeImageList = _imgList;

            try
            {
                var asd = Global.CurrentSettings.MACHINESTATUS;
                if (asd)
                {
                    _dev.SetPort(true);
                    _dev.OpenPort();
                    _dev.PortControl(li);
                    //_dev.ClosePort();
                }
            }
            catch
            {
               // MessageBox.Show("Cihaza bağlanılamadı..."); 
            }

            foreach (var item in li)
            {
                var lvi = new ListViewItem
                {
                    Tag = item,
                    Text = Global.CurrentSettings.MACHINETAGNAME + " " + item.NR,
                    ImageIndex = item.MACHINESTATUS
                };

                if ((item.MACHINESTATUS == (int)MachineType.SureliAcik) &&
                    (item.ENDDATETIME < DateTime.Now.AddMinutes(6)) && (item.ENDDATETIME > DateTime.Now.AddMinutes(-6)))
                    lvi.ImageIndex = 5;

                lvMachine.Items.Add(lvi);
            }

            SelectLogs();
        }

        private void Current()
        {
            string message;
            var setting = _s.Select(out message);
            if (setting.MACHINECOUNT < 1)
            {
                MessageBox.Show("Programın ilk açılışında lütfen işletmenize göre ayarlarınızı yapınız.", "HATIRLATMA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                var frmSetting = new FrmSettings();
                frmSetting.ShowDialog();
            }
            else
                Global.CurrentSettings = setting;
        }

        private void SelectMachine()
        {
            try
            {
                if (lvMachine.SelectedItems[0] == null || lvMachine.SelectedItems.Count <= 0) return;

                _selectedIndex = lvMachine.SelectedItems[0].Index;

                _selectedMachine = lvMachine.Items[_selectedIndex].Tag as Machine;

                if (_selectedMachine == null) return;

                SetButtonEnabled(_selectedMachine.MACHINESTATUS);

                var cdv = _pro.DetailView(_selectedMachine);
                lblSelectedMachineName.Text = cdv.MachineName;
                lblAccountState.Text = cdv.CalculateStatus;
                lblAdditionTotal.Text = string.Format("{0:n} TL", cdv.AdditionTotal);
                lblEndTime.Text = cdv.EndTime.ToString("HH:mm");
                lblRemainingTime.Text = string.Format("{0}:{1}", cdv.RemainingTime.Hours.ToString("00"), cdv.RemainingTime.Minutes.ToString("00"));
                lblStartTime.Text = cdv.StartTime.ToString(@"HH\:mm");
                lblUsedPrice.Text = string.Format("{0:n} TL", cdv.UsedPrice);
                lblUsedTime.Text = string.Format("{0}:{1}", cdv.UsedTime.Hours.ToString("00"), cdv.UsedTime.Minutes.ToString("00"));
                dgTotal.Text = (cdv.MachineStatus == (int)MachineType.Kapali ? "0,0 TL" : string.Format("{0:n} TL", (cdv.TotalPrice + cdv.AdditionTotal)));
            }
            catch { }
        }

        private void DoubleClick1()
        {
            try
            {
                if (lvMachine.SelectedItems[0] == null || lvMachine.SelectedItems.Count <= 0) return;

                _selectedMachine = (lvMachine.SelectedItems[0].Tag as Machine);
                if (_selectedMachine != null && _selectedMachine.MACHINESTATUS == (int)MachineType.Kapali)
                {
                    OpenFreeTimeMachine();
                }
                else if (_selectedMachine != null && (_selectedMachine.MACHINESTATUS != (int)MachineType.Durduruldu ||
                                                     _selectedMachine.MACHINESTATUS != (int)MachineType.Kapali))
                {
                    MachineClose();
                }
                GetMachineList();
            }
            catch { }
        }

        private void OpenFreeTimeMachine()
        {
            try
            {
                if (lvMachine.SelectedItems[0] == null) return;

                if (_selectedMachine.SELECTEDTARRIF == 0)
                {
                    var tar = _t.Selected();
                    _pro.OpenFreeTime(_selectedMachine, tar);
                    return;
                }

                var selectedTar = _t.Select(_selectedMachine.SELECTEDTARRIF);
                _pro.OpenFreeTime(_selectedMachine, selectedTar);
            }
            catch { }
        }

        private void OpenLimitedTimeMachine()
        {
            try
            {
                if (lvMachine.SelectedItems[0] != null && lvMachine.SelectedItems.Count > 0)
                {
                    _selectedMachine = (lvMachine.SelectedItems[0].Tag as Machine);

                    if (_selectedMachine != null && (_selectedMachine.MACHINESTATUS != (int)MachineType.Kapali &&
                                                    _selectedMachine.MACHINESTATUS != (int)MachineType.SureliAcik &&
                                                    _selectedMachine.MACHINESTATUS != (int)MachineType.OzelAcik)) return;
                    DialogResult result;

                    using (var mo = new FrmMachineOpen(_selectedMachine, (_selectedMachine.MACHINESTATUS == (int)MachineType.Kapali ? TimeChange.SureliAc : TimeChange.SureVer)))
                        result = mo.ShowDialog();
                    if (result == DialogResult.Yes)
                        GetMachineList();
                }
                else
                    MessageBox.Show("Lütfen açılacak masayı seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Lütfen geçerli bir işlem yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void MachineConvertTime()
        {
            try
            {
                if (lvMachine.SelectedItems[0] != null && lvMachine.SelectedItems.Count > 0)
                {
                    _selectedMachine = (lvMachine.SelectedItems[0].Tag as Machine);

                    if (_selectedMachine != null && (_selectedMachine.MACHINESTATUS != (int)MachineType.SuresizAcik &&
                                                    _selectedMachine.MACHINESTATUS != (int)MachineType.OzelAcik)) return;

                    DialogResult result;

                    using (var mo = new FrmMachineOpen(_selectedMachine, TimeChange.SureliyeCevir))
                        result = mo.ShowDialog();
                    if (result == DialogResult.Yes)
                        GetMachineList();
                }
                else
                    MessageBox.Show("Lütfen açılacak masayı seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Lütfen açılacak masayı seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void AdditionAdding()
        {
            try
            {
                if (lvMachine.SelectedItems[0] == null) return;

                var machine = lvMachine.SelectedItems[0].Tag as Machine;
                if (machine != null && machine.MACHINESTATUS == (int)MachineType.Kapali) return;

                var fa = new FrmAdditions(machine, AdditionFormType.MakineAdisyonlari);
                var dr = fa.ShowDialog();
                if (dr == DialogResult.Yes)
                    SelectLogs();
            }
            catch { }
        }

        private void MachineClose()
        {
            try
            {
                if (lvMachine.SelectedItems[0] == null) return;

                DialogResult result;
                using (var mc = new FrmMachineClose(_selectedMachine))
                    result = mc.ShowDialog();
                if (result == DialogResult.Yes)
                    GetMachineList();
            }
            catch { }
        }

        private void HoldMachine()
        {
            if (_selectedMachine.MACHINESTATUS == (int)MachineType.Durduruldu)
                _pro.HoldOffMachineCalculate(_selectedMachine);
            else
                _pro.HoldMachineCalculate(_selectedMachine);

            GetMachineList();
        }

        private void EmptyChangeMachine()
        {
            try
            {
                if (lvMachine.SelectedItems[0] == null) return;

                var mc = new FrmChangeMachine(_selectedMachine);
                var dr = mc.ShowDialog();
                if (dr == DialogResult.Yes) ;
                GetMachineList();
            }
            catch { }
        }

        private void SetButtonEnabled(int MachineStatus)
        {
            barButtonItem2.Caption = "Süreli Masa Aç";
            btnRMachineConvertTime.Enabled = false;
            if (MachineStatus == (int)MachineType.Durduruldu)
            {
                btnFreeOpen.Enabled = false; //Masayi suresiz ac
                btnLimitedOpen.Enabled = false; //Masayi Tarifeli ac
                barButtonItem2.Enabled = false; //Masayi Sureli Ac
                barButtonItem4.Enabled = true; //Masayi Kapat
                barButtonItem3.Enabled = true; //Hesap durdurma
                barButtonItem3.Caption = "Hesabı Devam Ettir"; //Hesap durdurma
                barButtonItem5.Enabled = true; //Adiyon ekle
                barButtonItem7.Enabled = true; //Masa degistir

                #region SagClick
                btnRAddAddition.Enabled = true;
                btnRBackToCalc.Enabled = false;
                btnRChangeMachine.Enabled = true;
                btnRFreeTime.Enabled = false;
                btnRHoldMachine.Enabled = true;
                btnRHoldMachine.Text = "Hesabı Devam Ettir";
                btnRLimitedTime.Enabled = false;
                btnRMachineClose.Enabled = true;
                btnRSpecialTime.Enabled = false;
                btnStartTimeChange.Enabled = true;
                btnREditTime.Enabled = false;
                #endregion
            }
            else if (MachineStatus == (int)MachineType.Kapali)
            {
                btnFreeOpen.Enabled = true; //Masayi suresiz ac
                btnLimitedOpen.Enabled = true; //Masayi Tarifeli ac
                barButtonItem2.Enabled = true; //Masayi Sureli Ac
                barButtonItem4.Enabled = false; //Masayi Kapat
                barButtonItem3.Enabled = false; //Hesap durdurma
                barButtonItem3.Caption = "Hesabı Durdur"; //Hesap durdurma
                barButtonItem5.Enabled = false; //Adiyon ekle
                barButtonItem7.Enabled = false; //Masa degistir

                #region SagClick
                btnRAddAddition.Enabled = false;
                btnRBackToCalc.Enabled = true;
                btnRChangeMachine.Enabled = false;
                btnRFreeTime.Enabled = true;
                btnRHoldMachine.Enabled = false;
                btnRHoldMachine.Text = "Hesabı Durdur";
                btnRLimitedTime.Enabled = true;
                btnRMachineClose.Enabled = false;
                btnRSpecialTime.Enabled = true;
                btnStartTimeChange.Enabled = false;
                btnREditTime.Enabled = false;
                #endregion
            }
            else if (MachineStatus == (int)MachineType.OzelAcik ||
                    MachineStatus == (int)MachineType.SureliAcik ||
                    MachineStatus == (int)MachineType.SuresizAcik)
            {
                btnFreeOpen.Enabled = false; //Masayi suresiz ac
                btnLimitedOpen.Enabled = false; //Masayi Tarifeli ac
                barButtonItem2.Enabled = false; //Masayi Sureli Ac
                barButtonItem4.Enabled = true; //Masayi Kapat
                barButtonItem3.Enabled = true; //Hesap durdurma
                barButtonItem3.Caption = "Hesabı Durdur"; //Hesap durdurma
                barButtonItem5.Enabled = true; //Adiyon ekle
                barButtonItem7.Enabled = true; //Masa degistir

                #region SagClick
                btnRAddAddition.Enabled = true;
                btnRBackToCalc.Enabled = false;
                btnRChangeMachine.Enabled = true;
                btnRFreeTime.Enabled = false;
                btnRHoldMachine.Enabled = true;
                btnRHoldMachine.Text = "Hesabı Durdur";
                btnRLimitedTime.Enabled = false;
                btnRMachineClose.Enabled = true;
                btnRSpecialTime.Enabled = false;
                btnStartTimeChange.Enabled = true;

                if (MachineStatus == (int)MachineType.SuresizAcik)
                {
                    btnREditTime.Enabled = false;
                }
                else
                {
                    btnREditTime.Enabled = true;
                    barButtonItem2.Enabled = true;
                    barButtonItem2.Caption = "Masaya Süre Ver";
                }
                #endregion
            }

            if (MachineStatus == (int)MachineType.SureliAcik)
            {
                barButtonItem3.Enabled = false;
                btnRHoldMachine.Enabled = false;
            }

            if (MachineStatus == (int)MachineType.SuresizAcik ||
                MachineStatus == (int)MachineType.OzelAcik)
                btnRMachineConvertTime.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var dr = MessageBox.Show("Programdan çıkış yapmak istediğinize emin misiniz?", "UYARI",
                MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            e.Cancel = dr != DialogResult.Yes;
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var galeriDropDown = new GalleryDropDown { Ribbon = ribbonControl1 };
            SkinHelper.InitSkinGalleryDropDown(galeriDropDown);
            barButtonItem1.DropDownControl = galeriDropDown;
            galeriDropDown.ShowPopup(new Point { X = 100, Y = 20 });
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmLicence = new FrmLicence();
            frmLicence.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fa = new FrmAbout();
            fa.ShowDialog();
        }
    }
}