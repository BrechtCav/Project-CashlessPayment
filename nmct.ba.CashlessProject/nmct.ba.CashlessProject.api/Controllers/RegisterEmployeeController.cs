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
    public class RegisterEmployeeController : ApiController
    {
        public List<Register_Employee> Get(int id)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return RegisterEmployeeDA.GetRegisterEmployees(id,p.Claims);
        }
        public int Post(Register_Employee newLogin)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return RegisterEmployeeDA.SaveLogin(newLogin, p.Claims);
        }
    }
}
