using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
            CenterToScreen();
            KontrolerKI.Instance.IzmenaKurseva += K_IzmenjenKurs;
            KontrolerKI.Instance.IzmenaPolaznika += P_IzmenjeniPolaznici;
            KontrolerKI.Instance.VratiKurseve();
            KontrolerKI.Instance.VratiPolaznike();
        }

        public void K_IzmenjenKurs()
        {
            Invoke(new Action(() => OsveziDVGKurs()));
        }

        private void OsveziDVGKurs()
        {
            if (KontrolerKI.Instance.kursevi == null) return;
            dvgKursevi.DataSource = KontrolerKI.Instance.kursevi.Select(k => new
            {
                k.IDKursa,
                k.BrojRaspolozivihMesta,
                k.Jezik,
                k.Nivo
            }).ToList();
        }

        public void P_IzmenjeniPolaznici()
        {
            Invoke(new Action(() => OsveziDVGPolaznik()));
        }

        private void OsveziDVGPolaznik()
        {
            if (KontrolerKI.Instance.polaznici == null) return;
            dvgPolaznici.DataSource = KontrolerKI.Instance.polaznici.Select(p => new
            {
                p.IDKorisnika,
                p.KorisnickoIme,
                p.Ime,
                p.Prezime,
                p.Email,
                p.BrojTelefona,
                p.Godine,
                p.Pol
            }).ToList();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KontrolerKI.Instance.Logout();
            Dispose();
        }

        private void FrmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            KontrolerKI.Instance.IzmenaKurseva -= K_IzmenjenKurs;
            KontrolerKI.Instance.IzmenaPolaznika -= P_IzmenjeniPolaznici;
        }
        
    }
}
