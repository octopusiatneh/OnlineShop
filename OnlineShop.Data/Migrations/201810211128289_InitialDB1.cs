namespace OnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Alisas", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Products", "Alias");
            DropColumn("dbo.Products", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Tags", c => c.String());
            AddColumn("dbo.Products", "Alias", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Products", "Alisas");
        }
    }
}
