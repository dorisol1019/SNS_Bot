namespace tweetBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSendReplyUsersData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SendReplyUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SendUserid = c.Long(nullable: false),
                        SerifDataId = c.Int(nullable: false),
                        FromTweetId = c.Long(nullable: false),
                        SendReplyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SendReplyUsers");
        }
    }
}
