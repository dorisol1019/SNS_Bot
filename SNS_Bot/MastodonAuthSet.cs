using Mastonet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweetBot
{
    public struct MastodonAuthSet
    {
        public MastodonAuthSet(AppRegistration appRegistration,string accessToken)
        {
            AppRegistration = appRegistration;
            AccessToken = accessToken;
        }

        public AppRegistration AppRegistration{ get; }
        public string AccessToken{ get; }
    }
}
