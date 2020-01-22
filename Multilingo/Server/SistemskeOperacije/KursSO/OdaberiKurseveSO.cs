using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Library;
using Library.Domen;

namespace Server.SistemskeOperacije.KursSO
{
    public class OdaberiKurseveSO : OpstaSistemskaOperacija
    {
        public OdaberiKurseveSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (!(Korisnik is Polaznik))
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            List<Kurs> kursevi = (List<Kurs>)objekat;
            Debug.WriteLine(kursevi.Count);
            foreach (Kurs k in kursevi)
            {
                if(k.BrojRaspolozivihMesta == 0)
                {
                    if(kursevi.Count == 1)
                        throw new SOException("Za odabrani kurs nema raspolozivih mesta!");
                    throw new SOException("Za neke od odabranih kurseva nema raspolozivih mesta!");
                }
                k.BrojRaspolozivihMesta--;
                Broker.Instance.Update(k, k.IDKursa.ToString());
                try
                {
                    Broker.Instance.Insert(new Pracenje()
                    {
                        IDKorisnika = Korisnik.IDKorisnika,
                        IDKursa = k.IDKursa,
                        DatumPrijave = DateTime.Now.Date
                    });
                }
                catch (SqlException)
                {
                    if (kursevi.Count == 1)
                        throw new SOException("Vec ste prijavili ovaj kurs!");
                    throw new SOException("Vec ste prijavili neke od izabranih kurseva!");

                }
            }
            if (kursevi.Count == 1)
                return "Uspesno odabran kurs.";
            return "Uspesno odabrani kursevi.";
        }
    }
}
