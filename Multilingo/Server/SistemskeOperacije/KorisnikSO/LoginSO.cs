using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Domen;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class LoginSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {
           if (Kontroler.Instance.korisnici.Any(k => k.Korisnik.KorisnickoIme == ((Korisnik)objekat).KorisnickoIme))
           {

                Debug.WriteLine($"Korisnik je vec prijavljen: {((Korisnik)objekat).KorisnickoIme}");
                throw new SOException("Korisnik je vec prijavljen!");
           }
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            Korisnik k = (Korisnik)objekat;
            List<IDomenskiObjekat> lista;
            if ((lista = Broker.Instance.Select(new Administrator() { KorisnickoIme = k.KorisnickoIme })) != null)
            {
                if(((Korisnik)lista[0]).Lozinka == k.Lozinka)
                    return lista[0];
                throw new SOException("Pogresna lozinka!");
            }
            else if ((lista = Broker.Instance.Select(new Polaznik() { KorisnickoIme = k.KorisnickoIme })) != null)
            {
                if (((Korisnik)lista[0]).Lozinka == k.Lozinka)
                    return lista[0];
                throw new SOException("Pogresna lozinka!");
            }
            else
                throw new SOException("Ne postoji korisnik sa datim podacima!");
        }

    }
}
