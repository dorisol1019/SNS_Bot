using Microsoft.VisualStudio.TestTools.UnitTesting;
using tweetBot.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweetBot.Controllers.Tests
{
    [TestClass()]
    public class SerifsControllerTests
    {
        [TestMethod()]
        public void GetSerifsTest()
        {
            SerifsController serif = new SerifsController();
            Random rand = new Random();
            var serifDatas = serif.GetSerifs().Where(e=>e.Name=="里美").ToArray();

            var serifData = serifDatas[rand.Next(serifDatas.Length)];
            serifData.IsNotNull();

            Console.WriteLine(serifData.Id);
            Console.WriteLine(serifData.Text);
            Console.WriteLine(serifData.Type);

        }
    }
}