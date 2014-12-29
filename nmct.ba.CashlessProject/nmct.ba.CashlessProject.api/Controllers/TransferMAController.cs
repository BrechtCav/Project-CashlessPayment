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
    public class TransferMAController : ApiController
    {
        public int Put(Transfer t)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return CustomerMADA.UpdateAccounts(t, p.Claims);
        }
    }
}
