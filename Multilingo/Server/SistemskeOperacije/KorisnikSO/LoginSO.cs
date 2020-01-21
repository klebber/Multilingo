using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Library;
using Library.Domen;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class LoginSO : OpstaSistemskaOperacija
    {
        public LoginSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (Korisnik.KorisnickoIme != "Gost")
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
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
            if ((lista = Broker.Instance.Select(new Korisnik() { KorisnickoIme = k.KorisnickoIme })) != null)
            {
                if(((Korisnik)lista[0]).Lozinka == k.Lozinka)
                    return lista[0];
                throw new SOException("Pogresna lozinka!");
            }
            else
                throw new SOException("Ne postoji korisnik sa datim podacima!");
        }

    }
}
