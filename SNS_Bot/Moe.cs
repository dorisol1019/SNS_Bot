using Mastonet.Entities;
using SNS_Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tweetBot;
using Wether.Widget;

namespace bot
{
    public class Moe : ICharacter
    {
        public string Name { get; }

        public TwitterAuthSet TwitterAuthSet { get; } =
            new TwitterAuthSet(
                AppSettings.Moe.Twitter.ConsumerKey,
                AppSettings.Moe.Twitter.ConsumerSecret,
                AppSettings.Moe.Twitter.AccessToken,
                AppSettings.Moe.Twitter.AccessTokenSecret
            );

        public MastodonAuthSet[] MastdonAuthSet { get; } = new MastodonAuthSet[]{
            new MastodonAuthSet(new AppRegistration
            {
                Id = int.Parse(AppSettings.Moe.Mstdn_jp.AppRegistration.Id),
                ClientId = AppSettings.Moe.Mstdn_jp.AppRegistration.ClientId,
                ClientSecret = AppSettings.Moe.Mstdn_jp.AppRegistration.ClientSecret,
                Instance = AppSettings.Moe.Mstdn_jp.AppRegistration.Instance
            }, AppSettings.Moe.Mstdn_jp.AppRegistration.AccessToken),
            new MastodonAuthSet(new AppRegistration
            {
                Id = int.Parse(AppSettings.Moe.Pawoo_net.AppRegistration.Id),
                ClientId = AppSettings.Moe.Pawoo_net.AppRegistration.ClientId,
                ClientSecret = AppSettings.Moe.Pawoo_net.AppRegistration.ClientSecret,
                Instance = AppSettings.Moe.Pawoo_net.AppRegistration.Instance
            },AppSettings.Moe.Pawoo_net.AppRegistration.AccessToken),
            new MastodonAuthSet(new AppRegistration
            {
                Id=int.Parse(AppSettings.Moe.Friends_nico.AppRegistration.Id),
                ClientId=AppSettings.Moe.Friends_nico.AppRegistration.ClientId,
                ClientSecret= AppSettings.Moe.Friends_nico.AppRegistration.ClientSecret,
                Instance=AppSettings.Moe.Friends_nico.AppRegistration.Instance
            },AppSettings.Moe.Friends_nico.AppRegistration.AccessToken)
        };

        public Moe()
        {
            Name = "萌瑛";

        }

        public string GetGreetingMessage(string accountName, string userName)
        {
            string message = $"@{accountName} わーい！{userName}さん、フォローありがとう！\n" +
                $"わたしからもフォローさせていただきました♪\n" +
                $"これからも《月と音》と、槍水・カリーノ＝萌瑛をよろしくお願いします！";

            return message;
        }

        public string GetWeathersReplyMessage(string day, string region, string telop)
        {
            string message = $"{day}の{region}の天気は、{telop}だよ！";
            return message;
        }

        public string GetUnknownWetherReplyMessage(UnknownType type)
        {
            string unknownWord = "";
            switch (type)
            {
                case UnknownType.Day:
                    unknownWord = "日";
                    break;
                case UnknownType.Region:
                    unknownWord = "地域";
                    break;
                default:
                    break;
            }
            string message = $"うーん、ごめんね。\nお姉さん、その{unknownWord}の天気は分からないよ……";

            return message;
        }

        public IEnumerable<string> RelationalTags { get; } = new[]{
            "げっとおん",
            "福原隼人",
            "東雲雅",
            "東雲初夢",
            "槍水萌瑛",
            "槍水カリーノ萌瑛",
            "風祭彩音",
            "宍戸凛",
            "新速要人",
            "ガルゲ・タンツァー",
            "契約農家の木村さん"
        };

    }
}