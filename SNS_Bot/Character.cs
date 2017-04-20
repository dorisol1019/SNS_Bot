
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot
{
    public enum CharacterType
    {
        Yarimizu_Moe,
    }

    static public class Character
    {
        public static ICharacter Create(CharacterType type)
        {
            ICharacter character = null;
            switch (type)
            {
                case CharacterType.Yarimizu_Moe:
                    character = new Moe();
                    break;
                default:
                    break;
            }

            return character;
        }
    }
}
