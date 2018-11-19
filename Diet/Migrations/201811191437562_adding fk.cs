namespace Diet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingfk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DietPlans", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.DietPlans", "ApplicationUserId");
            AddForeignKey("dbo.DietPlans", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DietPlans", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.DietPlans", new[] { "ApplicationUserId" });
            DropColumn("dbo.DietPlans", "ApplicationUserId");
        }
    }
}
