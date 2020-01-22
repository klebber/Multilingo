using Library;
using Library.Domen;
using System.Collections.Generic;

namespace Server.SistemskeOperacije.PracenjeSO
{
    public class VratiPracenjaKursevaSO : OpstaSistemskaOperacija
    {
        public VratiPracenjaKursevaSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (Korisnik.KorisnickoIme == "Gost")
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob;
            if (Korisnik is Administrator)
                ob = Broker.Instance.Select((Pracenje)objekat);
            else
                ob = Broker.Instance.Select((Pracenje)objekat, $"IDKorisnika = {Korisnik.IDKorisnika}");
            return ob == null ? new List<Pracenje>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Pracenje)o);
        }
    }
}
