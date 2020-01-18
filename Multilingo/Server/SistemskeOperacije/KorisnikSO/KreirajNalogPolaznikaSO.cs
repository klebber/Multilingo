using Library;
using Library.Domen;

namespace Server.SistemskeOperacije.KorisnikSO
{
    class KreirajNalogPolaznikaSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {
            Korisnik k = objekat as Polaznik;
            if (Broker.Instance.Select(new Korisnik() { KorisnickoIme = k.KorisnickoIme }) != null)
            {
                throw new SOException("Ovo korisnicko ime je zauzeto!");
            }
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            Polaznik p = objekat as Polaznik;
            Korisnik k = new Korisnik()
            {
                KorisnickoIme = p.KorisnickoIme,
                Lozinka = p.Lozinka,
                Ime = p.Ime,
                Prezime = p.Prezime,
                Email = p.Email
            };
            object id = Broker.Instance.Insert(k);
            if (id == null)
                throw new SOException("Greska prilikom registracije!");
            p.IDKorisnika = (int)id;
            Broker.Instance.Insert(p);
            return "Uspesno kreiran nalog.";
                
        }
    }
}
