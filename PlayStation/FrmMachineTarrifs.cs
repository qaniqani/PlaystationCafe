using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PlayStation.Data;
using System.Linq;
using ComboBox = System.Windows.Forms.ComboBox;

namespace PlayStation
{
    public partial class FrmMachineTarrifs : XtraForm
    {
        private readonly Machine _mac = new Machine();
        private readonly Tarrifs _tar = new Tarrifs();

        public FrmMachineTarrifs()
        {
            InitializeComponent();
        }

        private void FrmMachineTarrifs_Load(object sender, EventArgs e)
        {
            GetAllMachine();
        }

        private void GetAllMachine()
        {
            var tarrifs = GetAllTarrifs().OrderBy(a => a.LREF).ToList();
            if (tarrifs.Count == 0)
                return;

            var machineList = _mac.Select();
            if (machineList.Count == 0)
                return;

            var ctrlList = new Control[machineList.Count];
            for (var i = 0; i < machineList.Count; i++)
            {
                var machine = machineList[i];
                var panel = new Panel
                {
                    Dock = DockStyle.Top,
                    Name = "pnl" + i,
                    Size = new Size(361, 33)
                };

                var label = new Label
                {
                    Location = new Point(11, 10),
                    Name = "lblMachineName" + i,
                    Text = machine.NAME
                };

                var combo = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    FormattingEnabled = true,
                    Location = new Point(130, 7),
                    Name = "cmbTarrifs" + i,
                    Size = new Size(200, 21),
                    TabIndex = 1
                };

                var selectedIndex = 0;
                var defaultIndex = 0;

                for (var j = 0; j < tarrifs.Count; j++)
                {
                    var item = tarrifs[j];
                    var cbi = new Model.ComboboxItem
                    {
                        Text = item.NAME,
                        Value = item.LREF
                    };

                    if (item.SELECTED)
                        defaultIndex = j;

                    if (machine.SELECTEDTARRIF == item.LREF)
                        selectedIndex = j;


                    combo.Tag = machine;

                    combo.Items.Add(cbi);
                }

                combo.SelectedIndex = selectedIndex != 0 ? selectedIndex : defaultIndex;

                panel.Controls.Add(label);
                panel.Controls.Add(combo);

                ctrlList[i] = panel;
            }
            xscPanel.Controls.AddRange(ctrlList);
        }

        private IEnumerable<Model.Tarrifs> GetAllTarrifs()
        {
            var tarrifs = _tar.Select();
            return tarrifs;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTarrifsSave_Click(object sender, EventArgs e)
        {
            foreach (var ctrl in xscPanel.Controls)
            {
                if (!(ctrl is Panel)) continue;
                
                var pnl = ctrl as Panel;
                var index = Convert.ToInt32(pnl.Name.Replace("pnl", ""));
                var comboname = "cmbTarrifs" + index;
                var combo = pnl.Controls.Find(comboname, true)[0];
                    
                if (!(combo is ComboBox)) continue;
                    
                var selectedCombo = combo as ComboBox;
                var machine = selectedCombo.Tag as Model.Machine;
                var selectedItem = selectedCombo.SelectedItem as Model.ComboboxItem;
                machine.SELECTEDTARRIF = selectedItem.GetValue();
                string msg;
                _mac.Update(machine, out msg);
                if (!string.IsNullOrEmpty(msg))
                    MessageBox.Show("Bir hata oluştu. Tarifeler atanamadı. Hata detayı: " + msg, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}