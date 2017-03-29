namespace CarShop.Contracts
{
    using System.Collections.Generic;

    using CarShop.Models.ViewModels;

    public interface ICatalogService
    {
        IEnumerable<CarViewModel> GetCars();
    }
}
