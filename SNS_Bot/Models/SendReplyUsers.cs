using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweetBot.Models
{
    public class SendReplyUsers
    {
        [Key]
        public int Id { get; set; }

        public long SendUserid { get; set; }

        public int SerifDataId { get; set; }

        //どんなツイート宛に送ったか
        public long FromTweetId{ get; set; }

        public DateTime SendReplyDate { get; set; }
        
    }
}
