namespace MarkdownManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "ApplicationUserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "ApplicationUserID");
        }
    }
}
