using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Helper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.CashlessProject.api.Models
{
    public class OrganisationDA
    {
        public static Organisation CheckCredentials(string username, string password)
        {
            string sql = "SELECT * FROM Organisations WHERE Login=@Login AND Password=@Password";
            DbParameter par1 = Database.AddParameter("AdminDB", "@Login", username);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Password", Cryptography.Encrypt(password));
            try
            {
                DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1, par2);
                reader.Read();
                Organisation org =  new Organisation()
                {
                    ID = Int32.Parse(reader["ID"].ToString()),
                    Login = reader["Login"].ToString(),
                    Password = Cryptography.Decrypt(reader["Password"].ToString()),
                    DbName = Cryptography.Decrypt(reader["DbName"].ToString()),
                    DbLogin = Cryptography.Decrypt(reader["DbLogin"].ToString()),
                    DbPassword = Cryptography.Decrypt(reader["DbPassword"].ToString()),
                    OrganisationName = reader["OrganisationName"].ToString(),
                    Address = reader["Address"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString()
                };
                reader.Close();
                return org;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public static Employee CheckCredentialsME(string username, string password)
        {
            string sql = "SELECT * FROM Scouts.dbo.Employee WHERE Login=@Login AND Password=@Password";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@Login", username);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Password", password);
            try
            {
                DbDataReader reader = Database.GetData(Database.GetConnection("ConnectionString"), sql, par1, par2);
                reader.Read();
                Employee emp = new Employee()
                {
                    
                    ID = Int32.Parse(reader["ID"].ToString()),
                    EmployeeName = reader["EmployeeName"].ToString(),
                    Address = reader["Address"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                };
                reader.Close();
                return emp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
    }
}