using Library;
using Library.Domen;
using System.Collections.Generic;

namespace Server.SistemskeOperacije.KursSO
{
    public class VratiKurseveSO : OpstaSistemskaOperacija
    {
        public VratiKurseveSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (Korisnik.KorisnickoIme == "Gost")
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select((Kurs)objekat);
            return ob == null ? new List<Kurs>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Kurs)o);
        }
    }
}
