namespace CarShop.Contracts
{
    using CarShop.Models;
    using CarShop.Models.Entities;

    public interface IUnitOfWork
    {
        IGenericRepository<Brand> Brands { get; }

        IGenericRepository<Model> Models { get; }

        IGenericRepository<ModelType> ModelTypes { get; }

        IGenericRepository<Car> Cars { get; }

        IGenericRepository<Currency> Currencies { get; }

        IGenericRepository<Price> Prices { get; }

        void SaveChanges();
    }
}
