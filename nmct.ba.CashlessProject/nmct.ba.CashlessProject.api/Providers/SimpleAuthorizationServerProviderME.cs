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
    public class SimpleAuthorizationServerProviderME : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            Employee o = OrganisationDA.CheckCredentialsME(context.UserName, context.Password);
            if (o == null)
            {
                context.Rejected();
                return Task.FromResult(0);
            }
            var id = new ClaimsIdentity(context.Options.AuthenticationType);
            id.AddClaim(new Claim("dblogin", "Scouts"));
            id.AddClaim(new Claim("organisatie", "Scouts"));
            id.AddClaim(new Claim("dbpassword", "Scouts"));
            id.AddClaim(new Claim("dbname", "Scouts"));
            context.Validated(id);
            return Task.FromResult(0);
        }
    }
}