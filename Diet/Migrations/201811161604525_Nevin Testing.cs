namespace Diet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NevinTesting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dieters", "CreateDietId", "dbo.CreateDiets");
            DropForeignKey("dbo.Dieters", "DietPlanId", "dbo.DietPlans");
            DropIndex("dbo.Dieters", new[] { "DietPlanId" });
            DropIndex("dbo.Dieters", new[] { "CreateDietId" });
            DropColumn("dbo.Dieters", "DietPlanId");
            DropColumn("dbo.Dieters", "CreateDietId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dieters", "CreateDietId", c => c.Int(nullable: false));
            AddColumn("dbo.Dieters", "DietPlanId", c => c.Int(nullable: false));
            CreateIndex("dbo.Dieters", "CreateDietId");
            CreateIndex("dbo.Dieters", "DietPlanId");
            AddForeignKey("dbo.Dieters", "DietPlanId", "dbo.DietPlans", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Dieters", "CreateDietId", "dbo.CreateDiets", "ID", cascadeDelete: true);
        }
    }
}
