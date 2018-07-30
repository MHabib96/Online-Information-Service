namespace NetCoursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableDateTimeForEventTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Eventdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Eventdate", c => c.DateTime(nullable: false));
        }
    }
}
