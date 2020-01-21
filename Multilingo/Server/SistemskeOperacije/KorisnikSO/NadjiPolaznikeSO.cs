using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KorisnikSO
{
    public class NadjiPolaznikeSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {

        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select(new Polaznik(), (string)objekat);
            return ob == null ? new List<Polaznik>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Polaznik)o);
        }
    }
}
