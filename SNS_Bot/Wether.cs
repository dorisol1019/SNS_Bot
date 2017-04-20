using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wether.Widget;
using Wethers.Api;

namespace Wether
{
    public class WetherWidget
    {
        static readonly string[] days = { "今日", "明日", "明後日" };
        private Regex regex = new Regex(@"((今日の|明日の|明後日の)*)(\w*)((都|道|府|県|市|町|村)*)の天気");

        IWetherApi wetherApi;

        public WetherWidget(IWetherApi wetherApi)
        {
            this.wetherApi = wetherApi;
        }


        public bool IsEnable(string str, DateTime createdAt)
        {
            bool isMatch = regex.IsMatch(str);
            if (!isMatch) return false;

            var dateTime = createdAt;
            var nowTime = DateTime.Now.ToUniversalTime();
            var timeSpan = nowTime - dateTime;
            double minutes = timeSpan.TotalMinutes;
            if (minutes >= 5) return false;

            return true;
        }

        private (string city, string city_text, string day, int dayNumber) GetSearchCity(string text)
        {
            var matchValue = regex.Match(text).Value;
            int dayNumber = -1;
            for (var i = 0; i < days.Length; i++)
            {
                if (matchValue.Contains(days[i]))
                {
                    dayNumber = i; break;
                }
            }
            if (dayNumber == -1) dayNumber = 0;

            matchValue = matchValue.Replace($"{days[dayNumber]}の", "");
            var str = matchValue.Split("の".ToCharArray());

            if (str[0] == "天気" || str.Length == 1) str[0] = "東京";
            string search_str = str[0];
            if (search_str == "北海道") search_str = "道央";
            search_str = search_str.Replace("都", "").Replace("道", "").Replace("府", "").Replace("県", "").Replace("市", "").Replace("町", "").Replace("村", "");

            return (search_str, str[0], days[dayNumber], dayNumber);
        }

        private async Task<string> GetWetherText(string city, int dayNumber)
        {
            var text = await wetherApi.GetWeatherAsync(city, dayNumber);
            return text;
        }
        
        public async Task<string> GetWeathersReplyMessage(StatusForWether mention, IWetherAnswerable answerable)
        {

            (string city, string city_text, string day, int dayNumber) = GetSearchCity(mention.Content);
            
            try
            {
                var telop = await GetWetherText(city, dayNumber);
                return answerable.GetWeathersReplyMessage(day, city_text, telop);
            }
            catch (CityWetherNotFoundException)
            {
                return answerable.GetUnknownWetherReplyMessage(UnknownType.Region);
            }
            catch (DayWetherNotFoundException)
            {
                return answerable.GetUnknownWetherReplyMessage(UnknownType.Day);
            }

        }

    }

    public struct StatusForWether
    {
        public StatusForWether(long id, string content, DateTime createdAt)
        {
            Id = id;
            Content = content;
            CreatedAt = createdAt;
        }
        public long Id { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; }
    }
}
