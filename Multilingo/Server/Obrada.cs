using Library;
using Library.Domen;
using Library.Transfer;
using Server.SistemskeOperacije.KorisnikSO;
using Server.SistemskeOperacije.KursSO;
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
                    if(odgovor == null)
                        continue;
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
                    case Operacija.LOGIN:
                        if (Korisnik.KorisnickoIme != "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        Korisnik = (Korisnik) new LoginSO().IzvrsiSO(zahtev.Objekat);
                        odgovor.Poruka = "Korisnik uspesno ulogovan.";
                        odgovor.Objekat = Korisnik;
                        Kontroler.Instance.OnPrijavljen();
                        break;
                    case Operacija.LOGOUT:
                        Korisnik = new Korisnik() { KorisnickoIme = "Gost" };
                        Kontroler.Instance.OnPrijavljen();
                        break;
                    case Operacija.VRATI_POLAZNIKE:
                        if (Korisnik.KorisnickoIme == "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Polaznik>)new VratiPolaznikeSO().IzvrsiSO(new Polaznik());
                        break;
                    case Operacija.NADJI_POLAZNIKE:
                        break;
                    case Operacija.VRATI_POLAZNIKA:
                        break;
                    case Operacija.AZURIRAJ_POLAZNIKA:
                        break;
                    case Operacija.OBRISI_POLAZNIKA:
                        break;
                    case Operacija.VRATI_KURSEVE:
                        if (Korisnik.KorisnickoIme == "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Kurs>) new VratiKurseveSO().IzvrsiSO(new Kurs());
                        odgovor.Poruka = "Lista Kurseva";
                        break;
                    case Operacija.KREIRAJ_KURS:
                        break;
                    case Operacija.NADJI_KURSEVE:
                        break;
                    case Operacija.VRATI_KURS:
                        break;
                    case Operacija.AZURIRAJ_KURS:
                        break;
                    case Operacija.OBRISI_KURS:
                        break;
                     case Operacija.VRATI_TERMINE:
                        //if (Korisnik.KorisnickoIme == "Gost")
                        //    throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        //odgovor.Objekat = (List<Kurs>)new VratiKurseveSO().IzvrsiSO(new Kurs());
                        break;
                     case Operacija.NADJI_TERMINE:
                        break;
                     case Operacija.VRATI_TERMIN:
                        break;
                     case Operacija.AZURIRAJ_TERMIN:
                        break;
                     case Operacija.KREIRAJ_NALOG_POLAZNIKA:
                        if(Korisnik != null && Korisnik.KorisnickoIme != "Gost")
                            throw new SOException("Nije moguce kreirati nalog u ovom trenutku!");
                        odgovor.Poruka = (string) new KreirajNalogPolaznikaSO().IzvrsiSO(zahtev.Objekat);
                        odgovor.Objekat = zahtev.Objekat;
                        break;
                     case Operacija.ODABERI_KURSEVE:
                        if (Korisnik == null || Korisnik is Administrator)
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        break;
                     case Operacija.VRATI_PRACENJA_KURSEVA:
                        if (Korisnik.KorisnickoIme == "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        //odgovor.Objekat = (List<Kurs>)new VratiKurseveSO().IzvrsiSO(new Kurs());
                        break;
                     case Operacija.NADJI_PRACENJA_KURSEVA:
                        break;
                }
                odgovor.Operacija = zahtev.Operacija;
                odgovor.Signal = Signal.OK;
                return odgovor;
            }
            catch (SOException e)
            {
                odgovor.Signal = Signal.ERROR;
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
