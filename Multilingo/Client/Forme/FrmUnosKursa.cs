using Library.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmUnosKursa : Form
    {
        public FrmUnosKursa()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;
            List<IDomenskiObjekat> obj = new List<IDomenskiObjekat>();
            obj.Add(new Kurs()
            {
                BrojRaspolozivihMesta = (int)numBroj.Value,
                Jezik = txtJezik.Text,
                Nivo = txtNivo.Text
            });
            List<DayOfWeek> dani = Dani();
            foreach (DateTime day in EachDay(dateTimePicker1.Value, dateTimePicker2.Value))
            {
                if (dani.Contains(day.DayOfWeek))
                {
                    obj.Add(new Termin()
                    {
                        Datum = day,
                        Vreme = txtVreme.Text,
                        IDPredavaca = Sesija.Instance.Korisnik.IDKorisnika
                    });
                }
            }
            if(obj.Count == 0)
            {
                MessageBox.Show("Izabrani period ne sadrzi ni jedan termin!");
                return;
            }
            KontrolerKI.Instance.KreirajKurs(obj);
            Dispose();
        }

        private bool Validacija()
        {
            bool rez = true;
            if(Dani().Count == 0)
            {
                MessageBox.Show("Morate izabrati barem jedan dan.");
                rez = false;
            }
            if (!Regex.IsMatch(txtVreme.Text, @"([0-1]?[0-9]|2[0-3])\:([0-5][0-9])"))
            {
                MessageBox.Show("Unos nije ispravan!");
                return false;
            }
            if(txtJezik.Text == string.Empty)
            {
                MessageBox.Show("Morate uneti jezik");
                return false;
            }
            if(txtNivo.Text == string.Empty)
            {
                MessageBox.Show("Morate uneti nivo");
                return false;
            }
            return rez;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private List<DayOfWeek> Dani()
        {
            List<DayOfWeek> dani = new List<DayOfWeek>();
            if (cbPon.Checked) dani.Add(DayOfWeek.Monday);
            if (cbUto.Checked) dani.Add(DayOfWeek.Tuesday);
            if (cbSre.Checked) dani.Add(DayOfWeek.Wednesday);
            if (cbCet.Checked) dani.Add(DayOfWeek.Thursday);
            if (cbPet.Checked) dani.Add(DayOfWeek.Friday);
            if (cbSub.Checked) dani.Add(DayOfWeek.Saturday);
            if (cbNed.Checked) dani.Add(DayOfWeek.Sunday);
            return dani;
        }
    }
}
