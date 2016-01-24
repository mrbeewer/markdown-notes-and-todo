namespace MarkdownManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        Tag = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.MyUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DarkTheme = c.Boolean(nullable: false),
                        CodeCSS = c.String(),
                        FolderJSON = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        ParentFolder = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUserRoles", "MyUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "MyUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "MyUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserRoles", "MyUser_Id");
            CreateIndex("dbo.AspNetUserClaims", "MyUser_Id");
            CreateIndex("dbo.AspNetUserLogins", "MyUser_Id");
            AddForeignKey("dbo.AspNetUserClaims", "MyUser_Id", "dbo.MyUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "MyUser_Id", "dbo.MyUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "MyUser_Id", "dbo.MyUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "User_Id", "dbo.MyUsers");
            DropForeignKey("dbo.AspNetUserRoles", "MyUser_Id", "dbo.MyUsers");
            DropForeignKey("dbo.AspNetUserLogins", "MyUser_Id", "dbo.MyUsers");
            DropForeignKey("dbo.Documents", "User_Id", "dbo.MyUsers");
            DropForeignKey("dbo.AspNetUserClaims", "MyUser_Id", "dbo.MyUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "MyUser_Id" });
            DropIndex("dbo.Documents", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "MyUser_Id" });
            DropIndex("dbo.ToDoes", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "MyUser_Id" });
            DropColumn("dbo.AspNetUserLogins", "MyUser_Id");
            DropColumn("dbo.AspNetUserClaims", "MyUser_Id");
            DropColumn("dbo.AspNetUserRoles", "MyUser_Id");
            DropTable("dbo.Documents");
            DropTable("dbo.MyUsers");
            DropTable("dbo.ToDoes");
        }
    }
}
