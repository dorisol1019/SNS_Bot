using bot;
using System.Linq;
using System.Threading.Tasks;
using tweetBot;
using tweetBot.Models;
using Weathers.Api;
using Wether;
using System;

namespace Bot.Mastodon
{
    public class Mastodon : IPlatform
    {
        private MastdonHelper[] mastodonHelpers;

        WetherWidget wetherWidget = new WetherWidget(new WeatherHacksApi());


        public Mastodon()
        {
        }

        public async Task Initializer(ICharacter character)
        {
            mastodonHelpers = new MastdonHelper[character.MastdonAuthSet.Length];
            for (int i = 0; i < mastodonHelpers.Length; i++)
            {
                mastodonHelpers[i] = new MastdonHelper(character.MastdonAuthSet[i]);
                await mastodonHelpers[i].Initializer();
            }
        }

        public async Task RegularPostAsync(ICharacter character, IUsingDataTable usingDataTable)
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                string message = usingDataTable.GetUseSerif(character.Name, SerifType.Normal);
                if (mastodonHelper.Instance == "mstdn.jp")
                    await mastodonHelper.PoststatusAsync(message, Mastonet.Visibility.Unlisted);
                else
                    await mastodonHelper.PoststatusAsync(message, Mastonet.Visibility.Public);
            }
        }

        public async Task FollowBackAndGreetingAsync(ICharacter character)
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                var followBackedUsers = mastodonHelper.FollowBack();
                foreach (var user in followBackedUsers)
                {
                    string displayName = GetDisplayName(user.DisplayName, user.AccountName);

                    string replyMessage = character.GetGreetingMessage(user.AccountName, displayName);

                    if (mastodonHelper.Instance == "mstdn.jp")
                        await mastodonHelper.PoststatusAsync(replyMessage, Mastonet.Visibility.Unlisted);
                    else
                        await mastodonHelper.PoststatusAsync(replyMessage, Mastonet.Visibility.Public);

                    await Task.Delay(100);
                }
            }
        }

        static string GetDisplayName(string displayName, string accountName)
        {
            string _displayName = displayName;
            if (string.IsNullOrEmpty(_displayName)) _displayName = accountName;
            return _displayName;
        }

        //フォロワーさんを励ましたりする
        public async Task SendMessageToFollowerAsync<TWords>(ICharacter character, TWords words, SerifType type, IUsingDataTable usingDataTable)
             where TWords : IWords
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                var timeline = await mastodonHelper.GetTimeLineAsync();

                var tsuraiTweets = timeline.Where(e => !e.Reblogged ?? true).Where(e => e.Reblog == null).Where(e => !e.Favourited ?? true).Where(e => words.IsContained(e.Content)).Where(e => e.Account.Id != mastodonHelper.CurrentUser.Id).Where(e => e.Url.Contains(mastodonHelper.Instance)).Select(e => new { UserId = e.Account.Id, e.Id, e.Account.DisplayName, e.Account.AccountName, e.Content });

                foreach (var tsuraiTweet in tsuraiTweets)
                {
                    if (tsuraiTweet.Content.Contains("@")) continue;
                    if (tsuraiTweet.Content.Contains("＠")) continue;

                    string mes = usingDataTable.GetUseSerif(character.Name, SerifType.Ganbare);

                    string name = GetDisplayName(tsuraiTweet.DisplayName, tsuraiTweet.AccountName);
                    var txt = "@" + tsuraiTweet.AccountName + " " + mes.Replace("{ScreenName}", name);

                    await mastodonHelper.ReplyAsync(tsuraiTweet.Id, Mastonet.Visibility.Unlisted, txt);

                    await Task.Delay(100);

                    await mastodonHelper.FavouriteAsync(tsuraiTweet.Id);
                }
            }
        }

        public async Task RePostRelationalTagAsync(ICharacter character)
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                foreach (var tag in character.RelationalTags)
                {
                    var tweets = await mastodonHelper.SearchTagTimeLineAsync(20, tag);
                    if (tweets == null) continue;
                    tweets = tweets.Where(e => !e.Content.Contains("RT"));
                    tweets = tweets.Where(e => e.Reblogged == null || !e.Reblogged.Value);

                    foreach (var tweet in tweets)
                    {
                        await mastodonHelper.ReToot(tweet.Id);
                        await Task.Delay(100);

                    }
                }
            }
        }

        //今日の天気を聞かれたら返す機能
        public async Task SendTodayWetherAsync(ICharacter character)
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                var mentions = await mastodonHelper.GetMentionsTimeLineAsync();

                if (mentions == null)
                {
                    Console.WriteLine("Mentions is null in SendTodayWetherAsync.");
                    return;
                }

                var enablementions = mentions.Where(e => wetherWidget.IsEnable(e.Content, e.CreatedAt)).Select(e => new StatusForWether(e.Id, e.Content, e.CreatedAt));
                foreach (var mention in enablementions)
                {
                    string message = await wetherWidget.GetWeathersReplyMessage(mention, character);

                    await mastodonHelper.ReplyAsync((int)mention.Id, Mastonet.Visibility.Unlisted, message);

                    await Task.Delay(100);
                }
            }
        }

        public async Task RemoveBackAsync()
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                await mastodonHelper.RemoveBack();
            }
        }
    }
}
