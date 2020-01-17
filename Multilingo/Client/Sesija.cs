using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Sesija
    {
        private static Sesija _INSTANCE;
        public Korisnik Korisnik { get; set; }
        private Sesija()
        {
            Korisnik = null;
        }

        public static Sesija Instance
        {
            get
            {
                if (_INSTANCE == null) _INSTANCE = new Sesija();
                return _INSTANCE;
            }
        }
    }
}
