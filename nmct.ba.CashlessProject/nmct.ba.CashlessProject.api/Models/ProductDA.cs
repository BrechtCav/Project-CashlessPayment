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
    public class ProductDA
    {
        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpassword").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"BRECHT", dbname, dblogin, dbpass);
        }
        public static List<Product> GetProducts(IEnumerable<Claim> claims)
        {
            List<Product> resultaat = new List<Product>();
            string sql = "SELECT * FROM Product";
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                resultaat.Add(Create(reader));
            }
            reader.Close();
            return resultaat;
        }
        public static List<Product> GetProductsbycat(int id, IEnumerable<Claim> claims)
        {
            List<Product> resultaat = new List<Product>();
            string sql =  "SELECT * FROM Product WHERE CategorieID = " + id;
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)),sql);
            while (reader.Read())
            {
                resultaat.Add(Create(reader));
            }
            reader.Close();
            return resultaat;
        }
        public static Product GetProduct(int id, IEnumerable<Claim> claims)
        {
            Product resultaat = new Product();
            string sql = "SELECT * FROM Product WHERE ID = " + id;
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                resultaat = Create(reader);
            }
            reader.Close();
            if(resultaat.ProductName == null || resultaat.ProductName == "")
            {
                resultaat.ProductName = "(PRODUCT NIET MEER BESCHIKBAAR)";
            }
            return resultaat;
        }
        public static int SaveProduct(Product newProduct, IEnumerable<Claim> claims)
        {
            string sql = "INSERT INTO Product VALUES(@Name,@Price,@CategorieID)";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@Name", newProduct.ProductName);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Price", newProduct.Price);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@CategorieID", newProduct.Categorie);
            int id = Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3);
            return id;

        }
        public static int ChangeProduct(Product changeProduct, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Product SET ProductName = @Name, Price = @Price, CategorieID = @CategorieID WHERE ID = @ID";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@Name", changeProduct.ProductName);
            DbParameter par2 = Database.AddParameter("ConnectionString", "@Price", changeProduct.Price);
            DbParameter par3 = Database.AddParameter("ConnectionString", "@CategorieID", changeProduct.Categorie);
            DbParameter par4 = Database.AddParameter("ConnectionString", "@ID", changeProduct.ID);
            int id = Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4);
            return id;

        }
        public static int DeleteProduct(int productid, IEnumerable<Claim> claims)
        {
            string sql = "DELETE FROM Product WHERE ID = @ID";
            DbParameter par1 = Database.AddParameter("ConnectionString", "@ID", productid);
            int id = Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par1);
            return id;
        }
        private static Product Create(IDataRecord record)
        {
            return new Product()
            {
                ID = Convert.ToInt32(record["ID"]),
                ProductName = record["ProductName"].ToString(),
                Price = Convert.ToDouble(record["Price"]),
                Categorie = Convert.ToInt32(record["CategorieID"]),
            };
        }
    }
}