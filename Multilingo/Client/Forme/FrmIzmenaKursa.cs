using Library.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmIzmenaKursa : Form
    {
        private Kurs kurs;
        public FrmIzmenaKursa(Kurs kurs)
        {
            InitializeComponent();
            CenterToScreen();
            this.kurs = kurs;
            txtJezik.Text = kurs.Jezik;
            txtNivo.Text = kurs.Nivo;
            numBr.Value = kurs.BrojRaspolozivihMesta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;
            kurs.Jezik = txtJezik.Text;
            kurs.Nivo = txtNivo.Text;
            kurs.BrojRaspolozivihMesta = (int)numBr.Value;
            KontrolerKI.Instance.AzurirajKurs(kurs);
            Dispose();
        }

        private bool Validacija()
        {
            bool rez = true;
            if (txtJezik.Text == string.Empty || txtJezik.Text.Any(c => !char.IsLetter(c)))
            {
                txtJezik.BackColor = Color.LightCoral;
                rez = false;
            }
            if (txtNivo.Text == string.Empty || txtNivo.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                txtNivo.BackColor = Color.LightCoral;
                rez = false;
            }
            return rez;
        }
    }
}
