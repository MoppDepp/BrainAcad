namespace CarShop.WebApp.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using CarShop.Contracts;
    using CarShop.DAL;
    using CarShop.Models;
    using CarShop.Models.Entities;
    using CarShop.Services;
    using CarShop.Services.Repositories;

    public class CatalogController : Controller
    {
        private readonly ICatalogService catalogService;

        private readonly IUnitOfWork unitOfWork;

        public CatalogController()
        {
            this.catalogService = new CatalogService();
            this.unitOfWork = new UnitOfWork();
            this.unitOfWork.Brands.Get(Guid.NewGuid());
        }

        public ActionResult Index()
        {
            return this.View(this.catalogService.GetCars());
        }
    }
}
