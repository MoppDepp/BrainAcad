namespace CarShop.DAL
{
    using System.Data.Entity;

    using CarShop.Models;
    using CarShop.Models.Entities;

    public class CarShopContext : DbContext
    {
        public CarShopContext()
        {
            // Turn of lazy loading and proxy classes
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<ModelType> ModelTypes { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Models)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.BrandId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.Model)
                .HasForeignKey(e => e.ModelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ModelType>()
                .HasMany(e => e.Models)
                .WithRequired(e => e.ModelType)
                .HasForeignKey(e => e.ModelTypeId);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Prices)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.CarId);

            modelBuilder.Entity<Price>().Property(e => e.Value).HasPrecision(8, 2);
        }
    }
}