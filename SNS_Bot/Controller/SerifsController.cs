using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tweetBot.Models;

namespace tweetBot.Controllers
{
    public class SerifsController
    {
        Context.SerifDataContext db = new Context.SerifDataContext();

        public IQueryable<SerifData> GetSerifs()
        {
            return db.Serifs;
        }

        public void SetUsedTime(int id)
        {
            var serif = db.Serifs.Find(id);
            serif.LastUsedTime = DateTime.Now;
            db.Entry(serif).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }


        public IQueryable<SendReplyUsers> GetSendReplyUsers()
        {
            return db.SendReplyUsers;
        }

        public void SetSendReplyUser(long TweetId, long UserId, int SerifDataId)
        {
            var sendReplyUserData = new SendReplyUsers()
            {
                FromTweetId=TweetId,
                SendUserid=UserId,
                SerifDataId=SerifDataId,
                SendReplyDate=DateTime.Now,
                
            };
            db.SendReplyUsers.Add(sendReplyUserData);
            db.SaveChanges();
        }


        public void DeleteExpireSendReplyUser()
        {
            if (!db.SendReplyUsers.Any()) return;
            bool IsEnableTime(SendReplyUsers e)
            {
                DateTime t = e.SendReplyDate; 
                return (DateTime.Now - t).TotalDays >= 10;
            };
            var data = db.SendReplyUsers.Where(IsEnableTime).ToArray();
            db.SendReplyUsers.RemoveRange(data);

            db.SaveChanges();
        }

    }
}
