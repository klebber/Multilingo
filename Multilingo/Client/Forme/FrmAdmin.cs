using Library.Domen;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmAdmin : Form
    {
        public FrmTermini frmTermini;
        public FrmPracenja frmPracenja;
        public FrmIzmenaPolaznika frmIzmenaPolaznika;
        public FrmUnosKursa frmUnosKursa;
        public FrmIzmenaKursa frmIzmenaKursa;
        public FrmAdmin()
        {
            InitializeComponent();
            CenterToScreen();
            Text = "Multilingo - " + Sesija.Instance.Korisnik.KorisnickoIme + " (Administrator)";
            KontrolerKI.Instance.IzmenaKurseva += K_IzmenjenKurs;
            KontrolerKI.Instance.IzmenaPolaznika += P_IzmenjeniPolaznici;
            KontrolerKI.Instance.VratiKurseve();
            dvgKursevi.BackgroundColor = Color.WhiteSmoke;
            dvgPolaznici.BackgroundColor = Color.WhiteSmoke;
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
                k.Jezik,
                k.Nivo,
                k.BrojRaspolozivihMesta
            }).ToList();
            dvgKursevi.ClearSelection();
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
            dvgPolaznici.ClearSelection();
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
            if (frmTermini != null && frmTermini.Created) frmTermini.Dispose();
            if (frmPracenja != null && frmPracenja.Created) frmPracenja.Dispose();
            if (frmIzmenaPolaznika != null && frmIzmenaPolaznika.Created) frmIzmenaPolaznika.Dispose();
            if (frmUnosKursa != null && frmUnosKursa.Created) frmUnosKursa.Dispose();
            if (frmIzmenaKursa != null && frmIzmenaKursa.Created) frmIzmenaKursa.Dispose();
            KontrolerKI.Instance.IzmenaKurseva -= K_IzmenjenKurs;
            KontrolerKI.Instance.IzmenaPolaznika -= P_IzmenjeniPolaznici;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) KontrolerKI.Instance.VratiKurseve();
            if (tabControl1.SelectedIndex == 1) KontrolerKI.Instance.VratiPolaznike();
        }

        private void tabKursevi_Click(object sender, EventArgs e)
        {
            dvgKursevi.ClearSelection();
        }

        private void tabPolaznici_Click(object sender, EventArgs e)
        {
            dvgPolaznici.ClearSelection();
        }

        private void dvgKursevi_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void dvgPolaznici_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void txtKursevi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void txtKursevi_TextChanged(object sender, EventArgs e)
        {
            KontrolerKI.Instance.NadjiKurseve(txtKursevi.Text);
        }

        private void txtPolaznici_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void txtPolaznici_TextChanged(object sender, EventArgs e)
        {
            KontrolerKI.Instance.NadjiPolaznike(txtPolaznici.Text);
        }

        private void btnPBrisanje_Click(object sender, EventArgs e)
        {
            if (dvgPolaznici.SelectedRows.Count == 1)
            {
                DialogResult result1 = MessageBox.Show($"Da li ste sigurni da zelite da obrisete korisnika {dvgPolaznici.SelectedRows[0].Cells[1].Value}",
                "Brisanje polaznika!", MessageBoxButtons.YesNo);
                if(result1 == DialogResult.Yes)
                    KontrolerKI.Instance.ObrisiPolaznika(new Polaznik() { IDKorisnika = (int)dvgPolaznici.SelectedRows[0].Cells[0].Value });
            }
            else
                MessageBox.Show("Odaberite korisnika koga zelite da obrisete!");
        }

        internal void UspesnoBrisanjePolaznika(string poruka)
        {
            MessageBox.Show(poruka);
            KontrolerKI.Instance.NadjiPolaznike(txtPolaznici.Text);
        }

        private void btnTermini_Click(object sender, EventArgs e)
        {
            if (dvgKursevi.SelectedRows.Count == 0)
            {
                (frmTermini = new FrmTermini()).ShowDialog();
            }
            else
            {
                (frmTermini = new FrmTermini(dvgKursevi.SelectedRows[0].Cells[0].Value.ToString())).ShowDialog();
            }
        }

        public void UspesnoAzuriranjeTermina()
        {
            if (frmTermini != null && frmTermini.Created) frmTermini.UspesnoAzuriranje();
        }

        private void btnKPracenja_Click(object sender, EventArgs e)
        {
            if (dvgKursevi.SelectedRows.Count == 0)
            {
                (frmPracenja = new FrmPracenja()).ShowDialog();
            }
            else
            {
                Kurs kurs = new Kurs() { IDKursa = (int)dvgKursevi.SelectedRows[0].Cells[0].Value };
                (frmPracenja = new FrmPracenja(kurs)).ShowDialog();
            }
        }

        private void btnPPracenja_Click(object sender, EventArgs e)
        {
            if (dvgPolaznici.SelectedRows.Count == 0)
            {
                (frmPracenja = new FrmPracenja()).ShowDialog();
            }
            else
            {
                Polaznik kurs = new Polaznik() { IDKorisnika = (int)dvgPolaznici.SelectedRows[0].Cells[0].Value };
                (frmPracenja = new FrmPracenja(kurs)).ShowDialog();
            }
        }

        private void btnPIzmena_Click(object sender, EventArgs e)
        {
            if (dvgPolaznici.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati polaznika!");
            }
            else
            {
                int id = (int)dvgPolaznici.SelectedRows[0].Cells[0].Value;
                Polaznik polaznik = KontrolerKI.Instance.polaznici.Single(p => p.IDKorisnika == id);
                (frmIzmenaPolaznika = new FrmIzmenaPolaznika(polaznik)).ShowDialog();
                KontrolerKI.Instance.NadjiPolaznike(txtPolaznici.Text);
            }
        }

        private void btnKBrisanje_Click(object sender, EventArgs e)
        {
            if (dvgKursevi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite kurs koji zelite da obrisete!");
            }
            else
            {
                DialogResult result1 = MessageBox.Show($"Da li ste sigurni da zelite da obrisete Kurs {dvgKursevi.SelectedRows[0].Cells[0].Value}",
                "Brisanje polaznika!", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    Kurs kurs = new Kurs() { IDKursa = (int)dvgKursevi.SelectedRows[0].Cells[0].Value };
                    KontrolerKI.Instance.ObrisiKurs(kurs);
                }
            }
        }

        internal void UspesnoBrisanjeKursa(string poruka)
        {
            MessageBox.Show(poruka);
            KontrolerKI.Instance.NadjiKurseve(txtKursevi.Text);
        }

        private void btnKUnos_Click(object sender, EventArgs e)
        {
            (frmUnosKursa = new FrmUnosKursa()).ShowDialog();
            KontrolerKI.Instance.NadjiKurseve(txtKursevi.Text);
        }

        private void btnKIzmena_Click(object sender, EventArgs e)
        {
            if (dvgKursevi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati kurs!");
            }
            else
            {
                int id = (int)dvgKursevi.SelectedRows[0].Cells[0].Value;
                Kurs kurs = KontrolerKI.Instance.kursevi.Single(p => p.IDKursa == id);
                (frmIzmenaKursa = new FrmIzmenaKursa(kurs)).ShowDialog();
                KontrolerKI.Instance.NadjiKurseve(txtPolaznici.Text);
            }
        }
    }
}
