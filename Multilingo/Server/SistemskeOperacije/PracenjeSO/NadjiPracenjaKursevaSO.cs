using Library;
using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.PracenjeSO
{
    public class NadjiPracenjaKursevaSO : OpstaSistemskaOperacija
    {
        public NadjiPracenjaKursevaSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (!(Korisnik is Administrator))
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            
            object ob = Broker.Instance.Select(new Pracenje(), objekat is Kurs ? $"IDKursa = {((Kurs)objekat).IDKursa}" : $"IDKorisnika = {((Polaznik)objekat).IDKorisnika}");
            return ob == null ? new List<Pracenje>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Pracenje)o);
        }
    }
}
