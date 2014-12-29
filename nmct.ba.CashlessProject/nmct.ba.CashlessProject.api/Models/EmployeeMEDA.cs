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
    public class EmployeeMEDA
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> resultaat = new List<Employee>();
            DbDataReader reader = Database.GetData(Database.GetConnection("ConnectionString"), "SELECT * FROM Scouts.dbo.Employee");
            while (reader.Read())
            {
                resultaat.Add(Create(reader));
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
                Phone = record["Phone"].ToString()
            };
        }
    }
}