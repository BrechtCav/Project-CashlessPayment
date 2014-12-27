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
    public class EmployeeController : ApiController
    {
        public List<Employee> Get()
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return EmployeeDA.GetEmployees(p.Claims);
        }
        public int Post(Employee newEmployee)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return EmployeeDA.SaveEmployee(newEmployee, p.Claims);
        }
        public int Put(Employee changeEmployee)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return EmployeeDA.ChangeEmployee(changeEmployee, p.Claims);
        }
        public int Delete(int id)
        {
            ClaimsPrincipal p = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return EmployeeDA.DeleteEmployee(id, p.Claims);
        }

    }
}
