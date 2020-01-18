using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.Domen
{
    [Serializable]
    public class Administrator : Korisnik
    {
        public string PozicijaZaposlenog { get; set; }
        public string StepenStrucneSpreme { get; set; }

        public override string Tabela => "Administrator";
        public override string Alias => "administrator";
        public override string InsertValues => $"{IDKorisnika}, '{PozicijaZaposlenog}', '{StepenStrucneSpreme}'";
        public override string UpdateValues => $"IDKorisnika = '{IDKorisnika}', PozicijaZaposlenog = '{PozicijaZaposlenog}', StepenStrucneSpreme = '{StepenStrucneSpreme}'";
        public override string Join => "";
        public override string InsertedOutput => base.InsertedOutput;

        public override List<IDomenskiObjekat> ListaObjekata(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
        public override string Where(string criteria)
        {
            return $"where KorisnickoIme = '{KorisnickoIme}'";
        }
    }
}
