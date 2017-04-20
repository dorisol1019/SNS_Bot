namespace tweetBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSerifType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SerifDatas", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SerifDatas", "Type");
        }
    }
}
