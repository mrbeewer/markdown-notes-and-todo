namespace MarkdownManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ToDoes", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.ToDoes", name: "IX_User_Id", newName: "IX_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ToDoes", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.ToDoes", name: "UserID", newName: "User_Id");
        }
    }
}
