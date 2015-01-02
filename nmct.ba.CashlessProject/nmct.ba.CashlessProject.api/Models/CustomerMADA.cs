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
        private static ConnectionStringSettings CreateConnectionStringME(IEnumerable<Claim> claims)
        {
            string dblogin = "Scouts";
            string dbpass = "Scouts";
            string dbname = "Scouts";

            return Database.CreateConnectionString("System.Data.SqlClient", @"BRECHT", dbname, dblogin, dbpass);
        }
        public static List<Customer> GetCustomersME(IEnumerable<Claim> claims)
        {
            List<Customer> resultaat = new List<Customer>();
            string sql = "SELECT * FROM Customer";
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionStringME(claims)), sql);
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
        public static int ChangeCustomer(Customer changecustomer, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Customer SET CustomerName = @Name, Address = @Address, Picture = @Picture WHERE ID = @ID";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@Name", changecustomer.Name);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Address", changecustomer.Address);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@Picture", changecustomer.Picture);
            DbParameter par5 = Database.AddParameter("ConnectionString", "@ID", changecustomer.ID);
            int id = Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par5);
            return id;

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
        public static int UpdateAccounts(Transfer t, IEnumerable<Claim> claims)
        {
            int rowsaffected = 0;
            DbTransaction trans = null;

            try
            {
                trans = Database.BeginTransaction(Database.GetConnection(CreateConnectionString(claims)));
                if(t.Teken == 0)
                {
                    string sql = "UPDATE Customer SET Balance=Balance-@Amount WHERE ID=@ID";
                    DbParameter par1 = Database.AddParameter("ConnectionString", "@Amount", t.Amount);
                    DbParameter par2 = Database.AddParameter("ConnectionString", "@ID", t.Cust.ID);
                    rowsaffected += Database.ModifyData(trans, sql, par1, par2);
                }
                else if(t.Teken == 1)
                {
                    string sql2 = "UPDATE Customer SET Balance=Balance+@Amount WHERE ID=@ID";
                    DbParameter par3 = Database.AddParameter("ConnectionString", "@Amount", t.Amount);
                    DbParameter par4 = Database.AddParameter("ConnectionString", "@ID", t.Cust.ID);
                    rowsaffected += Database.ModifyData(trans, sql2, par3, par4);
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
            }
            finally
            {
                if (trans != null)
                    Database.ReleaseConnection(trans.Connection);
            }

            return rowsaffected;
        }
    }
}