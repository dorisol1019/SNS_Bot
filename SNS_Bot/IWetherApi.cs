using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wethers.Api
{
    public interface IWetherApi
    {
        Task<string> GetWeatherAsync(string city, int dayNumber);
    }

    public class CityWetherNotFoundException : Exception
    {
        
    }

    public class DayWetherNotFoundException : Exception
    {

    }
}
