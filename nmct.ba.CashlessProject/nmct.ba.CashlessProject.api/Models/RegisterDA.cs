using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace nmct.ba.CashlessProject.api.Models
{
    public class RegisterDA
    {
        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpassword").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"BRECHT", dbname, dblogin, dbpass);
        }
        public static List<Register> GetListRegisters()
        {
            List<Register> resultaat = new List<Register>();
            string sql = "SELECT * FROM Scouts.dbo.Register";
            DbDataReader reader = Database.GetData(Database.GetConnection("ConnectionString"), sql);
            while (reader.Read())
            {
                resultaat.Add(Create(reader));
            }
            reader.Close();
            return resultaat;
        }
        public static List<Register> GetRegisters(IEnumerable<Claim> claims)
        {
            List<Register> resultaat = new List<Register>();
            string sql = "SELECT * FROM Register";
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                resultaat.Add(Create(reader));
            }
            reader.Close();
            return resultaat;
        }
        public static Register GetRegister(int id, IEnumerable<Claim> claims)
        {
            Register resultaat = new Register();
            string sql = "SELECT * FROM Register where ID =" + id;
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                resultaat = Create(reader);
            }
            reader.Close();
            return resultaat;
        }
        private static Register Create(IDataRecord record)
        {
            return new Register()
            {
                RegisterID = Convert.ToInt32(record["ID"]),
                RegisterName = record["RegisterName"].ToString(),
                Device = record["Device"].ToString(),
                Location = record["Location"].ToString(),
            };
        }
    }
}