using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domen
{
    [Serializable]
    public class Polaznik : Korisnik
    {
        public string BrojTelefona { get; set; }
        public int Godine { get; set; }
        public string Pol { get; set; }

        public override string Tabela => "Polaznik";
        public override string Alias => "polaznik";
        public override string InsertValues => $"{ID}, '{BrojTelefona}', {Godine}, '{Pol}'";
        public override string UpdateValues => $"IDKorisnika = '{ID}', BrojTelefona = '{BrojTelefona}', Godine = {Godine}, Pol = '{Pol}'";
        public override string Join => "";
        public override string InsertedOutput => base.InsertedOutput;

        public override List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            //TODO redosled
            reader.Read();
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>()
            {
                new Polaznik()
                {
                    ID = reader.GetInt32(0),
                    KorisnickoIme = reader.GetString(1),
                    Lozinka = reader.GetString(2),
                    Ime = reader.GetString(3),
                    Prezime = reader.GetString(4),
                    Email = reader.GetString(5),
                    BrojTelefona = reader.GetString(6),
                    Godine = reader.GetInt32(7),
                    Pol = reader.GetString(8)
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
