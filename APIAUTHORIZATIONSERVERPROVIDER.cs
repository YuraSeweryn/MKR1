using Microsoft.Owin.Security.OAuth;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Test.Context;

public class APIAUTHORIZATIONSERVERPROVIDER : OAuthAuthorizationServerProvider
{
    DatabaseContext db = new DatabaseContext();

    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
        context.Validated();   
    }
    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
        var a = db.Students.ToList();
        if (db.Students.Where(stud => stud.NickName == context.UserName).Any())
        {
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            identity.AddClaim(new Claim("nickName", context.UserName));
            context.Validated(identity);
        }

        else
        {
            context.SetError("Provided username is incorrect");
            return;
        }
    }
}