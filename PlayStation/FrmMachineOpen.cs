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
    public partial class FrmMachineOpen : XtraForm
    {
        private Model.CalculateDetailView _cdv;
        private readonly Model.Machine _machine;
        private Model.Tarrifs _tar;
        private readonly Model.Base.TimeChange _type;

        private readonly Data.Tarrifs _t = new Data.Tarrifs();
        private readonly Process _pro = new Process();

        public FrmMachineOpen(Model.Machine mac, Model.Base.TimeChange time)
        {
            InitializeComponent();
            _machine = mac;
            _type = time;
        }

        private void FrmMachineOpen_Load(object sender, EventArgs e)
        {
            if (_machine != null)
            {
                ActiveControl = txtTime;
                switch (_type)
                {
                    case Model.Base.TimeChange.SureliAc:

                        #region //Masayi sureli ac
                        Text = "Masayı Süreli Aç";

                        _tar = _machine.SELECTEDTARRIF == 0 ? _t.Selected() : _t.Select(_machine.SELECTEDTARRIF);

                        if (_tar != null)
                        {
                            lblMachineName.Text = Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR;
                            txtTotal.Text = Global.CurrentSettings.MINIMUMTOTAL.ToString();
                            var minute = Global.CurrentSettings.MINIMUMTIME.Value.Minute;
                            txtTime.EditValue = string.Format("{0:0}", minute);
                        }
                        else
                        {
                            MessageBox.Show("Lütfen önce bir tarife ekleyip, seçili duruma getiriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                        break;

                        #endregion

                    case Model.Base.TimeChange.SureVer:

                        #region //Masaya sure ver
                        Text = "Masaya Süre Ver";
                        txtTime.RightToLeft = RightToLeft.No;
                        _tar = _t.Select(_machine.TARRIFSREF);
                        lblMachineName.Text = Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR;

                        txtTime.EditValue = string.Format("{0:0}", 0);
                        btn120Min.Enabled = false;
                        btn150Min.Enabled = false;
                        btn15Min.Enabled = false;
                        btn180Min.Enabled = false;
                        btn30Min.Enabled = false;
                        btn45Min.Enabled = false;
                        btn60Min.Enabled = false;
                        btn75Min.Enabled = false;
                        btn90Min.Enabled = false;
                        break;

                        #endregion

                    case Model.Base.TimeChange.SureliyeCevir:

                        #region //Masayi sureliye cevir
                        Text = "Masaya Süreli Çevir";
                        txtTime.RightToLeft = RightToLeft.No;

                        _tar = _t.Select(_machine.TARRIFSREF);
                        lblMachineName.Text = Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR;

                        _cdv = _pro.DetailView(_machine);

                        var dt = new DateTime(2010, 1, 1);
                        if (_machine.HOLDDATETIME > dt)
                        {
                            MessageBox.Show("Seçili masa daha önceden dondurulmuş hesabı olduğundan kapatılmadan süreliye çevrilemez.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }

                        txtTime.EditValue = string.Format("{0:0}", (DateTime.Now - _cdv.StartTime).TotalMinutes);

                        cbFreeTime.Enabled = false;
                        btn120Min.Enabled = false;
                        btn150Min.Enabled = false;
                        btn15Min.Enabled = false;
                        btn180Min.Enabled = false;
                        btn30Min.Enabled = false;
                        btn45Min.Enabled = false;
                        btn60Min.Enabled = false;
                        btn75Min.Enabled = false;
                        btn90Min.Enabled = false;
                        break;

                        #endregion
                }
            }
            else
                Close();
        }

        private void btnOkey_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case Model.Base.TimeChange.SureliAc:
                    if (cbFreeTime.Checked)
                        _pro.OpenFreeTime(_machine, _tar);
                    else
                        _pro.OpenLimitedTime(_machine, _tar, Convert.ToInt32(txtTime.Text.Trim()));

                    DialogResult = DialogResult.Yes;
                    break;
                case Model.Base.TimeChange.SureVer:
                    if (cbFreeTime.Checked)
                        _pro.OpenFreeTime(_machine, _tar);
                    else
                        _pro.EditLimitedTime(_machine, _tar, Convert.ToInt32(txtTime.Text.Trim()));

                    DialogResult = DialogResult.Yes;
                    break;
                case Model.Base.TimeChange.SureliyeCevir:
                    var totalMinute = Convert.ToInt32((DateTime.Now - _cdv.StartTime).TotalMinutes);
                    var enterMinute = Convert.ToInt32(txtTime.Text.Trim());
                    if (enterMinute < totalMinute)
                    {
                        MessageBox.Show("Girilen süre, kullanılan süreden az olduğu için bu işlem gerçekleştirilemez.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.No;
                    }
                    else
                    {
                        _machine.ENDDATETIME = _machine.STARTDATETIME;
                        _machine.MACHINESTATUS = (int)Model.Base.MachineType.SureliAcik;
                        Process.LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR + " süresiz hesaptan süreli hesaba çevrildi.", Model.Base.TransactionType.Ekle);

                        _pro.EditLimitedTime(_machine, _tar, Convert.ToInt32(txtTime.Text.Trim()));
                        DialogResult = DialogResult.Yes;
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotal.EditValue = (Convert.ToDecimal(txtTime.Text.Trim()) * _tar.MINUTEPRICE).ToString();
            }
            catch{
                MessageBox.Show("Lütfen geçerli bir işlem yapınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            var input = Convert.ToDecimal(txtTotal.Text.Replace(".", ","));
            var minute = Convert.ToInt32(input / _tar.MINUTEPRICE);
            txtTime.EditValue = minute;
        }

        private void txtTime_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    btnOkey_Click(null, null);
                    break;
                case 27:
                    Close();
                    break;
            }
        }

        private void btn15Min_Click(object sender, EventArgs e)
        {
            var minute = Convert.ToInt32(((SimpleButton)sender).Tag);
            _pro.OpenLimitedTime(_machine, _tar, minute);
            DialogResult = DialogResult.Yes;
        }
    }
}