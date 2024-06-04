namespace Bekhrad_project.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_model2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        groupid = c.Int(nullable: false, identity: true),
                        groupname = c.String(),
                        creategrouptime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.groupid);
            
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        userid = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 150),
                        family = c.String(nullable: false, maxLength: 150),
                        age = c.Short(nullable: false),
                        email = c.String(nullable: false),
                        groupid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userid)
                .ForeignKey("dbo.GroupUsers", t => t.groupid, cascadeDelete: true)
                .Index(t => t.groupid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInformations", "groupid", "dbo.GroupUsers");
            DropIndex("dbo.UserInformations", new[] { "groupid" });
            DropTable("dbo.UserInformations");
            DropTable("dbo.GroupUsers");
        }
    }
}
