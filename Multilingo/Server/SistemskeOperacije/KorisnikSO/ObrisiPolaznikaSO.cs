using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class ObrisiPolaznikaSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {

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
