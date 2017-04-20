
using tweetBot;
using Wether.Widget;

namespace bot
{
    public interface ICharacter: IWetherAnswerable, IRelationalTags
    {
        string Name { get; }

        TwitterAuthSet TwitterAuthSet { get; }
        MastodonAuthSet[] MastdonAuthSet{ get; }

        string GetGreetingMessage(string accountName, string userName);
        
    }


}
