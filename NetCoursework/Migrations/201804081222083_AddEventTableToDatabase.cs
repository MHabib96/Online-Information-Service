namespace NetCoursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Eventdate = c.DateTime(nullable: false),
                        EventSubject = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
