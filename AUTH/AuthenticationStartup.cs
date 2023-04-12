using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using MKR1;
using Owin;
using System.Web.Http;
using System;

public class AuthenticationStartup
{
    public void Configuration(IAppBuilder app)
    {
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        var myProvider = new APIAUTHORIZATIONSERVERPROVIDER();
        OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
        {
            AllowInsecureHttp = true,
            TokenEndpointPath = new PathString("/token"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            Provider = myProvider
        };
        app.UseOAuthAuthorizationServer(options);
        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        HttpConfiguration config = new HttpConfiguration();
        WebApiConfig.Register(config);
    }
}