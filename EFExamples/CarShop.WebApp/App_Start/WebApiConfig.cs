namespace CarShop.WebApp.App_Start
{
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;

    using CarShop.WebApp.Filters;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    using Owin;

    public static class WebApiConfig
    {
        public static void Configure(IAppBuilder app)
        {
            //// by this time the old bootstrapper should have been initialized but we'd better not use it here

            var config = new HttpConfiguration();

            // now we can resolve dependencies via Web API's resolver
            //var loggingService = (ILoggingService)config.DependencyResolver.GetService(typeof(ILoggingService));
            //var cacheProvider = (ICacheProviderAsync)config.DependencyResolver.GetService(typeof(ICacheProviderAsync));

            // CORS can be configured by Azure runtime for web apps (API -> CORS blade in the portal)
            //bool azureCorsEnabled = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("WEBSITE_CORS_ALLOWED_ORIGINS"));
            //if (!azureCorsEnabled)
            //{
            //    config.EnableCors(new EnableCorsAttribute("*", "*", "*")); // local dev environment
            //}

            //config.Services.Add(typeof(IExceptionLogger), new WebApiExceptionLogger(loggingService)); // There can be multiple exception loggers (by default, no exception loggers are registered)
            ////config.Services.Replace(typeof(IExceptionHandler), new WebApiExceptionHandler()); // There must be exactly one exception handler

            //config.Filters.Add(new WebApiAuthenticationFilter(loggingService, cacheProvider));
            //config.Filters.Add(new ValidateModelStateFilterAttribute(loggingService));
            config.Filters.Add(new WebApiExceptionFilterAttribute());
            config.Filters.Add(new WebApiResponseFilterAttribute());

            var defaultSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            //defaultSettings.Converters.Add(new StringEnumConverter());
            //JsonConvert.DefaultSettings = () => defaultSettings;

            // we don't support content negotiation, JSON is the only format
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new FormUrlEncodedMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings = defaultSettings;

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            //FilterConfig.RegisterGlobalFilters(config.Filters);

            app.UseWebApi(config);
        }
    }
}