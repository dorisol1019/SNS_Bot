using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweetBot
{
    public struct TwitterAuthSet
    {
        public TwitterAuthSet(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
        public string ConsumerKey { get; }
        public string ConsumerSecret { get; }
        public string AccessToken { get; }
        public string AccessTokenSecret { get; }
    }
}