using Framework.Common;
using Library;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TestWebApi
{
    /// <summary>
    /// The startup class used by the web host.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to inject items needed by the startup class.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> for this application.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// The <see cref="IConfiguration"/> for this application.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure services for.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // add a default memory cache based on Microsoft.Extensions.Caching.Memory
            services.AddMemoryCache();

            // add the client specific services (local project)
            services.AddClientSpecificTransformations();

            //     Adds MVC services to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
            services.AddMvc()
                //     Adds the XML Serializer formatters to MVC.
                .AddXmlSerializerFormatters()
                //     Sets the Microsoft.AspNetCore.Mvc.CompatibilityVersion for ASP.NET Core MVC for
                //     the application.
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                //      Configures Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.
                .ConfigureApiBehaviorOptions(options => {
                    //     Gets or sets a value that determines if the filter that returns an Microsoft.AspNetCore.Mvc.BadRequestObjectResult
                    //     when Microsoft.AspNetCore.Mvc.ActionContext.ModelState is invalid is suppressed.
                    //     Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory.
                    options.SuppressModelStateInvalidFilter = true;
                });

            // add swagger to the service collection
            services.AddSwaggerGen(c =>
            {
                //     Define one or more documents to be created by the Swagger generator
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SimpleValidateTransformExample",
                    Description = "A very simple example of using validation to validate and transform data.",
                    TermsOfService = "None"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> for the application.</param>
        /// <param name="env">The <see cref="IHostingEnvironment"/> for the application.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //     Captures synchronous and asynchronous System.Exception instances from the pipeline
                //     and generates HTML error responses.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            /// Run all startup actions for this service provider.
            app.ApplicationServices.RunStartupActions();

            //     Adds middleware for redirecting HTTP Requests to HTTPS.
            app.UseHttpsRedirection();

            //     Adds MVC to the Microsoft.AspNetCore.Builder.IApplicationBuilder request execution
            //     pipeline.
            app.UseMvc();

            // add the swagger to the application
            app.UseSwagger();

            // add the swagger user interface
            app.UseSwaggerUI(c =>
            {
                //     Adds Swagger JSON endpoints. Can be fully-qualified or relative to the UI page
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleValidateTransformExample V1");
            });
        }
    }
}
