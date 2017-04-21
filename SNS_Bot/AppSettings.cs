using System.Configuration;

namespace SNS_Bot
{
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public static class AppSettings
    {
        public static class ClientSettingsProvider
        {
            public static string ServiceUri
            {
                get { return ConfigurationManager.AppSettings["ClientSettingsProvider.ServiceUri"]; }
            }
        }

        public static class Moe
        {
            public static class Friends_nico
            {
                public static class AppRegistration
                {
                    public static string AccessToken
                    {
                        get { return ConfigurationManager.AppSettings["Moe.friends_nico.AppRegistration.AccessToken"]; }
                    }

                    public static string ClientId
                    {
                        get { return ConfigurationManager.AppSettings["Moe.friends_nico.AppRegistration.ClientId"]; }
                    }

                    public static string ClientSecret
                    {
                        get { return ConfigurationManager.AppSettings["Moe.friends_nico.AppRegistration.ClientSecret"]; }
                    }

                    public static string Id
                    {
                        get { return ConfigurationManager.AppSettings["Moe.friends_nico.AppRegistration.Id"]; }
                    }

                    public static string Instance
                    {
                        get { return ConfigurationManager.AppSettings["Moe.friends_nico.AppRegistration.Instance"]; }
                    }
                }
            }

            public static class Mstdn_jp
            {
                public static class AppRegistration
                {
                    public static string AccessToken
                    {
                        get { return ConfigurationManager.AppSettings["Moe.mstdn_jp.AppRegistration.AccessToken"]; }
                    }

                    public static string ClientId
                    {
                        get { return ConfigurationManager.AppSettings["Moe.mstdn_jp.AppRegistration.ClientId"]; }
                    }

                    public static string ClientSecret
                    {
                        get { return ConfigurationManager.AppSettings["Moe.mstdn_jp.AppRegistration.ClientSecret"]; }
                    }

                    public static string Id
                    {
                        get { return ConfigurationManager.AppSettings["Moe.mstdn_jp.AppRegistration.Id"]; }
                    }

                    public static string Instance
                    {
                        get { return ConfigurationManager.AppSettings["Moe.mstdn_jp.AppRegistration.Instance"]; }
                    }
                }
            }

            public static class Pawoo_net
            {
                public static class AppRegistration
                {
                    public static string AccessToken
                    {
                        get { return ConfigurationManager.AppSettings["Moe.pawoo_net.AppRegistration.AccessToken"]; }
                    }

                    public static string ClientId
                    {
                        get { return ConfigurationManager.AppSettings["Moe.pawoo_net.AppRegistration.ClientId"]; }
                    }

                    public static string ClientSecret
                    {
                        get { return ConfigurationManager.AppSettings["Moe.pawoo_net.AppRegistration.ClientSecret"]; }
                    }

                    public static string Id
                    {
                        get { return ConfigurationManager.AppSettings["Moe.pawoo_net.AppRegistration.Id"]; }
                    }

                    public static string Instance
                    {
                        get { return ConfigurationManager.AppSettings["Moe.pawoo_net.AppRegistration.Instance"]; }
                    }
                }
            }

            public static class Twitter
            {
                public static string AccessToken
                {
                    get { return ConfigurationManager.AppSettings["Moe.twitter.AccessToken"]; }
                }

                public static string AccessTokenSecret
                {
                    get { return ConfigurationManager.AppSettings["Moe.twitter.AccessTokenSecret"]; }
                }

                public static string ConsumerKey
                {
                    get { return ConfigurationManager.AppSettings["Moe.twitter.ConsumerKey"]; }
                }

                public static string ConsumerSecret
                {
                    get { return ConfigurationManager.AppSettings["Moe.twitter.ConsumerSecret"]; }
                }
            }
        }

        public static class Satomi
        {
            public static class Twitter
            {
                public static string AccessToken
                {
                    get { return ConfigurationManager.AppSettings["Satomi.twitter.AccessToken"]; }
                }

                public static string AccessTokenSecret
                {
                    get { return ConfigurationManager.AppSettings["Satomi.twitter.AccessTokenSecret"]; }
                }

                public static string ConsumerKey
                {
                    get { return ConfigurationManager.AppSettings["Satomi.twitter.ConsumerKey"]; }
                }

                public static string ConsumerSecret
                {
                    get { return ConfigurationManager.AppSettings["Satomi.twitter.ConsumerSecret"]; }
                }
            }
        }
    }
}

