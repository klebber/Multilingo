using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
            Kontroler.Instance.Pokreni();
            ObradaKomponenti();
            Kontroler.Instance.PrijavljenNov += K_PrijavljenNov;
            OsveziDGV();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (!Kontroler.Instance.status)
            {
                btnSwitch.Enabled = false;
                if(!Kontroler.Instance.Pokreni())
                {
                    MessageBox.Show("Greska prilikom pokretanja servera!");
                    btnSwitch.Enabled = true;
                    return;
                }
                btnSwitch.Enabled = true;
            }
            else
            {
                btnSwitch.Enabled = false;
                if(!Kontroler.Instance.Zaustavi())
                {
                    MessageBox.Show("Greska prilikom zaustavljanja servera!");
                    btnSwitch.Enabled = true;
                    return;
                }
                btnSwitch.Enabled = true;
            }
            ObradaKomponenti();
        }

        public void ObradaKomponenti()
        {
            if (Kontroler.Instance.status)
            {
                btnSwitch.Text = "Zaustavi";
                lblStatus.Text = "Server je pokrenut";
                lblStatus.ForeColor = Color.SeaGreen;
            }
            else
            {
                btnSwitch.Text = "Pokreni";
                lblStatus.Text = "Server je zaustavljen";
                lblStatus.ForeColor = Color.Maroon;
            }
        }

        public void OsveziDGV()
        {
            dataGridView1.DataSource = Kontroler.Instance.korisnici.Select(k => new
            {
                k.IP,
                k.Korisnik.KorisnickoIme,
                Uloga = k.Korisnik.Tabela
            }).ToList();
            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].Width = 125;
        }

        private void K_PrijavljenNov()
        {
            Invoke(new Action(() => { OsveziDGV(); }));
        }

        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Kontroler.Instance.PrijavljenNov -= K_PrijavljenNov;
            Kontroler.Instance.Zaustavi();
        }
    }
}
