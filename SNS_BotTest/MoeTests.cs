using Microsoft.VisualStudio.TestTools.UnitTesting;
using bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.Tests
{
    [TestClass()]
    public class MoeTests
    {
        [TestMethod()]
        public void MoeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetGreetingMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetWeathersReplyMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUnknownWetherReplyMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TwitterAuthTest()
        {
            Moe moe = new Moe();
            var tokens = CoreTweet.Tokens.Create(moe.TwitterAuthSet.ConsumerKey
                , moe.TwitterAuthSet.ConsumerSecret,
                moe.TwitterAuthSet.AccessToken,
                moe.TwitterAuthSet.AccessTokenSecret);
            var currentUser = tokens.Account.VerifyCredentials();

            Console.WriteLine(currentUser.ScreenName);
            Console.WriteLine(currentUser.Name);
            currentUser.IsNotNull();
        }

        [TestMethod]
        [ExpectedException(typeof(CoreTweet.TwitterException))]
        public async Task TwitterNotAuthTest()
        {
            var tokens = CoreTweet.Tokens.Create(""
                , "",
                "",
                "でたらめ");

            var currentUser = await tokens.Account.VerifyCredentialsAsync();
            
        }

        [TestMethod]
        public async Task MastodonAuthTest()
        {
            var moe = new Moe();
            foreach (var mastodonAuthSet in moe.MastdonAuthSet)
            {
                var client = new Mastonet.MastodonClient(
                    mastodonAuthSet.AppRegistration
                    , mastodonAuthSet.AccessToken);

                var currentUser = await client.GetCurrentUser();
                currentUser.IsNotNull();
                Console.WriteLine(mastodonAuthSet.AppRegistration.Instance);
                Console.WriteLine(currentUser.AccountName);
                Console.WriteLine(currentUser.DisplayName);
                Console.WriteLine();

            }
        }
    }
}