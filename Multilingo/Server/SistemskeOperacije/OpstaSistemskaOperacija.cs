﻿using Library.Domen;
using System;

namespace Server.SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        public Korisnik Korisnik { get; }

        public OpstaSistemskaOperacija(Korisnik korisnik)
        {
            Korisnik = korisnik;
        }

        protected abstract void Validacija(object objekat);

        public object IzvrsiSO(object objekat)
        {
            try
            { 
                Broker.Instance.OtvoriKonekciju();
                Broker.Instance.PokreniTransakciju();
                Validacija(objekat);
                object rezultat = IzvrsiKonkretnuOperaciju(objekat);
                Broker.Instance.Commit();
                return rezultat;
            }
            catch (Exception)
            {
                Broker.Instance.Rollback();
                throw;
            }
            finally
            {
                Broker.Instance.ZatvoriKonekciju();
            }
        }

        protected abstract object IzvrsiKonkretnuOperaciju(object objekat);
    }
}
