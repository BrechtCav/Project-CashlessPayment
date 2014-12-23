﻿using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Helper;
using nmct.ba.demo.apicall.helper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.CashlessProject.api.Models
{
    public class OrganisationDA
    {
        public static Organisation CheckCredentials(string username, string password, string organisation)
        {
            string sql = "SELECT * FROM Organisation WHERE Login=@Login AND Password=@Password";
            DbParameter par1 = Database.AddParameter("AdminDB", "@Login", username);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Password", Cryptography.Encrypt(password));
            try
            {
                DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1, par2);
                reader.Read();
                return new Organisation()
                {
                    ID = Int32.Parse(reader["ID"].ToString()),
                    Login = reader["Login"].ToString(),
                    Password = reader["Password"].ToString(),
                    DbName = reader["DbName"].ToString(),
                    DbLogin = reader["DbLogin"].ToString(),
                    DbPassword = reader["DbPassword"].ToString(),
                    OrganisationName = reader["OrganisationName"].ToString(),
                    Address = reader["Address"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}