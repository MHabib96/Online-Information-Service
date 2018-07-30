namespace NetCoursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1a587cdd-e353-4413-bd7f-93fba5c5bf8f', N'admin@coursework.com', 0, N'ADaJdxfrnOy2MDjKCGj2QqhdIK3V+28WjhJ/xEJGh9OuHfMhrBVIoNSrqD4PZ70hdA==', N'c975fe14-16cb-43fe-96ad-06d1997b78af', NULL, 0, 0, NULL, 1, 0, N'admin@coursework.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'39ccc9ef-29d7-4543-9b1f-8faf4610aaa1', N'admin@domain.com', 0, N'ADA7cz2HUEsj6dMHn8W7ibnljvGCCMP7LS1zLvDyalrGpYqvM9d1jxEDRWrO6TNocQ==', N'efd068e1-a88d-4186-b498-207b039a6c0c', NULL, 0, 0, NULL, 1, 0, N'admin@domain.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'83b90823-e5a8-4f5d-8e8b-53a0e72cedae', N'Administrator')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1a587cdd-e353-4413-bd7f-93fba5c5bf8f', N'83b90823-e5a8-4f5d-8e8b-53a0e72cedae')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
