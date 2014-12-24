using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace nmct.ba.CashlessProject.api.Controllers
{
    public class ProductController : ApiController
    {
        public List<Product> Get()
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return ProductDA.GetProducts(p.Claims);
        }
        public List<Product> Get(int id)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return ProductDA.GetProductsbycat(id,p.Claims);
        }
        public int Post(Product newProduct)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return ProductDA.SaveProduct(newProduct,p.Claims);
        }
        public int Put(Product changeProduct)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return ProductDA.ChangeProduct(changeProduct,p.Claims);
        }
        public int Delete(int id)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return ProductDA.DeleteProduct(id,p.Claims);
        }
    }
}
