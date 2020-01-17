using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domen
{
    [Serializable]
    public class Administrator : Korisnik
    {
        public string PozicijaZaposlenog { get; set; }
        public string StepenStrucneSpreme { get; set; }

        public override string Tabela => "Administrator";
        public override string InsertValues => $"'{KorisnickoIme}', '{Lozinka}', '{Ime}', '{Prezime}', '{Email}', '{PozicijaZaposlenog}', '{StepenStrucneSpreme}'";
        public override string UpdateValues => $"KorisnickoIme = '{KorisnickoIme}', Lozinka = '{Lozinka}', Ime = '{Ime}', Prezime = '{Prezime}'," +
            $" Email = '{Email}', PozicijaZaposlenog = '{PozicijaZaposlenog}', StepenStrucneSpreme = '{StepenStrucneSpreme}'";
        public override string Join => "";

        public override List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            reader.Read();
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>()
            {
                new Administrator()
                {
                    ID = reader.GetInt32(0),
                    KorisnickoIme = reader.GetString(1),
                    Lozinka = reader.GetString(2),
                    Ime = reader.GetString(3),
                    Prezime = reader.GetString(4),
                    Email = reader.GetString(5),
                    PozicijaZaposlenog = reader.GetString(6),
                    StepenStrucneSpreme = reader.GetString(7)
                }
            };
            return lista;
        }
        public override string Where(string criteria)
        {
            return $"where KorisnickoIme = '{KorisnickoIme}'";
        }
    }
}
