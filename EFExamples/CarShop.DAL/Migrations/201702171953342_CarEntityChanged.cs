namespace EFExamples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarEntityChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarBrands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Brand = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Brand = c.Guid(nullable: false),
                        Model = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.Brand)
                .Index(t => t.Brand);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarBrandModel = c.Guid(nullable: false),
                        Year = c.DateTime(nullable: false, storeType: "date"),
                        ModelSecondName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModels", t => t.CarBrandModel)
                .Index(t => t.CarBrandModel);
            
            CreateTable(
                "dbo.CarPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 30, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .Index(t => t.CarId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Symbol = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarModels", "Brand", "dbo.CarBrands");
            DropForeignKey("dbo.Cars", "CarBrandModel", "dbo.CarModels");
            DropForeignKey("dbo.CarPrices", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CarPrices", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.CarPrices", new[] { "CurrencyId" });
            DropIndex("dbo.CarPrices", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "CarBrandModel" });
            DropIndex("dbo.CarModels", new[] { "Brand" });
            DropTable("dbo.Currencies");
            DropTable("dbo.CarPrices");
            DropTable("dbo.Cars");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarBrands");
        }
    }
}
