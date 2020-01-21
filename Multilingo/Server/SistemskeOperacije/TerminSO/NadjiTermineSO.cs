using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.TerminSO
{
    public class NadjiTermineSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {

        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select(new Termin(), "IDKursa = " + (string)objekat);
            return ob == null ? new List<Termin>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Termin)o);
        }
    }
}
