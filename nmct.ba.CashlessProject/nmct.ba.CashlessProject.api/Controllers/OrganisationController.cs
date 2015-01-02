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
    public class OrganisationController : ApiController
    {
        public HttpResponseMessage Put(Password NewPas)
        {
            HttpResponseMessage response = null;
            Organisation org = new Organisation();
            org = OrganisationDA.CheckCredentials(NewPas.Login, NewPas.OldPassword);
            if(org != null)
            {
                OrganisationDA.ChangePassword(NewPas);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return response;
        }
    }
}
