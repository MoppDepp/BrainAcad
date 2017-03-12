namespace CarShop.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using CarShop.Models;

    public interface ICarBrandsRepository
    {
        void Add(CarBrands carBrand);

        IEnumerable<CarBrands> Find(
            Expression<Func<CarBrands, bool>> predicate, 
            Expression<Func<CarBrands, object>> includedProperties = null);

        CarBrands Get(Guid id);

        void Remove(Guid id);

        void Update(CarBrands carBrand);
    }
}