using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Tests
{
    [TestClass()]
    public class CharacterBotTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CharacterBotTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InitializerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task RegularPostAsyncTest()
        {
            CharacterBot charBot = CharacterBot.Create(bot.CharacterType.Yarimizu_Moe, PlatFormType.Mastodon, tweetBot.DataTableType.DataBase);
            charBot.IsNotNull();
            await charBot.RegularPostAsync();
        }

        [TestMethod()]
        public void FollowBackAndGreetingAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SendMessageToFollowerAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RePostRelationalTagAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SendTodayWetherAsyncTest()
        {
            Assert.Fail();
        }
    }
}