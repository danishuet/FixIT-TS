using Fixit.Service.AuthRepository;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Fixit.Api.Authorization
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IAuthRepository _repo;
        public SimpleAuthorizationServerProvider(IAuthRepository repo)
        {
            _repo = repo;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                IdentityUser user = await _repo.FindUser(context.UserName, context.Password);
                var roles = await _repo.GetRolesAsync(user.Id);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("userId", user.Id));
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}