namespace OnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFeedback : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "Name", c => c.String(maxLength: 250));
            AlterColumn("dbo.Feedbacks", "Email", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Feedbacks", "Message", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedbacks", "Message", c => c.String(maxLength: 500));
            AlterColumn("dbo.Feedbacks", "Email", c => c.String(maxLength: 250));
            AlterColumn("dbo.Feedbacks", "Name", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
