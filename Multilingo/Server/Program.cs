using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new FrmServer() {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(25, 50)
            }.ShowDialog();
        }
    }
}
