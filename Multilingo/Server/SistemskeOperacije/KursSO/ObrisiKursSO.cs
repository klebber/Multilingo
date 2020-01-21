using Library;
using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KursSO
{
    public class ObrisiKursSO : OpstaSistemskaOperacija
    {
        public ObrisiKursSO(Korisnik korisnik) : base(korisnik)
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
            Broker.Instance.Delete(new Pracenje(), $"IDKursa = {k.IDKursa.ToString()}");
            Broker.Instance.Delete(new Termin(), $"IDKursa = {k.IDKursa.ToString()}");
            Broker.Instance.Delete(new Kurs(), k.IDKursa.ToString());
            return "Uspesno brisanje kursa.";
        }
    }
}
