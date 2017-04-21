using bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tweetBot;
using Wether.Widget;

namespace SNS_Bot
{
    public class Satomi : ICharacter
    {
        public string Name => "里美";

        public TwitterAuthSet TwitterAuthSet => new TwitterAuthSet(
            AppSettings.Satomi.Twitter.ConsumerKey,
            AppSettings.Satomi.Twitter.ConsumerSecret,
            AppSettings.Satomi.Twitter.AccessToken,
            AppSettings.Satomi.Twitter.AccessTokenSecret
            );

        public MastodonAuthSet[] MastdonAuthSet => new MastodonAuthSet[0];

        public IEnumerable<string> RelationalTags => new[]{
                        "しぇいむおん",
                        "内藤隆也",
                        "阿部早苗",
                        "阿部里美",
                        "阿部幸子",
                        "木野村典乃",
                        "飯島可奈",
                        "飯島エアール可奈",
                        "栗原美幸",
                        "荒巻大介",
                        "琴乃志津江"
                    };

        public string GetGreetingMessage(string accountName, string userName)
        {
            return $"@{accountName} こんにちは、《しぇいむ☆おん》の阿部里美だよ！\n" +
                $"世間知らずだから色々と迷惑かけちゃうかもしれないけど、よろしくねお兄ちゃん！";
        }

        public string GetUnknownWetherReplyMessage(UnknownType type)
        {
            throw new NotImplementedException();
        }

        public string GetWeathersReplyMessage(string day, string region, string telop)
        {
            throw new NotImplementedException();
        }
    }
}
