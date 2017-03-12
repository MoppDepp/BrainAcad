namespace EFExamples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "NewField", c => c.String());
            DropColumn("dbo.Cars", "ModelSecondName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "ModelSecondName", c => c.String());
            DropColumn("dbo.Cars", "NewField");
        }
    }
}
