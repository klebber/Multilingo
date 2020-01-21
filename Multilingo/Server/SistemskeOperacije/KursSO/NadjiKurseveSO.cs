using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KursSO
{
    public class NadjiKurseveSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {
            
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select(new Kurs(), (string)objekat);
            return ob == null ? new List<Kurs>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Kurs)o);
        }
    }
}
