namespace CarShop.WebApp.Controllers
{
    using System.Web.Mvc;

    using CarShop.Models.Entities;
    using CarShop.Models.ViewModels;
    using CarShop.WebApp.Infrastructure;

    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Catalog()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Catalog(CarViewModel carViewModel)
        {
            return this.PartialView("CoolBigData");
        }

        [HttpPost]
        public ActionResult Brand(Brand brand)
        {
            return this.View();
        }

        public ActionResult Brand()
        {
            return this.View();
        }

        public ActionResult GoToUrl(string url)
        {
            return this.Redirect(url);
        }

        public ActionResult GoToAction(string someData)
        {
            this.TempData["MyTempData"] = someData;
            return this.RedirectToAction("Second");
        }

        public ActionResult Second()
        {
            return this.RedirectToAction("Third");
        }

        public ActionResult Third()
        {
            var data = (string)this.TempData["MyTempData"];
            return this.Redirect(data);
        }
    }
}