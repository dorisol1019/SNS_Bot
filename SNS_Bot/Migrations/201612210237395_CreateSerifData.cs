namespace tweetBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSerifData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SerifDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Text = c.String(nullable: false, maxLength: 140),
                        LastUsedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SerifDatas");
        }
    }
}
