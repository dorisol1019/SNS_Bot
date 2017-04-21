using bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS_Bot
{
    public class NeruWords : BaseWords
    {
        public override IEnumerable<string> Words =>
            new[]
            {
                "おやすみ"
            };
    }
}
