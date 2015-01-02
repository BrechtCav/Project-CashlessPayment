using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nmct.ba.CashlessProject.api.Controllers
{
    public class EmployeeMEController : ApiController
    {
        public List<Employee> Get()
        {
            return EmployeeMEDA.GetEmployees();
        }
        public HttpResponseMessage Put(Password NewPas)
        {
            HttpResponseMessage response = null;
            Employee emp = new Employee();
            emp = OrganisationDA.CheckCredentialsME(NewPas.Login, NewPas.OldPassword);
            if (emp != null)
            {
                EmployeeDA.ChangePassword(NewPas);
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
