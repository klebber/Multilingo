using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmRegistracija : Form
    {
        public FrmRegistracija()
        {
            InitializeComponent();
            CenterToParent();
            cbPol.SelectedIndex = 0;
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
            bool rez = true;
            if (txtKorIme.Text == string.Empty || txtKorIme.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                txtKorIme.BackColor = Color.LightCoral;
                rez = false;
            }
            if (txtPass.Text == string.Empty)
            {
                txtPass.BackColor = Color.LightCoral;
                rez = false;
            }
            if (txtIme.Text == string.Empty || txtIme.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                txtIme.BackColor = Color.LightCoral;
                rez = false;
            }
            if (txtPrezime.Text == string.Empty || txtPrezime.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                txtPrezime.BackColor = Color.LightCoral;
                rez = false;
            }
            if (txtEmail.Text == string.Empty)
            {
                txtEmail.BackColor = Color.LightCoral;
                rez = false;
            }
            if (txtBroj.Text == string.Empty || txtBroj.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                txtBroj.BackColor = Color.LightCoral;
                rez = false;
            }
            if (numGodine.Value < 0 && numGodine.Value > 100)
            {
                txtBroj.BackColor = Color.LightCoral;
                rez = false;
            }
            return rez;
        }
    }
}
