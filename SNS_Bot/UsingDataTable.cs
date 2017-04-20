using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweetBot
{

    public enum DataTableType
    {
        DataBase,CSV
    }

    public class UsingDataTable
    {
        public static IUsingDataTable Create(DataTableType type)
        {
            IUsingDataTable usingDataTable = null;
            switch (type)
            {
                case DataTableType.DataBase:
                    usingDataTable = new UsingDataBaseTable();
                    break;
                case DataTableType.CSV:
                    break;
                default:
                    break;
            }

            return usingDataTable;
        }
    }
}
