using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Server
{
    public class Kontroler
    {
        private static readonly Lazy<Kontroler> lazy = new Lazy<Kontroler>(() => new Kontroler());

        private Server server;
        public delegate void PrijavljenNovEventHandler();
        public event PrijavljenNovEventHandler PrijavljenNov;
        internal List<Obrada> korisnici;
        public bool status;

        private Kontroler()
        {
            server = new Server();
            korisnici = new List<Obrada>();
        }

        public static Kontroler Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public bool Pokreni()
        {
            if (status = server.PokreniServer())
            {
                Thread osluskivanje = new Thread(server.Osluskuj);
                osluskivanje.IsBackground = true;
                osluskivanje.Start();
            }
            return status;
        }

        public bool Zaustavi()
        {
            try
            {
                server.osluskujuciSocket.Close();
                foreach (Obrada o in korisnici)
                {
                    o.Zaustavi();
                }
                return !(status = false);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public void OnPrijavljen()
        {
            PrijavljenNov?.Invoke();
        }
    }
}
