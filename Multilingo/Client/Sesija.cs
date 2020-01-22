using Library.Domen;

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
