using Microsoft.VisualStudio.TestTools.UnitTesting;
using tweetBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweetBot.Tests
{
    [TestClass()]
    public class UsingDataBaseTableTests
    {
        [TestMethod()]
        public void GetUseSerifTest()
        {
            UsingDataBaseTable a = new UsingDataBaseTable();

            var ss = a.GetUseSerif("里美", Models.SerifType.Oyasumi,true);

            ss.IsNotNull();
            Console.WriteLine(ss);
            ss.Equals("おやすみなさい、お兄ちゃん！");
        }
    }
}