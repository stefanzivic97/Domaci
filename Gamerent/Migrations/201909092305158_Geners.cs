namespace Gamerent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Geners : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Strategy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'ActionRPG')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'FPS')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'MM0')");
        }
        
        public override void Down()
        {
        }
    }
}
