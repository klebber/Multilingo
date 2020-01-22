using Library;
using Library.Domen;
using System.Collections.Generic;

namespace Server.SistemskeOperacije.KursSO
{
    public class NadjiKurseveSO : OpstaSistemskaOperacija
    {
        public NadjiKurseveSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (Korisnik.KorisnickoIme == "Gost")
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select(new Kurs(), (string)objekat);
            return ob == null ? new List<Kurs>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Kurs)o);
        }
    }
}
