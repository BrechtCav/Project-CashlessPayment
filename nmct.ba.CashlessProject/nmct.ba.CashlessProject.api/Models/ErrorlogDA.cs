using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Helper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace nmct.ba.CashlessProject.api.Models
{
    public class ErrorlogDA
    {
        public static int SaveError(Errorlog newError)
        {
            string sql = "INSERT INTO Scouts.dbo.Errorlog VALUES(@RegisterID,@Timestamp,@Message,@Stacktrace)";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@RegisterID", newError.RegisterID.RegisterID);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Timestamp", DateTime.Now);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@Message", newError.Message);
            DbParameter par4 = Database.AddParameter("ConnectionString", "@Stacktrace", newError.Stacktrace);
            int id = Database.InsertData(Database.GetConnection("ConnectionString"), sql, par1, par2, par3, par4);
            return id;
        }
        public static int SaveErrorIT(Errorlog newError)
        {
            string sql = "INSERT INTO Errorlog VALUES(@RegisterID,@Timestamp,@Message,@Stacktrace,@OrganisationID)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@RegisterID", newError.RegisterID.RegisterID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Timestamp", DateTime.Now);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Message", newError.Message);
            DbParameter par4 = Database.AddParameter("AdminDB", "@Stacktrace", newError.Stacktrace);
            DbParameter par5 = Database.AddParameter("AdminDB", "@OrganisationID", 13);
            int id = Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5);
            return id;

        }
    }
}