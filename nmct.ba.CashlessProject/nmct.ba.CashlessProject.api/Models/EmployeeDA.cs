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
    public class EmployeeDA
    {
        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpassword").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"BRECHT", dbname, dblogin, dbpass);
        }
        public static int ChangePassword(Password NewPas)
        {
            string sql = "UPDATE Scouts.dbo.Employee SET Password = @Password WHERE Login = @Login";
            string newpas = NewPas.NewPassword;
            DbParameter par1 = Database.AddParameter("ConnectionString", "@Password", Cryptography.Encrypt(newpas));
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Login", NewPas.Login);
            int id = Database.InsertData(Database.GetConnection("ConnectionString"), sql, par1, par2);
            return id;
        }
        public static List<Employee> GetEmployees(IEnumerable<Claim> claims)
        {
            List<Employee> resultaat = new List<Employee>();
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), "SELECT * FROM Employee");
            while (reader.Read())
            {
                resultaat.Add(Create(reader));
            }
            reader.Close();
            return resultaat;
        }
        public static Employee GetEmployee(int id, IEnumerable<Claim> claims)
        {
            Employee resultaat = new Employee();
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), "SELECT * FROM Employee WHERE ID = " + id);
            while (reader.Read())
            {
                resultaat = Create(reader);
            }
            reader.Close();
            return resultaat;
        }
        private static Employee Create(IDataRecord record)
        {
            return new Employee()
            {
                ID = Convert.ToInt32(record["ID"]),
                EmployeeName = record["EmployeeName"].ToString(),
                Address = record["Address"].ToString(),
                Email = record["Email"].ToString(),
                Phone = record["Phone"].ToString(),
                Login = record["Login"].ToString()
            };
        }
        public static int SaveEmployee(Employee newEmployee, IEnumerable<Claim> claims)
        {
            string paswoord = "password";
            string sql = "INSERT INTO Employee VALUES(@EmployeeName,@Address,@Email,@Phone,@Login, @Password)";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@EmployeeName", newEmployee.EmployeeName);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Address", newEmployee.Address);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@Email", newEmployee.Email);
            DbParameter par4 = Database.AddParameter("ConnectionString", "@Phone", newEmployee.Phone);
            DbParameter par5 = Database.AddParameter("ConnectionString", "@Login", newEmployee.Login);
            DbParameter par6 = Database.AddParameter("ConnectionString", "@Password", paswoord);
            int id = Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4, par5, par6);
            return id;

        }
        public static int ChangeEmployee(Employee changeEmployee, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Employee SET EmployeeName = @Name, Address = @Address, Email = @Email, Phone = @Phone, Login = @Login WHERE ID = @ID";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@Name", changeEmployee.EmployeeName);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Address", changeEmployee.Address);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@Email", changeEmployee.Email);
            DbParameter par4 = Database.AddParameter("ConnectionString", "@Phone", changeEmployee.Phone);
            DbParameter par5 = Database.AddParameter("ConnectionString", "@Login", changeEmployee.Login);
            DbParameter par6 = Database.AddParameter("ConnectionString", "@ID", changeEmployee.ID);
            int id = Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4, par5, par6);
            return id;

        }
        public static int DeleteEmployee(int EmployeeId, IEnumerable<Claim> claims)
        {
            string sql = "DELETE FROM Employee WHERE ID = @ID";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@ID", EmployeeId);
            int id = Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par1);
            return id;
        }

    }
}