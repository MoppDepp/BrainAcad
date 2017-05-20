namespace CarShop.WebApp.Controllers
{
    using System.Threading;
    using System.Web.Mvc;

    public class AjaxController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult LoadText(string data)
        {
            Thread.Sleep(5000);
            return this.PartialView("CoolBigData");
        }
    }
}