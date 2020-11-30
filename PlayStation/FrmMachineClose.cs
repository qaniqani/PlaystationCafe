using System;
using System.Windows.Forms;

namespace PlayStation
{
    public partial class FrmMachineClose : DevExpress.XtraEditors.XtraForm
    {
        private readonly Model.Machine _machine;
        private readonly Process _pro = new Process();
        private readonly Data.Machine _m = new Data.Machine();
        private readonly Data.Tarrifs _t = new Data.Tarrifs();
        private readonly Data.Additions _a = new Data.Additions();
        private readonly Data.Calculates _c = new Data.Calculates();

        Model.CalculateDetailView _cdv;

        public FrmMachineClose(Model.Machine mac)
        {
            InitializeComponent();
            _machine = mac;
        }

        private void FrmMachineClose_Load(object sender, EventArgs e)
        {
            if (_machine != null)
            {
                //DialogResult = System.Windows.Forms.DialogResult.No;
                _cdv = _pro.DetailView(_machine);
                lblEndTime.Text = string.Format("{0:HH:mm}", _cdv.EndTime);
                lblAdditionRate.Text = string.Format("{0:n} TL", _cdv.AdditionTotal);
                lblMachineName.Text = _cdv.MachineName;
                lblPrepaid.Text = string.Format("{0:n} TL", _cdv.TotalPrice);
                lblRemainingTime.Text = string.Format("{0}:{1}", _cdv.RemainingTime.Hours.ToString("00"), _cdv.RemainingTime.Minutes.ToString("00"));
                lblStartTime.Text = string.Format("{0:HH:mm}", _cdv.StartTime);
                lblTarrifsName.Text = _t.Select(_machine.TARRIFSREF).NAME;
                lblTotal.Text = string.Format("{0:n} TL", (_cdv.UsedPrice + _cdv.AdditionTotal));
                lblUsedRate.Text = string.Format("{0:n} TL", _cdv.UsedPrice);
                lblUsedTime.Text = string.Format("{0}:{1}", _cdv.UsedTime.Hours.ToString("00"), _cdv.UsedTime.Minutes.ToString("00"));
            }
            else
                Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnMachineClose_Click(object sender, EventArgs e)
        {
            var cal = _c.MachineCalc(_machine.NR);
            var adds = _a.NotPaidSelect(_machine.NR);


            //SÜRELİ HESAPLARDA KULLANIM ÜCRETİ YERİNE VERİLEN PARA BEDELİNİN GEÇERLİ OLMASI İÇİN COMMENTLERİ KALDIR.
            //ÖRNEĞİN: 3TL'LİK HESAP 10DK KULLANILDIYSA KAPANDIĞINDA 3TL HESAP BEDELİ ÇIKAR.
            //COMMENTLİ ŞEKİLDE KULLANIM ÜCRETİ ÜZERİNDEN İŞLEM YAPAR
            //AYNI İŞLEM Process CLASS'INDA MachineCalcInsertAndUpdate METODUNDA DA VAR.

            //if (machine.MACHINESTATUS != (int)Model.Base.MachineType.SureliAcik)
            //{
                var copyMachine = _m.Select(_machine.NR);
                copyMachine.ENDDATETIME = DateTime.Now;
                _pro.MachineCalcInsertAndUpdate(cal, copyMachine, adds, "", "", "Update", Model.Base.MachineType.Kapali);
            //}
            //else
            //    pro.MachineCalcInsertAndUpdate(cal, machine, adds, "", "", "Update", Model.Base.MachineType.Kapali);

            _pro.MachineClosed(_machine);

            Process.LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + _machine.NR + " --> hesabı kapatıldı. Hesap toplamı: " + string.Format("{0:n} TL", (_cdv.TotalPrice + _cdv.AdditionTotal)), Model.Base.TransactionType.Duzenle);

            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnAdditionDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var fa = new FrmAdditions(_machine, Model.Base.AdditionFormType.HesapAdisyonlari);
            fa.ShowDialog();
        }

        private void btnAccountCancellation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ccn = new FrmCalculateCancelNote(_machine);
            var dr = ccn.ShowDialog();

            if (dr != DialogResult.Yes) return;

            DialogResult = DialogResult.Yes;
            Close();
        }

        private void FrmMachineClose_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                simpleButton2_Click(null, null);
        }
    }
}