namespace CarShop.Tests.Fake
{
    using CarShop.DAL;
    using CarShop.Services.Repositories;

    public class FakeCarBrandsRepository : CarBrandsRepository
    {
        private static readonly FakeDbContext Context = new FakeDbContext();

        protected override CarShopContext GetContext()
        {
            return Context;
        }
    }
}
