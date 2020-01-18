using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.KursSO
{
    public class VratiKurseveSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {
            
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select((Kurs)objekat).ConvertAll(o => (Kurs)o);
            return ob ?? new List<Kurs>();
        }
    }
}
