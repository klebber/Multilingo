using Library.Domen;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmTermini : Form
    {
        string id = null;
        private void init()
        {
            InitializeComponent();
            CenterToScreen();
            dvgTermini.BackgroundColor = Color.WhiteSmoke;
            KontrolerKI.Instance.IzmenaTermina += T_IzmenjenTermin;
        }
        public FrmTermini()
        {
            init();
            KontrolerKI.Instance.VratiTermine();
        }

        public FrmTermini(string IDKursa)
        {
            init();
            id = IDKursa;
            KontrolerKI.Instance.NadjiTermine(id);
        }

        private void T_IzmenjenTermin()
        {
            Invoke(new Action(() => {
                dvgTermini.DataSource = KontrolerKI.Instance.termini.Select(t => new
                {
                    ID = t.IDTermina,
                    Kurs = t.IDKursa,
                    Predavac = t.IDPredavaca,
                    t.Vreme,
                    t.Datum
                }).ToList();
                dvgTermini.ClearSelection();
            }));
        }

        private void FrmTermini_FormClosing(object sender, FormClosingEventArgs e)
        {
            KontrolerKI.Instance.IzmenaTermina -= T_IzmenjenTermin;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;
            Termin termin = KontrolerKI.Instance.termini.Single(t => t.IDTermina == (int)dvgTermini.SelectedRows[0].Cells[0].Value);
            termin.Vreme = textBox1.Text;
            KontrolerKI.Instance.AzurirajTermin(termin);
        }

        private bool Validacija()
        {
            if(!Regex.IsMatch(textBox1.Text, @"([0-1]?[0-9]|2[0-3])\:([0-5][0-9])"))
            {
                MessageBox.Show("Unos nije ispravan!");
                return false;
            }
            return true;
        }

        private void dvgTermini_SelectionChanged(object sender, EventArgs e)
        {
            if(dvgTermini.SelectedRows.Count == 1)
            {
                textBox1.Enabled = true;
                textBox1.Text = dvgTermini.SelectedRows[0].Cells[3].Value.ToString();
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "";
            }
        }

        public void UspesnoAzuriranje()
        {
            if(id == null)
                KontrolerKI.Instance.VratiTermine();
            else
                KontrolerKI.Instance.NadjiTermine(id);
        }
    }
}
