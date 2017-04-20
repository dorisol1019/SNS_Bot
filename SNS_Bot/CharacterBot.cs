using bot;
using System.Threading.Tasks;
using tweetBot;
using tweetBot.Models;

namespace Bot
{
    public enum Service
    {
        Twitter, Mastodon
    }

    public class CharacterBot
    {

        private ICharacter _character = null;
        private IPlatform _platform = null;
        private IUsingDataTable _usingDataTable = null;

        public static CharacterBot Create(CharacterType charType, PlatFormType platformType, DataTableType dataTableType)
        {
            ICharacter character = Character.Create(charType);
            IPlatform platform = Platform.Create(platformType);
            IUsingDataTable usingDataTable = UsingDataTable.Create(dataTableType);
            var characterBot = new CharacterBot(character, platform, usingDataTable);
            characterBot.Initializer().Wait();

            return characterBot;
        }

        public CharacterBot(ICharacter character,IPlatform platform,IUsingDataTable usingDataTable)
        {
            _character = character;
            _platform = platform;
            _usingDataTable = usingDataTable;
        }

        //初期化処理
        public async Task Initializer()
        {
            await _platform.Initializer(_character);
        }

        public async Task RegularPostAsync()
        {
            await _platform.RegularPostAsync(_character,_usingDataTable);
        }

        //フォロバ&挨拶
        public async Task FollowBackAndGreetingAsync()
        {
            await _platform.FollowBackAndGreetingAsync(_character);
        }

        public async Task RemoveBackAsync()
        {
            await _platform.RemoveBackAsync();
        }

        public async Task SendMessageToFollowerAsync<TWords>(TWords words, SerifType type)
            where TWords : IWords
        {
            await _platform.SendMessageToFollowerAsync(_character, words, type, _usingDataTable);
        }
        

        public async Task RePostRelationalTagAsync()
        {
            await _platform.RePostRelationalTagAsync(_character);
        }

        public async Task SendTodayWetherAsync()
        {
            await _platform.SendTodayWetherAsync(_character);
        }
    }

}
