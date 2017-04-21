using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNS_Bot;
using tweetBot;

namespace Bot.Twitter.Tests
{
    [TestClass()]
    public class TwitterTests
    {
        [TestMethod()]
        public async Task SendMessageToFollowerAsyncTest()
        {
            var satomi = new Satomi();
            var twitter = new Twitter();
            await twitter.Initializer(satomi);

            await twitter.SendMessageToFollowerAsync(satomi, new NeruWords(), tweetBot.Models.SerifType.Oyasumi, new UsingDataBaseTable());
        }
    }
}