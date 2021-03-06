﻿using Library;
using Library.Domen;
using System.Collections.Generic;

namespace Server.SistemskeOperacije.TerminSO
{
    public class NadjiTermineSO : OpstaSistemskaOperacija
    {
        public NadjiTermineSO(Korisnik korisnik) : base(korisnik)
        {
        }

        protected override void Validacija(object objekat)
        {
            if (Korisnik.KorisnickoIme == "Gost")
                throw new SOException("Ne mozete izvrsiti ovu operaciju!");
        }

        protected override object IzvrsiKonkretnuOperaciju(object objekat)
        {
            object ob = Broker.Instance.Select(new Termin(), "IDKursa = " + (string)objekat);
            return ob == null ? new List<Termin>() : ((List<IDomenskiObjekat>)ob).ConvertAll(o => (Termin)o);
        }
    }
}
