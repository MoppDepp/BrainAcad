namespace CarShop.DAL
{
    using System.Data.Entity;

    using CarShop.Models;

    public class CarShopContext : DbContext
    {
        public CarShopContext()
        {
            // Turn of lazy loading and proxy classes
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<CarBrands> CarBrands { get; set; }

        public virtual DbSet<CarModels> CarModels { get; set; }

        public virtual DbSet<CarPrices> CarPrices { get; set; }

        public virtual DbSet<Cars> Cars { get; set; }

        public virtual DbSet<Currencies> Currencies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrands>()
                .HasMany(e => e.CarModels)
                .WithRequired(e => e.CarBrands)
                .HasForeignKey(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarModels>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.CarModels)
                .HasForeignKey(e => e.CarBrandModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarPrices>().Property(e => e.Price).HasPrecision(30, 2);

            modelBuilder.Entity<Cars>()
                .HasMany(e => e.CarPrices)
                .WithRequired(e => e.Cars)
                .HasForeignKey(e => e.CarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currencies>()
                .HasMany(e => e.CarPrices)
                .WithRequired(e => e.Currencies)
                .HasForeignKey(e => e.CurrencyId)
                .WillCascadeOnDelete(false);
        }
    }
}