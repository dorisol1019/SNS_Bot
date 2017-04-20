using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot
{
    public abstract class BaseWords : IWords
    {
        public virtual IEnumerable<string> Words => throw new NotImplementedException();
        
        public bool IsContained(string text)
        {
            foreach (var word in Words)
            {
                if (text.Contains(word)) return true;
            }
            return false;
        }
    }
}
