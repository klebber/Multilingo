using System;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmRegistracija : Form
    {
        public FrmRegistracija()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;
            if(KontrolerKI.Instance.Registracija(txtKorIme.Text, txtPass.Text, txtIme.Text, txtPrezime.Text, 
                txtEmail.Text, txtBroj.Text, (int)numGodine.Value, cbPol.SelectedItem.ToString(), out string poruka))
            {
                MessageBox.Show(poruka);
                Dispose();
            }
            else
            {
                MessageBox.Show(poruka);
            }
        }

        private bool Validacija()
        {
            return true;
        }
    }
}
