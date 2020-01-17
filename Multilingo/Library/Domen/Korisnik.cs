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
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }

        public virtual string Tabela => "Gost";

        public virtual string InsertValues => throw new NotImplementedException();

        public virtual string UpdateValues => throw new NotImplementedException();

        public virtual string Join => throw new NotImplementedException();

        public virtual List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public virtual string Where(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
