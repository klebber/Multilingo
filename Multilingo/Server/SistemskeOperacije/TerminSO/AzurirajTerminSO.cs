using Library;
using Library.Domen;

namespace Server.SistemskeOperacije.TerminSO
{
    public class AzurirajTerminSO : OpstaSistemskaOperacija
    {
        public AzurirajTerminSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (!(Korisnik is Administrator))
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            Termin t = (Termin)objekat;
            return Broker.Instance.Update((Termin)objekat, $"IDTermina = {t.IDTermina} and IDKursa = {t.IDKursa}");
        }
    }
}
