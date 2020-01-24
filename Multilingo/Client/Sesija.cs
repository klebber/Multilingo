using Library.Domen;
using System;

namespace Client
{
    class Sesija
    {
        private static readonly Lazy<Sesija> lazy = new Lazy<Sesija>(() => new Sesija());

        public Korisnik Korisnik { get; set; }
        private Sesija()
        {
            Korisnik = null;
        }

        public static Sesija Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
