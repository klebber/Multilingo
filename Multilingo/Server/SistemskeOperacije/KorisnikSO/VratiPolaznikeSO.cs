using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class VratiPolaznikeSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {

        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select((Polaznik)objekat).ConvertAll(o => (Polaznik)o);
            return ob ?? new List<Polaznik>();
        }
    }
}
