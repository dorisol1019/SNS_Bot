using System.Collections.Generic;

namespace bot
{
    public interface IRelationalTags
    {
        IEnumerable<string> RelationalTags{ get; }
    }
}
