using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domen
{
    [Serializable]
    public class Korisnik : IDomenskiObjekat
    {
        public int IDKorisnika { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }

        public virtual string Tabela => "Korisnik";
        public virtual string Alias => "korisnik";
        public virtual string InsertValues => $"'{KorisnickoIme}', '{Lozinka}', '{Ime}', '{Prezime}', '{Email}'";
        public virtual string UpdateValues => throw new NotImplementedException();
        public virtual string Join => "left join Administrator administrator on (korisnik.IDKorisnika=administrator.IDKorisnika)";
        public virtual string InsertedOutput => "output inserted.IDKorisnika";

        public virtual List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            reader.Read();
            Korisnik korisnik;
            if (!DBNull.Value.Equals(reader["PozicijaZaposlenog"]))
                korisnik = new Administrator();
            else
                korisnik = new Polaznik();
            korisnik.IDKorisnika = reader.GetInt32(0);
            korisnik.KorisnickoIme = reader.GetString(1);
            korisnik.Lozinka = reader.GetString(2);
            korisnik.Ime = reader.GetString(3);
            korisnik.Prezime = reader.GetString(4);
            korisnik.Email = reader.GetString(5);
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>()
            {
                korisnik
            };
            return lista;
        }

        public virtual string Where(string criteria)
        {
            if (KorisnickoIme != null && KorisnickoIme != string.Empty) return $"where KorisnickoIme = '{KorisnickoIme}'";
            return criteria == string.Empty ? "" :
                (int.TryParse(criteria, out int _) ? $"where IDKorisnika = {criteria}" :
                $"where upper(KorisnickoIme) like upper('{criteria}%')");
        }
    }
}
