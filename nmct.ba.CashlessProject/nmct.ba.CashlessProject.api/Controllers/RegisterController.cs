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
    public class RegisterController : ApiController
    {
        public List<Register> Get()
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return RegisterDA.GetRegisters(p.Claims);
        }
    }
}
