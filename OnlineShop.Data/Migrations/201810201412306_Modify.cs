namespace OnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Alias", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Products", "Alisas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Alisas", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Products", "Alias");
        }
    }
}
