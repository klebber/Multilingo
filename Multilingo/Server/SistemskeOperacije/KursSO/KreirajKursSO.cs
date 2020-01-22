using Library;
using Library.Domen;
using System.Collections.Generic;

namespace Server.SistemskeOperacije.KursSO
{
    public class KreirajKursSO : OpstaSistemskaOperacija
    {
        public KreirajKursSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (!(Korisnik is Administrator))
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            List<IDomenskiObjekat> obj = (List<IDomenskiObjekat>)objekat;
            Kurs k = (Kurs)obj[0];
            obj.Remove(obj[0]);
            List<Termin> termini = obj.ConvertAll(t => (Termin)t);
            k.IDKursa = (int) Broker.Instance.Insert(k);
            foreach(Termin t in termini)
            {
                t.IDKursa = k.IDKursa;
                Broker.Instance.Insert(t);
            }
            return "Uspesno kreiranje kursa";
        }
    }
}
