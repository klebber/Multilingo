using System;

namespace Library.Transfer
{
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public object Objekat { get; set; }
        public object KriterijumPretrage { get; set; }

    }
}
