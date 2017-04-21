using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterBot;
using bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNS_Bot;

namespace TwitterBot.Tests
{
    [TestClass()]
    public class TwitterHelperTests
    {
        TwitterHelper twitterHelper;

        [TestInitialize]
        public void Initalize()
        {
            var character = new Satomi();
            twitterHelper = new TwitterHelper(character.TwitterAuthSet);
            twitterHelper.Initializer();
        }


        [TestMethod()]
        public void TwitterHelperTest()
        {
        }

        [TestMethod()]
        public void WriteUserDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task UpdateStatusAsyncTest()
        {
            await twitterHelper.UpdateStatusAsync("テスト");
//            Assert.Fail();
        }

        [TestMethod()]
        public void ReTweetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMyIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReplyAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FavoritesAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FollowBackTest()
        {

            var followUsers = twitterHelper.FollowBack();

            if (followUsers.Any())
            {
                foreach (var user in followUsers)
                {
                    Console.WriteLine(user.Id);
                    Console.WriteLine(user.Name);
                    Console.WriteLine(user.ScreenName);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nothing Follows Users");
            }
        }

        [TestMethod()]
        public void GetHaveNotFollowedUsers()
        {

            var followUsers = twitterHelper.AsDynamic().GetHaveNotFollowedUsers();
            
            foreach (var user in followUsers)
            {
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.ScreenName);
                Console.WriteLine();
            }

            Console.WriteLine("Nothing Not Friend Users");

        }

        [TestMethod]
        public void GetHaveNotRemovedUsers()
        {

            var haveNotRemovedUsers = twitterHelper.AsDynamic().GetHaveNotRemovedUsers();

            foreach (var user in haveNotRemovedUsers)
            {
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.ScreenName);
                Console.WriteLine();
            }

            Console.WriteLine("Nothing Have Not Removed Users");

        }


        [TestMethod()]
        public void RemoveBackTest()
        {

            var haveNotRemovedUsers = twitterHelper.AsDynamic().GetHaveNotRemovedUsers();

            //var removeUsers = twitterHelper.RemoveBack().ToList();

        }

        [TestMethod()]
        public void GetTimeLineAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMentionsTimeLineAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchTweetsAsyncTest()
        {
            Assert.Fail();
        }
        
        [TestMethod]
        public async Task FriendsCountTest()
        {
            var count = twitterHelper.Friends.Count;

            var currentUser = await twitterHelper.VerifyCredentialsAsync();

            Console.WriteLine($"CurrentUser's FriendsCount is {currentUser.FriendsCount}.");
            Console.WriteLine($"twitterHelper.Friends.Count is {count}.");

            currentUser.FriendsCount.Is(count);
        }
    }
}