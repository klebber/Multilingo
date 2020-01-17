using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using Library.Domen;

namespace Client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            KontrolerKI.Instance.PokreniKlijenta();
        }
    }
}
