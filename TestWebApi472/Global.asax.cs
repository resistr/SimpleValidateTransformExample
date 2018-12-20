using System.Web;
using System.Web.Http;

namespace TestWebApi472
{
    /// <summary>
    /// The application entry point. <see cref="HttpApplication"/>
    /// Defines the methods, properties, and events that are common to all application
    /// objects in an ASP.NET application. This class is the base class for applications
    /// that are defined by the user in the Global.asax file.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Called at application startup.
        /// </summary>
        protected void Application_Start()
        {
            // Configure the application.
            GlobalConfiguration.Configure(WebApiConfig.Configure);
        }
    }
}
