using Library;
using Library.Domen;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class AzurirajPolaznikaSO : OpstaSistemskaOperacija
    {
        public AzurirajPolaznikaSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (!(Korisnik is Administrator))
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            int rez =  Broker.Instance.Update((Polaznik)objekat, ((Polaznik)objekat).IDKorisnika.ToString());
            if (rez == 0)
                throw new SOException("Izmena nije moguca.");
            else
                return "Uspesna izmena";
        }
    }
}
