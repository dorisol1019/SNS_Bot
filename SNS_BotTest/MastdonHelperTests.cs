using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bot;

namespace Bot.Tests
{
    [TestClass()]
    public class MastdonHelperTests
    {

        MastdonHelper[] mastodonHelpers;

        [TestInitialize]
        public async Task Init()
        {
            Moe moe = new Moe();
            mastodonHelpers = new MastdonHelper[moe.MastdonAuthSet.Length];
            for (int i = 0; i < moe.MastdonAuthSet.Length; i++)
            {
                mastodonHelpers[i] = new MastdonHelper(moe.MastdonAuthSet[i]);
                await mastodonHelpers[i].Initializer();
            }
        }

        [TestMethod()]
        public void MastdonHelperTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void InitializerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task PoststatusAsyncTest()
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                await mastodonHelper.PoststatusAsync("うーん...", Mastonet.Visibility.Private);
            }
        }

        [TestMethod()]
        public void FavouriteAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReTootTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReplyAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchTagTimeLineAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMentionsTimeLineAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FollowBackTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveBackTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTimeLineAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHaveNotRemovedUsersTest()
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                var users = mastodonHelper.AsDynamic().GetHaveNotRemovedUsers() as IEnumerable<Mastonet.Entities.Account>;

                var count = users.Count();
                Console.WriteLine($"リムーブすべき人は{count}人です");

                Assert.AreEqual(mastodonHelper.Friends.Count() - mastodonHelper.Followers.Count(), count);
            }
        }

        [TestMethod]
        public async Task FriendsTest()
        {
            var moe = new Moe();
            foreach (var item in moe.MastdonAuthSet)
            {
                var mastodonHelper = new MastdonHelper(item);
                await mastodonHelper.Initializer();

                var users = mastodonHelper.Friends;
                
                Assert.AreEqual(users.Count(), mastodonHelper.CurrentUser.FollowingCount);
            }
        }

        [TestMethod]
        public void FollowersTest()
        {
            foreach (var mastodonHelper in mastodonHelpers)
            {
                var users = mastodonHelper.Followers;

                Assert.AreEqual(users.Count(), mastodonHelper.CurrentUser.FollowersCount);
            }
        }

    }
}