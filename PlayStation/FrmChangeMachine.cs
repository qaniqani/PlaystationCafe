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
    public partial class FrmChangeMachine : XtraForm
    {
        private readonly Data.Machine _mac = new Data.Machine();
        private readonly Model.Machine _m;

        public FrmChangeMachine(Model.Machine machine)
        {
            InitializeComponent();
            _m = machine;
        }

        private void FrmChangeMachine_Load(object sender, EventArgs e)
        {
            lblMachineName.Text = _m.NAME;
            GetEmptyMachine();
        }

        private void GetEmptyMachine()
        {
            cmbMachineList.Items.Clear();
            cmbMachineList.Items.Add(new Model.KeyValueData("Seçiniz", 0));
            cmbMachineList.SelectedIndex = 0;
            var li = _mac.EmptyMachine();

            if (li.Count > 0)
            {
                foreach (var item in li)
                    cmbMachineList.Items.Add(new Model.KeyValueData(item.NAME, item.NR));
            }
            else
            {
                MessageBox.Show("Boş " + Global.CurrentSettings.MACHINETAGNAME + " bulunmamaktadır.");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var kvd = cmbMachineList.SelectedItem as Model.KeyValueData;

            if (kvd != null && kvd.ItemData != 0)
            {
                var emptyMachine = _mac.Select(Convert.ToInt32(kvd.ItemData));
                _mac.EmptyChangeMachine(_m, emptyMachine);
                Process.LogInsert(Global.CurrentSettings.MACHINETAGNAME + " " + _m.NR + " --> " + Global.CurrentSettings.MACHINETAGNAME + " " + emptyMachine.NR + " taşındı.", Model.Base.TransactionType.Duzenle);
                DialogResult = DialogResult.Yes;
                Close();
            }
            else
                MessageBox.Show("Lütfen aktarılacak masayı seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}