namespace Diet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class goals : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Goals");
            AddColumn("dbo.Goals", "GoalId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Goals", "Goal", c => c.String());
            AlterColumn("dbo.Goals", "LittleGoals", c => c.String());
            AddPrimaryKey("dbo.Goals", "GoalId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Goals");
            AlterColumn("dbo.Goals", "LittleGoals", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Goals", "Goal");
            DropColumn("dbo.Goals", "GoalId");
            AddPrimaryKey("dbo.Goals", "LittleGoals");
        }
    }
}
