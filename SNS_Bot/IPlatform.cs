using bot;
using System.Threading.Tasks;
using tweetBot;
using tweetBot.Models;

namespace Bot
{
    public interface IPlatform
    {       

        Task Initializer(ICharacter character);

        Task RegularPostAsync(ICharacter character, IUsingDataTable usingDataTable);

        Task FollowBackAndGreetingAsync(ICharacter character);

        Task RemoveBackAsync();

        Task SendMessageToFollowerAsync<TWords>(ICharacter character,TWords word, SerifType type, IUsingDataTable usingDataTable)
             where TWords : IWords;

        Task RePostRelationalTagAsync(ICharacter character);

        Task SendTodayWetherAsync(ICharacter character);
    }
}
