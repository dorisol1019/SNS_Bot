using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    public enum PlatFormType
    {
        Twitter,Mastodon
    }

    public static class Platform
    {
        public static IPlatform Create(PlatFormType type)
        {
            IPlatform platform = null;
            switch (type)
            {
                case PlatFormType.Twitter:
                    platform = new Twitter.Twitter();
                    break;
                case PlatFormType.Mastodon:
                    platform = new Mastodon.Mastodon();
                    break;
                default:
                    break;
            }

            return platform;
        }
    }
}
