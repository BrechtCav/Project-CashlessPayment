using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.CashlessProject.api.Models
{
    public class CustomerDA
    {
        public static List<Customer> GetCustomers()
        {
            List<Customer> resultaat = new List<Customer>();
            DbDataReader reader = Database.GetData(Database.GetConnection("ConnectionString"), "SELECT * FROM RSCA.dbo.Customer");
            while (reader.Read())
            {
                resultaat.Add(Create(reader));
            }
            reader.Close();
            return resultaat;
        }
        private static Customer Create(IDataRecord record)
        {
            return new Customer()
            {
                ID = Convert.ToInt32(record["ID"]),
                Name = record["CustomerName"].ToString(),
                NationalNumber = record["NationalNumber"].ToString(),
                Address = record["Address"].ToString(),
                Balance = Convert.ToDouble(record["Balance"]),
                Picture = record["Picture"].ToString()
            };
        }
    }
}