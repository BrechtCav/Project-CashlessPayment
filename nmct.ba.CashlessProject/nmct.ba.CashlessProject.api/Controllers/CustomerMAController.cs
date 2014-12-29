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
    public class CustomerMAController : ApiController
    {
        public List<Customer> Get()
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return CustomerMADA.GetCustomers(p.Claims);
        }
        public int Put(Customer changecustomer)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return CustomerMADA.ChangeCustomer(changecustomer, p.Claims);
        }
    }
}
