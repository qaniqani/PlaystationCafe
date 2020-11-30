using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmOpenTarrifs : XtraForm
    {
        private readonly Data.Tarrifs _t = new Data.Tarrifs();
        private readonly Model.Machine _mac = new Model.Machine();
        private readonly Process _pro = new Process();

        public FrmOpenTarrifs(Model.Machine machine)
        {
            InitializeComponent();
            _mac = machine;
        }

        private void FrmOpenTarrifs_Load(object sender, EventArgs e)
        {
            if (_mac != null)
                GetTarrifLists();
            else
                Close();
        }

        private void GetTarrifLists()
        {
            var li = _t.Select();
            lvTarrifsList.Items.Clear();
            foreach (var item in li)
            {
                var lvi = new ListViewItem
                {
                    Tag = item,
                    Text = item.NAME
                };
                lvi.SubItems.Add(string.Format("{0:#.###,##} TL", item.HOURPRICE));
                lvi.SubItems.Add((item.SELECTED ? "Seçili" : "-"));
                lvTarrifsList.Items.Add(lvi);
            }
        }

        private void btnOpenMachine_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvTarrifsList.SelectedItems[0] == null) return;

                var tar = lvTarrifsList.SelectedItems[0].Tag as Model.Tarrifs;
                _pro.OpenFreeTime(_mac, tar);
                DialogResult = DialogResult.Yes;
                Close();
            }
            catch
            {
                // ignored
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}