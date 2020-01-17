using Library.Domen;
using Library.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
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

        protected abstract void Validacija(object objekat);

        protected abstract object IzvrsiKonkretnuOperaciju(object objekat);
    }
}
