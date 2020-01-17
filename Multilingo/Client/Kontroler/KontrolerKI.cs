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
            bool rez = Komunikacija.Instance.PoveziSe();
            if (obradaOdgovora == null || !obradaOdgovora.IsAlive)
            {
                obradaOdgovora = new Thread(Obrada);
                obradaOdgovora.IsBackground = true;
                obradaOdgovora.Start(); 
            }
            return rez;
        }

        public bool Login(string user, string pass)
        {
            return Komunikacija.Instance.PosaljiZahtev(new Zahtev()
            {
                Operacija = Operacija.LOGIN,
                Objekat = new Korisnik()
                {
                    KorisnickoIme = user,
                    Lozinka = pass
                }
            });
        }

        public void Registracija(string user, string pass, string ime, string prezime, string email, 
            string broj, int godine, string pol)
        {
            Komunikacija.Instance.PosaljiZahtev(new Zahtev()
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
                    if (o == null) continue;
                    switch (o.Operacija)
                    {
                        case Operacija.LOGIN:
                            if (o.Signal == Signal.ERROR)
                                frmLogin.FailedLogin(o.Poruka);
                            else
                            {
                                frmLogin.SuccessfulLogin((Korisnik)o.Objekat);
                                Sesija.Instance.Korisnik = (Korisnik)o.Objekat;
                            }
                            break;
                        case Operacija.KREIRAJ_NALOG_POLAZNIKA:
                            if (o.Signal == Signal.ERROR)
                                frmRegistracija.FailedReg(o.Poruka);
                            else
                                frmRegistracija.SuccessfulReg(o.Poruka);
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
                kraj = false;
                DisposeForms();
            }
            
        }

        private void DisposeForms()
        {
            if (frmRegistracija != null && frmRegistracija.Created) frmRegistracija.Kill();
            if (frmAdmin != null && frmAdmin.Created) frmAdmin.Kill();
            if (frmPolaznik != null && frmPolaznik.Created) frmPolaznik.Kill();
            if (frmLogin != null && frmLogin.Created) frmLogin.Kill();
        }
    }
}
