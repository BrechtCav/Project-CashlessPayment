using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Helper;
using System;
using System.Collections.Generic;
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
            DbDataReader reader = Database.GetData(Database.GetConnection("ConnectionString"), "SELECT * FROM Scouts.dbo.Customer");
            while (reader.Read())
            {
                Customer c = new Customer();
                c.ID = Convert.ToInt32(reader["ID"]);
                c.Name = reader["CustomerName"].ToString();
                c.NationalNumber = reader["NationalNumber"].ToString();
                c.Address = reader["Address"].ToString();
                c.Balance = Double.Parse(reader["Balance"].ToString());
                if (!DBNull.Value.Equals(reader["Picture"]))
                    c.Picture = (byte[])reader["Picture"];
                else
                    c.Picture = new byte[0];
                resultaat.Add(c);
            }
            reader.Close();
            return resultaat;
        }
        public static int SaveCustomer(Customer newcustomer)
        {
            string sql = "INSERT INTO Scouts.dbo.Customer VALUES(@CustomerName,@Address,@Balance,@NationalNumber,@Picture)";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@CustomerName", newcustomer.Name);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Address", newcustomer.Address);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@Balance", newcustomer.Balance);
            DbParameter par4 = Database.AddParameter("ConnectionString", "@NationalNumber", newcustomer.NationalNumber);
            DbParameter par5 = Database.AddParameter("ConnectionString", "@Picture", newcustomer.Picture);
            int id = Database.InsertData(Database.GetConnection("ConnectionString"), sql, par1, par2, par3, par4, par5);
            return id;

        }
    }
}