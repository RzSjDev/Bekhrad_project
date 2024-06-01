namespace Bekhrad_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migratio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        createGroupTime = c.DateTime(nullable: false),
                        user_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.UserInformations", t => t.user_UserId)
                .Index(t => t.user_UserId);
            
            AlterColumn("dbo.UserInformations", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.UserInformations", "Family", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.UserInformations", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "user_UserId", "dbo.UserInformations");
            DropIndex("dbo.Groups", new[] { "user_UserId" });
            AlterColumn("dbo.UserInformations", "Email", c => c.String());
            AlterColumn("dbo.UserInformations", "Family", c => c.String());
            AlterColumn("dbo.UserInformations", "Name", c => c.String());
            DropTable("dbo.Groups");
        }
    }
}
