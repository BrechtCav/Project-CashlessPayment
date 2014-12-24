using Microsoft.Owin.Security.OAuth;
using nmct.ba.cashlessproject.model;
using nmct.ba.CashlessProject.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace nmct.ba.CashlessProject.api.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
             Organisation o = OrganisationDA.CheckCredentials(context.UserName, context.Password);
            if(o == null)
            {
                context.Rejected();
                return Task.FromResult(0);
            }
            var id = new ClaimsIdentity(context.Options.AuthenticationType);
            id.AddClaim(new Claim("username", context.UserName));
            id.AddClaim(new Claim("dblogin", o.DbLogin));
            id.AddClaim(new Claim("organisatie", o.OrganisationName));
            id.AddClaim(new Claim("dbpassword", o.DbPassword));
            id.AddClaim(new Claim("dbname", o.DbName));
            context.Validated(id);
            return Task.FromResult(0);
        }
    }
}