using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PlayStation.Functions;

namespace PlayStation
{
    public partial class FrmSettings : XtraForm
    {
        private DialogResult _dr = DialogResult.No;
        private readonly Data.Settings _s = new Data.Settings();
        private readonly Data.Users _u = new Data.Users();
        private readonly Data.Tarrifs _t = new Data.Tarrifs();
        private Device _device = new Device();

        int _tarLref = 0;
        int _userLref = 0;
        int _tableCount = 0;

        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            try
            {
                #region //Database Ayarlari
                txtDBServerName.Text = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("ServerName"));
                txtDBName.Text = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("DatabaseName"));
                txtDBUserName.Text = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("UserName"));
                txtDBPassword.Text = Functions.Function.DecryptIt(Functions.Function.ReadRegistry("Password"));
                #endregion

                #region //Program Ayarlari
                string message;
                var set = _s.Select(out message);
                if (!string.IsNullOrEmpty(message))
                    MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    if (set != null)
                    {
                        GetPortList();
                        _tableCount = set.MACHINECOUNT;
                        txtMachineCount.Text = set.MACHINECOUNT.ToString();
                        txtMachineTag.Text = set.MACHINETAGNAME;
                        txtMinTime.EditValue = set.MINIMUMTIME;
                        txtMinTotal.Text = set.MINIMUMTOTAL.ToString().Replace(",", ".");
                        txtRounding.Text = set.ROUNDINGPRICE.ToString().Replace(",", ".");
                        rbMachineFalse.Checked = (set.MACHINESTATUS ? Convert.ToBoolean(Model.Base.Status.Kapali) : Convert.ToBoolean(Model.Base.Status.Acik));
                        rbMachineTrue.Checked = (set.MACHINESTATUS ? Convert.ToBoolean(Model.Base.Status.Acik) : Convert.ToBoolean(Model.Base.Status.Kapali));

                        if (set.MACHINESTATUS)
                        {
                            var comPort = Function.ReadRegistry("UsedComPort");
                            var baudRate = Function.ReadRegistry("UsedBaudRate");
                            cmbBaudList.Text = baudRate;
                            cmbPortList.Text = comPort;
                        }
                    }
                #endregion

                GetUserList();

                Process.LogInsert("Ayarlar görüntülendi.", Model.Base.TransactionType.Goruntule);
            }
            catch { }
        }

        private void GetPortList()
        {
            var ports = _device.PortList();
            if (ports.Length > 0)
            {
                cmbPortList.Properties.Items.AddRange(ports);
                cmbPortList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                cmbPortList.SelectedIndex = 0;
                cmbBaudList.SelectedIndex = 0;
            }
            else
            {
                cmbBaudList.Enabled = false;
                cmbPortList.Enabled = false;
            }
        }

        private void GetUserList()
        {
            var li = _u.Select();
            lvUserList.Items.Clear();
            foreach (var item in li)
            {
                var lvi = new ListViewItem
                {
                    Tag = item,
                    Text = item.NAME + " " + item.SURNAME
                };
                lvi.SubItems.Add(item.USERNAME);
                lvUserList.Items.Add(lvi);
                Application.DoEvents();
            }
            lvUserList.Refresh();
        }

        private void GetTarrifLists()
        {
            var li = _t.Select();
            lvTarrifsList.Items.Clear();
            foreach (var item in li)
            {
                var lvi = new ListViewItem
                {
                    Tag = item.LREF,
                    Text = item.NAME
                };
                lvi.SubItems.Add(string.Format("{0:#.###,##} TL", item.HOURPRICE));
                lvi.SubItems.Add((item.SELECTED ? "Seçili" : "-"));
                lvTarrifsList.Items.Add(lvi);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvUserList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsRightClick.Show(lvUserList, e.X, e.Y);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDBSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDBName.Text) && !string.IsNullOrEmpty(txtDBPassword.Text) && !string.IsNullOrEmpty(txtDBServerName.Text) && !string.IsNullOrEmpty(txtDBUserName.Text))
            {
                Process.LogInsert("Database ayarları değiştirildi.", Model.Base.TransactionType.Duzenle);
                Functions.Function.WriteRegistry("ServerName", Functions.Function.EncryptIt(txtDBServerName.Text.Trim()));
                Functions.Function.WriteRegistry("DatabaseName", Functions.Function.EncryptIt(txtDBName.Text.Trim()));
                Functions.Function.WriteRegistry("UserName", Functions.Function.EncryptIt(txtDBUserName.Text.Trim()));
                Functions.Function.WriteRegistry("Password", Functions.Function.EncryptIt(txtDBPassword.Text.Trim()));
                MessageBox.Show("Database ayarları güncellendi. Ayarların aktif olması için program kapatılacaktır. Tekrar yeniden açabilirsiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CancelEventArgs c = new CancelEventArgs();
                c.Cancel = false;

                Application.Exit(c);
            }
            else
                MessageBox.Show("Lütfen database ayarlarını tam giriniz.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message;
            var set = new Model.Settings {MACHINECOUNT = Convert.ToInt32(txtMachineCount.Text)};
            bool changeStatus;
            if (_tableCount != set.MACHINECOUNT)
            {
                var dr = MessageBox.Show("Masaların tamamı kapatılıp yeniden açılacak. Bu işlemi yapmak istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dr != DialogResult.Yes) return;
                
                set.MACHINESTATUS = rbMachineTrue.Checked;
                set.MACHINETAGNAME = txtMachineTag.Text;
                set.MINIMUMTIME = Convert.ToDateTime(txtMinTime.Text);
                set.MINIMUMTOTAL = Convert.ToDecimal(txtMinTotal.Text.Replace(".", ","));
                set.MODIFIEDDATETIME = DateTime.Now;
                set.MODIFIEDUSER = (Global.CurrentUser == null ? 0 : Global.CurrentUser.LREF);
                set.ROUNDINGPRICE = Convert.ToDecimal(txtRounding.Text.Replace(".", ","));
                set.VERSION = 1;
                set.ACTIVE = true;
                set.CREATEUSER = (Global.CurrentUser == null ? 0 : Global.CurrentUser.LREF);
                set.DATETIME = DateTime.Now;

                _s.Insert(set, out message);

                Global.CurrentSettings = set;

                Process.CreateMachine(Convert.ToInt32(txtMachineCount.Text));
                changeStatus = true;
            }
            else
            {
                set.MACHINESTATUS = rbMachineTrue.Checked;
                set.MACHINETAGNAME = txtMachineTag.Text;
                set.MINIMUMTIME = Convert.ToDateTime(txtMinTime.Text);
                set.MINIMUMTOTAL = Convert.ToDecimal(txtMinTotal.Text.Replace(".", ","));
                set.MODIFIEDDATETIME = DateTime.Now;
                set.MODIFIEDUSER = (Global.CurrentUser == null ? 0 : Global.CurrentUser.LREF);
                set.ROUNDINGPRICE = Convert.ToDecimal(txtRounding.Text.Replace(".", ","));
                set.VERSION = 1;
                set.ACTIVE = true;
                set.CREATEUSER = (Global.CurrentUser == null ? 0 : Global.CurrentUser.LREF);
                set.DATETIME = DateTime.Now;

                _s.Insert(set, out message);

                Global.CurrentSettings = set;
                changeStatus = false;
            }

            if (rbMachineTrue.Checked)
            {
                Function.WriteRegistry("UsedComPort", cmbPortList.Text);
                Function.WriteRegistry("UsedBaudRate", cmbBaudList.Text);
            }

            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message);
            else
            {
                Process.LogInsert("Mekanın genel ayarları değiştirildi.", Model.Base.TransactionType.Duzenle);
                MessageBox.Show("Ayarlar kaydedildi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.LogInsert("Ayarlar değiştirildi.", Model.Base.TransactionType.Duzenle);
                DialogResult = changeStatus ? DialogResult.Yes : DialogResult.No;
                Close();
            }
        }

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                if (_userLref == 0)
                {
                    var user = new Model.Users
                    {
                        ACTIVE = cbActive.Checked,
                        CHANGESTARTTIME = cbChangeStartTime.Checked,
                        DATETIME = DateTime.Now,
                        NAME = txtName.Text,
                        PASSWORD = txtPassword.Text.Trim(),
                        SURNAME = txtSurname.Text,
                        TYPE = Convert.ToInt32(cbAdminAccount.Checked),
                        USERNAME = txtUsername.Text.Trim()
                    };
                    string message;

                    _u.Insert(user, out message);
                    GetUserList();
                    if (!string.IsNullOrEmpty(message))
                        MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Process.LogInsert("Yeni yönetici eklendi. Yöneticinin adı: " + txtName.Text + ", kullanıcı adı: " + txtUsername.Text, Model.Base.TransactionType.Duzenle);
                        _userLref = 0;
                        txtName.Text = "";
                        txtPassword.Text = "";
                        txtSurname.Text = "";
                        txtUsername.Text = "";
                        cbActive.Checked = true;
                        cbAdminAccount.Checked = false;
                        cbChangeStartTime.Checked = false;
                        Process.LogInsert(txtName.Text + " " + txtSurname.Text + " adında yeni yönetici eklendi.", Model.Base.TransactionType.Ekle);
                    }
                }
                else
                {
                    var user = new Model.Users
                    {
                        ACTIVE = cbActive.Checked,
                        CHANGESTARTTIME = cbChangeStartTime.Checked,
                        DATETIME = DateTime.Now,
                        NAME = txtName.Text,
                        PASSWORD = txtPassword.Text.Trim(),
                        SURNAME = txtSurname.Text,
                        TYPE = Convert.ToInt32(cbAdminAccount.Checked),
                        USERNAME = txtUsername.Text.Trim(),
                        LREF = _userLref
                    };
                    string message;

                    _u.Update(user, out message);
                    GetUserList();
                    if (!string.IsNullOrEmpty(message))
                        MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Process.LogInsert(txtName.Text + " " + txtSurname.Text + " adında ki, "+ txtUsername.Text +" kullanıcı adlı yöneticinin bilgileri güncellendi.", Model.Base.TransactionType.Duzenle);
                        _userLref = 0;
                        txtName.Text = "";
                        txtPassword.Text = "";
                        txtSurname.Text = "";
                        txtUsername.Text = "";
                        cbActive.Checked = true;
                        cbAdminAccount.Checked = false;
                        cbChangeStartTime.Checked = false;
                    }
                }
            }
            else
                MessageBox.Show("Adı, kullanıcı adı ve parola boş bırakılamaz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Kullanıcıyı silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;
            
            try
            {
                if (lvUserList.SelectedItems[0] == null) return;
                var lvi = lvUserList.SelectedItems[0];
                var lref = Convert.ToInt32(((Model.Users)lvi.Tag).LREF);
                string message;
                var result = _u.Delete(lref, out message);
                if (result < 1)
                    MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Process.LogInsert(lvi.Text + " adındaki kullanıcı silindi.", Model.Base.TransactionType.Sil);
                    GetUserList();
                }
            }
            catch { }
        }

        private void lvTarrifsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsTarrifsRight.Show(lvTarrifsList, e.X, e.Y);
            }
        }

        private void btnTarrifsSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTarrifsName.Text.Trim()) && !string.IsNullOrEmpty(txtTotal.Text.Trim()))
            {
                if (_tarLref == 0)
                {
                    var tar = new Model.Tarrifs
                    {
                        ACTIVE = cbTarActive.Checked,
                        CREATEUSER = Global.CurrentUser.LREF,
                        DATETIME = DateTime.Now,
                        HOURPRICE = Convert.ToDecimal(txtTotal.Text.Replace(".", ","))
                    };
                    tar.MINUTEPRICE = (tar.HOURPRICE / 60);
                    tar.MODIFIEDDATETIME = DateTime.Now;
                    tar.MODIFIEDUSER = Global.CurrentUser.LREF;
                    tar.NAME = txtTarrifsName.Text;
                    tar.SELECTED = cbSelected.Checked;
                    string message;

                    if (cbSelected.Checked)
                        _t.UpdateSelectFalse();

                    _t.Insert(tar, out message);
                    GetTarrifLists();
                    if (!string.IsNullOrEmpty(message))
                        MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Process.LogInsert(txtTarrifsName.Text + " adında " + string.Format("{0:n} TL", txtTotal.Text) + " fiyatında yeni tarife eklendi.", Model.Base.TransactionType.Ekle);
                        _tarLref = 0;
                        txtTarrifsName.Text = "";
                        txtTotal.Text = "";
                        cbTarActive.Checked = false;
                        cbSelected.Checked = false;
                    }
                }
                else
                {
                    var tar = new Model.Tarrifs();
                    var beForeMoney = tar.HOURPRICE;

                    tar.ACTIVE = cbTarActive.Checked;
                    tar.DATETIME = DateTime.Now;
                    tar.HOURPRICE = Convert.ToDecimal(txtTotal.Text.Replace(".", ","));
                    tar.MINUTEPRICE = Convert.ToDecimal(Convert.ToDouble(tar.HOURPRICE / 60));
                    tar.MODIFIEDDATETIME = DateTime.Now;
                    tar.MODIFIEDUSER = Global.CurrentUser.LREF;
                    tar.NAME = txtTarrifsName.Text;
                    tar.SELECTED = cbSelected.Checked;
                    tar.LREF = _tarLref;
                    string message;

                    if (cbSelected.Checked)
                        _t.UpdateSelectFalse();

                    _t.Update(tar, out message);
                    this.GetTarrifLists();
                    if (!string.IsNullOrEmpty(message))
                        MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Process.LogInsert(tar.NAME + " adlı tarife güncellendi. " + string.Format("{0:n} TL", beForeMoney) + " olan saat ücreti " + string.Format("{0:n} TL", tar.HOURPRICE) + " olarak kaydedildi.", Model.Base.TransactionType.Duzenle);
                        _tarLref = 0;
                        txtTarrifsName.Text = "";
                        txtTotal.Text = "";
                        cbTarActive.Checked = false;
                        cbSelected.Checked = false;
                    }
                }
            }
            else
                MessageBox.Show("Tarife adını ve tutarını boş bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvUserList.SelectedItems[0] == null) return;
                try
                {
                    var lvi = lvUserList.SelectedItems[0];
                    var user = lvi.Tag as Model.Users;
                    var lref = user.LREF;

                    txtName.Text = user.NAME;
                    txtSurname.Text = user.SURNAME;
                    txtUsername.Text = user.USERNAME;
                    txtPassword.Text = user.PASSWORD;
                    cbTarActive.Checked = user.ACTIVE;
                    cbAdminAccount.Checked = Convert.ToBoolean(user.TYPE);
                    cbChangeStartTime.Checked = user.CHANGESTARTTIME;
                    _userLref = lref;
                    Process.LogInsert(user.NAME + " " + user.SURNAME + " adında ki kullanıcının bilgileri görüntülendi.", Model.Base.TransactionType.Goruntule);
                }
                catch { }
            }
            catch { }
        }

        private void tsmiTarrifsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvTarrifsList.SelectedItems[0] == null) return;
                var tar = _t.Select(Convert.ToInt32(lvTarrifsList.SelectedItems[0].Tag));
                txtTarrifsName.Text = tar.NAME;
                txtTotal.Text = string.Format("{0:n}", tar.HOURPRICE);
                cbTarActive.Checked = tar.ACTIVE;
                cbSelected.Checked = tar.SELECTED;
                _tarLref = tar.LREF;
            }
            catch { }
        }

        private void tsmiTarrifsDelete_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Daha önce bu tarifeyi kullanmışsanız, hesaplarınız karışabilir veya program hata alabilir. Tarifeyi silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;
            
            try
            {
                if (lvTarrifsList.SelectedItems[0] == null) return;
                var lref = Convert.ToInt32(lvTarrifsList.SelectedItems[0].Tag);
                string message;

                var result = _t.Delete(lref, out message);
                if (result < 1)
                    MessageBox.Show(message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    GetTarrifLists();
            }
            catch { }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            GetTarrifLists();
        }

        private void btnMachineTarrifs_Click(object sender, EventArgs e)
        {
            var frmMachineTarrifs = new FrmMachineTarrifs();
            frmMachineTarrifs.ShowDialog();
        }
    }
}