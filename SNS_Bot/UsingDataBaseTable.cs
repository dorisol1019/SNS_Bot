using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tweetBot.Controllers;
using tweetBot.Models;

namespace tweetBot
{
    public class UsingDataBaseTable: IUsingDataTable
    {
        SerifsController serifsController = new SerifsController();
        

        static readonly Random _rand = new Random();

        public void DeleteExpireSendReplyUser()
        {
            serifsController.DeleteExpireSendReplyUser();
        }

        private IEnumerable<SerifData> GetSerif(string name, SerifType type)
        {
            return serifsController.GetSerifs().Where(e => e.Name == name).Where(e => e.Type == type);
        }

        bool IsEnableTime(tweetBot.Models.SerifData e)
        {
            DateTime t = DateTime.MinValue;
            if (e.LastUsedTime.HasValue) { t = e.LastUsedTime.Value; }
            return (DateTime.Now - t).TotalDays >= 2;
        }

        public string GetUseSerif(string name, SerifType type, bool record = false)
        {
            //if (cacheSerif != null) return cacheSerif;

            var enableSerif = GetSerif(name, type).ToList();

            if (record) enableSerif = enableSerif.Where(IsEnableTime).ToList();
            
            var serif = enableSerif[_rand.Next(enableSerif.Count)];

            if (record) serifsController.SetUsedTime(serif.Id);

            return  serif.Text;
        }

        //T RandomElementAt<T>(IEnumerable<T> ie)
        //{
        //    return ie.ElementAt(_rand.Next(ie.Count()));
        //}
    }
}
