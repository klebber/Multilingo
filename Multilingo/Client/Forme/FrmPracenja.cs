using Library.Domen;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Forme
{
    public partial class FrmPracenja : Form
    {
        private IDomenskiObjekat objekat;
        public void init()
        {
            InitializeComponent();
            CenterToScreen();
            dvgPracenja.BackgroundColor = Color.WhiteSmoke;
            KontrolerKI.Instance.IzmenaPracenja += P_IzmenjenaPracenja;
        }

        public FrmPracenja()
        {
            init();
            KontrolerKI.Instance.VratiPracenja();
        }

        public FrmPracenja(IDomenskiObjekat objekat)
        {
            this.objekat = objekat;
            init();
            KontrolerKI.Instance.NadjiPracenja(objekat);
        }

        private void P_IzmenjenaPracenja()
        {
            Invoke(new Action(() => {
                dvgPracenja.DataSource = KontrolerKI.Instance.pracenja.Select(t => new
                {
                    Polaznik = t.IDKorisnika,
                    Kurs = t.IDKursa,
                    t.DatumPrijave
                }).ToList();
                dvgPracenja.ClearSelection();
            }));
        }

        private void FrmPracenja_FormClosing(object sender, FormClosingEventArgs e)
        {
            KontrolerKI.Instance.IzmenaPracenja -= P_IzmenjenaPracenja;
        }

        private void dvgPracenja_SelectionChanged(object sender, EventArgs e)
        {
            dvgPracenja.ClearSelection();
        }
    }
}
