namespace Diet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goals", "LittleGoals", c => c.String());
            DropColumn("dbo.Goals", "LittleGoals1");
            DropColumn("dbo.Goals", "LittleGoals2");
            DropColumn("dbo.Goals", "LittleGoals3");
            DropColumn("dbo.Goals", "LittleGoals4");
            DropColumn("dbo.Goals", "LittleGoals5");
            DropColumn("dbo.Goals", "LittleGoals6");
            DropColumn("dbo.Goals", "LittleGoals7");
            DropColumn("dbo.Goals", "LittleGoals8");
            DropColumn("dbo.Goals", "LittleGoals9");
            DropColumn("dbo.Goals", "LittleGoals10");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Goals", "LittleGoals10", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals9", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals8", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals7", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals6", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals5", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals4", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals3", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals2", c => c.String());
            AddColumn("dbo.Goals", "LittleGoals1", c => c.String());
            DropColumn("dbo.Goals", "LittleGoals");
        }
    }
}
