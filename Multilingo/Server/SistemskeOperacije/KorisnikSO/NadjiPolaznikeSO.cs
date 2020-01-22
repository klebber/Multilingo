using Library;
using Library.Domen;
using System.Collections.Generic;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class NadjiPolaznikeSO : OpstaSistemskaOperacija
    {
        public NadjiPolaznikeSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (!(Korisnik is Administrator))
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select(new Polaznik(), (string)objekat);
            return ob == null ? new List<Polaznik>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Polaznik)o);
        }
    }
}
