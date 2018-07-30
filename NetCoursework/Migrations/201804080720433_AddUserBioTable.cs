namespace NetCoursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserBioTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biographies",
                c => new
                    {
                        BiographyId = c.Int(nullable: false, identity: true),
                        Subject = c.String(maxLength: 255),
                        SkillOne = c.String(),
                        SkillTwo = c.String(),
                        SkillThree = c.String(),
                    })
                .PrimaryKey(t => t.BiographyId);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Birthdate = c.DateTime(),
                        Gender = c.String(),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Postcode = c.String(),
                        Phonenumber = c.String(nullable: false),
                        BiographyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Biographies", t => t.BiographyId, cascadeDelete: true)
                .Index(t => t.BiographyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisteredUsers", "BiographyId", "dbo.Biographies");
            DropIndex("dbo.RegisteredUsers", new[] { "BiographyId" });
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Biographies");
        }
    }
}
