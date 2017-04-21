using bot;
using System.Linq;
using System.Threading.Tasks;
using tweetBot;
using tweetBot.Models;
using TwitterBot;
using Weathers.Api;
using Wether;
using System;

namespace Bot.Twitter
{
    public class Twitter : IPlatform
    {
        TwitterHelper twitterHelper;
        
        WetherWidget wetherWidget = new WetherWidget(new WeatherHacksApi());
        
        public Twitter()
        {

        }

        public async Task Initializer(ICharacter character)
        {
            twitterHelper = new TwitterHelper(character.TwitterAuthSet);
            twitterHelper.Initializer();
            await Task.Delay(100);
        }

        public async Task RegularPostAsync(ICharacter character, IUsingDataTable usingDataTable)
        {
            string message = usingDataTable.GetUseSerif(character.Name, SerifType.Normal, record: true);

            await twitterHelper.UpdateStatusAsync(message);

        }

        public async Task FollowBackAndGreetingAsync(ICharacter character)
        {
            var followBackedUsers = twitterHelper.FollowBack();


            foreach (var user in followBackedUsers)
            {
                string replyMessage = character.GetGreetingMessage(user.ScreenName, user.Name);

                await twitterHelper.UpdateStatusAsync(replyMessage);

                await Task.Delay(100);                
            }
        }

        //フォロワーさんを励ます機能
        public async Task SendMessageToFollowerAsync<TWords>(ICharacter character, TWords word, SerifType type, IUsingDataTable usingDataTable)
            where TWords : IWords
        {
            var timeline = await twitterHelper.GetTimeLineAsync();

            var tsuraiTweets = timeline.Where(e => e.RetweetedStatus == null).Where(e => !e.IsFavorited ?? true).Where(e => word.IsContained(e.Text)).Select(e => new { UserId = e.User.Id, e.Id, e.User.Name, e.Text });
            
            foreach (var tsuraiTweet in tsuraiTweets)
            {

                if (tsuraiTweet.UserId == await twitterHelper.GetMyId()) continue;
                if (tsuraiTweet.Text.Contains("@")) continue;
                if (tsuraiTweet.Text.Contains("＠")) continue;
                string mes = usingDataTable.GetUseSerif(character.Name, type);

                var txt = mes.Replace("{ScreenName}", tsuraiTweet.Name);

                await twitterHelper.ReplyAsync(tsuraiTweet.Id, txt);

                await Task.Delay(100);

                await twitterHelper.FavoritesAsync(tsuraiTweet.Id);

            }
        }

        public async  Task RePostRelationalTagAsync(ICharacter character)
        {
            foreach (var tag in character.RelationalTags)
            {
                var tweets = await twitterHelper.SearchTweetsAsync(20, tag);

                tweets = tweets.Where(e => !e.Text.Contains("RT"));

                foreach (var tweet in tweets)
                {
                    await twitterHelper.ReTweet(tweet.Id);
                    await Task.Delay(100);

                }
            }
        }

        //今日の天気を聞かれたら返す機能
        public async  Task SendTodayWetherAsync(ICharacter character)
        {
            var mentions = await twitterHelper.GetMentionsTimeLineAsync();

            var enableMentions = mentions.Where(e => wetherWidget.IsEnable(e.Text, e.CreatedAt.DateTime)).Select(e => new StatusForWether(e.Id, e.Text, e.CreatedAt.DateTime));

            foreach (var mention in enableMentions)
            {
                string message = await wetherWidget.GetWeathersReplyMessage(mention, character);

                await twitterHelper.ReplyAsync(mention.Id, message);

                await Task.Delay(100);
            }
        }

        public async Task RemoveBackAsync()
        {
            await twitterHelper.RemoveBack();
        }
    }
}
