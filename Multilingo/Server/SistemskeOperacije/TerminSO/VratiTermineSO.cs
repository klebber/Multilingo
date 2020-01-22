using Library;
using Library.Domen;
using System.Collections.Generic;
using System.Linq;

namespace Server.SistemskeOperacije.TerminSO
{
    public class VratiTermineSO : OpstaSistemskaOperacija
    {
        public VratiTermineSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (Korisnik.KorisnickoIme == "Gost")
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob;
            if (Korisnik is Administrator)
                ob = Broker.Instance.Select((Termin)objekat);
            else
            {
                object temp = Broker.Instance.Select(new Pracenje(), $"IDKorisnika = {Korisnik.IDKorisnika}");
                List<Pracenje> pracenja = temp == null ? new List<Pracenje>() : ((List<IDomenskiObjekat>)temp).ConvertAll(o => (Pracenje)o);
                string kursevi = string.Join(",", pracenja.Select(p => p.IDKursa.ToString()).ToList());
                if (kursevi != string.Empty)
                    ob = Broker.Instance.Select((Termin)objekat, $"IDKursa in ({kursevi})");
                else
                    ob = null;
            }
            return ob == null ? new List<Termin>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Termin)o);
        }
    }
}
