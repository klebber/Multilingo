using Library;
using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KursSO
{
    public class AzurirajKursSO : OpstaSistemskaOperacija
    {
        public AzurirajKursSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (!(Korisnik is Administrator))
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            Kurs k = (Kurs)objekat;
            Broker.Instance.Update(k, k.IDKursa.ToString());
            return "Uspesno azuriranje kursa";
        }
    }
}
