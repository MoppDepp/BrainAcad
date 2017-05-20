namespace CarShop.WebApp.Filters
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;

    public class WebApiResponseFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateResponse(
                HttpStatusCode.OK,
                new { Data = new[] { "Hello world", "Hello world 1", "Hello world 1" } });
        }
    }
}