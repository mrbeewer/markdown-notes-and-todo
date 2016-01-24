namespace MarkdownManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToDoLists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoes", "ApplicationUserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoes", "ApplicationUserID");
        }
    }
}
