using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        internal Socket osluskujuciSocket;

        public Server()
        {
        }

        internal bool PokreniServer()
        {
            try
            {
                osluskujuciSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                osluskujuciSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 26300));
                osluskujuciSocket.Listen(5);
                Debug.WriteLine(">>>S:S: Server je pokrenut");
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public void Osluskuj()
        {
            try
            {
                bool kraj = false;
                while (!kraj)
                {
                    Debug.WriteLine(">>>S:S: Osluskivanje je u toku");
                    Socket klijentskiSoket = osluskujuciSocket.Accept();
                    Obrada obrada = new Obrada(klijentskiSoket);
                    Kontroler.Instance.korisnici.Add(obrada);
                    Kontroler.Instance.OnPrijavljen();
                    Thread nitKlijenta = new Thread(obrada.ObradaZahteva);
                    nitKlijenta.IsBackground = true;
                    nitKlijenta.Start();
                }
            }
            catch (SocketException)
            {
                Debug.WriteLine(">>>S:S: Sokcet zatvoren, osluskivanje prekinuto");
            }
        }
        
    }
}
