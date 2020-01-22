using System;

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
