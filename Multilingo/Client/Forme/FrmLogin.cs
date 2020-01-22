using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Client.Forme;
using Library.Domen;

namespace Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            CenterToScreen();
            Connect();
        }

        private bool Connect()
        {
            if (KontrolerKI.Instance.PoveziSe())
            {
                EnableForm();
                return true;
            }
            else
            {
                DisableForm();
                return false;
            }
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;
            if (!KontrolerKI.Instance.Login(txtUser.Text, txtPass.Text, out string poruka))
            {
                Connect();
                MessageBox.Show(poruka);
            }
            else
            {
                Dispose();
                if (Sesija.Instance.Korisnik is Administrator)
                    (KontrolerKI.Instance.frmAdmin = new Forme.FrmAdmin()).ShowDialog();
                else
                    (KontrolerKI.Instance.frmPolaznik = new Forme.FrmPolaznik()).ShowDialog();
            }
        }

        private bool Validacija()
        {
            bool rez = true;
            if(txtUser.Text == string.Empty || txtUser.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                txtUser.BackColor = Color.LightCoral;
                rez = false;
            }
            if (txtPass.Text == string.Empty)
            {
                txtPass.BackColor = Color.LightCoral;
                rez = false;
            }
            return rez;
        }

        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            (KontrolerKI.Instance.frmRegistracija = new FrmRegistracija()).ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void EnableForm()
        {
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            btnPrijava.Enabled = true;
            btnRegistracija.Enabled = true;
            btnConnect.Visible = false;
        }

        public void DisableForm()
        {
            txtUser.Text = "";
            txtPass.Text = "";
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            btnPrijava.Enabled = false;
            btnRegistracija.Enabled = false;
            btnConnect.Visible = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!Connect()) MessageBox.Show("Server nije dostupan");
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            txtUser.BackColor = Color.White;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.BackColor = Color.White;
        }
    }
}
