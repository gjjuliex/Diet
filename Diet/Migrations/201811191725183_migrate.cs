namespace Diet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageBoards",
                c => new
                    {
                        MessageBoardID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Topic = c.String(),
                        Message = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MessageBoardID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MessageBoards");
        }
    }
}
