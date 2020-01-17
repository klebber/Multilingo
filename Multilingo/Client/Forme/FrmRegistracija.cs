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
            KontrolerKI.Instance.Registracija(txtKorIme.Text, txtPass.Text, txtIme.Text, txtPrezime.Text, txtEmail.Text, txtBroj.Text, (int)numGodine.Value, cbPol.SelectedItem.ToString());
        }

        internal void FailedReg(string poruka)
        {
            MessageBox.Show(poruka);
        }

        internal void SuccessfulReg(string poruka)
        {
            MessageBox.Show(poruka);
            Invoke(new Action(() => Dispose()));
        }

        internal void Kill()
        {
            Invoke(new Action(() => Dispose()));
        }
    }
}
