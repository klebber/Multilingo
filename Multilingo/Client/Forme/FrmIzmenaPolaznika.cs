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
    public partial class FrmIzmenaPolaznika : Form
    {
        Polaznik polaznik;
        public FrmIzmenaPolaznika(Polaznik polaznik)
        {
            InitializeComponent();
            this.polaznik = polaznik;
            textBox1.Text = polaznik.BrojTelefona;
            numGodine.Value = polaznik.Godine;
            cbPol.SelectedItem = polaznik.Pol;
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validacija()) return;
            polaznik.BrojTelefona = textBox1.Text;
            polaznik.Godine = (int)numGodine.Value;
            polaznik.Pol = cbPol.SelectedItem.ToString();
            KontrolerKI.Instance.AzurirajPolaznika(polaznik);
            Dispose();
        }

        private bool Validacija()
        {
            bool rez = true;
            if (textBox1.Text == string.Empty || textBox1.Text.Any(c => char.IsLetter(c)))
            {
                textBox1.BackColor = Color.LightCoral;
                rez = false;
            }
            if (numGodine.Value < 0 && numGodine.Value > 100)
            {
                numGodine.BackColor = Color.LightCoral;
                rez = false;
            }
            return rez;
        }
    }
}
