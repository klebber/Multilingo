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
        public override string InsertValues => $"{IDKorisnika}, '{BrojTelefona}', {Godine}, '{Pol}'";
        public override string UpdateValues => $"IDKorisnika = '{IDKorisnika}', BrojTelefona = '{BrojTelefona}', Godine = {Godine}, Pol = '{Pol}'";
        public override string Join => "join Korisnik korisnik on (korisnik.IDKorisnika=polaznik.IDKorisnika)";
        public override string InsertedOutput => base.InsertedOutput;

        public override List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while(reader.Read())
            {
                lista.Add(new Polaznik()
                {
                    BrojTelefona = reader.GetString(1),
                    Godine = reader.GetInt32(2),
                    Pol = reader.GetString(3),
                    IDKorisnika = reader.GetInt32(4),
                    KorisnickoIme = reader.GetString(5),
                    Lozinka = reader.GetString(6),
                    Ime = reader.GetString(7),
                    Prezime = reader.GetString(8),
                    Email = reader.GetString(9)
                });
            }
            return lista;
        }
        public override string Where(string criteria)
        {
            return criteria != string.Empty ? $"where KorisnickoIme = '{KorisnickoIme}'" : "";
        }
    }
}
