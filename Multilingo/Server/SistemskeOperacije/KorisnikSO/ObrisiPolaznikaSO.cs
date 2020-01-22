using Library;
using Library.Domen;
using System.Collections.Generic;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class ObrisiPolaznikaSO : OpstaSistemskaOperacija
    {
        public ObrisiPolaznikaSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (!(Korisnik is Administrator))
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            Polaznik p = (Polaznik)objekat;
            object obj = Broker.Instance.Select(new Kurs() { BrojRaspolozivihMesta = -1 }, p.IDKorisnika.ToString());
            if (obj != null)
            {
                List<Kurs> kursevi = ((List<IDomenskiObjekat>)obj).ConvertAll(k => (Kurs)k);
                foreach (Kurs k in kursevi)
                {
                    k.BrojRaspolozivihMesta += 1;
                    Broker.Instance.Update(k, k.IDKursa.ToString());
                }
            }
            Broker.Instance.Delete(new Pracenje(), $"IDKorisnika = {p.IDKorisnika.ToString()}");
            Broker.Instance.Delete(new Polaznik(), p.IDKorisnika.ToString());
            Broker.Instance.Delete(new Korisnik(), p.IDKorisnika.ToString());
            return "Uspesno obrisan polaznik";
        }
    }
}
