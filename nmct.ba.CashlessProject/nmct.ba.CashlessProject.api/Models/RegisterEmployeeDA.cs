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
    public class RegisterEmployeeDA
    {
        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpassword").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"BRECHT", dbname, dblogin, dbpass);
        }
        public static List<Register_Employee> GetRegisterEmployees(int id,IEnumerable<Claim> claims)
        {
            List<Register_Employee> resultaat = new List<Register_Employee>();
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), "SELECT * FROM Register_Employee where RegisterID =" + id);
            while (reader.Read())
            {
                resultaat.Add(Create(reader, claims));
            }
            reader.Close();
            return resultaat;
        }
        private static Register_Employee Create(IDataRecord record, IEnumerable<Claim> claims)
        {
            return new Register_Employee()
            {
                RegisterID = RegisterDA.GetRegister(Convert.ToInt32(record["RegisterID"]), claims),
                EmployeeID = EmployeeDA.GetEmployee(Convert.ToInt32(record["EmployeeID"]), claims ),
                From = Convert.ToDateTime(record["FromTime"]),
                Until = Convert.ToDateTime(record["UntilTime"]),
            };
        }
        public static int SaveLogin(Register_Employee newLogin, IEnumerable<Claim> claims)
        {
            string sql = "INSERT INTO Register_Employee VALUES(@RegisterID,@EmployeeID,@FromTime,@UntilTime)";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@RegisterID", newLogin.RegisterID.RegisterID);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@EmployeeID", newLogin.EmployeeID.ID);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@FromTime", newLogin.From);
            DbParameter par4 = Database.AddParameter("ConnectionString", "@UntilTime", newLogin.Until);
            int id = Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4);
            return id;

        }
    }
}