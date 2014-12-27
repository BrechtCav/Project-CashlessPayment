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
    public class SaleDA
    {
        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpassword").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"BRECHT", dbname, dblogin, dbpass);
        }
        public static List<Sale> GetSales(IEnumerable<Claim> claims)
        {
            List<Sale> resultaat = new List<Sale>();
            string sql = "SELECT * FROM Sale";
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                resultaat.Add(Create(reader, claims));
            }
            reader.Close();
            return resultaat;
        }
        private static Sale Create(IDataRecord record, IEnumerable<Claim> claims)
        {
            return new Sale()
            {
                ID = Convert.ToInt32(record["ID"]),
                Timestamp = Convert.ToDateTime(record["TimeOfSale"]),
                ProductID = ProductDA.GetProduct(Convert.ToInt32(record["ProductID"]), claims),
                CustomerID = CustomerMADA.GetCustomer(Convert.ToInt32(record["CustomerID"]), claims),
                RegisterID = RegisterDA.GetRegister(Convert.ToInt32(record["RegisterID"]), claims),
                Amount = Convert.ToInt32(record["Amount"]),
                Totalprice = Convert.ToDouble(record["TotalPrice"])
            };
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}