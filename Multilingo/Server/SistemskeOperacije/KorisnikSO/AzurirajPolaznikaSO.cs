using Library;
using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class AzurirajPolaznikaSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {

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
