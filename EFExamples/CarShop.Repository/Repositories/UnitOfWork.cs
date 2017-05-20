namespace CarShop.Services.Repositories
{
    using System;
    using System.Data.Entity;

    using CarShop.Contracts;
    using CarShop.DAL;
    using CarShop.Models;
    using CarShop.Models.Entities;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        private IGenericRepository<Brand> brandsRepository;
        private IGenericRepository<Model> modelsRepository;
        private IGenericRepository<ModelType> modelTypesRepository;
        private IGenericRepository<Car> carsRepository;
        private IGenericRepository<Currency> currrenciesRepository;
        private IGenericRepository<Price> pricesRepository;

        public UnitOfWork()
        {
            
        }

        public UnitOfWork(IGenericRepository<Brand> brand)
        {
            this.brandsRepository = brand;
            this.context = new CarShopContext();
        }

        public IGenericRepository<Brand> Brands => this.brandsRepository; //?? (this.brandsRepository = new GenericRepository<Brand>(this.context));
        public IGenericRepository<Model> Models => this.modelsRepository ?? (this.modelsRepository = new GenericRepository<Model>(this.context));
        public IGenericRepository<ModelType> ModelTypes => this.modelTypesRepository ?? (this.modelTypesRepository = new GenericRepository<ModelType>(this.context));
        public IGenericRepository<Car> Cars => this.carsRepository ?? (this.carsRepository = new GenericRepository<Car>(this.context));
        public IGenericRepository<Currency> Currencies => this.currrenciesRepository ?? (this.currrenciesRepository = new GenericRepository<Currency>(this.context));
        public IGenericRepository<Price> Prices => this.pricesRepository ?? (this.pricesRepository = new GenericRepository<Price>(this.context));


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
