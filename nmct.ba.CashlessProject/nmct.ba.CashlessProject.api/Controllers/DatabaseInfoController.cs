using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace nmct.ba.CashlessProject.api.Controllers
{
    public class DatabaseInfoController : ApiController
    {
        public string Get()
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            string org = p.Claims.FirstOrDefault(c => c.Type == "organisatie").Value;
            return org;
        }
    }
}
