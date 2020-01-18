using Library.Domen;
using Library.Transfer;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    class Komunikacija
    {
        private static Komunikacija _INSTANCE;
        private Socket klijentskiSocket;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        private Komunikacija()
        {
            formatter = new BinaryFormatter();
        }
        public static Komunikacija Instance
        {
            get
            {
                if (_INSTANCE == null) _INSTANCE = new Komunikacija();
                return _INSTANCE;
            }
        }

        internal bool PoveziSe()
        {
            if (klijentskiSocket != null && klijentskiSocket.Connected)
                return true;
            try
            {
                klijentskiSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                klijentskiSocket.Connect("localhost", 26300);
                stream = new NetworkStream(klijentskiSocket);
                return true;
            }
            catch (SocketException)
            {
                Debug.WriteLine(">>> Komunikacija PoveziSe Exception!");
                return false;
            }
        }
        
        internal bool PosaljiZahtev(Zahtev zahtev)
        {
            Korisnik kor = (Korisnik)zahtev.Objekat;
            try
            {
                formatter.Serialize(stream, zahtev);
                Debug.WriteLine($">>> Klijent poslao: {zahtev.Operacija} at {DateTime.Now.TimeOfDay.ToString()}");
                return true;
            }
            catch (IOException)
            {
                Debug.WriteLine("Posalji zah u komunikacija");
                klijentskiSocket.Close();
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Odgovor PrihvatiOdgovor()
        {
            try
            {
                Odgovor odgovor = (Odgovor)formatter.Deserialize(stream);
                Debug.WriteLine($">>> Klijent primio: {odgovor.Poruka} at {DateTime.Now.TimeOfDay.ToString()}");
                return odgovor;
            }
            catch (IOException)
            {
                Debug.WriteLine("Prihvati odg u komunikacija");
                klijentskiSocket.Close();
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
