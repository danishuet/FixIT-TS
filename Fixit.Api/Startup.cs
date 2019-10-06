using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http.Dependencies;
using Fixit.Service.AuthRepository;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Fixit.Api.Authorization;

[assembly: OwinStartup(typeof(Fixit.Api.Startup))]

namespace Fixit.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            UnityConfig.RegisterComponents(config);
            WebApiConfig.Register(config);
            ConfigureOAuth(app, config.DependencyResolver);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IDependencyResolver resolver)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider((IAuthRepository)resolver.GetService(typeof(IAuthRepository)))
            };
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
