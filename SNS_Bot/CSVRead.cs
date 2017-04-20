using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace tweetBot
{
    static class CSVRead
    {
        public static IEnumerable<Models.SerifData> getSerifCSV(string path)
        {
            using (var csv = new CsvReader(new StreamReader(path, Encoding.GetEncoding("shift_jis"))))
            {

                csv.Configuration.HasHeaderRecord = false; // Headerはなし
                csv.Configuration.RegisterClassMap<SerifMap>();
                var records = csv.GetRecords<Models.SerifData>();
                foreach (var item in records)
                {
                    yield return item;
                }
            }
        }

        sealed class SerifMap : CsvHelper.Configuration.CsvClassMap<Models.SerifData>
        {
            public SerifMap()
            {
                Map(x => x.Id).Index(0);
                Map(x => x.Name).Index(1);
                Map(x => x.Text).Index(2);
                Map(x => x.Type).Index(3);                
            }
        }
    }
}
