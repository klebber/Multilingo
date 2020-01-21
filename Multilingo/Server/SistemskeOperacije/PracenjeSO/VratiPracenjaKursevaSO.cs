﻿using Library.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.PracenjeSO
{
    public class VratiPracenjaKursevaSO : OpstaSistemskaOperacija
    {
        protected override void Validacija(object objekat)
        {

        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select((Pracenje)objekat);
            return ob == null ? new List<Pracenje>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Pracenje)o);
        }
    }
}
