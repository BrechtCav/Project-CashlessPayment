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
    public class CustomerMADA
    {
        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpassword").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"BRECHT", dbname, dblogin, dbpass);
        }
        public static List<Customer> GetCustomers(IEnumerable<Claim> claims)
        {
            List<Customer> resultaat = new List<Customer>();
            string sql = "SELECT * FROM Customer";
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                resultaat.Add(Create(reader));
            }
            reader.Close();
            return resultaat;
        }
        public static Customer GetCustomer(int id, IEnumerable<Claim> claims)
        {
            Customer resultaat = new Customer();
            string sql = "SELECT * FROM Customer WHERE ID = " + id;
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                resultaat = Create(reader);
            }
            reader.Close();
            return resultaat;
        }
        private static Customer Create(IDataRecord record)
        {
            Customer cust = new  Customer();
            cust.ID = Convert.ToInt32(record["ID"]);
            cust.Name = record["CustomerName"].ToString();
            cust.Address = record["Address"].ToString();
            cust.Balance = Convert.ToSingle(record["Balance"]);
            if (!DBNull.Value.Equals(record["Picture"]))
            {
                cust.Picture = (byte[])record["Picture"];
            }
            else
            {
                cust.Picture = new byte[0];
            }
            return cust;
        }
    }
}