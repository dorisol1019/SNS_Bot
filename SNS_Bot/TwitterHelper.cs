using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using CoreTweet;

using tweetBot;

namespace TwitterBot
{
    public class TwitterHelper
    {
        private Tokens tokens;
        public List<User> Followers { get; private set; }
        public List<User> Friends { get; private set; }
        private UserResponse _verifyCredentials;
        public async ValueTask<UserResponse> VerifyCredentialsAsync() =>
             _verifyCredentials ?? (_verifyCredentials = await GetMyVerifyCredentialsAsync());

        public string Instance { get; } = "twitter.com";

        public TwitterHelper(TwitterAuthSet twitterAuthSet)
        {
            tokens = GetToken(twitterAuthSet);
            Logger.NLogInfo($"Constructer OK on {Instance}.");
        }

        public void Initializer()
        {
            Followers = GetFollowers().ToList();
            Friends = GetFriends().ToList();

            Logger.NLogInfo($"Initializer OK on {Instance}.");

        }


        private Tokens GetToken(TwitterAuthSet tas)
        {
            Logger.NLogInfo($"Get Token on {Instance}.");
            return Tokens.Create(tas.ConsumerKey, tas.ConsumerSecret, tas.AccessToken, tas.AccessTokenSecret);
        }

        public async Task UpdateStatusAsync(string message)
        {
            var response = await tokens.Statuses.UpdateAsync(status => message);
            Logger.NLogInfo($"Send Tweet {message} on {Instance}.");
        }

        public async Task ReTweet(long id_)
        {
            try
            {
                StatusResponse result = await tokens.Statuses.RetweetAsync(id => id_);
            }
            catch (System.Exception e)
            {
                Logger.NLogInfo(e.Message);
                return;
                throw;
            }

            Logger.NLogInfo($"ReTweet id {id_} on Twitter.");
        }

        public async Task<long> GetMyId()
        {
            var verifyCredentials = await VerifyCredentialsAsync();
            return verifyCredentials.Id.Value;
        }

        public async Task ReplyAsync(long tweetId, string message)
        {
            try
            {
                 await tokens.Statuses.UpdateAsync(in_reply_to_status_id => tweetId, auto_populate_reply_metadata => true, status => message);
                Logger.NLogInfo($"Reply message is {message} on {Instance}.");
            }
            catch (System.Exception e)
            {
                Logger.NLogInfo($"TwitterHelperError!:{e.Message}");
            }
        }

        public async Task FavoritesAsync(long _id)
        {
            await tokens.Favorites.CreateAsync(id => _id);
            Logger.NLogInfo($"Favo is {_id}.");

        }

        public IEnumerable<User> FollowBack()
        {

            var haveNotFollowedUsers = GetHaveNotFollowedUsers();

            foreach (var user in haveNotFollowedUsers)
            {
                tokens.Friendships.Create(user_id => user.Id);
                Logger.NLogInfo($"FollowBack to {user.ScreenName}");
                Friends.Add(user);
                yield return user;
            }
        }

        private IEnumerable<User> GetHaveNotFollowedUsers()
        {
            foreach (var user in Followers)
            {
                if (!Friends.Any(e => e.Id == user.Id))
                {
                    yield return user;
                }
            }
        }

        public async Task<IEnumerable<User>> RemoveBack()
        {
            var haveNotRemovedUsers = GetHaveNotRemovedUsers();
            var removeUsers = new List<User>();
            foreach (var user in haveNotRemovedUsers)
            {
                await tokens.Friendships.DestroyAsync(user_id => user.Id);
                Logger.NLogInfo($"RemoveBack to {user.ScreenName}");
                removeUsers.Add(user);
            }

            foreach (var user in removeUsers)
            {
                Friends.Remove(user);
            }

            return removeUsers;
        }

        private IEnumerable<User> GetHaveNotRemovedUsers()
        {
            foreach (var user in Friends)
            {
                if (!Followers.Any(e => e.Id == user.Id))
                {
                    yield return user;
                }
            }
        }

        public async Task<IEnumerable<Status>> GetTimeLineAsync()
        {
            var HomeTileline = await tokens.Statuses.HomeTimelineAsync(count => 100);
            Logger.NLogInfo($"GetHomeTimeline on {Instance}.");

            return HomeTileline;
        }

        public async Task<IEnumerable<Status>> GetMentionsTimeLineAsync()
        {
            var menstionsTileline = await tokens.Statuses.MentionsTimelineAsync(count => 20);
            Logger.NLogInfo($"GetMentionsTimeline on {Instance}.");

            return menstionsTileline;
        }

        public async Task<IEnumerable<Status>> SearchTweetsAsync(int _count, string keyword)
        {
            var tweets = await tokens.Search.TweetsAsync(count => _count, q => "#" + keyword);
            Logger.NLogInfo($"Search keyword is {keyword},Count is {_count}.");
            return tweets;
        }


        private IEnumerable<User> GetFollowers()
        {
            var followers = tokens.Followers.EnumerateList(EnumerateMode.Next, user_id => tokens.Users);
            Logger.NLogInfo("Get Followers EnumrateList on Twitter.");
            return followers;
        }

        private IEnumerable<User> GetFriends()
        {
            var friends = tokens.Friends.EnumerateList(EnumerateMode.Next, user_id => tokens.Users);
            Logger.NLogInfo("Get Friends EnumrateList on Twitter.");
            return friends;
        }

        private async Task<UserResponse> GetMyVerifyCredentialsAsync()
        {
            var verifyCredentials = await tokens.Account.VerifyCredentialsAsync(include_entities => false);
            return verifyCredentials;
        }



    }
}