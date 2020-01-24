using Library;
using Library.Domen;
using Library.Transfer;
using Server.SistemskeOperacije.KorisnikSO;
using Server.SistemskeOperacije.KursSO;
using Server.SistemskeOperacije.PracenjeSO;
using Server.SistemskeOperacije.TerminSO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    class Obrada
    {
        private Socket klijentskiSoket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        public string IP { get; set; }
        public Korisnik Korisnik { get; set; }

        public Obrada(Socket klijentskiSoket)
        {
            this.klijentskiSoket = klijentskiSoket;
            stream = new NetworkStream(klijentskiSoket);
            IPEndPoint ipep = (IPEndPoint)klijentskiSoket.RemoteEndPoint;
            IP = ipep.Address.ToString() + ":" + ipep.Port.ToString();
            Korisnik = new Korisnik() { KorisnickoIme = "Gost" };
        }

        public void ObradaZahteva()
        {
            bool kraj = false;
            try
            {
                while (!kraj)
                {
                    Zahtev zahtev = (Zahtev)formatter.Deserialize(stream);
                    Debug.WriteLine($">>> Server primio: {zahtev.Operacija} at {DateTime.Now.TimeOfDay.ToString()}");
                    Odgovor odgovor = GenerisiOdgovor(zahtev);
                    if(odgovor == null) continue;
                    Debug.WriteLine($">>> Server poslao: {odgovor.Poruka} at {DateTime.Now.TimeOfDay.ToString()}");
                    formatter.Serialize(stream, odgovor);
                }
            }
            catch (IOException)
            {
                Debug.WriteLine(">>> Klijent diskonektovan.");
                Kontroler.Instance.korisnici.Remove(this);
                Kontroler.Instance.OnPrijavljen();
            }
            catch (SerializationException)
            {
                Debug.WriteLine(">>> Klijent diskonektovan.");
                Kontroler.Instance.korisnici.Remove(this);
                Kontroler.Instance.OnPrijavljen();
            }

        }

        private Odgovor GenerisiOdgovor(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            try
            {
                switch (zahtev.Operacija)
                {
                    case Operacija.Login:
                        Korisnik = (Korisnik) new LoginSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        odgovor.Poruka = "Korisnik uspesno ulogovan.";
                        odgovor.Objekat = Korisnik;
                        Kontroler.Instance.OnPrijavljen();
                        break;
                    case Operacija.Logout:
                        Korisnik = new Korisnik() { KorisnickoIme = "Gost" };
                        odgovor.Poruka = "Korisnik uspesno izlogovan.";
                        Kontroler.Instance.OnPrijavljen();
                        break;
                    case Operacija.VratiPolaznike:
                        odgovor.Objekat = (List<Polaznik>)new VratiPolaznikeSO(Korisnik).IzvrsiSO(new Polaznik());
                        odgovor.Poruka = "Lista Polaznika";
                        break;
                    case Operacija.NadjiPolaznike:
                        odgovor.Objekat = (List<Polaznik>)new NadjiPolaznikeSO(Korisnik).IzvrsiSO(zahtev.KriterijumPretrage);
                        odgovor.Poruka = "Lista Polaznika";
                        break;
                    case Operacija.AzurirajPolaznika:
                        odgovor.Poruka = (string)new AzurirajPolaznikaSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        break;
                    case Operacija.ObrisiPolaznika:
                        odgovor.Poruka = (string)new ObrisiPolaznikaSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        break;
                    case Operacija.VratiKurseve:
                        odgovor.Objekat = (List<Kurs>) new VratiKurseveSO(Korisnik).IzvrsiSO(new Kurs());
                        odgovor.Poruka = "Lista Kurseva";
                        break;
                    case Operacija.KreirajKurs:
                        odgovor.Poruka = (string)new KreirajKursSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        break;
                    case Operacija.NadjiKurseve:
                        odgovor.Objekat = (List<Kurs>)new NadjiKurseveSO(Korisnik).IzvrsiSO(zahtev.KriterijumPretrage);
                        odgovor.Poruka = "Lista Kurseva";
                        break;
                    case Operacija.AzurirajKurs:
                        odgovor.Poruka = (string)new AzurirajKursSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        break;
                    case Operacija.ObrisiKurs:
                        odgovor.Poruka = (string)new ObrisiKursSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        break;
                     case Operacija.VratiTermine:
                        odgovor.Objekat = (List<Termin>)new VratiTermineSO(Korisnik).IzvrsiSO(new Termin());
                        odgovor.Poruka = "Lista Termina";
                        break;
                     case Operacija.NadjiTermine:
                        odgovor.Objekat = (List<Termin>)new NadjiTermineSO(Korisnik).IzvrsiSO(zahtev.KriterijumPretrage);
                        odgovor.Poruka = "Lista Termina";
                        break;
                     case Operacija.AzurirajTermin:
                        odgovor.Objekat = new AzurirajTerminSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        odgovor.Poruka = "Termin azuriran";
                        break;
                     case Operacija.KreirajNalogPolaznika:
                        odgovor.Poruka = (string) new KreirajNalogPolaznikaSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        odgovor.Objekat = zahtev.Objekat;
                        break;
                     case Operacija.OdaberiKurseve:
                        odgovor.Poruka = (string)new OdaberiKurseveSO(Korisnik).IzvrsiSO(zahtev.Objekat);
                        break;
                     case Operacija.VratiPracenjaKurseva:
                        odgovor.Objekat = (List<Pracenje>)new VratiPracenjaKursevaSO(Korisnik).IzvrsiSO(new Pracenje());
                        odgovor.Poruka = "Lista pracenja";
                        break;
                     case Operacija.NadjiPracenjaKurseva:
                        odgovor.Objekat = (List<Pracenje>)new NadjiPracenjaKursevaSO(Korisnik).IzvrsiSO(zahtev.KriterijumPretrage);
                        odgovor.Poruka = "Lista pracenja";
                        break;
                }
                odgovor.Operacija = zahtev.Operacija;
                odgovor.Signal = Signal.Ok;
                return odgovor;
            }
            catch (SOException e)
            {
                odgovor.Signal = Signal.Error;
                odgovor.Poruka = e.Message;
                return odgovor;
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>>S:O: " + e.Message);
                throw;
            }
        }

        internal void Zaustavi()
        {
            klijentskiSoket.Shutdown(SocketShutdown.Both);
            klijentskiSoket.Close();
        }
        
    }
}
