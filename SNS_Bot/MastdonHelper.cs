using Mastonet;
using Mastonet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tweetBot;

namespace Bot
{
    public class MastdonHelper
    {

        MastodonClient client;
        private AppRegistration appRegistration;

        public IEnumerable<Account> Friends { get; private set; }
        public IEnumerable<Account> Followers { get; private set; }
        public Account CurrentUser { get; private set; }

        string acsessToken;

        public string Instance { get; }

        public MastdonHelper(MastodonAuthSet mastdonAuthSet)
        {
            appRegistration = mastdonAuthSet.AppRegistration;
            Instance = appRegistration.Instance;
            acsessToken = mastdonAuthSet.AccessToken;
            Logger.NLogInfo($"Constructer OK on {Instance}.");
        }

        public async Task Initializer()
        {
            client = new MastodonClient(appRegistration, acsessToken);

            CurrentUser = await GetCurrentUser();
            Followers = await GetFollowers();
            Friends = await GetFriends();

            Logger.NLogInfo($"Initializer OK on {Instance}.");
        }

        public async Task PoststatusAsync(string status, Visibility visibility)
        {
            var response = await client.PostStatus(status, visibility);
            Logger.NLogInfo($"Post Toot on {Instance}.");
            Logger.NLogInfo($"Toot message is {status}.");
        }


        public async Task FavouriteAsync(int id)
        {
            await client.Favourite(id);
            Logger.NLogInfo($"Fovourite is {id} on {Instance}.");

        }

        public async Task ReToot(int id)
        {
            try
            {
                var result = await client.Reblog(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
                throw;
            }

            Logger.NLogInfo($"Retoot is {id} on {Instance}.");

        }


        public async Task ReplyAsync(int tweetId, Visibility visibillity, string message)
        {
            try
            {
                await client.PostStatus(message, visibillity, (int)tweetId);
                Logger.NLogInfo($"Retoot is {tweetId},Visibillity is {visibillity.ToString()} on {Instance}.");
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"MastodonHelperError!:{e.Message}");
            }
        }
        public async Task<IEnumerable<Status>> SearchTagTimeLineAsync(int _count, string keyword)
        {
            var tweets = await client.GetTagTimeline(keyword, false);

            Logger.NLogInfo($"Search keyword is {keyword} on {Instance}.");
            return tweets;
        }


        public async Task<IEnumerable<Status>> GetMentionsTimeLineAsync()
        {
            var menstionsTileline = await client.GetNotifications();
            Logger.NLogInfo($"GetMentionsTimeline on {Instance}.");
            return menstionsTileline.Where(e => e.Type == "mention").Select(e => e.Status);
        }

        public IEnumerable<Account> FollowBack()
        {
            foreach (var user in Followers)
            {
                if (Friends.FirstOrDefault(e => e.Id == user.Id) == null)
                {
                    client.Follow(user.Id);
                    Logger.NLogInfo($"FollowBack to {user.UserName} on {Instance}.");
                    yield return user;
                }
            }
        }

        public async Task<IEnumerable<Account>> RemoveBack()
        {
            var users = new List<Account>();
            var haveNotRemovedUsers = GetHaveNotRemovedUsers();
            foreach (var user in haveNotRemovedUsers)
            {
                await client.Unfollow(user.Id);
                Logger.NLogInfo($"UnFollowBack to {user.UserName} on {Instance}.");
                users.Add(user);
            }
            return users;
        }


        private IEnumerable<Account> GetHaveNotRemovedUsers()
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
            Logger.NLogInfo($"GetHomeTimeline on {Instance}.");
            return await client.GetHomeTimeline();
        }

        private async Task<IEnumerable<Account>> GetFollowers()
        {
            var followers = await client.GetAccountFollowers(CurrentUser.Id);
            Logger.NLogInfo($"Get Followers EnumrateList on {Instance}.");
            return followers;
        }

        private async Task<IEnumerable<Account>> GetFriends()
        {
            var friends = await client.GetAccountFollowing(CurrentUser.Id);
            Logger.NLogInfo($"Get Friends EnumrateList on {Instance}.");
            return friends;
        }

        
        private async Task<Account> GetCurrentUser()
        {
            Logger.NLogInfo($"GetCurrentUser on {Instance}.");
            return await client.GetCurrentUser();
        }
    }
}
