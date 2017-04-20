using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

using Weathers.Models;
using System.Text.RegularExpressions;
using Wethers.Api;

namespace Weathers
{
    namespace Api
    {

        

        public class WeatherHacksApi : IWetherApi
        {

            public async Task<string> GetWeatherAsync(string city, int dayNumber)
            {

                var model = await GetWeatherModelAsync(city) ?? throw new CityWetherNotFoundException();
                
                

                if (dayNumber >= model.forecasts.Length) throw new DayWetherNotFoundException();


                return model.forecasts[dayNumber].telop;

            }

            public async Task<WeatherHacksModel> GetWeatherModelAsync(string city)
            {
                string cityId = GetCityId(city);
                if (cityId == null)
                {
                    return null;
                }
                HttpClient client = new HttpClient();

                const string baseurl = @"http://weather.livedoor.com/forecast/webservice/json/v1";
                string url = baseurl + $"?city={cityId}";
                var response = await client.GetStringAsync(url);

                var model = JsonConvert.DeserializeObject<WeatherHacksModel>(response);

                Console.WriteLine("Get Wether OK.");

                return model;
            }


            private string GetCityId(string search_cityName)
            {
                string url = "http://weather.livedoor.com/forecast/rss/primary_area.xml";
                //RSSフィードで使用している名前空間
                XNamespace ldWeather = "http://weather.livedoor.com/%5C/ns/rss/2.0";

                Console.Write("Gettig RSS... ");

                // RSSフィードの読み込みます。
                XElement spx = XElement.Load(url);
                Console.WriteLine("Get RSS OK.");

                // チャンネル情報を取得します。
                XElement channel = spx.Element("channel");

                // 各話のデータを取得します。
                var AllCountry = channel.Elements(ldWeather + "source");
                foreach (var country in AllCountry)
                {
                    var prefs = country.Elements($"pref");
                    foreach (var pref in prefs)
                    {
                        string prefName = pref.Attribute("title").Value;
                        prefName = prefName.Replace("県", "");
                        bool searching = false;
                        if (prefName == (search_cityName)) searching = true;
                        var citys = pref.Elements("city");
                        foreach (var city in citys)
                        {
                            string cityName = city.Attribute("title").Value;
                            string cityId = city.Attribute("id").Value;

                            if (cityName == search_cityName || searching)
                            {
                                Console.WriteLine("Get CityId OK.");
                                return cityId;
                            }
                        }
                    }
                }


                Console.WriteLine("Get CityId NG...");
                return null;
            }
        }

    }
}
