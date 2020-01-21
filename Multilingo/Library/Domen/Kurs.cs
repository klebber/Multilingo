using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domen
{
    [Serializable]
    public class Kurs : IDomenskiObjekat
    {
        public int IDKursa { get; set; }
        public int BrojRaspolozivihMesta { get; set; }
        public string Jezik { get; set; }
        public string Nivo { get; set; }

        public string Tabela => "Kurs";
        public string Alias => "kurs";
        public string InsertValues => $"{BrojRaspolozivihMesta}, '{Jezik}', '{Nivo}'";
        public string UpdateValues => $"BrojRaspolozivihMesta = {BrojRaspolozivihMesta}, Jezik = '{Jezik}', Nivo = '{Nivo}'";
        public string Join => "left join Pracenje pracenje on pracenje.IDKursa=kurs.IDKursa";
        public string InsertedOutput => "output inserted.IDKursa";

        public List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Kurs()
                {
                    IDKursa = reader.GetInt32(0),
                    BrojRaspolozivihMesta = reader.GetInt32(1),
                    Jezik = reader.GetString(2),
                    Nivo = reader.GetString(3)
                });
            }
            return lista;
        }

        public string Where(string criteria)
        {
            return criteria == string.Empty ? "" : 
                (BrojRaspolozivihMesta == -1 ? $"where pracenje.IDKorisnika = {criteria}" :
                (int.TryParse(criteria, out int _) ? $"where IDKursa = {criteria}" :
                $"where upper(Jezik) like upper('{criteria}%')"));
        }
    }
}
