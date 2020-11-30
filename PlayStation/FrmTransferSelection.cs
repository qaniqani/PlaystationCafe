using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmTransferSelection : XtraForm
    {
        private Model.Machine _dragMachine;
        private Model.Machine _dropMachine;
        private readonly Process _pro = new Process();
        private readonly Data.Machine _mac = new Data.Machine();

        public FrmTransferSelection(Model.Machine m1, Model.Machine m2)
        {
            InitializeComponent();
            _dragMachine = m1;
            _dropMachine = m2;
        }

        private void FrmTransferSelection_Load(object sender, EventArgs e)
        {
            if (_dragMachine.MACHINESTATUS == (int)Model.Base.MachineType.SureliAcik || _dropMachine.MACHINESTATUS == (int)Model.Base.MachineType.SureliAcik)
                btnCalculateTransfer.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            #region //Hesaplari birlestir
            var dr = MessageBox.Show(Global.CurrentSettings.MACHINETAGNAME + " " + _dragMachine.NR + " --> " + Global.CurrentSettings.MACHINETAGNAME + " " + _dropMachine.NR + " taşınacak. Devam etmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                if (_dragMachine.MACHINESTATUS != (int)Model.Base.MachineType.SureliAcik && _dropMachine.MACHINESTATUS != (int)Model.Base.MachineType.SureliAcik)
                {
                    _pro.CalculatesTransfer(_dragMachine, _dropMachine);
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("Süreli hesaplar da hesap aktarımı yapılamaz.","UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.No;
                }
            }
            else
                DialogResult = DialogResult.No;
            #endregion
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var m = _mac.Select(_dragMachine.NR);
            _mac.DragDropChangeMachine(_dragMachine, m, _dropMachine);
            Process.LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + _dragMachine.NR + " ile " + Global.CurrentSettings.MACHINETAGNAME + " " + _dropMachine.NR + " yer değiştirdi.", Model.Base.TransactionType.Duzenle);
            DialogResult = DialogResult.Yes;
        }
    }
}