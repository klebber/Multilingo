using System;
using System.Threading;
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
            Reconnect();
        }

        private void Reconnect()
        {
            DisableForm();
            while (!KontrolerKI.Instance.PoveziSe())
            {
                Thread.Sleep(1000);
            }
            EnableForm();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (!KontrolerKI.Instance.Login(txtUser.Text, txtPass.Text))
            {
                MessageBox.Show("Server nije dostupan.");
                DisableForm();
                Reconnect();
            }
        }

        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            (KontrolerKI.Instance.frmRegistracija = new FrmRegistracija()).ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void EnableForm()
        {
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            btnPrijava.Enabled = true;
            btnRegistracija.Enabled = true;
        }

        private void DisableForm()
        {
            txtUser.Text = "";
            txtPass.Text = "";
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            btnPrijava.Enabled = false;
            btnRegistracija.Enabled = false;
        }

        internal void FailedLogin(string poruka)
        {
            MessageBox.Show(poruka);
        }

        internal void SuccessfulLogin(Korisnik k)
        {
            Invoke(new Action(() => 
            {
                Dispose();
                if(k is Administrator)
                    (KontrolerKI.Instance.frmAdmin = new Forme.FrmAdmin()).ShowDialog();
                else
                    (KontrolerKI.Instance.frmPolaznik = new Forme.FrmPolaznik()).ShowDialog();
            }));
        }

        internal void Kill()
        {
            Invoke(new Action(() => Dispose()));
        }
    }
}
