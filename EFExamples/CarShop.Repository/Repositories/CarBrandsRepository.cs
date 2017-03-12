namespace CarShop.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using CarShop.Contracts;
    using CarShop.DAL;
    using CarShop.Models;

    public class CarBrandsRepository : ICarBrandsRepository
    {
        public void Add(CarBrands carBrand)
        {
            using (var db = this.GetContext())
            {
                db.CarBrands.Add(carBrand);
                db.SaveChanges();
            }
        }

        public IEnumerable<CarBrands> Find(
            Expression<Func<CarBrands, bool>> predicate, 
            Expression<Func<CarBrands, object>> includedProperties = null)
        {
            using (var db = this.GetContext())
            {
                if (includedProperties != null)
                {
                    return db.CarBrands.Include(includedProperties).Where(predicate).ToArray();
                }

                return db.CarBrands.Where(predicate).ToArray();
            }
        }

        public CarBrands Get(Guid id)
        {
            using (var db = this.GetContext())
            {
                return db.CarBrands.FirstOrDefault(c => c.Id == id);
            }
        }

        public void Remove(Guid id)
        {
            var carBrand = this.Find(x => x.Id == id).FirstOrDefault();

            using (var db = this.GetContext())
            {
                // db.CarBrands.Remove(carBrand); - 
                // We can't use remove as we retrieved entity in other db context that is already closed
                // Rather we can attach entry to a current dbContext and mark it as deleted
                db.Entry(carBrand).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(CarBrands carBrand)
        {
            using (var context = new CarShopContext())
            {
                var entity = context.CarBrands.Find(carBrand.Id);
                context.Entry(entity).CurrentValues.SetValues(carBrand);
                context.SaveChanges();
            }
        }

        protected virtual CarShopContext GetContext()
        {
            // Will be replaced later by DI injection
            return new CarShopContext();
        }
    }
}