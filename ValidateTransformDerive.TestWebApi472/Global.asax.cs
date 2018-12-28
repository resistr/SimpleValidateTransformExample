using System.Web.Http;

namespace ValidateTransformDerive.TestWebApi472
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
            => GlobalConfiguration.Configure(WebApiConfig.Register);
    }
}
