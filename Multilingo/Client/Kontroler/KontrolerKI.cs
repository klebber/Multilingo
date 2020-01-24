using Client.Forme;
using Library.Domen;
using Library.Transfer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    class KontrolerKI
    {
        private static readonly Lazy<KontrolerKI> lazy = new Lazy<KontrolerKI>(() => new KontrolerKI());

        public bool kraj;
        public FrmLogin frmLogin;
        public FrmAdmin frmAdmin;
        public FrmPolaznik frmPolaznik;
        public FrmRegistracija frmRegistracija;
        public Thread obradaOdgovora;

        public List<Kurs> kursevi;
        public delegate void IzmenaKursevaHandler();
        public event IzmenaKursevaHandler IzmenaKurseva;
        public List<Polaznik> polaznici;
        public delegate void IzmenaPolaznikaHandler();
        public event IzmenaPolaznikaHandler IzmenaPolaznika;
        public List<Termin> termini;
        public delegate void IzmenaTerminaHandler();
        public event IzmenaTerminaHandler IzmenaTermina;
        public List<Pracenje> pracenja;
        public delegate void IzmenaPracenjaHandler();
        public event IzmenaPracenjaHandler IzmenaPracenja;

        private KontrolerKI()
        {
        }

        public static KontrolerKI Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void PokreniKlijenta()
        {
            while (!kraj)
            {
                kraj = true;
                frmLogin = new FrmLogin();
                frmLogin.ShowDialog();
            }
        }

        public bool PoveziSe()
        {
            return Komunikacija.Instance.PoveziSe();
        }

        public bool Login(string user, string pass, out string poruka)
        {
            if (!Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.Login,
                Objekat = new Korisnik()
                {
                    KorisnickoIme = user,
                    Lozinka = pass
                }
            }))
            {
                poruka = "Server nije dostupan!";
                return false;
            }
            else
            {
                Odgovor o = Komunikacija.Instance.PrihvatiOdgovor();
                poruka = o.Poruka;
                if (o.Signal == Signal.Error)
                    return false;
                else
                {
                    Sesija.Instance.Korisnik = (Korisnik)o.Objekat;
                    obradaOdgovora = new Thread(Obrada);
                    obradaOdgovora.IsBackground = true;
                    obradaOdgovora.Start();
                    return true;
                }
            }
        }

        public void Logout()
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.Logout
            });
            CleanUp();
        }

        private void CleanUp()
        {
            Sesija.Instance.Korisnik = null;
            kraj = false;
        }

        public bool Registracija(string user, string pass, string ime, string prezime, string email, 
            string broj, int godine, string pol, out string poruka)
        {
            if(!Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.KreirajNalogPolaznika,
                Objekat = new Polaznik()
                {
                    KorisnickoIme = user,
                    Lozinka = pass,
                    Ime = ime,
                    Prezime = prezime,
                    Email = email,
                    BrojTelefona = broj,
                    Godine = godine,
                    Pol = pol
                }
            }))
            {
                poruka = "Server nije dostupan";
                return false;
            }
            else
            {
                Odgovor o = Komunikacija.Instance.PrihvatiOdgovor();
                poruka = o.Poruka;
                if (o.Signal == Signal.Error)
                    return false;
                else
                    return true;
            }
        }


        public void VratiKurseve()
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.VratiKurseve
            });
        }

        public void NadjiKurseve(string kriterijumPretrage)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.NadjiKurseve,
                KriterijumPretrage = kriterijumPretrage
            });
        }

        public void KreirajKurs(List<IDomenskiObjekat> lista)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.KreirajKurs,
                Objekat = lista
            });
        }

        public void AzurirajKurs(Kurs kurs)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.AzurirajKurs,
                Objekat = kurs
            });
        }

        public void OdaberiKurseve(List<Kurs> kursevi)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.OdaberiKurseve,
                Objekat = kursevi
            });
        }

        public void ObrisiKurs(Kurs kurs)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.ObrisiKurs,
                Objekat = kurs
            });
        }

        public void VratiPolaznike()
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.VratiPolaznike
            });
        }

        public void NadjiPolaznike(string kriterijumPretrage)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.NadjiPolaznike,
                KriterijumPretrage = kriterijumPretrage
            });
        }

        public void AzurirajPolaznika(Polaznik polaznik)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.AzurirajPolaznika,
                Objekat = polaznik
            });
        }

        public void ObrisiPolaznika(Polaznik polaznik)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.ObrisiPolaznika,
                Objekat = polaznik
            });
        }

        public void VratiTermine()
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.VratiTermine
            });
        }

        public void NadjiTermine(string kriterijumPretrage)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.NadjiTermine,
                KriterijumPretrage = kriterijumPretrage
            });
        }

        public void AzurirajTermin(Termin termin)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.AzurirajTermin,
                Objekat = termin
            });
        }

        public void VratiPracenja()
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.VratiPracenjaKurseva
            });
        }

        public void NadjiPracenja(IDomenskiObjekat kriterijumPretrage)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.NadjiPracenjaKurseva,
                KriterijumPretrage = kriterijumPretrage
            });
        }

        private void Obrada()
        {
            bool k = false;
            try
            {
                while (!k)
                {
                    Odgovor o = Komunikacija.Instance.PrihvatiOdgovor();
                    if(o.Signal == Signal.Error)
                    {
                        MessageBox.Show(o.Poruka);
                        continue;
                    }
                    switch (o.Operacija)
                    {
                        case Operacija.Logout:
                            k = true;
                            break;
                        case Operacija.VratiKurseve:
                            kursevi = (List<Kurs>)o.Objekat;
                            IzmenaKurseva?.Invoke();
                            break;
                        case Operacija.NadjiKurseve:
                            kursevi = (List<Kurs>)o.Objekat;
                            IzmenaKurseva?.Invoke();
                            break;
                        case Operacija.KreirajKurs:
                            MessageBox.Show(o.Poruka);
                            break;
                        case Operacija.AzurirajKurs:
                            MessageBox.Show(o.Poruka);
                            break;
                        case Operacija.OdaberiKurseve:
                            MessageBox.Show(o.Poruka);
                            break;
                        case Operacija.ObrisiKurs:
                            frmAdmin.UspesnoBrisanjeKursa(o.Poruka);
                            break;
                        case Operacija.VratiPolaznike:
                            polaznici = (List<Polaznik>)o.Objekat;
                            IzmenaPolaznika?.Invoke();
                            break;
                        case Operacija.NadjiPolaznike:
                            polaznici = (List<Polaznik>)o.Objekat;
                            IzmenaPolaznika?.Invoke();
                            break;
                        case Operacija.AzurirajPolaznika:
                            MessageBox.Show(o.Poruka);
                            break;
                        case Operacija.ObrisiPolaznika:
                            frmAdmin.UspesnoBrisanjePolaznika(o.Poruka);
                            break;
                        case Operacija.VratiTermine:
                            termini = (List<Termin>)o.Objekat;
                            IzmenaTermina?.Invoke();
                            break;
                        case Operacija.NadjiTermine:
                            termini = (List<Termin>)o.Objekat;
                            IzmenaTermina?.Invoke();
                            break;
                        case Operacija.AzurirajTermin:
                            frmAdmin.UspesnoAzuriranjeTermina();
                            break;
                        case Operacija.VratiPracenjaKurseva:
                            pracenja = (List<Pracenje>)o.Objekat;
                            IzmenaPracenja?.Invoke();
                            break;
                        case Operacija.NadjiPracenjaKurseva:
                            pracenja = (List<Pracenje>)o.Objekat;
                            IzmenaPracenja?.Invoke();
                            break;
                    }
                }
            }

            catch (ThreadInterruptedException)
            {
                Debug.WriteLine("Obrada odgovora interrupted");
            }
            catch (SerializationException)
            {
                MessageBox.Show("Izgubljena konekcija sa serverom.");
                CleanUp();
                DisposeForms();
            }
            
        }

        private void DisposeForms()
        {
            if (frmRegistracija != null && frmRegistracija.Created) frmRegistracija.Invoke(new Action(() => frmRegistracija.Dispose()));
            if (frmAdmin != null && frmAdmin.Created) frmAdmin.Invoke(new Action(() => frmAdmin.Dispose()));
            if (frmPolaznik != null && frmPolaznik.Created) frmPolaznik.Invoke(new Action(() => frmPolaznik.Dispose()));
            if (frmLogin != null && frmLogin.Created) frmLogin.Invoke(new Action(() => frmLogin.Dispose()));
        }
    }
}
