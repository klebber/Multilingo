using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
