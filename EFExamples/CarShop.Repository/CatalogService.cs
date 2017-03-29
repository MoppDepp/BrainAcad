namespace CarShop.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using CarShop.Contracts;
    using CarShop.Models.ViewModels;
    using CarShop.Services.Repositories;

    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork unitOfWork;

        public CatalogService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public IEnumerable<CarViewModel> GetCars()
        {
            return 
                this.unitOfWork.Cars.Find(c => true, c => c.Model.ModelType, c => c.Model.Brand, c => c.Prices)
                    .Select(
                        c =>
                        new CarViewModel
                            {
                                Id = c.Id,
                                Model = c.Model.Name,
                                Brand = c.Model.Brand.Name,
                                ChasisNumber = c.ChasisNumber,
                                Type = c.Model.ModelType.Type,
                                Color = c.Color,
                                Year = c.Model.Year.ToString()
                            });
        }
    }
}
