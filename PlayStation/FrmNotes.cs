using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PlayStation
{
    public partial class FrmNotes : XtraForm
    {
        private readonly Data.Note _note = new Data.Note();

        public FrmNotes()
        {
            InitializeComponent();
        }

        private void FrmNotes_Load(object sender, EventArgs e)
        {
            GetNotes();
            ActiveControl = btnSave;
            Process.LogInsert("Not defteri görüntülendi.", Model.Base.TransactionType.Goruntule);
        }

        private void GetNotes()
        {
            var n = _note.Select();
            if (n != null)
                txtNote.Text = n.NOTE;
        }

        private void InsertNote()
        {
            string result;

            var n = new Model.Note
            {
                CREATEDATE = DateTime.Now,
                NOTE = txtNote.Text.Trim()
            };
            _note.Insert(n, out result);
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNote.Text.Trim()))
            {
                var dr = MessageBox.Show("Not defteri boş kaydedilecek. Devam etmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr != DialogResult.Yes) return;

                InsertNote();
                Process.LogInsert("Not defteri boş kaydedildi.", Model.Base.TransactionType.Duzenle);
                Close();
            }
            else
            {
                InsertNote();
                Process.LogInsert("Not defteri güncellendi.", Model.Base.TransactionType.Duzenle);
                Close();
            }
        }
    }
}