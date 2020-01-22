using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.Domen
{
    [Serializable]
    public class Termin : IDomenskiObjekat
    {
        public int IDKursa { get; set; }
        public int IDTermina { get; set; }
        public string Vreme { get; set; }
        public DateTime Datum { get; set; }
        public int IDPredavaca { get; set; }

        public string Tabela => "Termin";
        public string Alias => "termin";
        public string InsertValues => $"{IDKursa}, '{Vreme}', '{Datum.ToString("yyyy-MM-dd")}', {IDPredavaca}";
        public string UpdateValues => $"Vreme = '{Vreme}'";
        public string Join => "";
        public string InsertedOutput => "";
        public List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Termin()
                {
                    IDKursa = reader.GetInt32(0),
                    IDTermina = reader.GetInt32(1),
                    Vreme = reader.GetString(2),
                    Datum = reader.GetDateTime(3),
                    IDPredavaca = reader.GetInt32(4)
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
