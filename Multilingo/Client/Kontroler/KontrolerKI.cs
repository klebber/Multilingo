using Client.Forme;
using Library.Domen;
using Library.Transfer;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    class KontrolerKI
    {
        private static KontrolerKI _INSTANCE;

        public bool kraj;
        public FrmLogin frmLogin;
        public FrmAdmin frmAdmin;
        public FrmPolaznik frmPolaznik;
        public FrmRegistracija frmRegistracija;
        public Thread obradaOdgovora;

        private KontrolerKI()
        {
        }

        public static KontrolerKI Instance
        {
            get
            {
                if (_INSTANCE == null) _INSTANCE = new KontrolerKI();
                return _INSTANCE;
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
                Operacija = Operacija.LOGIN,
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
                if (o.Signal == Signal.ERROR)
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
                Operacija = Operacija.LOGOUT
            });
            Sesija.Instance.Korisnik = null;
            kraj = false;
        }

        public bool Registracija(string user, string pass, string ime, string prezime, string email, 
            string broj, int godine, string pol, out string poruka)
        {
            if(!Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.KREIRAJ_NALOG_POLAZNIKA,
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
                if (o.Signal == Signal.ERROR)
                    return false;
                else
                    return true;
            }
        }
        
        private void Obrada()
        {
            bool k = false;
            try
            {
                while (!k)
                {
                    Odgovor o = Komunikacija.Instance.PrihvatiOdgovor();
                    switch (o.Operacija)
                    {
                        case Operacija.LOGOUT:
                            k = true;
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
                Sesija.Instance.Korisnik = null;
                kraj = false;
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
