using Library;
using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Broker.Instance.Update((Termin)objekat, "IDTermina = " + ((Termin)objekat).IDTermina);
        }
    }
}
