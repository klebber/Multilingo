using Library;
using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KorisnikSO
{
    class KreirajNalogPolaznikaSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {
            Korisnik k = objekat as Polaznik;
            if (Broker.Instance.Select(new Administrator() { KorisnickoIme = k.KorisnickoIme }) != null 
                || Broker.Instance.Select(new Polaznik() { KorisnickoIme = k.KorisnickoIme }) != null)
            {
                throw new SOException("Ovo korisnicko ime je zauzeto!");
            }
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            Polaznik p = objekat as Polaznik;
            if (Broker.Instance.Insert(p) > 0)
                return "Uspesna registracija.";
            else
                throw new SOException("Greska prilikom kreiranja naloga!");
        }
    }
}
