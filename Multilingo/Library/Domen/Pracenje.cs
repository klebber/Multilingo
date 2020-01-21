using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domen
{
    [Serializable]
    public class Pracenje : IDomenskiObjekat
    {
        public int IDKorisnika { get; set; }
        public int IDKursa { get; set; }
        public DateTime DatumPrijave { get; set; }

        public string Tabela => "Pracenje";
        public string Alias => "pracenje";
        public string InsertValues => $"{IDKorisnika}, {IDKursa}, '{DatumPrijave.ToString("yyyy-MM-dd")}'";
        public string UpdateValues => throw new NotImplementedException();
        public string Join => "";
        public string InsertedOutput => "";

        public List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Pracenje()
                {
                    IDKorisnika = reader.GetInt32(0),
                    IDKursa = reader.GetInt32(1),
                    DatumPrijave = reader.GetDateTime(2)
                });
            }
            return lista;
        }

        public string Where(string criteria)
        {
            return criteria != string.Empty ? $"where {criteria}" : "";
        }
    }
}
