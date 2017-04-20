using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wether.Widget
{
    public interface IWetherAnswerable
    {

        //day:今日or明日or明後日
        //region:地名
        //telop:天気
        string GetWeathersReplyMessage(string day, string region, string telop);

        string GetUnknownWetherReplyMessage(UnknownType type);
    }


    public enum UnknownType
    {
        Day, Region
    }

}
