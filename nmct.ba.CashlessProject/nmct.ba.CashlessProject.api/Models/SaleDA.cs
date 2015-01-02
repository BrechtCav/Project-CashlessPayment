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
            Sale Verkoop = new Sale();
            Verkoop.ID = Convert.ToInt32(record["ID"]);
            Verkoop.Timestamp = Convert.ToDateTime(record["TimeOfSale"]);
            Verkoop.ProductID = ProductDA.GetProduct(Convert.ToInt32(record["ProductID"]), claims);
            Verkoop.CustomerID = CustomerMADA.GetCustomer(Convert.ToInt32(record["CustomerID"]), claims);
            Verkoop.RegisterID = RegisterDA.GetRegister(Convert.ToInt32(record["RegisterID"]), claims);
            Verkoop.Amount = Convert.ToInt32(record["Amount"]);
            Verkoop.Totalprice = Convert.ToDouble(record["TotalPrice"]);
            return Verkoop;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static int SaveSale(Sale newSale, IEnumerable<Claim> claims)
        {
            string sql = "INSERT INTO Sale VALUES(@CustomerID,@RegisterID,@ProductID,@Amount,@TotalPrice,@TimeOfSale)";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@CustomerID", newSale.CustomerID.ID);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@RegisterID", newSale.RegisterID.RegisterID);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@ProductID", newSale.ProductID.ID);
            DbParameter par4 = Database.AddParameter("ConnectionString", "@Amount", newSale.Amount);
            DbParameter par5 = Database.AddParameter("ConnectionString", "@TotalPrice", newSale.Totalprice);
            DbParameter par6 = Database.AddParameter("ConnectionString", "@TimeOfSale", DateTime.Now);
            int id = Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4, par5, par6);
            return id;

        }
    }
}