using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Kontroler
    {
        private static Kontroler _INSTANCE;
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
                if (_INSTANCE == null) _INSTANCE = new Kontroler();
                return _INSTANCE;
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
