using Library.Transfer;
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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.LOGOUT
            });
            KontrolerKI.Instance.kraj = false;
            Dispose();
        }

        internal void Kill()
        {
            Invoke(new Action(() => Dispose()));
        }
    }
}
