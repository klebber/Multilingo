using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domen
{
    public interface IDomenskiObjekat
    {
        string Tabela { get; }
        string Alias { get; }
        string InsertValues { get; }
        string UpdateValues { get; }
        string Join { get; }
        string InsertedOutput { get; }
        string Where(string criteria);
        List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader);
    }
}
