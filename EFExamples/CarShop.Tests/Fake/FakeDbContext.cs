namespace CarShop.Tests.Fake
{
    using System.Data.Entity;

    using CarShop.DAL;
    using CarShop.Models;

    public class FakeDbContext : CarShopContext
    {
        public override DbSet<CarBrands> CarBrands
        {
            get
            {
                return new FakeDbSet<CarBrands>();
            }
        }

        public override int SaveChanges()
        {
            return 1;
        }
    }
}