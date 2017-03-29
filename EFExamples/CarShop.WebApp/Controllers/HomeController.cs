namespace CarShop.WebApp.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Luxury Car Shop";
            return this.View();
        }
    }
}