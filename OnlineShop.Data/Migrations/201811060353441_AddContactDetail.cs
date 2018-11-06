namespace OnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactDetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContacDetails", "Website", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContacDetails", "Website", c => c.String(maxLength: 250));
        }
    }
}
