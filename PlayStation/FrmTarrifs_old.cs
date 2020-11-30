using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmTarrifs_old : DevExpress.XtraEditors.XtraForm
    {
        Data.Tarrifs t = new Data.Tarrifs();

        int tarLREF = 0;
        
        public FrmTarrifs_old()
        {
            InitializeComponent();
        }

        private void FrmTarrifs_Load(object sender, EventArgs e)
        {
            this.GetTarrifLists();
        }

        private void GetTarrifLists()
        {
            List<Model.Tarrifs> li = t.Select();
            lvTarrifsList.Items.Clear();
            foreach (var item in li)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = item.LREF;
                lvi.Text = item.NAME;
                lvi.SubItems.Add(string.Format("{0:#.###,##} TL", item.HOURPRICE));
                lvi.SubItems.Add((item.SELECTED ? "Seçili" : "-"));
                lvTarrifsList.Items.Add(lvi);
            }
        }

        private void lvTarrifsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cmsRightClick.Show(lvTarrifsList, e.X, e.Y);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTarrifsName.Text.Trim()) && !string.IsNullOrEmpty(txtTotal.Text.Trim()))
            {
                if (tarLREF == 0)
                {
                    Model.Tarrifs tar = new Model.Tarrifs();
                    tar.ACTIVE = cbActive.Checked;
                    tar.CREATEUSER = Global.CurrentUser.LREF;
                    tar.DATETIME = DateTime.Now;
                    tar.HOURPRICE = Convert.ToDecimal(txtTotal.Text.Replace(".", ","));
                    tar.MINUTEPRICE = (tar.HOURPRICE / 60);
                    tar.MODIFIEDDATETIME = DateTime.Now;
                    tar.MODIFIEDUSER = Global.CurrentUser.LREF;
                    tar.NAME = txtTarrifsName.Text;
                    tar.SELECTED = cbSelected.Checked;
                    string Message;

                    if (cbSelected.Checked)
                        t.UpdateSelectFalse();

                    t.Insert(tar, out Message);
                    this.GetTarrifLists();
                    if (!string.IsNullOrEmpty(Message))
                        MessageBox.Show(Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Process.LogInsert(txtTarrifsName.Text + " adında " + string.Format("{0:n} TL", txtTotal.Text) + " fiyatında yeni tarife eklendi.", Model.Base.TransactionType.Ekle);
                        tarLREF = 0;
                        txtTarrifsName.Text = "";
                        txtTotal.Text = "";
                        cbActive.Checked = false;
                        cbSelected.Checked = false;
                    }
                }
                else
                {
                    Model.Tarrifs tar = new Model.Tarrifs();
                    decimal beForeMoney = tar.HOURPRICE;

                    tar.ACTIVE = cbActive.Checked;
                    tar.DATETIME = DateTime.Now;
                    tar.HOURPRICE = Convert.ToDecimal(txtTotal.Text.Replace(".", ","));
                    tar.MINUTEPRICE = Convert.ToDecimal(Convert.ToDouble(tar.HOURPRICE / 60));
                    tar.MODIFIEDDATETIME = DateTime.Now;
                    tar.MODIFIEDUSER = Global.CurrentUser.LREF;
                    tar.NAME = txtTarrifsName.Text;
                    tar.SELECTED = cbSelected.Checked;
                    tar.LREF = tarLREF;
                    string Message;

                    if (cbSelected.Checked)
                        t.UpdateSelectFalse();

                    t.Update(tar, out Message);
                    this.GetTarrifLists();
                    if (!string.IsNullOrEmpty(Message))
                        MessageBox.Show(Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Process.LogInsert(tar.NAME + " adlı tarife güncellendi. " + string.Format("{0:n} TL", beForeMoney) + " olan saat ücreti " + string.Format("{0:n} TL", tar.HOURPRICE) + " olarak kaydedildi.", Model.Base.TransactionType.Duzenle);
                        tarLREF = 0;
                        txtTarrifsName.Text = "";
                        txtTotal.Text = "";
                        cbActive.Checked = false;
                        cbSelected.Checked = false;
                    }
                }
            }
            else
                MessageBox.Show("Tarife adını ve tutarını boş bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvTarrifsList.SelectedItems[0] != null)
                {
                    Model.Tarrifs tar = t.Select(Convert.ToInt32(lvTarrifsList.SelectedItems[0].Tag));
                    txtTarrifsName.Text = tar.NAME;
                    txtTotal.Text = string.Format("{0:n}", tar.HOURPRICE);
                    cbActive.Checked = tar.ACTIVE;
                    cbSelected.Checked = tar.SELECTED;
                    tarLREF = tar.LREF;
                }
            }catch{}
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Kullanıcıyı silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (lvTarrifsList.SelectedItems[0] != null)
                    {
                        int lref = Convert.ToInt32(lvTarrifsList.SelectedItems[0].Tag);
                        string Message;
                        int result = t.Delete(lref, out Message);
                        if (result < 1)
                            MessageBox.Show(Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            this.GetTarrifLists();
                    }
                }
                catch { }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}