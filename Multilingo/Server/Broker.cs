using Library.Domen;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System;

namespace Server
{
    public class Broker
    {
        private static readonly Lazy<Broker> lazy = new Lazy<Broker>(() => new Broker());

        private SqlConnection connection;
        private SqlTransaction transaction;

        private Broker()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Baza"].ToString());
        }

        public static Broker Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        public void PokreniTransakciju()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public List<IDomenskiObjekat> Select(IDomenskiObjekat objekat, string uslov = "")
        {
            using (SqlCommand command = new SqlCommand($"select * from {objekat.Tabela} {objekat.Alias} {objekat.Join} {objekat.Where(uslov)}", connection, transaction))
            {
                Debug.WriteLine(command.CommandText);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows ? objekat.ListaObjekata(reader) : null;
                }
            }
        }

        public int Update(IDomenskiObjekat objekat, string uslov = "")
        {
            using (SqlCommand command = new SqlCommand($"update {objekat.Tabela} set {objekat.UpdateValues} {objekat.Where(uslov)}", connection, transaction))
            {
                Debug.WriteLine(command.CommandText);
                return command.ExecuteNonQuery();
            }
        }

        public object Insert(IDomenskiObjekat objekat)
        {
            using (SqlCommand command = new SqlCommand($"insert into {objekat.Tabela} {objekat.InsertedOutput} values ({objekat.InsertValues})", connection, transaction))
            {
                Debug.WriteLine(command.CommandText);
                return command.ExecuteScalar();
            }
        }

        public int Delete(IDomenskiObjekat objekat, string uslov = "")
        {
            using (SqlCommand command = new SqlCommand($"delete from {objekat.Tabela} {objekat.Where(uslov)}", connection, transaction))
            {
                Debug.WriteLine(command.CommandText);
                return command.ExecuteNonQuery();
            }
        }
    }
}
