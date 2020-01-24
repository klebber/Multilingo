using Library.Domen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmPolaznik : Form
    {
        public FrmPolaznik()
        {
            InitializeComponent();
            CenterToScreen();
            Text = "Multilingo - " + Sesija.Instance.Korisnik.KorisnickoIme;
            KontrolerKI.Instance.IzmenaKurseva += K_IzmenjenKurs;
            KontrolerKI.Instance.IzmenaPracenja += P_IzmenjeniPracenja;
            KontrolerKI.Instance.IzmenaTermina += T_IzmenjeniTermini;
            KontrolerKI.Instance.VratiKurseve();
            dvgTermini.RowHeadersVisible = false;
            dvgKursevi.BackgroundColor = Color.WhiteSmoke;
            dvgPracenja.BackgroundColor = Color.WhiteSmoke;
            dvgTermini.BackgroundColor = Color.WhiteSmoke;
        }

        private void T_IzmenjeniTermini()
        {
            Invoke(new Action(() => OsveziDVGTermini()));
        }

        private void OsveziDVGTermini()
        {
            dvgTermini.DataSource = KontrolerKI.Instance.termini.Select(t => new
            {
                ID = t.IDTermina,
                Predavac = t.IDPredavaca,
                t.Vreme,
                t.Datum
            }).ToList();
            dvgTermini.ClearSelection();
        }

        private void P_IzmenjeniPracenja()
        {
            Invoke(new Action(() => OsveziDVGPracenja()));
        }

        private void OsveziDVGPracenja()
        {
            dvgPracenja.DataSource = KontrolerKI.Instance.pracenja.Select(k => new
            {
                ID = k.IDKursa,
                KontrolerKI.Instance.kursevi.Single(ku => ku.IDKursa == k.IDKursa).Jezik,
                KontrolerKI.Instance.kursevi.Single(ku => ku.IDKursa == k.IDKursa).Nivo
            }).ToList();
            dvgPracenja.ClearSelection();
        }

        private void K_IzmenjenKurs()
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KontrolerKI.Instance.Logout();
            Dispose();
        }

        private void dvgTermini_SelectionChanged(object sender, EventArgs e)
        {
            dvgTermini.ClearSelection();
        }

        private void FrmPolaznik_FormClosing(object sender, FormClosingEventArgs e)
        {
            KontrolerKI.Instance.IzmenaKurseva -= K_IzmenjenKurs;
            KontrolerKI.Instance.IzmenaPracenja -= P_IzmenjeniPracenja;
            KontrolerKI.Instance.IzmenaTermina -= T_IzmenjeniTermini;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) KontrolerKI.Instance.VratiKurseve();
            if (tabControl1.SelectedIndex == 1)
            {
                KontrolerKI.Instance.VratiPracenja();
                KontrolerKI.Instance.VratiTermine();
            }
        }

        private void dvgPracenja_SelectionChanged(object sender, EventArgs e)
        {
            if(dvgPracenja.SelectedRows.Count == 0)
            {
                KontrolerKI.Instance.VratiTermine();
            }
            else
            {
                KontrolerKI.Instance.NadjiTermine(dvgPracenja.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void txtKursevi_TextChanged(object sender, EventArgs e)
        {
            KontrolerKI.Instance.NadjiKurseve(txtKursevi.Text);
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            if(dvgKursevi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate izabrati barem jedan kurs!");
            }
            else
            {
                List<Kurs> kursevi = new List<Kurs>();
                foreach (DataGridViewRow row in dvgKursevi.SelectedRows)
                {
                    kursevi.Add(KontrolerKI.Instance.kursevi.Single(k => (int)row.Cells[0].Value == k.IDKursa));
                }
                KontrolerKI.Instance.OdaberiKurseve(kursevi);
                KontrolerKI.Instance.NadjiKurseve(txtKursevi.Text);
            }
        }
    }
}
