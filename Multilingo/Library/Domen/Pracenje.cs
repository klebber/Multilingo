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
        public string Tabela => throw new NotImplementedException();
        public string Alias => throw new NotImplementedException();
        public string InsertValues => throw new NotImplementedException();
        public string UpdateValues => throw new NotImplementedException();
        public string Join => throw new NotImplementedException();
        public string InsertedOutput => throw new NotImplementedException();

        public List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public string Where(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
