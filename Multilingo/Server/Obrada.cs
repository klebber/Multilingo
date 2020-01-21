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
                    case Operacija.Login:
                        if (Korisnik.KorisnickoIme != "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        Korisnik = (Korisnik) new LoginSO().IzvrsiSO(zahtev.Objekat);
                        odgovor.Poruka = "Korisnik uspesno ulogovan.";
                        odgovor.Objekat = Korisnik;
                        Kontroler.Instance.OnPrijavljen();
                        break;
                    case Operacija.Logout:
                        Korisnik = new Korisnik() { KorisnickoIme = "Gost" };
                        Kontroler.Instance.OnPrijavljen();
                        break;
                    case Operacija.VratiPolaznike:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Polaznik>)new VratiPolaznikeSO().IzvrsiSO(new Polaznik());
                        odgovor.Poruka = "Lista Polaznika";
                        break;
                    case Operacija.NadjiPolaznike:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Polaznik>)new NadjiPolaznikeSO().IzvrsiSO(zahtev.KriterijumPretrage);
                        odgovor.Poruka = "Lista Polaznika";
                        break;
                    case Operacija.AzurirajPolaznika:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Poruka = (string)new AzurirajPolaznikaSO().IzvrsiSO(zahtev.Objekat);
                        break;
                    case Operacija.ObrisiPolaznika:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Poruka = (string)new ObrisiPolaznikaSO().IzvrsiSO(zahtev.Objekat);
                        break;
                    case Operacija.VratiKurseve:
                        if (Korisnik.KorisnickoIme == "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Kurs>) new VratiKurseveSO().IzvrsiSO(new Kurs());
                        odgovor.Poruka = "Lista Kurseva";
                        break;
                    case Operacija.KreirajKurs:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Poruka = (string)new KreirajKursSO().IzvrsiSO(zahtev.Objekat);
                        break;
                    case Operacija.NadjiKurseve:
                        if (Korisnik.KorisnickoIme == "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Kurs>)new NadjiKurseveSO().IzvrsiSO(zahtev.KriterijumPretrage);
                        odgovor.Poruka = "Lista Kurseva";
                        break;
                    case Operacija.AzurirajKurs:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Poruka = (string)new AzurirajKursSO().IzvrsiSO(zahtev.Objekat);
                        break;
                    case Operacija.ObrisiKurs:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Poruka = (string)new ObrisiKursSO().IzvrsiSO(zahtev.Objekat);
                        break;
                     case Operacija.VratiTermine:
                        if (Korisnik.KorisnickoIme == "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Termin>)new VratiTermineSO().IzvrsiSO(new Termin());
                        odgovor.Poruka = "Lista Termina";
                        break;
                     case Operacija.NadjiTermine:
                        if (Korisnik.KorisnickoIme == "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Termin>)new NadjiTermineSO().IzvrsiSO(zahtev.KriterijumPretrage);
                        odgovor.Poruka = "Lista Termina";
                        break;
                     case Operacija.AzurirajTermin:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = new AzurirajTerminSO().IzvrsiSO(zahtev.Objekat);
                        odgovor.Poruka = "Termin azuriran";
                        break;
                     case Operacija.KreirajNalogPolaznika:
                        if(Korisnik != null && Korisnik.KorisnickoIme != "Gost")
                            throw new SOException("Nije moguce kreirati nalog u ovom trenutku!");
                        odgovor.Poruka = (string) new KreirajNalogPolaznikaSO().IzvrsiSO(zahtev.Objekat);
                        odgovor.Objekat = zahtev.Objekat;
                        break;
                     case Operacija.OdaberiKurseve:
                        break;
                     case Operacija.VratiPracenjaKurseva:
                        if (!(Korisnik is Administrator))
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Pracenje>)new VratiPracenjaKursevaSO().IzvrsiSO(new Pracenje());
                        odgovor.Poruka = "Lista pracenja";
                        break;
                     case Operacija.NadjiPracenjaKurseva:
                        if (Korisnik.KorisnickoIme == "Gost")
                            throw new SOException("Ne mozete izvrsiti ovu operaciju!");
                        odgovor.Objekat = (List<Pracenje>)new NadjiPracenjaKursevaSO().IzvrsiSO(zahtev.KriterijumPretrage);
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
