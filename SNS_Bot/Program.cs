﻿using System;
using System.Data.Entity.Migrations;
using Bot;
using bot;
using tweetBot.Models;

namespace tweetBot
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            //argmentsの渡し方　しばやん雑記から引用
            //https://{sitename}.scm.azurewebsites.net/api/triggeredwebjobs/{jobname}/run?arguments={arguments}
            var argments = Environment.GetEnvironmentVariable("WEBJOBS_COMMAND_ARGUMENTS");
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            Console.WriteLine($"Tweetbot program Version is {asm.GetName().Version}");
            Console.WriteLine($"Argments is {argments ?? "Test"}");

            var twitterBot = CharacterBot.Create(CharacterType.Yarimizu_Moe, PlatFormType.Twitter, DataTableType.DataBase);

            var mastodonBot = CharacterBot.Create(CharacterType.Yarimizu_Moe, PlatFormType.Mastodon, DataTableType.DataBase);

#if DEBUG
            //mastodonbot.RegularPostAsync().Wait();
            //mastodonbot.FollowBackAndGreetingAsync().Wait();

            //mastodonbot.RetweetRelationTagAsync().Wait();
            //mastodonBot.FollowBackAndGreetingAsync().Wait();
            //mastodonBot.SendMessageToFollowerAsync(new TsuraiWords(),SrtifType.Ganbare).Wait();
            //return;
            //mastodonbot.SendTodayWetherAsync().Wait();

#endif
            switch (argments)
            {
                case "RegularTweet":
                    mastodonBot.RegularPostAsync().Wait();
                    mastodonBot.FollowBackAndGreetingAsync().Wait();
                    mastodonBot.RemoveBackAsync().Wait();

                    twitterBot.RegularPostAsync().Wait();
                    twitterBot.FollowBackAndGreetingAsync().Wait();
                    twitterBot.RemoveBackAsync().Wait();


                    mastodonBot.RePostRelationalTagAsync().Wait();
                    twitterBot.RePostRelationalTagAsync().Wait();
                    break;
                case "20MinutesSpan":
                    twitterBot.SendMessageToFollowerAsync(new TsuraiWords(), SerifType.Ganbare).Wait();
                    mastodonBot.SendMessageToFollowerAsync(new TsuraiWords(), SerifType.Ganbare).Wait();
                    break;
                case "5MinutesSpan":
                    twitterBot.SendTodayWetherAsync().Wait();
                    mastodonBot.SendTodayWetherAsync().Wait();
                    break;
                default:
                    Console.WriteLine("Job is None.");
                    return;
            }


            Console.WriteLine("success.");
        }

        static public void Seed(tweetBot.Context.SerifDataContext context)
        {

            var serifCSV = CSVRead.getSerifCSV(
        "D:/リポジトリ的な何か/SerifExcerpter/Get_on_SerifExcerpter/Get_on_SerifExcerpter/萌瑛.csv");



            foreach (var serifData in serifCSV)
            {
                context.Serifs.AddOrUpdate(p => p.Id,
                new Models.SerifData
                {
                    Id = serifData.Id,
                    Name = serifData.Name,
                    Text = serifData.Text,
                    LastUsedTime = null,
                    Type = serifData.Type
                });
            }


            context.SaveChanges();
        }
    }
}
