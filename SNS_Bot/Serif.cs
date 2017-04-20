using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moe_tweetBot
{
    public class Serif
    {
        string[] serifs = {
            "「日本語でおｋ（おけ）、ですよ」",
            "「Ｅｘａｃｔｌｙ（そのとおりでございます！）！」",
            "「………………最高１４４０度？」",
            "「ツインテー♪	　カチューシャー♪　うまく作れるかな、あゆにゃん」",
            "「ふふ、冗談。『プリヴィエート』っていうのはロシアの挨拶で、　日本語で『やあ』くらいの意味です」",
            "「もう、おとうさんったら。ちょっとは自重しなさい」",
            "「Ａｌｌ　ｒｉｇｈｔ！『まったく幼女は最高だぜ！』」",
            "「ひ、１００人っ！？　友だち１００人作るより大変だよっ！」",
            "「まだまだスピード出せるよっ、いっくぜー！」",
            "「独りぼっちは辛いよね……」",
            "「はぁー、就職活動も大変だよ……」",
            "「これからは『魔法少女あゆにゃん』より『超光魔神シャンゼリマン』だよ！　すっごく面白いんだからっ！」",
            "「Ｙａｈ！」",
        };
        public string GetSerif()
        {
            Random rand = new Random();
            return serifs[rand.Next(serifs.Length)];
        }
    }
}