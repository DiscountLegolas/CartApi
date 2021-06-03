using CartApi.OAuth;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(CartApi.OAuth.OWİN))]
namespace CartApi.OAuth
{
    public class OWİN
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }

        void ConfigureOAuth(IAppBuilder app)
        {
            //Token üretimi için authorization ayarlarını belirliyoruz.
            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"), //Token talebini yapacağımız dizin
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1), //Oluşturulacak tokenı bir gün geçerli olacak şekilde ayarlıyoruz.
                AllowInsecureHttp = true, //Güvensiz http portuna izin veriyoruz.
                Provider = new SimpleAuthorizationServerProvider() //Sağlayıcı sınıfını belirtiyoruz. Birazdan bu sınıfı oluşturacağız.
            };

            //Yukarıda belirlemiş olduğumuz authorization ayarlarında çalışması için server'a ilgili OAuthAuthorizationServerOptions tipindeki nesneyi gönderiyoruz.
            app.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);

            //Authentication Type olarak Bearer Authentication'ı kullanacağımızı belirtiyoruz.
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //Bearer Token, OAuth 2.0 ile gelen standartlaşmış bir token türüdür.
            //Herhangi bir kriptolu veriye ihtiyaç duyulmaksızın client tarafından token isteğinde bulunulur ve server belirli bir zamana sahip access_token üretir.
            //Bearer Token SSL güvenliğine dayanır.
        }
    }
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili ValidateClientAuthentication metotunu override ediyoruz.
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Domainler arası etkileşim ve kaynak paylaşımını sağlayan ve bir domainin bir başka domainin kaynağını kullanmasını sağlayan CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            Data.CartContext cartcontext = new Data.CartContext();
            //Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
            if (cartcontext.Users.Any(x=>x.Username==context.UserName&&x.Password==context.Password))
            {
                ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);

                context.Validated(identity);
            }
            else
            {
                context.SetError("hata", "Kullanıcı adı veya şifre hatalı.");
            }
        }
    }

}
