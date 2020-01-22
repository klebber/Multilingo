using System;

namespace Library.Transfer
{
    [Serializable]
    public class Odgovor
    {
        public Signal Signal { get; set; }
        public string Poruka { get; set; }
        public Operacija Operacija { get; set; }
        public object Objekat { get; set; }
    }
}
