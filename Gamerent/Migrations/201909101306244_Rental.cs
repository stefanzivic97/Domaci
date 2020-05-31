namespace Gamerent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRental = c.DateTime(nullable: false),
                        customer_Id = c.Int(),
                        game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_Id)
                .ForeignKey("dbo.Games", t => t.game_Id)
                .Index(t => t.customer_Id)
                .Index(t => t.game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "game_Id", "dbo.Games");
            DropForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "game_Id" });
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
